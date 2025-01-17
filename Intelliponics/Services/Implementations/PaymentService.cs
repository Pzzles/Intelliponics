using Intelliponics.Models.Entities;
using Intelliponics.Repositories.Interfaces;
using Intelliponics.Services.Interfaces;

namespace Intelliponics.Services.Implementations
{
    public class PaymentService : IPaymentService, IBaseService<Payment>
    {
        private readonly IPaymentRepository _paymentRepo;
        public PaymentService(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }
        public async Task<bool> CreateAsync(Payment entity)
        {
            return await _paymentRepo.AddAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           return await _paymentRepo.DeleteAsync(id);
        }

        public Task<IEnumerable<Payment>> GetAllAsync()
        {
            return _paymentRepo.GetAllAsync();
        }

        public Task<Payment> GetByIdAsync(int id)
        {
           return _paymentRepo.GetByIdAsync(id);
        }

        public Task<Payment> GetPaymentByCustomerIDAsync(int custid)
        {
            return _paymentRepo.GetPaymentByCustomerIdAsync(custid);
        }

        public Task<bool> UpdateAsync(int id, Payment entity)
        {
            return _paymentRepo.UpdateAsync(id, entity);
        }
    }
}
