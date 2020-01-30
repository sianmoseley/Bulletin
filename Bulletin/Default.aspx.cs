using System;
using Bulletin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulletin
{
    public partial class Login : System.Web.UI.Page
    {
        User user = new User();
        Utility utility = new Utility();
        static int count = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLabel.Text = " ";
            PassLabel.Text = " ";
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UserTextBox.Text;
            string password = PassTextBox.Text;
            string checkUsername = utility.CheckUsername(username, "login");
            string checkPassword = utility.CheckPassword(password, "login");
            if (checkUsername == "OK" && checkPassword == "OK")
            {
                user = user.Login(username, password);
                if (user != null)
                {
                    DateTime lastLogIn = user.LastLoginDate;
                    user.LastLoginDate = DateTime.Now;
                    user.UpdateUser(user);
                    Session.Add("loggedInUser", user);
                    Session.Add("LastLogIn", lastLogIn);
                    User _user = (User)(Session["loggedInUser"]);
                    Response.Redirect("Boards.aspx");
                }
            }




            else
            {
                if (count < 3)
                {
                    UserLabel.Text = checkUsername;
                    PassLabel.Text = checkPassword;
                    count++;
                }
                else
                    Response.Redirect("Register.aspx");

            
            }

        }
    }
}