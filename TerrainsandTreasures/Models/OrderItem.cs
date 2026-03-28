using System.ComponentModel.DataAnnotations;

namespace Terrains_Treasures.Models
{
    public class OrderItem
    {
        [Key]
        [Required]
        public int OrderItemId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
