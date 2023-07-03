using Microsoft.AspNetCore.Mvc;
using NerdShop.WebApp.Models;
using NerdShop.WebApp.ViewModels;

namespace NerdShop.WebApp.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetItemInShoppingCart();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                TotalShoppingCart = _shoppingCart.GetTotalShoppingCart(),
            };

            return View(shoppingCartViewModel);
        }
    }
}
