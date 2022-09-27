using Microsoft.AspNetCore.Mvc;

namespace sales_system_example.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
