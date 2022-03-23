using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //[BindProperty]
        public FoodType? FoodType { get; set; }

        public CreateModel(ApplicationDbContext db)
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
                await _db.AddAsync(FoodType);
                _db.SaveChanges();
                TempData[Constants.NOTIFICATION] = "Success;Category was created successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
