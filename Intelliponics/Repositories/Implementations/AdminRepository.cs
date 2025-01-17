using Intelliponics.Data;
using Intelliponics.Models;
using Intelliponics.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intelliponics.Repositories.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AdminRepository> _logger;

        public AdminRepository(AppDbContext context, ILogger<AdminRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<HashSet<User>> GetAllAsync()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return new HashSet<User>((IEnumerable<User>)users);
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                _logger.LogError(ex, "An error occurred while getting all users.");
                throw;
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<User>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while getting the user with ID {id}.");
                throw;
            }
        }

        public async Task AddAsync(User user)
        {
            try
            {
                await _context.Set<User>().AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new user.");
                throw;
            }
        }

        public async Task UpdateAsync(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user.");
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var user = await _context.Set<User>().FindAsync(id);
                if (user != null)
                {
                    _context.Set<User>().Remove(user);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _logger.LogWarning($"Employee with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the user with ID {id}.");
                throw;
            }
        }
    }
}
