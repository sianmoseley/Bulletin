using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Bulletin.Repository
{
    public class BulletinContext : DbContext
    {
        public BulletinContext() : base("BulletinContext") { }
        public DbSet<Bulletin.Models.User> Users { set; get; }
        public DbSet<Bulletin.Models.Board> Boards { set; get; }
        public DbSet<Bulletin.Models.Post> Posts { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}