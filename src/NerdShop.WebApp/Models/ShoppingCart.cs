using Microsoft.EntityFrameworkCore;
using NerdShop.WebApp.Context;

namespace NerdShop.WebApp.Models
{
    public class ShoppingCart
    {
        private readonly NerdShopDbContext _nerdShopDbContext;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(NerdShopDbContext nerdShopDbContext)
        {
            _nerdShopDbContext = nerdShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services) 
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<NerdShopDbContext>();

            var cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId,
            };
        }

        public void AddToCart(Product product) 
        {
            var shoppingCartItem = _nerdShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId && 
                s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Quantity = 1
                };

                _nerdShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else 
            {
                shoppingCartItem.Quantity++;
            }

            _nerdShopDbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product) 
        {
            var shoppingCartItem = _nerdShopDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Product.ProductId == product.ProductId &&
                s.ShoppingCartId == ShoppingCartId);

            var localQuantity = 0;

            if (shoppingCartItem != null) 
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localQuantity = shoppingCartItem.Quantity;
                }
                else 
                {
                    _nerdShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _nerdShopDbContext.SaveChanges();
            return localQuantity;
        }

        public List<ShoppingCartItem> GetItemInShoppingCart() 
        {
            return ShoppingCartItems ??
            (ShoppingCartItems =
                       _nerdShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Product)
                           .ToList());
        }

        public void ClearCart() 
        {
            var cartItems = _nerdShopDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _nerdShopDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _nerdShopDbContext.SaveChanges();
        }

        public decimal GetTotalShoppingCart() 
        {
            var total = _nerdShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Quantity).Sum();

            return total;
        }
    }
}
