using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Terrains_Treasures.Models;
using Terrains_Treasures.ViewModels;

namespace Terrains_Treasures.Controllers
{
    public class HomeController : Controller
    {
        private readonly T_TContext _context;

        public HomeController(T_TContext context) => _context = context;


        public IActionResult Index(string? productType)
        { // If a product type is specified, filter products by that type
            var products = _context.Products;

            if(products == null)
            {  
                return NotFound(); 
            }

            return View(products.ToList());
        }

       public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
       
    }
}
