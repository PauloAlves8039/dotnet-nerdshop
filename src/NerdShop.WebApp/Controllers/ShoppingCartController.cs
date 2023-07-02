using Microsoft.AspNetCore.Mvc;
using NerdShop.WebApp.Models;
using NerdShop.WebApp.Repositories.Interfaces;
using NerdShop.WebApp.ViewModels;

namespace NerdShop.WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
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

        public IActionResult AddItemToShoppingCart(int productId) 
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(x => x.ProductId == productId);

            if (selectedProduct != null) 
            {
                _shoppingCart.AddToCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemFromShoppingCart(int productId) 
        {
            var selectedProduct = _productRepository.Products.FirstOrDefault(x => x.ProductId == productId);

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }
    }
}
