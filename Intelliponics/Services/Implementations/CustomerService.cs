using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;
using Intelliponics.Services.Interfaces;

namespace Intelliponics.Services.Implementations
{
    public class CustomerService : ICustomerService, IBaseService<Customer>
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<bool> CreateAsync(Customer entity)
        {
            try
            {
               return await _customerRepo.AddAsync(entity);
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _customerRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepo.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepo.GetByIdAsync(id);
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            return await _customerRepo.GetCustomerByEmailAsync(email);
        }

        public async Task<bool> UpdateAsync(int id, Customer entity)
        {
            return await _customerRepo.UpdateAsync(id, entity);
        }
    }
}
