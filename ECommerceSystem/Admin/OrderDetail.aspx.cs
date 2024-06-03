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
    public partial class OrderDetail : System.Web.UI.Page
    {
        OrderDB orderDB = new OrderDB();
        OrderItemDB orderItemDB = new OrderItemDB();
        Order order = new Order();
        List<OrderItem> orderItems = new List<OrderItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Order_Number = Convert.ToInt32(Request.QueryString["Order_No"]);

                if (Order_Number == 0)
                {
                    Response.Redirect("~/Admin/OrderList.aspx");
                }

                ViewState["Order_No"] = Order_Number;

                order = GetOrder(Order_Number);

                orderItems = orderItemDB.GetOrderItems(order.Order_ID);

                Order_No.Text = order.Order_No.ToString();
                Order_Quantity.Text = order.Order_Quantity.ToString();
                Order_Price.Text = Convert.ToDecimal(order.Order_Price).ToString("₱#,##0.00");
                Shipping_Address.Text = order.Shipping_Address;

                Payment_Method.Checked = true;
            }
        }

        protected Order GetOrder(int Order_Number)
        {
            order = orderDB.Get(Order_Number);

            return order;
        }

        protected void UpdateOrderButton_Click(object sender, EventArgs e)
        {
            order = GetOrder((int)ViewState["Order_No"]);

            order.Order_Status = Order_Status.Text;

            orderDB.Update(order);
        }
    }
}