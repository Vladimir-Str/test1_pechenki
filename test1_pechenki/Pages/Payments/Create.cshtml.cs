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

namespace test1_pechenki.Pages.Payments
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
        public Payment Payment { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPayment = new Payment();

            if (await TryUpdateModelAsync<Payment>(
                emptyPayment,
                "payment",   // Prefix for form value.
                p => p.PaymentSum, p => p.PaymentSum, p => p.UserID))
            {
                _context.Payments.Add(emptyPayment);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
