using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using test1_pechenki.Pages.Users;

namespace test1_pechenki.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Фамилия не более 50 символов.")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Имя отчество не более 50 символов.")]
        [Display(Name = "Имя Отчетсво")]
        public string FirstMidName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Администратор")]
        public bool IsAdmin { get; set; }

  


        public ICollection<Payment> Payments { get; set; }
        public  ICollection<Purchase> Purchases { get; set; }

        [Display(Name = "Баланс")]
        public decimal Balance
        {
            get
            {
                
                if (Payments != null && Purchases != null)
                    return Payments.Sum(payment => payment.PaymentSum) + Purchases.Sum(purchase => purchase.PurchaseSum)- IndexModel.PurchasesSum;
                return IndexModel.PurchasesSum;
            }

        }
    }
}
