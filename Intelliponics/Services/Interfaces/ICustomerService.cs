using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;

namespace Intelliponics.Services.Interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<Customer> GetCustomerByEmail(string email);
    }
}
