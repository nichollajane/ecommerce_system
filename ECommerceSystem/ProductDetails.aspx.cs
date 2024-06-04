using System;
using ECommerceSystem.Models;
using ECommerceSystem.Database;
using System.Web.Security;
using System.Web.UI;

namespace ECommerceSystem
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        ProductDB productDB = new ProductDB();
        Product product = new Product();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Product_ID = Convert.ToInt32(Request.QueryString["Product_ID"]);

                if (Product_ID == 0)
                {
                    Response.Redirect("ProductList.aspx");
                }

                ViewState["Product_ID"] = Product_ID;

                product = GetProduct(Product_ID);
            }
        }

        protected Product GetProduct(int Product_ID)
        {
            Product product = productDB.Get(Product_ID);

            Product_Name.Text = product.Product_Name;
            Product_Image.ImageUrl = product.Product_Image_Url;
            Product_Description.Text = product.Product_Description;
            Product_Availability.Text = product.Product_Availability;
            Product_Price.Text = Convert.ToDecimal(product.Product_Price).ToString("₱#,##0.00");
            Product_Category.Text = product.Category_Name;
            Product_Quantity.Text = product.Product_Quantity + "pcs";

            if (product.Product_Quantity == 0)
            {
                AddToCartButton.Visible = false;
            }

            return product;
        }

        protected void AddToCartButton_Click(object sender, EventArgs e)
        {
            CartDB cartDB = new CartDB();
            CartItemDB cartItemDB = new CartItemDB();

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            Product product = productDB.Get((int)ViewState["Product_ID"]);

            Cart cart = cartDB.CheckCartProductExists(product.Product_ID, int.Parse(ticket.Name));

            int quantity = int.Parse(Quantity.Text);

            if (quantity > product.Product_Quantity)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Entered quantity exceeds available quantity!');", true);
            }
            else
            {
                if (cart != null)
                {
                    cart.Quantity = cart.Quantity + quantity;
                    cart.Price = cart.Price + product.Product_Price * quantity;
                    cart.Last_Update = DateTime.Now;

                    cartDB.Update(cart);
                }
                else
                {
                    cart = new Cart();
                    cart.User_ID = int.Parse(ticket.Name);
                    cart.Product_ID = product.Product_ID;
                    cart.Quantity = quantity;
                    cart.Price = product.Product_Price * quantity;
                    cart.Date_Created = DateTime.Now;
                    cart.Last_Update = DateTime.Now;

                    cartDB.Create(cart);
                }

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Added to cart!');", true);

                Response.Redirect("ProductDetails.aspx");
            }
        }
    }
}