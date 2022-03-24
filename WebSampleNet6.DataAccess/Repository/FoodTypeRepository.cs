using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.Models;

namespace WebSampleNet6.DataAccess.Repository.IRepository
{
    public class FoodTypeRepository : Repository<FoodType>, IFoodTypeRepository
    {
        public FoodTypeRepository(ApplicationDbContext db) : base(db)
        {

        }

        public void Update(FoodType category)
        {
            _db.Update(category);
        }
    }
}
