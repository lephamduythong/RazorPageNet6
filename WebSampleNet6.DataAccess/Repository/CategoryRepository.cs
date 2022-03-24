using Microsoft.EntityFrameworkCore;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.DataAccess.Repository.IRepository;
using WebSampleNet6.Models;

#nullable disable

namespace WebSampleNet6.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {

        }

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(c => c.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
