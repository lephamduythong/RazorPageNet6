using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.DataAccess.Repository.IRepository;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;

        //[BindProperty]
        public FoodType? FoodType { get; set; }

        public CreateModel(IUnitOfWork db)
        {
            FoodType = new FoodType();
            _db = db;
        }
        
        public void OnGet()
        {

        }

        //public async Task<IActionResult> OnPostCreate()
        //public async Task<IActionResult> OnPost(Category category)
        public async Task<IActionResult> OnPost()
        {
            if (FoodType == null)
            {
                return Page();
            }

            if (ModelState.IsValid)
            {
                _db.FoodTypeRepository.Add(FoodType);
                _db.Save();
                TempData[Constants.NOTIFICATION] = "Success;Category was created successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
