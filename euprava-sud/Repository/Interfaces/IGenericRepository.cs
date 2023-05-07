using System.Linq.Expressions;

namespace euprava_sud.Repository.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllBy(Expression<Func<T,bool>> lambda);
        Task<T> GetById(Object id);
        Task<T> Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
