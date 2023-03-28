using SuperStore.Data.Models;

namespace SuperStoreAPI.Interfaces
{
    public interface IPaymentsRepository
    {
        public Task<Payment> AddPayment(Payment payment);
        public Task<Payment> GetPayment(Guid paymentId);
        public Task<List<Payment>> GetPayments(Guid userId);
        public void UpdatePayment(Payment payment);
        public Task DeletePayment(Payment payment);
        public Task SaveAsync();
    }
}
