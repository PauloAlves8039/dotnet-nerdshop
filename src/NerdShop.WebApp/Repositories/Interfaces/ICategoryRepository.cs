using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
