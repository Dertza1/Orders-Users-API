using Microsoft.EntityFrameworkCore;

namespace ShoppingCenter.Database
{
    public class ShopContext : DbContext
    {
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderComposition> Compositions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }

        public ShopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ShopDB.db");
        }
    }
}
