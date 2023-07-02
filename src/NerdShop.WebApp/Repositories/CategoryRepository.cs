using NerdShop.WebApp.Context;
using NerdShop.WebApp.Models;
using NerdShop.WebApp.Repositories.Interfaces;

namespace NerdShop.WebApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NerdShopDbContext _nerdShopDbContext;

        public CategoryRepository(NerdShopDbContext nerdShopDbContext)
        {
            _nerdShopDbContext = nerdShopDbContext;
        }

        public IEnumerable<Category> Categories => _nerdShopDbContext.Categories;
    }
}
