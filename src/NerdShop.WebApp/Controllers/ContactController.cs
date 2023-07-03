using Microsoft.AspNetCore.Mvc;

namespace NerdShop.WebApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
