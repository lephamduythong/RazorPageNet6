using System.ComponentModel.DataAnnotations;

namespace WebSampleNet6.Models
{
    public class FoodType
    {
        public int Id { get; set; } 
        [Required]
        [Display(Name = "Food Type")]
        public string? Name { get; set; }
    }
}
