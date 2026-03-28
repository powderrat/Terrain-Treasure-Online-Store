using Microsoft.AspNetCore.Mvc;

namespace Terrains_Treasures.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inventory()
        {
            return View();
        }

        public IActionResult Products() 
        { 
            return View(); 
        }
    }
}
