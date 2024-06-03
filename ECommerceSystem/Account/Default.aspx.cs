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
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value);

            User user = userDB.Get(int.Parse(ticket.Name));

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

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}