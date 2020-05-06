using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test1_pechenki.Data;
using test1_pechenki.Models;
using Microsoft.AspNetCore.Authorization;

namespace test1_pechenki.Pages.Users
{
    [Authorize(Roles = "admin")]
    public class DetailsModel : PageModel
    {
        private readonly test1_pechenki.Data.test1_pechenkiContext _context;

        public DetailsModel(test1_pechenki.Data.test1_pechenkiContext context)
        {
            _context = context;
        }

        public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //User = await _context.Users.FirstOrDefaultAsync(m => m.UserID == id);

            User = await _context.Users
                .Include(s => s.Payments)
                .Include(e => e.Purchases)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.UserID == id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
