using System.ComponentModel.DataAnnotations;

namespace WebSampleNet6.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; }
        
        [Display(Name = "Display Order")]
        [Range(0, double.MaxValue)]
        public int DisplayOrder { get; set; }
    }
}
