using Microsoft.AspNetCore.Mvc;
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

        public IActionResult List()
        {
            var productListViewModel = new ProductListViewModel();
            productListViewModel.Products = _productRepository.Products;
            productListViewModel.CurrentCategory = "Categoria Atual";

            return View(productListViewModel);
        }
    }
}
