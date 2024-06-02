using System;
using ECommerceSystem.Models;
using ECommerceSystem.Database;
using System.Web;

namespace ECommerceSystem
{
    public partial class CreateCategory : System.Web.UI.Page
    {
        CategoryDB categoryDB = new CategoryDB();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            category.Category_Name = Category_Name.Text;
            category.Category_Description = Category_Description.Text;

            if (FileUpload.HasFile)
            {
                HttpPostedFile file = FileUpload.PostedFile;

                byte[] imageData = new byte[FileUpload.PostedFile.ContentLength];
                file.InputStream.Read(imageData, 0, file.ContentLength);

                category.Category_Image = imageData;
            }

            categoryDB.Create(category);

            Response.Redirect("Categories.aspx");
        }
    }
}