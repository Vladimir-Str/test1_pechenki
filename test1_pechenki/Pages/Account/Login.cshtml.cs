using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using test1_pechenki.Data;
using test1_pechenki.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.ComponentModel.DataAnnotations;

namespace test1_pechenki.Pages.Account
{
    public class AccountModel : PageModel
    {
        private readonly test1_pechenki.Data.test1_pechenkiContext _context;

        public AccountModel(test1_pechenki.Data.test1_pechenkiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public  IActionResult OnGet()
        {
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(string Email, string Password)
        {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email && u.Password == Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToPage("/Balance/Index");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return Page();
        }

        private async Task Authenticate(User user)
        {
            string role;

            if (user.IsAdmin)
            { role = "admin"; }
            else role = "user";
                

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

    }
}
