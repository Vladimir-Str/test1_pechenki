using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test1_pechenki.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int UserID { get; set; }

        [Required]
        [Display(Name = "Сумма покупки")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PurchaseSum { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата покупки")]
        public DateTime PurchaseDate { get; set; }
        [Display(Name = "Сотрудник")]
        public virtual User User { get; set; }

    }
}
