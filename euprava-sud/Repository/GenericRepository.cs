using euprava_sud.Data;
using euprava_sud.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace euprava_sud.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public async Task Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _table.AsEnumerable();
        }

        public async Task<IEnumerable<T>> GetAllBy(Expression<Func<T, bool>> lambda)
        {
            return _table.Where(lambda);
        }

        public async Task<T> GetById(object id)
        {
            return _table.Find(id);
        }

        public async Task<T> Insert(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task Update(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
