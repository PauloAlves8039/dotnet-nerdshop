using Microsoft.AspNetCore.Mvc;
using NerdShop.WebApp.Repositories.Interfaces;

namespace NerdShop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult List()
        {
            var products = _productRepository.Products;
            return View(products);
        }
    }
}
