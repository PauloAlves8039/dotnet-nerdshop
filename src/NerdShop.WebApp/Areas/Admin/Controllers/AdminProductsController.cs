using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NerdShop.WebApp.Context;
using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminProductsController : Controller
    {
        private readonly NerdShopDbContext _nerdShopDbContext;

        public AdminProductsController(NerdShopDbContext nerdShopDbContext)
        {
            _nerdShopDbContext = nerdShopDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var nerdShopDbContext = _nerdShopDbContext.Products.Include(p => p.Category);
            return View(await nerdShopDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _nerdShopDbContext.Products == null)
            {
                return NotFound();
            }

            var product = await _nerdShopDbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_nerdShopDbContext.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Description,Price,ImageUrl,IsFavoriteProduct,InStock,CategoryId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _nerdShopDbContext.Add(product);
                await _nerdShopDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_nerdShopDbContext.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _nerdShopDbContext.Products == null)
            {
                return NotFound();
            }

            var product = await _nerdShopDbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_nerdShopDbContext.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Description,Price,ImageUrl,IsFavoriteProduct,InStock,CategoryId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _nerdShopDbContext.Update(product);
                    await _nerdShopDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_nerdShopDbContext.Categories, "CategoryId", "CategoryName", product.CategoryId);
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _nerdShopDbContext.Products == null)
            {
                return NotFound();
            }

            var product = await _nerdShopDbContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_nerdShopDbContext.Products == null)
            {
                return Problem("A entidade 'Produto' é nula.");
            }
            var product = await _nerdShopDbContext.Products.FindAsync(id);
            if (product != null)
            {
                _nerdShopDbContext.Products.Remove(product);
            }
            
            await _nerdShopDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _nerdShopDbContext.Products.Any(e => e.ProductId == id);
        }
    }
}
