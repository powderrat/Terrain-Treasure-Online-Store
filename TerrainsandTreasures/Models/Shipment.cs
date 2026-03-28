using System.ComponentModel.DataAnnotations;

namespace Terrains_Treasures.Models
{
    public class Shipment
    {
        [Key]
        [Required]
        public int ShipmentId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order ?Order { get; set; }

        public string ?Status { get; set; }

        public DateTime ?ShipmentDate { get; set; }
        public string ?Carrier { get; set; }

        public string ?TrackingNumber { get; set; }
    }
}
