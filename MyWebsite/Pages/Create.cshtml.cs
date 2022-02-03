using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebsite.Data;
using MyWebsite.Models;

namespace MyWebsite.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly MyWebsite.Data.MyWebsiteContext _context;

        public CreateModel(MyWebsite.Data.MyWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ListUser ListUsers { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ListUsers.Add(ListUsers);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

            //var emptyUser = new ListUser();

            //if (await TryUpdateModelAsync<ListUser>(
            //    emptyUser,
            //    "Alluser",   // Prefix for form value.
            //    s => s.FullName, s => s.Email, s => s.Position, s => s.DateJoined))
            //{
            //    _context.ListUsers.Add(emptyUser);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}

            return Page();
        }
    }
}
