using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<FoodType>? FoodTypes { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
            FoodTypes = _db.FoodTypes;
        }

        public void OnGet()
        {
            
        }
    }
}
