using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSampleNet6.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        
        public int FoodTypeId { get; set; }
        public FoodType FoodType { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
