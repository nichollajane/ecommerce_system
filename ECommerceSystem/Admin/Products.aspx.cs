using System;
using System.Data;
using System.Web.UI.WebControls;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        ProductDB productDB = new ProductDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                ProductsGridView.DataSource = productDB.List();
                ProductsGridView.DataBind();
            }
        }

        protected void ProductsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                byte[] bytes = (byte[])(e.Row.DataItem as DataRowView)["Product_Image"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                (e.Row.FindControl("Product_Image") as Image).ImageUrl = "data:image/png;base64," + base64String;
            }
        }

        protected void ProductsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditProduct")
            {
                Response.Redirect("EditProduct.aspx?Product_ID=" + id);
            }

            if (e.CommandName == "DeleteProduct")
            {
                Delete_Product(id);
            }
        }


        public void Delete_Product(int Product_ID)
        {
            Product product = new Product();
            product.Product_ID = Product_ID;

            productDB.Delete(product);

            Response.Redirect("Products.aspx");
        }
    }
}