using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebSampleNet6.DataAccess.Repository.IRepository;
using WebSampleNet6.Models;

namespace WebSampleNet6.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public Category? Category { get; set; }

        public EditModel(IUnitOfWork db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int id)
        {
            Category = _db.CategoryRepository.GetFirstOrDefault(category => category.Id == id);
            return Page();
        }
        
        public async Task<IActionResult> OnPost()
        {
            if (Category != null)
            {
                _db.CategoryRepository.Update(Category);
                _db.Save();
                TempData[Constants.NOTIFICATION] = "Success;Category was editted successfully";
            }
            return RedirectToPage("Index");
        }
    }
}
