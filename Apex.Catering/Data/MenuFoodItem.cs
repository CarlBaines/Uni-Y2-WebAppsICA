using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Apex.Catering.Data
{
    public class MenuFoodItem
    {
        [Required]
        public int MenuId { get; set; }
        [Required]
        public int FoodItemId { get; set; }
    }
}
