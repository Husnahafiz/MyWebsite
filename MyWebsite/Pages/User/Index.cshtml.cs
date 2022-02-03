using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Data;
using MyWebsite.Models;

namespace MyWebsite.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly MyWebsiteContext _context;
        //private string sortOrder;

        public IndexModel(MyWebsiteContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<ListUser> ListUser { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //ListUser = await _context.ListUser.ToListAsync();
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<ListUser> usersIQ = from s in _context.ListUsers
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                usersIQ = usersIQ.Where(s => s.FullName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    usersIQ = usersIQ.OrderByDescending(s => s.FullName);
                    break;
                case "Date":
                    usersIQ = usersIQ.OrderBy(s => s.DateJoined);
                    break;
                case "date_desc":
                    usersIQ = usersIQ.OrderByDescending(s => s.DateJoined);
                    break;
                default:
                    usersIQ = usersIQ.OrderBy(s => s.FullName);
                    break;
            }

            ListUser = await usersIQ.AsNoTracking().ToListAsync();
        }
    }
}

