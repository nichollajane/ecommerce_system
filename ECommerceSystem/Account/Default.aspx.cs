using System;
using ECommerceSystem.Database;
using ECommerceSystem.Models;
using System.Web.Security;

namespace ECommerceSystem.Account
{
	public partial class Default : System.Web.UI.Page
	{
        UserDB userDB = new UserDB();

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

                User user = userDB.Get(int.Parse(ticket.Name));

                ViewState["User_ID"] = int.Parse(ticket.Name);

                FullName.Text = user.Fullname;
                Email.Text = user.Email;
                Password.Text = user.Password;
                ContactNo.Text = "" + user.Contact_No;
                Gender.Text = user.Gender;
                HomeNo.Text = user.Home_No;
                Street.Text = user.Street;
                Barangay.Text = user.Barangay;
                City.Text = user.City;
                Municipality.Text = user.Municipality;
                Region.Text = user.Region;
                Country.Text = user.Country;
                Zipcode.Text = "" + user.Zipcode;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            User user = userDB.Get((int)ViewState["User_ID"]);

            user.User_ID = user.User_ID;
            user.Fullname = FullName.Text;
            user.Email = Email.Text;
            user.Contact_No = ContactNo.Text;
            user.Gender = Gender.Text;
            user.Home_No = HomeNo.Text;
            user.Street = Street.Text;
            user.City = City.Text;
            user.Municipality = Municipality.Text;
            user.Region = Region.Text;
            user.Country = Country.Text;
            user.Zipcode = int.Parse(Zipcode.Text);
            user.User_Type = user.User_Type;
            user.Barangay = Barangay.Text;

            // If password is blank then don't update it
            if (Password.Text == null)
            {
                user.Password = user.Password;
            }

            userDB.Update(user);

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Changes saved!');", true);
        }
    }
}