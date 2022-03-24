using System.Linq.Expressions;

namespace WebSampleNet6.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
