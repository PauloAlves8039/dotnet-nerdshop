using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> FavoriteProducts { get; set; }
    }
}
