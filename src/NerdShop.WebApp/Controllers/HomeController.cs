using Microsoft.AspNetCore.Mvc;
using NerdShop.WebApp.Models;
using NerdShop.WebApp.Repositories.Interfaces;
using NerdShop.WebApp.ViewModels;
using System.Diagnostics;

namespace NerdShop.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel 
            {
                FavoriteProducts = _productRepository.FavoriteProducts
            };

            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}