using System;
using System.Web;
using System.Collections.Generic;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem.Admin
{
    public partial class EditProduct : System.Web.UI.Page
    {
        ProductDB productDB = new ProductDB();

        Product product = new Product();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateCategories();

            if (!IsPostBack)
            {
                int Product_ID = Convert.ToInt32(Request.QueryString["Product_ID"]);

                if (Product_ID == 0)
                {
                    Response.Redirect("~/Admin/Product/Products.aspx");
                }

                ViewState["Product_ID"] = Product_ID;

                this.product = GetProduct(Product_ID);
            }
        }

        protected Product GetProduct(int Product_ID)
        {
            product = productDB.Get(Product_ID);

            Product_SKU.Text = this.product.Product_SKU;
            Product_Name.Text = this.product.Product_Name;
            Product_Description.Text = this.product.Product_Description;
            Product_Price.Text = this.product.Product_Price.ToString();
            Product_Brand.Text = this.product.Product_Brand;
            Product_Availability.Text = this.product.Product_Availability;
            Product_Quantity.Text = this.product.Product_Quantity.ToString();
            Product_Color.Text = this.product.Product_Color;
            Product_Size.Text = this.product.Product_Size;
            Category_ID.Text = this.product.Category_ID.ToString();

            return product;
        }

        protected void SaveChangesButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();

            product.Product_ID = (int)ViewState["Product_ID"];
            product.Product_SKU = Product_SKU.Text;
            product.Product_Name = Product_Name.Text;
            product.Product_Description = Product_Description.Text;
            product.Product_Price = decimal.Parse(Product_Price.Text);
            product.Product_Brand = Product_Brand.Text;
            product.Product_Availability = Product_Availability.Text;
            product.Product_Quantity = int.Parse(Product_Quantity.Text);
            product.Product_Color = Product_Color.Text;
            product.Product_Size = Product_Size.Text;
            product.Category_ID = int.Parse(Category_ID.Text);

            if (FileUpload.HasFile)
            {
                HttpPostedFile file = FileUpload.PostedFile;

                byte[] imageData = new byte[FileUpload.PostedFile.ContentLength];
                file.InputStream.Read(imageData, 0, file.ContentLength);

                product.Product_Image = imageData;
            }

            productDB.Update(product);

            Response.Redirect("~/Admin/Product/Products.aspx");
        }

        protected void PopulateCategories()
        {
            CategoryDB categoryDB = new CategoryDB();

            List<Category> categories = categoryDB.GetCategories();

            Category_ID.DataSource = categories;
            Category_ID.DataTextField = "Category_Name";
            Category_ID.DataValueField = "Category_ID";
            Category_ID.DataBind();
        }
    }
}
