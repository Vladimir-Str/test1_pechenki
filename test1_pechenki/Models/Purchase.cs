using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1_pechenki.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int UserID { get; set; }
        public float PurchaseSum { get; set; }
        public DateTime PurchaseDate { get; set; }
        public User User { get; set; }

    }
}
