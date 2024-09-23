using System.Linq.Expressions;

namespace JobPortal.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task<IEnumerable<T>> CreateAsync(IEnumerable<T> entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
