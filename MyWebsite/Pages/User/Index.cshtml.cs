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
        private readonly MyWebsite.Data.MyWebsiteContext _context;

        public IndexModel(MyWebsite.Data.MyWebsiteContext context)
        {
            _context = context;
        }

        public IList<ListUser> ListUser { get;set; }

        public async Task OnGetAsync()
        {
            ListUser = await _context.ListUser.ToListAsync();
        }
    }
}
