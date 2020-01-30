using System;
using Bulletin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulletin
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        Utility utility = new Utility();
        User user;
        static User userForUpdate;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            user = new User();
            int id = ((User)Session["loggedInUser"]).ID;
            userForUpdate = user.GetUser(id);
        }

        protected void ChanePassButton_Click(object sender, EventArgs e)
        {
            string oldPassword = OldPassTextBox.Text;
            string newPassword1 = NewPass1TextBox.Text;
            string newPassword2 = NewPass2TextBox.Text;
            string checkOldPassword = utility.CheckPassword(oldPassword, "change");
            string acceptNewPassword = utility.CheckPasswordMatch(newPassword1, newPassword2);
            if (checkOldPassword == "OK" && acceptNewPassword == "OK")
            {
                userForUpdate.Password = newPassword1;
                user.UpdateUser(userForUpdate);
                Response.Redirect("MyAccount.aspx");
            }
            else
            {//Display error messages
                if (checkOldPassword == "Please enter your password!")
                {
                    OldPassLabel.Text = "Please enter your password!";
                }
                if (checkOldPassword == "Oops, wrong password!")
                {
                    OldPassLabel.Text = "Password does not match our records.";
                }
                if (acceptNewPassword == "pass1error")
                {
                    NewPass1Label.Text = "Please enter a new password!";
                }
                if (acceptNewPassword == "pass2error")
                {
                    NewPass2Label.Text = "Please enter your new password again!";
                }
                if (acceptNewPassword == "pass1notpass2")
                {
                    NewPass1Label.Text = "";
                    NewPass2Label.Text = "Passwords don't match!";
                }



            }
        }
    }
}