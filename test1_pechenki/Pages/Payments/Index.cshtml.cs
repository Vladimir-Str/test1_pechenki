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
    public class IndexModel : PageModel
    {
        private readonly test1_pechenki.Data.test1_pechenkiContext _context;

        public IndexModel(test1_pechenki.Data.test1_pechenkiContext context)
        {
            _context = context;
        }

        public IList<Payment> Payment { get;set; }

        public async Task OnGetAsync()
        {
            Payment = await _context.Payments
                .Include(p => p.User).ToListAsync();
        }
    }
}
