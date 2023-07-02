using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> FavoriteProducts { get; }
        Product GetProductById(int productId);
    }
}
