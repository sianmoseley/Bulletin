using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bulletin.Repository;

namespace Bulletin.Models
{
    public class Post
    {
        BulletinContext _context;
        public Post()
        {
            _context = new BulletinContext();
        }
        public int ID { get; set; }

        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public Post addPost(Board board, User user, Post post)
        {
            BulletinContext _context = new BulletinContext();
            //Create the board in the context and add post
            Board _board = _context.Boards.Find(board.ID);
            _board.Posts.Add(item: post);
            //Create the user in the context and add the post
            User _user = _context.Users.Find(user.ID);
            _user.Posts.Add(item: post);
            //save changes
            _context.SaveChanges();
            return _context.Posts.Find(post.ID);
        }



    }
}