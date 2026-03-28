using System.ComponentModel.DataAnnotations;
using Terrains_Treasures.Models;

namespace Terrains_Treasures.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int QuantityInStock { get; set; }

        public int SelectedQuantity { get; set; }
        public Product? Product { get; set; }
        
        public List<ProductImage>? Images { get; set; }
    }
}
