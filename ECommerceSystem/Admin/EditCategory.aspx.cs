using System;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem.Admin
{
    public partial class EditCategory : System.Web.UI.Page
    {
        CategoryDB categoryDB = new CategoryDB();

        Category category = new Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Category_ID = Convert.ToInt32(Request.QueryString["Category_ID"]);

                if (Category_ID == 0)
                {
                    Response.Redirect("~/Admin/Categories.aspx");
                }

                ViewState["Category_ID"] = Category_ID;

                this.category = GetCategory(Category_ID);
            }
        }

        protected Category GetCategory(int Category_ID)
        {
            category = categoryDB.Get(Category_ID);

            Category_Name.Text = this.category.Category_Name;
            Category_Description.Text = this.category.Category_Description;

            return category;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            this.category.Category_ID = (int)ViewState["Category_ID"];
            this.category.Category_Name = Category_Name.Text;
            this.category.Category_Description = Category_Description.Text;

            categoryDB.Update(this.category);

            Response.Redirect("Categories.aspx");
        }

        protected void Category_Description_TextChanged(object sender, EventArgs e)
        {

        }
    }
}