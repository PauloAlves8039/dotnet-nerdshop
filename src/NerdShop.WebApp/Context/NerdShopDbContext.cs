using Microsoft.EntityFrameworkCore;
using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.Context
{
    public class NerdShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public NerdShopDbContext(DbContextOptions<NerdShopDbContext> options) : base(options) { }

    }
}
