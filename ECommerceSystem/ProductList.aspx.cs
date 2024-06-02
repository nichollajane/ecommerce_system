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
            GetProducts();
        }

        protected void GetProducts()
        {
            List<Product> products = productDB.GetProducts();

            ProductsRepeater.DataSource = products;
            ProductsRepeater.DataBind();
        }
    }
}