using Microsoft.EntityFrameworkCore;
using Sovos.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Sovos.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // customers
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(c => c.Id);
            builder.Entity<Customer>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(c => c.Name).IsRequired();
            builder.Entity<Customer>().Property(c => c.Email).IsRequired();

            builder.Entity<Customer>().HasData
             (
                new Customer { Id = 100, Name = "Royal Philips", Email = "Royal@email.com" },
                new Customer { Id = 101, Name = "Sun Chemical", Email = "Sun@email.com" },
                new Customer { Id = 102, Name = "Brown-Forman", Email = "Brown@email.com" }
             );


            // order
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Order>().HasKey(x => x.Id);
            builder.Entity<Order>().Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(x => x.Description).IsRequired();
            builder.Entity<Order>().Property(x => x.CreateDate).IsRequired();
            
            // customers x orders
            builder.Entity<Order>()
               .HasOne<Customer>(x => x.Customer)
               .WithMany(y => y.Orders)
               .HasForeignKey(z => z.CustomerId);


            builder.Entity<OrderItem>().ToTable("OrderItems");
            builder.Entity<OrderItem>().HasKey(x => new { x.OrderId, x.ItemId });

            builder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany(y => y.OrderItems)
                .HasForeignKey(z => z.OrderId);

            builder.Entity<OrderItem>()
                .HasOne(x => x.Item)
                .WithMany(y => y.OrderItems)
                .HasForeignKey(z => z.ItemId);

            //itemsB
            builder.Entity<Item>().ToTable("Items");
            builder.Entity<Item>().HasKey(i => i.Id);
            builder.Entity<Item>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();

        }

    }


}
