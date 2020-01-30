using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bulletin.Models;

namespace Bulletin
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Prepare the List of User
            User user = new User();
            // Create a User object and use its appropriate method 
            //  to populate the list of user
            List<User> listOfUser = new List<User>();
            listOfUser = user.GetUsers();

            //Create the First Row, with the Headings
            string u = @"
                        <div class='container'>
                        <div class='userlist'>
                        <table style ='width:auto;' class='table''>
                        <tr><td align ='center'><b>User ID</b></td>
                        <td align ='center'><b>Name</b></td>
                        <td align ='center'><b>Username</b></td>
                        <td align ='center'><b>Password</b></td>
                        <td align ='center'><b>User Type</b></td>
                        <td align ='center'><b>Last Login Date</b></td>
                        <td align ='center'><b>Action</b></td></tr>";
            // Increment through the List and Create the HTML string
            for (int n = 0; n <listOfUser.Count; n = n + 1)
            {
                if (n % 2 == 0)
                    u = u + "<tr>";
                else
                    u = u + "</tr><tr>";
                u = u + "<td align = 'center'>" + listOfUser.ElementAt(n).ID + "</td>";
                u = u + "<td align = 'center'>" + listOfUser.ElementAt(n).Name + "</td>";
                u = u + "<td align = 'center'>" + listOfUser.ElementAt(n).Username + "</td>";
                u = u + "<td align = 'center'>" + listOfUser.ElementAt(n).Password + "</td>";
                u = u + "<td align = 'center'>" + listOfUser.ElementAt(n).UserType + "</td>";
                u = u + "<td align = 'center'>" + listOfUser.ElementAt(n).LastLoginDate.ToString() + "</td>";
                u = u + "<td align = 'center'>";
                string reDirect = String.Format("UpdateUser.aspx?id={0}", listOfUser.ElementAt(n).ID);
                string hyperLink = "<a href = '" + reDirect + "'>Go to User!</a>";
                u = u + hyperLink + "</td>";
            }
            u = u + "</tr></table></div></div>";
            // Create a ContentPlaceHolder holder object and set its value to the
            //  userPlaceHolder in site master for this page
            ContentPlaceHolder cpu = Page.Master.FindControl("usersPlaceHolder") as ContentPlaceHolder;

            // Add a LiteralControl to the controls of userPlaceHolder
            cpu.Controls.Add(new LiteralControl(u));

        }
    }
}