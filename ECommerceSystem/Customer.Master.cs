using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;

namespace ECommerceSystem
{
    public partial class Customer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (ticket != null)
                    {
                        Fullname.Text = ticket.UserData;
                    }
                }
            }
            else
            {
                Response.Redirect("Signin.aspx");
            }
        }
        
        protected void SignoutButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect("Signin.aspx");
        }
    }
}