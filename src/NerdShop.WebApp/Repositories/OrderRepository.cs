using NerdShop.WebApp.Context;
using NerdShop.WebApp.Models;
using NerdShop.WebApp.Repositories.Interfaces;

namespace NerdShop.WebApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NerdShopDbContext _nerdShopDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(NerdShopDbContext nerdShopDbContext, ShoppingCart shoppingCart)
        {
            _nerdShopDbContext = nerdShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderSent = DateTime.Now;
            _nerdShopDbContext.Orders.Add(order);
            _nerdShopDbContext.SaveChanges();

            var shoppingCartItem = _shoppingCart.ShoppingCartItems;

            foreach (var cartItem in shoppingCartItem) 
            {
                var orderDetail = new OrderDetail() 
                {
                    Quantity = cartItem.Quantity,
                    ProductId = cartItem.Product.ProductId,
                    OrderId = order.OrderId,
                    Price = cartItem.Product.Price
                };

                _nerdShopDbContext.OrderDetails.Add(orderDetail);
            }

            _nerdShopDbContext.SaveChanges();
        }
    }
}
