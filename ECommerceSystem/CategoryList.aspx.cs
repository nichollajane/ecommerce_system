using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerceSystem.Database;
using ECommerceSystem.Models;

namespace ECommerceSystem
{
    public partial class CategoryList : System.Web.UI.Page
    {
        CategoryDB categoryDB = new CategoryDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetCategories();
        }

        protected void GetCategories()
        {
            List<Category> categories = categoryDB.GetCategories();

            CategoriesRepeater.DataSource = categories;
            CategoriesRepeater.DataBind();
        }
    }
}