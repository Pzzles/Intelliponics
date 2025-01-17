using Intelliponics.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Intelliponics.Services.Interfaces
{
    public interface IPaymentService : IBaseService<Payment>
    {
        Task<Payment> GetPaymentByCustomerIDAsync(int custid);
    }
}
