
using Intelliponics.Models;

namespace Intelliponics.Services.Interfaces
{
    public interface IAdminService
    {
        Task<HashSet<User>> FetchAdminEmployeesAsync();
        Task<User> FetchAdminEmployeeByIdAsync(int id);
        Task AddAdminEmployeeAsync(User employee);
        Task UpdateAdminEmployeeAsync(User employee);
        Task DeleteAdminEmployeeAsync(int id);
    }
}
