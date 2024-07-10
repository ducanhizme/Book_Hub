using BookHub.data.Models;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookHub.data
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public AppContext() : base("name=BookHub")
        {
            Database.SetInitializer<AppContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Carts)
                .WithRequired(c => c.User)
                .HasForeignKey(c => c.UserId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithRequired(o => o.User)
                .HasForeignKey(o => o.UserId);
            modelBuilder.Entity<Publisher>()
                .HasMany(p => p.Books)
                .WithRequired(b => b.Publisher)
                .HasForeignKey(b => b.PublisherId);
            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            modelBuilder.Entity<BookCategory>()
                .HasRequired(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            modelBuilder.Entity<BookCategory>()
                .HasRequired(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithRequired(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithRequired(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);
            base.OnModelCreating(modelBuilder);

        }
    }
}
