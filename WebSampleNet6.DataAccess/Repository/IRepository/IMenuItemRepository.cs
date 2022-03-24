using WebSampleNet6.Models;

namespace WebSampleNet6.DataAccess.Repository.IRepository
{
    public interface IMenuItemRepository : IRepository<FoodType>
    {
        void Update(MenuItem menuItem);
    }
}
