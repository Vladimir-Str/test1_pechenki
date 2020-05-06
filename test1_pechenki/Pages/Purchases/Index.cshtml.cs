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
    public class IndexModel : PageModel
    {
        private readonly test1_pechenki.Data.test1_pechenkiContext _context;

        public IndexModel(test1_pechenki.Data.test1_pechenkiContext context)
        {
            _context = context;
        }

        public IList<Purchase> Purchases { get;set; }

        public async Task OnGetAsync()
        {
            Purchases = await _context.Purchases
                .Include(p => p.User).ToListAsync();
        }
    }
}
