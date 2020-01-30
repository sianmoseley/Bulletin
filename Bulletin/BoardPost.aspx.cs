using System;
using Bulletin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulletin
{
    public partial class BoardPost : System.Web.UI.Page
    {
        int boardID;
        int userID;
        Utility utility = new Utility();
        User user = new User();
  
        protected void Page_Load(object sender, EventArgs e)
        {

            //Recover the board ID from the URL
            boardID = int.Parse(Request.QueryString["id"]);

            //Create an object of Board called board
            Board board = new Board();
            //Create another object of board called _board
            Board _board = board.GetBoard(boardID);
            //Display the name of the board
            string p1 = "<div class='container'><h2>" +_board.Name + " Posts</h2></div>";
            //Use the boardPostPlaceHolder1 to display the board's name
            ContentPlaceHolder cpp1 = Page.Master.FindControl("boardPostPlaceHolder1") as ContentPlaceHolder;
            //Add a literal control
            cpp1.Controls.Add(new LiteralControl(p1));
            //How for the post's info
            string p2 = @"
                        <div class='container'>
                        <div class= 'boardpostslist'>
                        <table style ='width:auto;' class='table'>
                        <tr><th><b>Post</b></th>    
                        <th><b>Date Created</b></th>
                        <th><b>User Who Created Post</b></th>";

            //Run through the list and create the HTML string

            for (int n = 0; n < _board.Posts.Count; n = n + 1)
            {
                if (n % 2 == 0)
                    p2 = p2 + "<tr>";
                else
                    p2 = p2 + "</tr><tr>";
                p2 = p2 + "<td>" + _board.Posts.ElementAt(n).Text + "</td>";
                p2 = p2 + "<td align = 'center'>" + _board.Posts.ElementAt(n).DateCreated.ToString() + "</td>";
                p2 = p2 + "<td align = 'center'>" + user.getUsername(_board.Posts.ElementAt(n)) + "</td>";
                
                //putting the post into getUsername method returns the username of who made the post 
            }

            p2 = p2 + "</tr></table></div></div>"; //HTML string is now created
            //Send the html string to the ContentPlaceHolder (boardNamePlaceHolder2)
            ContentPlaceHolder cpp2 = Page.Master.FindControl("boardPostPlaceHolder2") as ContentPlaceHolder;
            //Add a Literal Control
            cpp2.Controls.Add(new LiteralControl(p2));

        }

        protected void NewPostButton_Click(object sender, EventArgs e)
        {
            string newPostText = NewPostTextBox.Text;
            //Do check to make sure new post text box is not empty
            string checkPostText = utility.CheckNewPostText(newPostText);
            if (checkPostText == "OK")
            {//if post text  box is not empty, we can add the post to the board
                Post post = new Post();
                Board board = new Board();
                User user = new User();

                //Finds the board ID from the url
                boardID = int.Parse(Request.QueryString["id"]);
                //Finds the user ID from the log in
                userID = ((User)Session["loggedInUser"]).ID;

                //Create an object of Post called newPost
                Post newPost = new Post();
                //_board to store the ID of the board the post is to be added to
                Board _board = board.GetBoard(boardID);
                //_user to store ID of the logged in user making the post
                User _user = user.GetUser(userID);

                newPost.Text = newPostText;
                newPost.DateCreated = DateTime.Now;
                //Use addPost method and input parameters 
                post.addPost(_board, _user, newPost);

                //_user.Posts.Add(newPost);

                Response.Redirect(Request.RawUrl);
            }
            else
                NewPostLabel.Text = checkPostText;

        
        
        }
    }
}