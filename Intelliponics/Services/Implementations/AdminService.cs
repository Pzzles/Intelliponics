using Intelliponics.Models;
using Intelliponics.Repositories.Interfaces;
using Intelliponics.Services.Interfaces;

namespace Intelliponics.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly ILogger<AdminService> _logger;

        public AdminService(IAdminRepository adminRepository, ILogger<AdminService> logger)
        {
            _adminRepository = adminRepository;
            _logger = logger;
        }

        public async Task AddAdminEmployeeAsync(User user)
        {
            try
            {
                await _adminRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new user.");
                throw;
            }
        }

        public async Task DeleteAdminEmployeeAsync(int id)
        {
            try
            {
                await _adminRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the user with ID {id}.");
                throw;
            }
        }

        public async Task<User> FetchAdminEmployeeByIdAsync(int id)
        {
            try
            {
                return await _adminRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching the user with ID {id}.");
                throw;
            }
        }

        public async Task<HashSet<User>> FetchAdminEmployeesAsync()
        {
            try
            {
                return await _adminRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all employees.");
                throw;
            }
        }

        public async Task UpdateAdminEmployeeAsync(User user)
        {
            try
            {
                await _adminRepository.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user.");
                throw;
            }
        }
    }
}
