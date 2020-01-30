using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bulletin.Repository;
namespace Bulletin.Models
{
    public class Board
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public List<Board> GetBoards()
        {
            BulletinContext _context = new BulletinContext();
            List<Board> _listOfBoard = new List<Board>();
            _listOfBoard = _context.Boards.ToList();
            return _listOfBoard;
        }

        public Board GetBoard(int id)
        {
            BulletinContext _context = new BulletinContext();
            return _context.Boards.Find(id);
        }

        public Board addBoard (Board board, User user)
        {
            BulletinContext _context = new BulletinContext();
            //Create the user in the context and add board
            User _user = _context.Users.Find(user.ID);
            _user.Boards.Add(item: board);

            //save changes
            _context.SaveChanges();
            return _context.Boards.Find(board.ID);
        }

        public List<string> GetBoardNames()
        {
            BulletinContext _context = new BulletinContext();
            IQueryable<string> boardnames = from _boardnames
                                           in _context.Boards
                                           select _boardnames.Name;
            return boardnames.ToList();
        }

        public string getBoardname(Post post) //method gets list of all users and looks through list of boards by each user
        {
            List<Board> boardList = GetBoards();
            int d = 0;
            Board board = new Board();
            string boardname = "Could not identify board";
            bool boardFound = false;
            while (boardFound == false)
            {
                for (int i = 0; i < boardList.Count; i++)
                {
                    for (int j = 0; j < boardList.ElementAt(i).Posts.Count; j++)
                    {
                        d = boardList.ElementAt(i).Posts.ElementAt(j).ID;
                        if (boardList.ElementAt(i).Posts.ElementAt(j).ID == post.ID)
                        {
                            board = boardList.ElementAt(i);
                            boardFound = true;
                            boardname = board.Name;
                        }
                    }
                }
            }

            return boardname;
        }

        

    }

}