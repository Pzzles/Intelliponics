using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;

namespace Intelliponics.Repositories.Interfaces
{
    public interface IPaymentRepository : IBaseRepository<Payment>
    {
        Task<Payment> GetPaymentByCustomerIdAsync(int custid);
    }

}
