using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bulletin.Models
{
    public class Utility
    {
        public string CheckUsername (string username, string action)
        {//Various checks on username string
            User user = new User();
            if (username.Length == 0)
                return "Please enter your username!";
            else if (user.GetUsernames().Contains(username))
                if (action == "register")
                    return "Username is already taken!";
                else
                    return "OK";
            else
                return "OK";
        }
        public string CheckPassword(string password, string action)
        {//Checks there's a password for login and whether it matches what is in database for user
            User user = new User();
            if (password.Length == 0)
                return "Please enter your password!";
            else if (user.GetPasswords().Contains(password)) //When user logs in, this check's that the password is correct as per database
                return "OK";
            else
                return "Oops, wrong password!";

        }

        public string CheckName (string name)
        {
            if (name.Length == 0)
                return "Please enter your name!";
            else
                return "OK";
        }

        public string CheckPasswordMatch (string password1, string password2)
        {
            if ((password1.Length == 0 && password2.Length == 0) || (password1.Length == 0 && password2.Length != 0))
                return "pass1error";
            else if (password1.Length != 0 && password2.Length == 0)
                return "pass2error";
            else if (password1.Length != 0 && password2.Length != 0)
                if (password1 != password2)
                    return "pass1notpass2";
                else
                    return "OK";
            return
                "OK";
        }

        public string CheckNewBoardName (string boardname, string action)
        {
            Board board = new Board();
            if (boardname.Length == 0)
                return "Please enter a board name!";
            else if (board.GetBoardNames().Contains(boardname))
                if (action == "create board")
                    return "Board already exists!";
                else
                    return "OK";
            else
                return "OK";
             
        }

        public string CheckNewPostText (string postText)
        {
            Post post = new Post();
            if (postText.Length == 0)
                return "Please enter a post!";
            else
                return "OK";

        }
    }
}