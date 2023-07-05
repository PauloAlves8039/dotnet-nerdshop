﻿using Microsoft.AspNetCore.Mvc;
using NerdShop.WebApp.Areas.Admin.Services;

namespace NerdShop.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSalesReportController : Controller
    {
        private readonly ServiceSalesReport _serviceSalesReport;

        public AdminSalesReportController(ServiceSalesReport serviceSalesReport)
        {
            _serviceSalesReport = serviceSalesReport;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSalesReport(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _serviceSalesReport.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
    }
}
