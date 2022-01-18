using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;

namespace WeatherAPI.DAL
{
    public class GenericRepos<T> : IGenericRepos<T> where T : class
    {
        protected readonly WeatherAPIContext _context;
        protected readonly DbSet<T> DbSet;
        public GenericRepos(WeatherAPIContext context)
        {
            this._context = context;
            this.DbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> getAll()
        {
            IEnumerable<T> items = DbSet.ToList();
            return items;
        }
        public virtual async Task<T> getById(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public virtual async Task<Boolean> insert(T entity)
        {
            await DbSet.AddAsync(entity);
            return true;
        }
        public virtual async Task<Boolean> update(T entity)
        {
            DbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }
        public virtual async Task<Boolean> delete(int id)
        {
            T item = DbSet.Find(id);
            DbSet.Remove(item);
            return true;
        }
    }
}
