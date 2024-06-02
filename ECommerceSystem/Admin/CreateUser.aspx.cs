using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerceSystem;
using ECommerceSystem.Database;

namespace ECommerceSystem.Admin.User
{
    public partial class CreateUser : System.Web.UI.Page
    {
        UserDB userDB = new UserDB();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AddSaveButton_Click(object sender, EventArgs e)
        {
            Models.User user = new Models.User();

            user.Fullname = Fullname.Text;
            user.User_Type = User_Type.Text;
            user.Email = Email.Text;
            user.Password = Password.Text;
            user.Contact_No = int.Parse(Contact_No.Text);
            user.Gender = Gender.Text;
            user.Home_No = Home_No.Text;
            user.Street = Street.Text;
            user.Barangay = Barangay.Text;
            user.City = City.Text;
            user.Municipality = Municipality.Text;
            user.Region = Region.Text;
            user.Country = Country.Text;
            user.Zipcode = int.Parse(Zipcode.Text);

            userDB.Create(user);

            Response.Redirect("Users.aspx");
        }
    }
}