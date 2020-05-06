using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test1_pechenki.Data;
using test1_pechenki.Models;

namespace test1_pechenki.Data
{
    public static class DbInitializer
    {
        public static void Initialize(test1_pechenkiContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User{FirstMidName = "Владимир Иванович", LastName = "Федоров" , IsAdmin=false},
                new User{FirstMidName = "Иван Иванович", LastName = "Петров",  IsAdmin=true}
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var payments = new Payment[]
            {
                new Payment{UserID=1,PaymentSum = 20.50M, PaymentDate=DateTime.Parse("01.01.2020")},
                new Payment{UserID=2,PaymentSum = 10.20M, PaymentDate=DateTime.Parse("02.02.2020")}
            };
            foreach (Payment p in payments)
            {
                context.Payments.Add(p);
            }
            context.SaveChanges();

            var purchases = new Purchase[]
            {
                new Purchase{UserID=1, PurchaseDate=DateTime.Parse("31.01.2020"),PurchaseSum=50.50M}
            };
            foreach (Purchase pr in purchases)
            {
                context.Purchases.Add(pr);
            }
            context.SaveChanges();
        }
    }
}
