using System.ComponentModel.DataAnnotations;

namespace InventoryManagment.Models
{
    public class InventoryModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public ProductType Type { get; set; }
    }
}
