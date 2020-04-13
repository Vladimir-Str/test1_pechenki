using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using test1_pechenki.Data;
using test1_pechenki.Models;

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

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
