using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using Terrains_Treasures.Models;
using Terrains_Treasures.ViewModels;

namespace Terrains_Treasures.Controllers
{

    public class CartController : Controller
    { //DB context setup
        private readonly T_TContext _context;
        public CartController(T_TContext context) => _context = context;

        private const string CartSessionKey = "CART";

        [HttpGet]
        public IActionResult Index()
        {
            var cart = GetCartFromSession();
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(int productId, int selectedQuantity)
        {

            if (selectedQuantity < 1)
                selectedQuantity = 1;


            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
                return NotFound();

            // Inventory check 
            var inStock = _context.Inventories
                .Where(i => i.ProductId == productId)
                .Select(i => i.QuantityInStock)
                .FirstOrDefault();

            if (selectedQuantity > inStock)
                selectedQuantity = inStock; // clamp 

            var cart = GetCartFromSession();

            // Add or update existing item
            var existing = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (existing == null)
            {
                cart.Items.Add(new CartItemViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.Name,
                    Price = product.Price,
                    Quantity = selectedQuantity,
                    ImageName = product.ImageName 
                });
            }
            else
            {
                // Increase quantity (clamp to stock)
                existing.Quantity = Math.Min(existing.Quantity + selectedQuantity, inStock);
            }

            SaveCartToSession(cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity (int productId, int newQuantity)
        {
            
            if (newQuantity < 1)
                newQuantity = 1;
            var inStock = _context.Inventories
                .Where(i => i.ProductId == productId)
                .Select(i => i.QuantityInStock)
                .FirstOrDefault();

            if (newQuantity > inStock)
                newQuantity = inStock; // clamp 

            var cart = GetCartFromSession();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity = newQuantity;
                SaveCartToSession(cart);
            }
            return RedirectToAction("Index");
        }
         
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            var cart = GetCartFromSession();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
                SaveCartToSession(cart);
            }
            return RedirectToAction("Index");
        }
        // ---------- Session helpers ----------

        private CartViewModel GetCartFromSession()
        {
            var json = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrWhiteSpace(json))
                return new CartViewModel(); // should initialize Items inside the VM

            try
            {
                return JsonSerializer.Deserialize<CartViewModel>(json) ?? new CartViewModel();
            }
            catch
            {
                // If session got corrupted, reset it
                return new CartViewModel();
            }
        }

        private void SaveCartToSession(CartViewModel cart)
        {
            var json = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(CartSessionKey, json);
        }
    }
}