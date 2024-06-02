using System;
using ECommerceSystem.Models;
using ECommerceSystem.Database;
using System.Web.Security;
using System.Web;

namespace ECommerceSystem
{
    public partial class Signin : System.Web.UI.Page
    {
        UserDB userDB = new UserDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void SigninButton_Click(object sender, EventArgs e)
        {
            Reset();

            string email = Email.Text;
            string password = Password.Text;

            User user = userDB.checkUser(email, password);

            if (user == null)
            {
                InvalidSignin.Visible = true;
                return;
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
               1,
               "" + user.User_ID,
               DateTime.Now,
               DateTime.Now.AddMinutes(30),
               false,
               user.Fullname
           );

            // Encrypt the ticket and store it in a cookie
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            Response.Cookies.Add(cookie);

            if (user.User_Type == "Customer")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Admin/Users.aspx");
            }
        }

        protected void Reset()
        {
            InvalidSignin.Visible = false;
        }
    }
}