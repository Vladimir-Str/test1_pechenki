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

namespace test1_pechenki.Pages.Payments
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
        public Payment Payment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payment = await _context.Payments
                .Include(p => p.User).FirstOrDefaultAsync(m => m.PaymentID == id);

            if (Payment == null)
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

            Payment = await _context.Payments.FindAsync(id);

            if (Payment != null)
            {
                _context.Payments.Remove(Payment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
