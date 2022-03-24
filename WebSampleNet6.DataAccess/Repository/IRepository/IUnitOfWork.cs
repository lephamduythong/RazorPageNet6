using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSampleNet6.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IFoodTypeRepository FoodTypeRepository { get; }
        IMenuItemRepository MenuItemRepository { get; }
        
        void Save();
    }
}
