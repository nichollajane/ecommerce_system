using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
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

        protected void CheckOutButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string argument = button.CommandArgument;
           
            Response.Redirect("~/Account/CheckOut.aspx?Cart_ID=" + argument);
        }

        protected void RemoveCartButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string argument = button.CommandArgument;

            cart.Cart_ID = int.Parse(argument);

            cartDB.Delete(cart);

            Response.Redirect("~/Account/CartList.aspx");
        }

        protected void IncrementQuantityButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string argument = button.CommandArgument;

            cart.Cart_ID = int.Parse(argument);

            cart = cartDB.Get(cart.Cart_ID);

            UpdateQuantity(cart, "increment");
        }

        protected void DecrementQuantityButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string argument = button.CommandArgument;

            cart.Cart_ID = int.Parse(argument);

            cart = cartDB.Get(cart.Cart_ID);

            UpdateQuantity(cart, "decrement");
        }

        protected void UpdateQuantity(Models.Cart cart, string type)
        {
            if (type == "increment")
            {
                cart.Quantity += 1;
            }
            else
            {
               cart.Quantity -= 1;
            }

            cartDB.Update(cart);

            Response.Redirect("~/Account/CartList.aspx");
        }

        protected void CartsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}