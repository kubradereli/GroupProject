using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-9LUSC50;database=BookDb2;integrated security=true;");
        }

        //--Database Tables--//
        public DbSet<About> Abouts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ReadBook> ReadBooks { get; set; }
        public DbSet<ReadingActivity> ReadingActivities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserReadingActivity> UserReadingActivities { get; set; }

        //--Dto--//
        //public DbSet<ReadBook_Page> ReadBook_Page { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ReadBook_Page>(eb => { eb.HasNoKey(); });
        //}
    }
}
