using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public Category? Category { get; set; }

        public EditModel(ApplicationDbContext db)
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
            _db.Categories.Update(Category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
