using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Repository.IRepository;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public FoodType? FoodType { get; set; }

        public EditModel(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            FoodType = _db.FoodTypeRepository.GetFirstOrDefault(foodType => foodType.Id == id);
            return Page();
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (FoodType != null)
            {
                _db.FoodTypeRepository.Update(FoodType);
                _db.Save();
                TempData[Constants.NOTIFICATION] = "Success;FoodType was editted successfully";
            }
            return RedirectToPage("Index");
        }
    }
}
