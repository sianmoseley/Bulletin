using System;
using Bulletin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bulletin
{
    public partial class Boards : System.Web.UI.Page
    {
        int userID;
        Utility utility = new Utility();
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime lastDT = (DateTime)(Session["LastLogIn"]);
            LastLoginLabel.Text = lastDT.ToString();


            //Prepare list of Boards
            Board _board = new Board();
            List<Board> listOfBoard = new List<Board>();
            listOfBoard = _board.GetBoards();

            //Create an object of User called user
            User user = new User();

            //Create the first row with heading, for the Name of Board
            string b = @"
                        <div class='container boardpostslist '>     
                        <table style ='width:auto;' class= 'table boardlist'>
                        <tr><td align ='center'><b>Board Name</b></td>";
            //Run through the List and Create the HTML string
            for (int n = 0; n <listOfBoard.Count; n = n +1)
            {
                if (n % 2 == 0)
                {
                    b = b + "<tr>";
                }
                else
                {
                    b = b + "</tr><tr>";
                }
                b = b + "<td align ='center'>";
                //Create a hyperlink of each Board
                string reDirect = String.Format("BoardPost.aspx?id={0}", + listOfBoard.ElementAt(n).ID);
                string linkText = listOfBoard.ElementAt(n).Name;
                string hyperLink = "<a href = '" + reDirect + "'>" + linkText + "</a>";
                b = b + hyperLink + "</td>";
            }

            b = b + "</tr></table></div>"; //HTML string is now created

            //Send the HTML string to Content Place Holder
            ContentPlaceHolder cpb = Page.Master.FindControl("boardsPlaceHolder") as ContentPlaceHolder;
            cpb.Controls.Add(new LiteralControl(b));
        }

        protected void CreateBoardButton_Click(object sender, EventArgs e)
        {
            string newBoardName = CreateBoardTextBox.Text;
            //Check that the text box isn't empty or a board name that already exists
            string checkBoardName = utility.CheckNewBoardName(newBoardName, "create board");
            if (checkBoardName == "OK")
            {//If board name is unique, we can go ahead and make new board
                Board board = new Board();
                User user = new User();
                userID = ((User)Session["loggedInUser"]).ID;
                User _user = user.GetUser(userID);
                Board newBoard = new Board();

                newBoard.Name = newBoardName;
                newBoard.DateCreated = DateTime.Now;
                board.addBoard(newBoard, _user);

                //_user.Boards.Add(newBoard);

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                CreateNewBoardLabel.Text = checkBoardName;
            }

            
            

        }
    }
}