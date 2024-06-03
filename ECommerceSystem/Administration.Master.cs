using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ECommerceSystem.Database;
using ECommerceSystem.Models;

namespace ECommerceSystem
{
    public partial class Administration : System.Web.UI.MasterPage
    {
        UserDB userDB = new UserDB();
        User user = new User();

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
                        user = userDB.Get(int.Parse(ticket.Name));

                        if (user.User_Type == "Customer")
                        {
                            Response.Redirect("/");
                        } 
                        else
                        {
                            Fullname.Text = ticket.UserData;
                        }

                        
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