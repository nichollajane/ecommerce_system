using System;
using ECommerceSystem.Models;
using ECommerceSystem.Database;
using System.Web;

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

            Category_Name.Text = category.Category_Name;
            Category_Description.Text = category.Category_Description;

            return category;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            category.Category_ID = (int)ViewState["Category_ID"];
            category.Category_Name = Category_Name.Text;
            category.Category_Description = Category_Description.Text;

            if (FileUpload.HasFile)
            {
                HttpPostedFile file = FileUpload.PostedFile;

                byte[] imageData = new byte[FileUpload.PostedFile.ContentLength];
                file.InputStream.Read(imageData, 0, file.ContentLength);

                category.Category_Image = imageData;
            }

            categoryDB.Update(category);

            Response.Redirect("Categories.aspx");
        }
    }
}