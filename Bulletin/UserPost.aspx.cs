using System;
using Bulletin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulletin
{
    public partial class UserPost : System.Web.UI.Page
    {
        Board board = new Board();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Recover the user ID from the logged in session
            int id = ((User)Session["loggedInUser"]).ID;

            //Create an object of User called user
            User user = new User();

            //Create another object of user called _user
            User _user = user.GetUser(id);

            //Display the username 
            string up1 = "<div class='container'><h2>Posts by " +_user.Username + "</h2></div>";

            //Use the userPostPlaceHolder to display User's name
            ContentPlaceHolder cpup1 = Page.Master.FindControl("userPostPlaceHolder1") as ContentPlaceHolder;
            //Add a Literal Control
            cpup1.Controls.Add(new LiteralControl(up1));

            //Now show the post's info
            string up2 = @" 
                        <div class='container'>
                        <div class='userposts'>
                        <table style='width:auto;' class='table'>
                        <tr><td align ='center'><b>Text</b></td>
                        <td align='center'><b>Date Created</b></td>
                        <td align='center'><b>Board Name</b></td>";

            // Run through the list and create the HTML string

            for (int n = 0; n <_user.Posts.Count; n = n + 1)
            {
                if (n % 2 == 0)
                    up2 = up2 + "<tr>";
                else 
                    up2 = up2 + "</tr><tr>";
                up2 = up2 + "<td align='center'>" + _user.Posts.ElementAt(n).Text + "</td>";
                up2 = up2 + "<td align='center'>" + _user.Posts.ElementAt(n).DateCreated.ToString() + "</td>";
                up2 = up2 + "<td align = 'center'>" + board.getBoardname(_user.Posts.ElementAt(n)) + "</td>";
               
            }

            up2 = up2 + "</tr></table></div></div>"; //HTML string is now created
            //Send HTML string to the ContentPlaceHolder 
            ContentPlaceHolder cpp2 = Page.Master.FindControl("userPostPlaceHolder2") as ContentPlaceHolder;
            // Add a Literal Control
            cpp2.Controls.Add(new LiteralControl(up2));

        }
    }
}