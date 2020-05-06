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

namespace test1_pechenki.Pages.Purchases
{
    [Authorize(Roles = "admin")]
    public class DeleteModel : PageModel
    {
        private readonly test1_pechenki.Data.test1_pechenkiContext _context;

        public DeleteModel(test1_pechenki.Data.test1_pechenkiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Purchase Purchase { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Purchase = await _context.Purchases
                .Include(p => p.User).FirstOrDefaultAsync(m => m.PurchaseID == id);

            if (Purchase == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Purchase = await _context.Purchases.FindAsync(id);

            if (Purchase != null)
            {
                _context.Purchases.Remove(Purchase);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
