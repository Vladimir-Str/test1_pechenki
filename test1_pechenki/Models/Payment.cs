using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test1_pechenki.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Сумма платежа")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaymentSum { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата платежа")]
        public DateTime PaymentDate { get; set; }
        [Display(Name = "Сотрудник")]
        public virtual User User { get; set; }
    }
}
