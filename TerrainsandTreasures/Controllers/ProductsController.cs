using Microsoft.AspNetCore.Mvc;
using Terrains_Treasures.Models;
using Terrains_Treasures.ViewModels;

namespace Terrains_Treasures.Controllers
{
    public class ProductsController : Controller
    {
        private readonly T_TContext _context;

        public ProductsController(T_TContext context) => _context = context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _context.Products.ToList();
            return Json(products);
        }

        [HttpGet]
        public IActionResult Details(int id)
        { // Get the product details, images, and inventory quantity
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            var images = _context.ProductImages
                .Where(pi => pi.ProductId == id)
                .OrderBy(pi => pi.sortOrder).ToList();

            var quantity = _context.Inventories
                .Where(i => i.ProductId == id)
                .Sum(i => i.QuantityInStock);

            var viewModel = new ProductDetailsViewModel
            {
                Product = product,
                Images = images,
                QuantityInStock = quantity
            };
            return View(viewModel);
        }
    }
}
