using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using test1_pechenki.Data;
using test1_pechenki.Models;
using Microsoft.AspNetCore.Authorization;

namespace test1_pechenki.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly test1_pechenki.Data.test1_pechenkiContext _context;

        public CreateModel(test1_pechenki.Data.test1_pechenkiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            var emptyUser = new User();

            if (await TryUpdateModelAsync<User>(
                emptyUser,
                "user",   // Prefix for form value.
                u => u.FirstMidName, u => u.LastName))
            {
                _context.Users.Add(emptyUser);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
