using System;
using System.Web;
using System.Collections.Generic;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        CategoryDB categoryDB = new CategoryDB();
        ProductDB productDB = new ProductDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateCategories();
        }

        protected void AddSaveButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();

            product.Product_SKU = Product_SKU.Text;
            product.Product_Name = Product_Name.Text;
            product.Product_Description = Product_Description.Text;
            product.Product_Price = decimal.Parse(Product_Price.Text);
            product.Product_Brand = Product_Brand.Text;
            product.Product_Availability = Product_Availability.SelectedItem.Text;
            product.Product_Quantity = int.Parse(Product_Quantity.Text);
            product.Product_Color = Product_Color.Text;
            product.Product_Size = Product_Size.Text;
            product.Category_ID = int.Parse(Category_ID.Text);

            if (FileUpload.HasFile)
            {
                HttpPostedFile file = FileUpload.PostedFile;

                byte[] imageData = new byte[FileUpload.PostedFile.ContentLength];
                file.InputStream.Read(imageData, 0, file.ContentLength);

                product.Product_Image = imageData;
            }

            productDB.Create(product);

            Response.Redirect("Products.aspx");
        }

        protected void PopulateCategories()
        {
            List<Category> categories = categoryDB.GetCategories();

            Category_ID.DataSource = categories;
            Category_ID.DataTextField = "Category_Name";
            Category_ID.DataValueField = "Category_ID";
            Category_ID.DataBind();
        }
    }
}