using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using test1_pechenki.Data;
using test1_pechenki.Models;
using Microsoft.AspNetCore.Authorization;

namespace test1_pechenki.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly test1_pechenki.Data.test1_pechenkiContext _context;

        public IndexModel(test1_pechenki.Data.test1_pechenkiContext context)
        {
            _context = context;
        }

        public IList<User> Users { get;set; }

        public static decimal PurchasesSum;

        public async Task OnGetAsync()
        {
             Users = await _context.Users
                 .Include(s => s.Payments)
                 .Include(e => e.Purchases)
                 .AsNoTracking()
                 .ToListAsync();

            PurchasesSum = await _context.Purchases.SumAsync(p => p.PurchaseSum);
        }
    }
}
