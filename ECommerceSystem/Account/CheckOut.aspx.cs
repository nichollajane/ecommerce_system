using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using ECommerceSystem.Database;
using System.Data.SqlTypes;

namespace ECommerceSystem.Account
{
    public partial class CheckOut : System.Web.UI.Page
    {
        CartDB cartDB = new CartDB();
        ProductDB productDB = new ProductDB();
        Models.Cart cart = new Models.Cart();
        List<Models.Cart> carts = new List<Models.Cart>();

        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            if (!IsPostBack)
            {
                int Cart_ID = Convert.ToInt32(Request.QueryString["Cart_ID"]);

                if (Cart_ID != 0)
                {
                    cart.Cart_ID = Cart_ID;
                    carts = cartDB.GetCarts(int.Parse(ticket.Name), cart);
                    ViewState["Cart_ID"] = Cart_ID;
                }
                else
                {
                    carts = cartDB.GetCarts(int.Parse(ticket.Name));
                }

                if (carts.Count == 0)
                {
                    Response.Redirect("~/Account/CartList.aspx");
                }

                UserDB userDB = new UserDB();

                Models.User user = userDB.Get(int.Parse(ticket.Name));

                int totalQuantity = carts.Sum(cart => cart.Quantity);
                decimal totalPrice = carts.Sum(cart => cart.Total_Price);

                Order_No.Text = GenerateOrderNumber();
                Order_Quantity.Text = totalQuantity.ToString();
                Order_Price.Text = Convert.ToDecimal(totalPrice).ToString("₱#,##0.00");
                Shipping_Address.Text = user.Home_No + " " + user.Street + " " + user.Municipality + " " + user.Region + " " + user.Country;

                Payment_Method.Checked = true;

                CartItemsGridView.DataSource = carts;
                CartItemsGridView.DataBind();
            }
        }

        protected void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            OrderDB orderDB = new OrderDB();
            OrderItemDB orderItemDB = new OrderItemDB();
            Models.Order order = new Models.Order();

            int Cart_ID = Convert.ToInt32(Request.QueryString["Cart_ID"]);

            if (Cart_ID != 0)
            {
                cart.Cart_ID = Cart_ID;
                carts = cartDB.GetCarts(int.Parse(ticket.Name), cart);
                ViewState["Cart_ID"] = Cart_ID;
            }
            else
            {
                carts = cartDB.GetCarts(int.Parse(ticket.Name));
            }

            order.Order_No = int.Parse(Order_No.Text);
            order.User_ID = int.Parse(ticket.Name);
            order.Order_Date = DateTime.Now;
            order.Order_Quantity = int.Parse(Order_Quantity.Text);
            order.Order_Price = carts.Sum(cart => cart.Total_Price);
            order.Shipping_Address = Shipping_Address.Text;
            order.Payment_Method = "COD";
            order.Order_Status = "Order placed";

            orderDB.Create(order);

            order = orderDB.Get(order.Order_No);

            foreach (Models.Cart cart in carts)
            {
                Models.OrderItem orderItem = new Models.OrderItem();
                orderItem.Order_ID = order.Order_ID;
                orderItem.Product_ID = cart.Product_ID;
                orderItem.Order_Quantity = cart.Quantity;
                orderItem.Unit_Price = cart.Price;
                orderItem.Total_Price = cart.Total_Price;

                orderItemDB.Create(orderItem);

                cartDB.Delete(cart);

                Models.Product product = new Models.Product();
                product.Product_ID = orderItem.Product_ID;
                product.Product_Quantity -= orderItem.Order_Quantity;

                productDB.Update(product);
            }

            Response.Redirect("~/Account/OrderList.aspx");
        }

        public string GenerateOrderNumber()
        {
            Guid guid = Guid.NewGuid();

            byte[] bytes = guid.ToByteArray();

            int orderNumberInt = BitConverter.ToInt32(bytes, 0);

            orderNumberInt = Math.Abs(orderNumberInt);

            string orderNumber = (orderNumberInt % 1000000).ToString("D6");

            return orderNumber;
        }
    }
}