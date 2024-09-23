using JobPortal.Data;
using JobPortal.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobPortal.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected JobPortalDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(JobPortalDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }
        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity; // Return the added entity
            }
            catch (Exception ex)
            {
                // Handle the exception here, such as logging or throwing a custom exception
                // For demonstration purposes, rethrowing the exception
                // throw new Exception("An error occurred while saving the entity.", ex.InnerException);

                throw ex;
            }
        }
        public async Task<IEnumerable<T>> CreateAsync(IEnumerable<T> entity)
        {
            try
            {
                await _dbSet.AddRangeAsync(entity);
                await _context.SaveChangesAsync();
                return entity; // Return the added entity
            }
            catch (Exception)
            {
                // Handle the exception here, such as logging or throwing a custom exception
                // For demonstration purposes, rethrowing the exception
                // throw new Exception("An error occurred while saving the entity.", ex.InnerException);

                throw; // Re-throw the original exception to preserve the stack trace
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            if (entity != null)
            {
                try
                {
                    _dbSet.Remove(entity);
                    int affectedRows = await _context.SaveChangesAsync();
                    return affectedRows > 0; // Return true if at least one row is affected
                }
                catch (Exception ex)
                {
                    // Handle the exception here, such as logging or throwing a custom exception
                    // For demonstration purposes, rethrowing the exception
                    throw new Exception("An error occurred while deleting the entity.", ex);
                }
            }
            return false; // Return false if the entity is null
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }
        public async Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }
        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Update(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while saving the entity.", ex);
            }
        }

        public async Task<T> GetByIdAsync(long Id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(Id);
                //if (entity == null)
                //{
                //    // Throw custom exception indicating entity not found with specific ID
                //    throw new Exception($"Entity with ID {Id} not found.");
                //}

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
