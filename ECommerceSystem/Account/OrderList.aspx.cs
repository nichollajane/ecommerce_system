using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem.Account
{
    public partial class OrderList : System.Web.UI.Page
    {
        OrderDB orderDB = new OrderDB();
        Order order = new Order();
        List<Order> orders = new List<Order>();

        protected void Page_Load(object sender, EventArgs e)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            OrdersGridView.DataSource = orderDB.List(int.Parse(ticket.Name));
            OrdersGridView.DataBind();
        }

        protected void OrdersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "View")
            {
                Response.Redirect("OrderDetail.aspx?Order_ID=" + id);
            }
        }
    }
}