using AutoMapper;
using SuperStore.Data.Models;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Helpers
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentView>();
            CreateMap<PaymentView, Payment>();
            CreateMap<CreatePaymentView, Payment>();
            CreateMap<UpdatePaymentView, Payment>();
        }
    }
}
