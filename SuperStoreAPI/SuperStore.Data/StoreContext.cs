using Microsoft.EntityFrameworkCore;
using SuperStore.Data.Models;

namespace SuperStore.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {

        }

        public DbSet<Example> Examples { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(b => b.Date).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Order>().Property(b => b.OrderNumber).ValueGeneratedOnAdd();
        }
    }
}