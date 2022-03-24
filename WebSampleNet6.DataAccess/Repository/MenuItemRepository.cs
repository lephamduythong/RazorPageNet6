using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.DataAccess.Repository.IRepository
{
    public class MenuItemRepository : Repository<FoodType>, IMenuItemRepository
    {
        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {

        }

        public void Update(MenuItem menuItem)
        {
            _db.Update(menuItem);
        }
    }
}
