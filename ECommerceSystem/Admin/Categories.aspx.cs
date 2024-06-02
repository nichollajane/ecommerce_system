using System;
using System.Web.UI.WebControls;
using ECommerceSystem.Models;
using ECommerceSystem.Database;
using System.Data;

namespace ECommerceSystem
{
    public partial class Categories : System.Web.UI.Page
    {
        CategoryDB categoryDB = new CategoryDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriesGridView.DataSource = categoryDB.List();
                CategoriesGridView.DataBind();
            }
        }

        protected void CategoriesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                byte[] bytes = (byte[])(e.Row.DataItem as DataRowView)["Category_Image"];
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                (e.Row.FindControl("Category_Image") as Image).ImageUrl = "data:image/png;base64," + base64String;
            }
        }

        protected void CategoriesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "EditCategory")
            {
                Response.Redirect("EditCategory.aspx?Category_ID=" + id);
            }

            if (e.CommandName == "DeleteCategory")
            {
                DeleteCategory(id);
            }
        }

        public void DeleteCategory(int Category_ID)
        {
            Category category = new Category();
            category.Category_ID = Category_ID;

            categoryDB.Delete(category);

            Response.Redirect("Categories.aspx");
        }
    }
}