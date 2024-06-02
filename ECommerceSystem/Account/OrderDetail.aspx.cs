﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem.Account
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
                int Order_ID = Convert.ToInt32(Request.QueryString["Order_ID"]);

                if (Order_ID == 0)
                {
                    Response.Redirect("~/Account/OrderList.aspx");
                }

                ViewState["Order_ID"] = Order_ID;

                order = GetOrder(Order_ID);

                orderItems = orderItemDB.GetOrderItems(Order_ID);

                OrderItemsGridView.DataSource = orderItems;
                OrderItemsGridView.DataBind();
            }
        }

        protected Order GetOrder(int Order_ID)
        {
            order = orderDB.Get(Order_ID);

            return order;
        }
    }
}