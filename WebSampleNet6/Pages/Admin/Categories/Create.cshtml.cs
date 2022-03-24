using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Repository.IRepository;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;

        //[BindProperty]
        public Category? Category { get; set; }

        public CreateModel(IUnitOfWork db)
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
                _db.CategoryRepository.Add(Category);
                _db.Save();
                TempData[Constants.NOTIFICATION] = "Success;Category was created successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
