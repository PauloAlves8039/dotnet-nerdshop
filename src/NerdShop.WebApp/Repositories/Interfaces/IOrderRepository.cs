using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
