using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1_pechenki.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public double Balance { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
