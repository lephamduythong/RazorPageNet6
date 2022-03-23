using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //[BindProperty]
        public Category? Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            Category = new Category();
            _db = db;
        }
        
        public void OnGet()
        {

        }

        //public async Task<IActionResult> OnPostCreate()
        //public async Task<IActionResult> OnPost(Category category)
        public async Task<IActionResult> OnPost()
        {
            if (Category == null)
            {
                return Page();
            }
            
            // Custom validation
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name is never the same as Display Order");
            }

            if (ModelState.IsValid)
            {
                await _db.AddAsync(Category);
                _db.SaveChanges();
                TempData[Constants.NOTIFICATION] = "Success;Category was created successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
