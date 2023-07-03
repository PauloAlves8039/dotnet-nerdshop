using Microsoft.AspNetCore.Mvc;
using NerdShop.WebApp.Models;
using NerdShop.WebApp.Repositories.Interfaces;
using NerdShop.WebApp.ViewModels;

namespace NerdShop.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult List(string category)
        {
            IEnumerable<Product> products;
            var currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.Products.OrderBy(p => p.ProductId);
                currentCategory = "Todos os produtos";
            }
            else 
            {
                products = _productRepository.Products.Where(p => p.Category.CategoryName.Equals(category)).OrderBy(c => c.Name);

                currentCategory = category;
            }

            var productListViewModel = new ProductListViewModel 
            {
                Products = products,
                CurrentCategory = currentCategory
            };

            return View(productListViewModel);
        }

        public IActionResult Details(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }
    }
}
