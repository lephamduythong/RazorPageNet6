using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebSampleNet6.DataAccess.Data;
using WebSampleNet6.DataAccess.Repository.IRepository;

#nullable disable

namespace WebSampleNet6.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _db;
        private DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            /// IMPORTANT !!!
            this.dbSet = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return dbSet.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void Add(T entity)
        {
            _db.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _db.AddRange(entities);
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }
    }
}
