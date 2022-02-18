using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {
            
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
    }
}