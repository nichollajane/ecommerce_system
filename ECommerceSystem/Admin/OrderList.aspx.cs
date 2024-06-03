using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem.Admin
{
    public partial class OrderList : System.Web.UI.Page
    {
        OrderDB orderDB = new OrderDB();
        Order order = new Order();
        List<Order> orders = new List<Order>();

        protected void Page_Load(object sender, EventArgs e)
        {
            OrdersGridView.DataSource = orderDB.ListAllOrders();
            OrdersGridView.DataBind();
        }
    }
}