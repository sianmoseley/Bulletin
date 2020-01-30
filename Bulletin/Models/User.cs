using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bulletin.Repository;

namespace Bulletin.Models
{
    public class User
    {
        BulletinContext _context;
        public User()
        {
            _context = new BulletinContext();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string UserType { get; set; }

        public DateTime LastLoginDate { get; set; }

        public virtual ICollection<Board> Boards { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
 
        public List<User> GetUsers()
        {
            
            List<User> _listOfUser = new List<User>();
            _listOfUser = _context.Users.ToList();
            return _listOfUser;
        }

        public User UpdateUser(User user)
        {
            
            //Place _user object in context
            User _user = _context.Users.Find(user.ID);
            //Dress up the _user object as the user object
            _user.Name = user.Name;
            _user.Password = user.Password;
            _user.UserType = user.UserType;
            _user.LastLoginDate = user.LastLoginDate;
            //Commit _user for user
            _context.SaveChanges();
            //Optionally, return the object
            return _context.Users.Find(user.ID);
        }

        public List<string> GetUsernames()
        {
            
            IQueryable<string> usernames = from _usernames
                                           in _context.Users
                                           select _usernames.Username;
            return usernames.ToList();
        }

        public List<string> GetPasswords()
        {
           
            IQueryable<string> passwords = from _passwords
                                          in _context.Users
                                          select _passwords.Password;
            return passwords.ToList();
        }



       
        public User Login(string username, string password)
        {//Only attempt to do the work if  username is one we have
            if (GetUsernames().Contains(username))
            {//Get the user with username
               
                IQueryable<User> result = from _user
                                          in _context.Users
                                          where _user.Username == username
                                          select _user;
                User user = result.First();
                if (user.Password == password) //Does password check?
                { //Manages to Login, sets the date
                    //user.LastLoginDate = DateTime.Now;
                    //UpdateUser(user);
                    return user;
                }
                else //Fails to login
                    return null;
            }
            else
                return null;

        }

        public bool Register(User user)
        {
           
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<Post> GetPosts()
        {
            List<Post> _listOfPost = new List<Post>();
            _listOfPost = _context.Posts.ToList();
            return _listOfPost;
        }


        public bool DeleteUser(User user)
        {

            try
            {
                _context.Users.Remove(user);
                List<Post> postList = GetPosts();
                postList.Clear();
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

       public string getUsername(Post post) //method gets list of all users,  looks through list of Posts by each user and if post matches the post ID inputted into method, it returns the username
        {
            List<User> userList = GetUsers();
            int d = 0;
            User user = new User();
            string username = "Could not identify user";
            bool userFound = false;
            //while (userFound == false)
            //{
                for (int i = 0; i < userList.Count; i++)
                {
                    for (int j = 0; j < userList.ElementAt(i).Posts.Count; j++)
                    {
                        d = userList.ElementAt(i).Posts.ElementAt(j).ID;
                        if (userList.ElementAt(i).Posts.ElementAt(j).ID == post.ID)
                        {
                            user = userList.ElementAt(i);
                            userFound = true;
                            username = user.Username;
                        }
                    }
                }
            //}

            return username;
        }

        public string getUsernameForBoard(Board board) //method gets list of all users,  looks through list of Boards by each user and if post matches the board ID inputted into method, it returns the username
        {
            List<User> userList = GetUsers();
            int d = 0;
            User user = new User();
            string username = "User has been deleted!";
            bool userFound = false;
            //while (userFound == false)
            //{
            for (int i = 0; i < userList.Count; i++)
            {
                for (int j = 0; j < userList.ElementAt(i).Boards.Count; j++)
                {
                    d = userList.ElementAt(i).Boards.ElementAt(j).ID;
                    if (userList.ElementAt(i).Boards.ElementAt(j).ID == board.ID)
                    {
                        user = userList.ElementAt(i);
                        userFound = true;
                        username = user.Username;
                    }
                }
            }
            //}

            return username;
        }




    }
}