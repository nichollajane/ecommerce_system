using System;
using System.Collections.Generic;
using ECommerceSystem.Models;
using ECommerceSystem.Database;
using System.Web.UI.WebControls;

namespace ECommerceSystem
{
    public partial class ProductList : System.Web.UI.Page
    {
        ProductDB productDB = new ProductDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Category_ID = Convert.ToInt32(Request.QueryString["Category_ID"]);


                if (Category_ID == 0)
                {
                    ProductsRepeater.DataSource = productDB.GetProducts();
                    ProductsRepeater.DataBind();
                } 
                else
                {
                    ProductsRepeater.DataSource = productDB.GetProductsByCategory(Category_ID);
                    ProductsRepeater.DataBind();
                }
            }
        }
    }
}