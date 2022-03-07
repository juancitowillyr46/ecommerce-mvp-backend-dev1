using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)      
        {
            // configures one-to-many relationship
            // modelBuilder.Entity<Product>()
            // .HasOne<Category>(p => p.Category)
            // .WithMany(b => b.Products)
            // .HasForeignKey(p => p.CategoryId);
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Customer> Customers {get; set;}

        /* Models Shopping Cart */
        public DbSet<ShoppingCart> ShoppingCarts {get; set;}
        public DbSet<ShoppingCartItem> ShoppingCartsItems {get; set;}

        /* Model Order */
        public DbSet<Order> Orders { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        
    }
}