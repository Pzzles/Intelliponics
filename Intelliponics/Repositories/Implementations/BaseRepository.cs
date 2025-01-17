using Intelliponics.Data;
using Intelliponics.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intelliponics.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        private readonly ILogger<BaseRepository<T>> _logger;


        public BaseRepository(AppDbContext context, ILogger<BaseRepository<T>> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetByIdAsync)} while fetching entity with ID: {id}");
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetAllAsync)} while fetching all entities.");
                throw;
            }
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(AddAsync)} while adding entity of type {typeof(T).Name}");
                throw;
            }
        }
        public async Task<bool> UpdateAsync(int id, T entity)
        {
            try
            {
                var existingEntity = await GetByIdAsync(id);
                if (existingEntity == null)
                {
                    _logger.LogWarning($"Entity of type {typeof(T).Name} with ID: {id} not found for update.");
                    return false;
                }

                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(UpdateAsync)} while updating entity with ID: {id}");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var existingEntity = await GetByIdAsync(id);
                if (existingEntity == null)
                {
                    _logger.LogWarning($"Entity of type {typeof(T).Name} with ID: {id} not found for update.");
                    throw new Exception($"The entity with ID: {id} does not exist.");
                }

                _dbSet.Remove(existingEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(UpdateAsync)} while updating entity with ID: {id}");
                throw;
            }
        }
    }
}
