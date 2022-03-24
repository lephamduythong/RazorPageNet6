using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.DataAccess.Repository.IRepository;

#nullable disable

namespace WebSampleNet6.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICategoryRepository CategoryRepository { get; private set; }

        public IFoodTypeRepository FoodTypeRepository { get; private set; }
        public IMenuItemRepository MenuItemRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            FoodTypeRepository = new FoodTypeRepository(_db);
            MenuItemRepository = new MenuItemRepository(_db);
        }
         
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
