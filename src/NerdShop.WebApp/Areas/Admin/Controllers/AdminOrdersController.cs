using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NerdShop.WebApp.Context;
using NerdShop.WebApp.Models;
using ReflectionIT.Mvc.Paging;

namespace NerdShop.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly NerdShopDbContext _nerdShopDbContext;

        public AdminOrdersController(NerdShopDbContext nerdShopDbContext)
        {
            _nerdShopDbContext = nerdShopDbContext;
        }

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Name")
        {
            var result = _nerdShopDbContext.Orders.AsNoTracking().AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(filter)) 
            {
                result = result.Where(o => o.Name.Contains(filter));
            }

            var model = await PagingList.CreateAsync(result, 5, pageindex, sort, "Name");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _nerdShopDbContext.Orders == null)
            {
                return NotFound();
            }

            var order = await _nerdShopDbContext.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,Name,LastName,Address,Complement,PostCode,State,City,PhoneNumber,Email,OrderSent,OrderDeliveredAt")] Order order)
        {
            if (ModelState.IsValid)
            {
                _nerdShopDbContext.Add(order);
                await _nerdShopDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _nerdShopDbContext.Orders == null)
            {
                return NotFound();
            }

            var order = await _nerdShopDbContext.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Name,LastName,Address,Complement,PostCode,State,City,PhoneNumber,Email,OrderSent,OrderDeliveredAt")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _nerdShopDbContext.Update(order);
                    await _nerdShopDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _nerdShopDbContext.Orders == null)
            {
                return NotFound();
            }

            var order = await _nerdShopDbContext.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_nerdShopDbContext.Orders == null)
            {
                return Problem("A entidade 'Pedido' é nula.");
            }
            var order = await _nerdShopDbContext.Orders.FindAsync(id);
            if (order != null)
            {
                _nerdShopDbContext.Orders.Remove(order);
            }
            
            await _nerdShopDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return _nerdShopDbContext.Orders.Any(e => e.OrderId == id);
        }
    }
}
