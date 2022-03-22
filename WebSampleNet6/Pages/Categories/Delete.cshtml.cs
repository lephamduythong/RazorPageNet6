using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category? Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Category = await _db.Categories.FindAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category != null)
            {
                _db.Categories.Remove(Category);
            }
            await _db.SaveChangesAsync();
            TempData[Constants.NOTIFICATION] = "Success;Category was deleted successfully";
            return RedirectToPage("Index");
        }
    }
}
