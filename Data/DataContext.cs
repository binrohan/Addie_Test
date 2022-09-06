using Addie.Models;
using Microsoft.EntityFrameworkCore;

namespace Addie.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetails> SalesDetails { get; set; }
        public DbSet<User> Users { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base.OnModelCreating(builder);

            builder.Entity<User>().HasData
            (
                new User()
                {
                    Id = 1,
                    Password = "admin123",
                    Username = "admin"
                }
            );

            base.OnModelCreating(builder);
        }
    }
}