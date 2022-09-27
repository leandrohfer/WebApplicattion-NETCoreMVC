using Microsoft.AspNetCore.Mvc;
using sales_system_example.Data;
using sales_system_example.Services;

namespace sales_system_example.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController (SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var listSellers = _sellerService.FindAll();

            return View(listSellers);
        }
    }
}
