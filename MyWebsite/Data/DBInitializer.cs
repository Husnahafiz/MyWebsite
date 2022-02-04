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
            if (context.ListUsers.Any())
            {
                return;   // DB has been seeded
            }

            var user = new ListUser[]
            {
                new ListUser{FullName="Alexander",Email="Alex@gmail.com",Position="Admin",DateJoined=DateTime.Parse("2022-01-01")},
                new ListUser{FullName="Lila",Email="Lila@gmail.com",Position="Employee",DateJoined=DateTime.Parse("2022-01-01")},
                new ListUser{FullName="Natan",Email="Natan@yahoo.com",Position="Employee",DateJoined=DateTime.Parse("2022-01-14")},
                new ListUser{FullName="Dahlia",Email="Dahlia@hotmail.com",Position="Employee",DateJoined=DateTime.Parse("2022-01-21")},
                new ListUser{FullName="Adam",Email="Adam@yahoo.com",Position="Employee",DateJoined=DateTime.Parse("2022-01-27")},
                new ListUser{FullName="Nick",Email="Nick@gmail.com",Position="Employee",DateJoined=DateTime.Parse("2022-01-31")}

            };

            context.ListUsers.AddRange(user);
            context.SaveChanges();
        }
    }
}

