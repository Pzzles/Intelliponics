using Intelliponics.Data;
using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Intelliponics.Repositories.Implementations
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context, ILogger<CustomerRepository> logger) : base(context, logger) { }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            if(email != null)
            {
                try
                {
                    return await _dbSet.FirstOrDefaultAsync(c => c.Email.Equals(email));
                }
                catch(Exception ex)
                {
                    throw;
                }

            }
          
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetCustomersByCountryAsync(string country)
        {
            return await _dbSet.Where(c => c.Country == country).ToListAsync();
        }

        public async Task<Customer> GetCustomersByEmailAsync(string email)
        {
            if (email == null) 
            {
                // logger.LogWarning("Email is null");
                throw new ArgumentNullException(nameof(email));
            }

            try
            {
                return await _dbSet.FindAsync(email);
            }
            catch (Exception ex) 
            {
             //   logger.LogError(ex, $"Error in {nameof(GetCustomersByEmailAsync)} while fetching entity with email: {email}");
                throw;
            }
        }
    }

}
