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
        }
    }
}