using NerdShop.WebApp.Models;
using NerdShop.WebApp.Services.Promotions;

namespace NerdShop.WebApp.Services
{
    public class Promotion : IPromotion
    {
        public decimal TakeTwoPayOne(bool favorite)
        {
            var product = new Product();
            var total = product.Price;

            var percentage = 50.00m;
            decimal result = 0;

            var getFavoriteProduct = favorite;

            if (getFavoriteProduct == true)
            {
                result = total - (percentage * total);
            }

            return result;
        }

        public decimal PayThreeForTen(bool favorite, int quantity)
        {
            var product = new Product();
            var priceProduct = product.Price;
            var getFavoriteProduct = favorite;

            var shoppingCartItem = new ShoppingCartItem();
            var productQuantity = shoppingCartItem.Quantity;

            if (productQuantity == 3 || getFavoriteProduct == true) 
            {
                priceProduct = 10.00m;
            }          
            return priceProduct;
        }
    }
}
