using System.ComponentModel.DataAnnotations;

namespace Terrains_Treasures.Models
{
    public class Inventory
    {
        [Key]
        [Required]
        public int InventoryId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int QuantityInStock { get; set; }
        
    }
}
