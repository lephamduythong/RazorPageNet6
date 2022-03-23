using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public FoodType? FoodType { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            FoodType = await _db.FoodTypes.FindAsync(id);
            return Page();
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (FoodType != null)
            {
                _db.FoodTypes.Update(FoodType);
                await _db.SaveChangesAsync();
                TempData[Constants.NOTIFICATION] = "Success;FoodType was editted successfully";
            }
            return RedirectToPage("Index");
        }
    }
}
