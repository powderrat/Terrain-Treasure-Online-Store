using System.ComponentModel.DataAnnotations;

namespace Terrains_Treasures.Models
{
    public class ProductImage
    {
        [Key]
        [Required]
        public int ProductImageId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public string ImageName { get; set; } = string.Empty;

        [Required]
        public int sortOrder { get; set; }
    }
}
