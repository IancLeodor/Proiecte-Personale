using AutoMapper;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IMapper _mapper;

        public PaymentsService(IPaymentsRepository paymentsRepository, IMapper mapper)
        {
            _paymentsRepository = paymentsRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentView>> GetPayments(Guid userId)
        {
            var payments = await _paymentsRepository.GetPayments(userId);
            var view = _mapper.Map<List<PaymentView>>(payments);
            foreach (var payment in view)
            {
                payment.CardNumber = HideCardNumber(payment.CardNumber);
            }
            return view;
        }

        public async Task<PaymentView> GetPayment(Guid paymentId)
        {
            var payment = await _paymentsRepository.GetPayment(paymentId);
            if (payment != null)
            {
                payment.CardNumber = HideCardNumber(payment.CardNumber);
                return _mapper.Map<PaymentView>(payment);
            }
            else
            {
                return null;
            }

        }

        private string HideCardNumber(string cardNumber)
        {
            var numbersToHide = "************";
            cardNumber = string.Concat(numbersToHide, cardNumber.Substring(12));//first 12 digits are replaced by * and we take the last 4 as they are
            return cardNumber;
        }

        public async Task<PaymentView> AddPayment(CreatePaymentView createPaymentView)
        {
            var paymentModel = _mapper.Map<Payment>(createPaymentView);
            paymentModel.Currency = paymentModel.Currency.ToUpper();
            var payment = await _paymentsRepository.AddPayment(paymentModel);
            await _paymentsRepository.SaveAsync();
            return _mapper.Map<PaymentView>(payment);
        }

        public async Task DeletePayment(Guid paymentId)
        {
            var paymentToDelete = await _paymentsRepository.GetPayment(paymentId);
            await _paymentsRepository.DeletePayment(paymentToDelete);
        }

        public async Task UpdatePayment(UpdatePaymentView updatePaymentView)
        {
            var paymentModel = _mapper.Map<Payment>(updatePaymentView);
            paymentModel.Currency = paymentModel.Currency.ToUpper();
            _paymentsRepository.UpdatePayment(paymentModel);
            await _paymentsRepository.SaveAsync();
        } 
    }
}
