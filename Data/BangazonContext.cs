using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

/*
Author: Jammy Laird, Elliott Williams, Liz Sanger, David Yunker, Fletcher Watson
*/

namespace Bangazon.Data
{
    //The BangazonContext class is the middle man that defines what entity framework will be working with the database. It inherits from DbContext, which represents a session with the databse
    public class BangazonContext : DbContext
    {
        //Method: The BangazonContext() is a constructor function that accepts an argument of type DbContextOptions<BangazonContext>, which is passed to the parent class.
        public BangazonContext(DbContextOptions<BangazonContext> options)
            : base(options)
        { }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<LineItem> LineItem { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }

        //Method: OnModelCreating() accepts one argument of type ModelBuilder and specifies exactly what properties will be included on each model as its table is created in the db.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<Order>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<Product>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");

            modelBuilder.Entity<PaymentType>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("strftime('%Y-%m-%d %H:%M:%S')");
        }
    }
}