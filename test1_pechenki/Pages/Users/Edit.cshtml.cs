using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test1_pechenki.Data;
using test1_pechenki.Models;
using Microsoft.AspNetCore.Authorization;

namespace test1_pechenki.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly test1_pechenki.Data.test1_pechenkiContext _context;

        public EditModel(test1_pechenki.Data.test1_pechenkiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = await _context.Users.FindAsync(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int id)
        {
            var UserToUpdate = await _context.Users.FindAsync(id);

            if (UserToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<User>(
                UserToUpdate,
                "user",
                u => u.FirstMidName, u => u.LastName, u => u.Email, u => u.Password))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
