using System;
using Bulletin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulletin
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        User user;
        static User userForUpdate;
        protected void Page_Load(object sender, EventArgs e)
        {// Get the user ID and load it into the page
            user = new User();
            int id = int.Parse(Request.QueryString["id"]);
            userForUpdate = user.GetUser(id);
            NameLabel.Text = userForUpdate.Name;
            UsernameLabel.Text = userForUpdate.Username;
            if (!Page.IsPostBack)
            {
                RoleRadio.SelectedValue = userForUpdate.UserType;
            }

        }

        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {//Save button persists the user and redirects to Users.aspx
            userForUpdate.UserType = RoleRadio.SelectedValue;
            user.UpdateUser(userForUpdate);
            Response.Redirect("Users.aspx");

        }

        protected void DeleteUserButton_Click(object sender, EventArgs e)
        {

            user.DeleteUser(userForUpdate);
            Response.Redirect("Users.aspx");
        }
    }
}