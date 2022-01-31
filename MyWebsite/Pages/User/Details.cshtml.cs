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
    public class DetailsModel : PageModel
    {
        private readonly MyWebsite.Data.MyWebsiteContext _context;

        public DetailsModel(MyWebsite.Data.MyWebsiteContext context)
        {
            _context = context;
        }

        public ListUser ListUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListUser = await _context.ListUser.FirstOrDefaultAsync(m => m.ID == id);

            if (ListUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
