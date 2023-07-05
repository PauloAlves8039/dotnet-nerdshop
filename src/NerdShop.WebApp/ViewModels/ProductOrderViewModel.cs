using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.ViewModels
{
    public class ProductOrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
