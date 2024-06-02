using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerceSystem;
using ECommerceSystem.Database;
using System.Web.Security;

namespace ECommerceSystem.Account
{
    public partial class CartList : System.Web.UI.Page
    {
        CartDB cartDB = new CartDB();
        Models.Cart cart = new Models.Cart();

        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            List<Models.Cart> carts = cartDB.GetCarts(int.Parse(ticket.Name));

            CartsRepeater.DataSource = carts;
            CartsRepeater.DataBind();
        }

        protected void RemoveCartButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string argument = button.CommandArgument;

            cart.Cart_ID = int.Parse(argument);

            cartDB.Delete(cart);

            Response.Redirect("~/Account/CartList.aspx");
        }

        protected void AddQuantity_Click(object sender, EventArgs e)
        {

        }
    }
}