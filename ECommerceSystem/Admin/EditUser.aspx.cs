using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ECommerceSystem.Database;

namespace ECommerceSystem.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {
        UserDB userDB = new UserDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int User_ID = Convert.ToInt32(Request.QueryString["User_ID"]);

                if (User_ID == 0)
                {
                    Response.Redirect("~/Admin/User.aspx");
                }

                GetUser(User_ID);
            }
        }

        protected void GetUser(int User_ID)
        {
            Models.User user = userDB.Get(User_ID);

            Fullname.Text = user.Fullname;
            User_Type.Text = user.User_Type;
            Email.Text = user.Email;
            Password.Text = user.Password;
            Contact_No.Text = "" + user.Contact_No;
            Gender.Text = user.Gender;
            Home_No.Text = user.Home_No;
            Street.Text = user.Street;
            User_Barangay.Text = user.Barangay;
            City.Text = user.City;
            Municipality.Text = user.Municipality;
            Region.Text = user.Region;
            Country.Text = user.Country;
            Zipcode.Text = "" + user.Zipcode;
        }

        protected void SaveChangesButton_Click(object sender, EventArgs e)
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
            user.Barangay = User_Barangay.Text;
            user.City = City.Text;
            user.Municipality = Municipality.Text;
            user.Region = Region.Text;
            user.Country = Country.Text;
            user.Zipcode = int.Parse(Zipcode.Text);

            userDB.Update(user);

            Response.Redirect("Users.aspx");
        }
    }
}