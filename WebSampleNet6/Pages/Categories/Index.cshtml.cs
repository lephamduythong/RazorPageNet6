using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Category>? Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
            Categories = _db.Categories.OrderBy(category => category.DisplayOrder);
        }

        public void OnGet()
        {
            
        }
    }
}
