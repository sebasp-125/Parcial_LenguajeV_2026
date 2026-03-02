using Microsoft.EntityFrameworkCore;

namespace Api_Shoes_v1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Woker> Wokers { get; set; }
        public DbSet<Customer> Customers { get; set; }


    }
}