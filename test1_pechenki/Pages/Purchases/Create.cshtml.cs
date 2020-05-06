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

namespace test1_pechenki.Pages.Purchases
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
        ViewData["UserID"] = new SelectList(_context.Users, "UserID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Purchase Purchase { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Purchases.Add(Purchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
