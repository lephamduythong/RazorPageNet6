using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.DataAccess.Repository.IRepository;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public IEnumerable<FoodType>? FoodTypes { get; set; }

        public IndexModel(IUnitOfWork db)
        {
            _db = db;
        }

        public void OnGet()
        {
            FoodTypes = _db.FoodTypeRepository.GetAll();
        }
    }
}
