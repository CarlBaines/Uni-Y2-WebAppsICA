using System.ComponentModel.DataAnnotations;

namespace Apex.Catering.Data
{
    public class FoodItem
    {
        [Required]
        public int FoodItemId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ItemName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double UnitPrice { get; set; }
    }
}
