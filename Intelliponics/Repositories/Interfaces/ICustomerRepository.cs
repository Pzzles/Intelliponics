using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;

namespace Intelliponics.Repositories.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetCustomerByEmailAsync(string email);
    }

}
