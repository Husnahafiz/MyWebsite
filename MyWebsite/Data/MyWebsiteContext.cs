using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Models;

namespace MyWebsite.Data
{
    public class MyWebsiteContext : DbContext
    {
        public MyWebsiteContext (DbContextOptions<MyWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<ListUser> ListUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListUser>().ToTable("ListUser");
        }
    }
}
