using System;
using System.Web.UI.WebControls;
using ECommerceSystem.Models;
using ECommerceSystem.Database;

namespace ECommerceSystem.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        UserDB userDB = new UserDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminUsersGridView.DataSource = userDB.List();
                AdminUsersGridView.DataBind();
            }
        }

        protected void AdminUsersGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Edit")
            {
                Response.Redirect("EditUser.aspx?User_ID=" + id);
            }

            if (e.CommandName == "Delete")
            {
                Delete_User(id);
            }
        }

        public void Delete_User(int User_ID)
        {
   
            Models.User user = new Models.User();
            user.User_ID = User_ID;

            userDB.Delete(user);

            Response.Redirect("Users.aspx");
        }
    }
}