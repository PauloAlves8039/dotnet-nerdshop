using Microsoft.EntityFrameworkCore;
using NerdShop.WebApp.Context;
using NerdShop.WebApp.Models;
using NerdShop.WebApp.Repositories.Interfaces;

namespace NerdShop.WebApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NerdShopDbContext _nerdShopDbContext;

        public ProductRepository(NerdShopDbContext nerdShopDbContext)
        {
            _nerdShopDbContext = nerdShopDbContext;
        }

        public IEnumerable<Product> Products => _nerdShopDbContext.Products.Include(c => c.Category);

        public IEnumerable<Product> FavoriteProducts => _nerdShopDbContext.Products.
                                    Where(p => p.IsFavoriteProduct).
                                    Include(c => c.Category);

        public Product GetProductById(int productId)
        {
            return _nerdShopDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
