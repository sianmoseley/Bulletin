using System;
using Bulletin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulletin
{
   
    public partial class Register : System.Web.UI.Page
    {
        User user = new User();
        Utility utility = new Utility();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            //Pick up the information from the controls
            string name = NameTextBox.Text;
            string username = UsernameTextBox.Text;
            string password1 = Pass1TextBox.Text;
            string password2 = Pass2TextBox.Text;

            //Perform checks on the information
            string checkName = utility.CheckName(name);
            string checkUsername = utility.CheckUsername(username, "register");
            string checkPassword = utility.CheckPasswordMatch(password1, password2);
            if (checkName == "OK" && checkUsername == "OK" && checkPassword == "OK")
            {//If all checks are good, we can do the work
                user.Name = name;
                user.Username = username;
                user.Password = password1;
                user.UserType = "USER";
                user.LastLoginDate = DateTime.Parse("1900-01-01");
                if (user.Register(user) == false) //For some reason unsuccessful
                    MessageLabel.Text = "That didn't work!";
                else //Successful registration and prompt to Login screen
                    Response.Redirect("Default.aspx");
            }
            else
            { //Display error messages
                NameLabel.Text = checkName;
                UsernameLabel.Text = checkUsername;
                if (checkPassword == "pass1error")
                {
                    Pass1Label.Text = "Please enter a password!";
                }
                if (checkPassword == "pass2error")
                {
                    Pass2Label.Text = "Please enter your password again!";
                }
                if (checkPassword == "pass1notpass2")
                {
                    Pass1Label.Text = "";
                    Pass2Label.Text = "Passwords don't match!";
                }
                

            }






        }
    }
}