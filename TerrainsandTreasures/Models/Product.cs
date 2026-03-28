using System.ComponentModel.DataAnnotations;

namespace Terrains_Treasures.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string ImageName { get; set; } = string.Empty;   

        [Required]
        public decimal Price { get; set; }
    }
}
