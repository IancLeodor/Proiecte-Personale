using SuperStoreAPI.Views;

namespace SuperStoreAPI.Interfaces
{
    public interface IPaymentsService
    {
        public Task<List<PaymentView>> GetPayments(Guid userId);
        public Task<PaymentView> GetPayment(Guid paymentId);
        public Task<PaymentView> AddPayment(CreatePaymentView createPaymentView);
        public Task UpdatePayment(UpdatePaymentView updatePaymentView);
        public Task DeletePayment(Guid paymentId);
    }
}
