using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Data;
using MyWebsite.Models;

namespace MyWebsite.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly MyWebsite.Data.MyWebsiteContext _context;

        public EditModel(MyWebsite.Data.MyWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ListUser ListUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListUser = await _context.ListUsers.FindAsync(id);
            //FirstOrDefaultAsync(m => m.ID == id);

            if (ListUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //    if (!ModelState.IsValid)
            //    {
            //        return Page();
            //    }

            //    _context.Attach(ListUser).State = EntityState.Modified;

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ListUserExists(ListUser.ID))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return RedirectToPage("./Index");
            //}

            var userToUpdate = await _context.ListUsers.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<ListUser>(
                userToUpdate,
                "Alluser",
                s => s.FullName, s => s.Email, s => s.Position, s => s.DateJoined))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();

            //    private bool ListUserExists(int id)
            //{
            //    return _context.ListUser.Any(e => e.ID == id);
            //}
        }
    }
}
