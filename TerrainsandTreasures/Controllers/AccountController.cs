using Microsoft.AspNetCore.Mvc;

namespace Terrains_Treasures.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
