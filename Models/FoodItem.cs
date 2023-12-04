using System.ComponentModel.DataAnnotations;

namespace Kuchta_Ethan_FinalProjectCp.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public bool InStock { get; set; }

    }
}
