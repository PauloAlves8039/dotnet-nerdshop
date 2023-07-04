using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NerdShop.WebApp.Context;
using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCategoriesController : Controller
    {
        private readonly NerdShopDbContext _nerdShopDbContext;

        public AdminCategoriesController(NerdShopDbContext nerdShopDbContext)
        {
            _nerdShopDbContext = nerdShopDbContext;
        }

        public async Task<IActionResult> Index()
        {
              return View(await _nerdShopDbContext.Categories.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _nerdShopDbContext.Categories == null)
            {
                return NotFound();
            }

            var category = await _nerdShopDbContext.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _nerdShopDbContext.Add(category);
                await _nerdShopDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _nerdShopDbContext.Categories == null)
            {
                return NotFound();
            }

            var category = await _nerdShopDbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _nerdShopDbContext.Update(category);
                    await _nerdShopDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _nerdShopDbContext.Categories == null)
            {
                return NotFound();
            }

            var category = await _nerdShopDbContext.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_nerdShopDbContext.Categories == null)
            {
                return Problem("A entidade 'Categoria' é nula.");
            }
            var category = await _nerdShopDbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _nerdShopDbContext.Categories.Remove(category);
            }
            
            await _nerdShopDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
          return _nerdShopDbContext.Categories.Any(e => e.CategoryId == id);
        }
    }
}
