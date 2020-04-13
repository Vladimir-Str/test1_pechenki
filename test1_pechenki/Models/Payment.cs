using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1_pechenki.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int UserID { get; set; }
        public float PaymentSum { get; set; }
        public DateTime PaymentDate { get; set; }

        public User User { get; set; }
    }
}
