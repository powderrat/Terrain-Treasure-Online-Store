using System.ComponentModel.DataAnnotations;

namespace Terrains_Treasures.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public int PaymentId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order ?Order { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public string ?Status { get; set; }
    }
}
