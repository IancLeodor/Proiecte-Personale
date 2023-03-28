using Microsoft.EntityFrameworkCore;
using SuperStore.Data;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;

namespace SuperStoreAPI.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly StoreContext _context;

        public PaymentsRepository(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            if (payment.UserId == null)
            {
                throw new ArgumentNullException(nameof(payment.UserId));
            }

            if (payment == null)
            {
                throw new ArgumentNullException();
            }

            payment.PaymentDate = DateTime.Now;
            payment.EndSubscriptionDate = payment.PaymentDate.AddMonths(1);
            await _context.Payments.AddAsync(payment);
            return payment;
        }

        public async Task<Payment> GetPayment(Guid paymentId)
        {
            if (paymentId == Guid.Empty)
            {
                throw new ArgumentNullException();
            }

            return await _context.Payments
                .Where(p => p.Id == paymentId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Payment>> GetPayments(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            return await _context.Payments
                .Where(p => p.UserId == userId)
                .OrderBy(p => p.PaymentDate)
                .ToListAsync();
        }

        public async Task DeletePayment(Payment payment)
        {
            _context.Payments.Remove(payment);
            await SaveAsync();
        }
        public void UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
