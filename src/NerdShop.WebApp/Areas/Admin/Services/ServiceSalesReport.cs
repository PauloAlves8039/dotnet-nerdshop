using Microsoft.EntityFrameworkCore;
using NerdShop.WebApp.Context;
using NerdShop.WebApp.Models;

namespace NerdShop.WebApp.Areas.Admin.Services
{
    public class ServiceSalesReport
    {
        private readonly NerdShopDbContext _nerdShopDbContext;

        public ServiceSalesReport(NerdShopDbContext nerdShopDbContext)
        {
            _nerdShopDbContext = nerdShopDbContext;
        }

        public async Task<List<Order>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _nerdShopDbContext.Orders select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.OrderSent >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.OrderSent <= maxDate.Value);
            }

            return await result
                         .Include(o => o.OrderItems)
                         .ThenInclude(p => p.Product)
                         .OrderByDescending(x => x.OrderSent)
                         .ToListAsync();
        }
    }
}
