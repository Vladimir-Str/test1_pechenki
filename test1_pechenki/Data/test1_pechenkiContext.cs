using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test1_pechenki.Models;

namespace test1_pechenki.Data
{
    public class test1_pechenkiContext : DbContext
    {
        public test1_pechenkiContext(DbContextOptions<test1_pechenkiContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<Purchase>().ToTable("Purchase");
            modelBuilder.Entity<User>().ToTable("User");
        }

    }

    
}
