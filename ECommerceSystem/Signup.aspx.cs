using System;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem
{
    public partial class Signup : System.Web.UI.Page
    {
        UserDB userDB = new UserDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void SignupButton_Click(object sender, EventArgs e)
        {
            User user = new User();

            user.Fullname = FullName.Text;
            user.Email = Email.Text;
            user.Password = Password.Text;
            user.Contact_No = int.Parse(ContactNo.Text);
            user.Gender = Gender.Text;
            user.Home_No = HomeNo.Text;
            user.Street = Street.Text;
            user.City = City.Text;
            user.Municipality = Municipality.Text;
            user.Region = Region.Text;
            user.Country = Country.Text;
            user.Zipcode = int.Parse(Zipcode.Text);
            user.User_Type = "Customer";

            if (userDB.checkUserEmailExists(user.Email))
            {
                return;
            }

            Response.Redirect("/Signin.aspx");
        }
    }
}