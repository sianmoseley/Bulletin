using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bulletin.Models;

namespace Bulletin.Repository
{
    public class BulletinInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BulletinContext>
    {
        protected virtual void Seed(BulletinContext _context)
        {
            //// Create a User object and set it's properties
            //// Add the user object to the Users property of _context
            //User user = new User();
            //user.Name = "Sian Moseley";
            //user.Username = "sian";
            //user.Password = "password";
            //user.UserType = "ADMIN";
            //user.LastLoginDate = DateTime.Parse("2019-18-12");


            //// call the method of _context to commit
            //_context.SaveChanges(); // Commit to database
        }
    }
}