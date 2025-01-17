using Intelliponics.Models;

namespace Intelliponics.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<HashSet<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
