using Microsoft.AspNetCore.Mvc;
using NerdShop.WebApp.Models;
using NerdShop.WebApp.Repositories.Interfaces;

namespace NerdShop.WebApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var totalItemsOrdered = 0;
            var totalOrderPrice = 0.0m;

            List<ShoppingCartItem> items = _shoppingCart.GetItemInShoppingCart();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio, que tal incluir um produto...");
            }

            foreach (var item in items)
            {
                totalItemsOrdered += item.Quantity;
                totalOrderPrice += (item.Product.Price * item.Quantity);
            }

            order.TotalOrderItems = totalItemsOrdered;
            order.TotalOrder = totalOrderPrice;

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);

                ViewBag.CheckoutCompleteMenssage = "Obrigado pelo seu pedido :)";
                ViewBag.TotalOrder = _shoppingCart.GetTotalShoppingCart();

                _shoppingCart.ClearCart();

                return View("~/Views/Order/CheckoutComplete.cshtml", order);
            }

            return View();
        }
    }
}
