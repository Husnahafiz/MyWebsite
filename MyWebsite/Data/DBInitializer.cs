using MyWebsite.Data;
using MyWebsite.Models;
using System;
using System.Linq;


namespace MyWebsite.Data
{
    public class DBInitializer
    {

        public static void Initialize(MyWebsiteContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.ListUser.Any())
            {
                return;   // DB has been seeded
            }

            var user = new ListUser[]
            {
                new ListUser{FullName="Alexander",Email="alex@gmail.com",Position="Admin",DateJoined=DateTime.Parse("2022-01-01")},
                
            };

            context.ListUser.AddRange(user);
            context.SaveChanges();
        }
    }
}

