using SuperStoreAPI.ResourceParameters;
using System.ComponentModel.DataAnnotations;

namespace SuperStoreAPI.Views
{
    public abstract class PaymentViewForManipulation
    {
        public DateTime PaymentDate { get; set; }
        public DateTime EndSubscriptionDate { get; set; }

        [MaxLength(16, ErrorMessage = "The card number should be 16 digits long."), MinLength(16, ErrorMessage = "The card number should be 16 digits long.")]
        public string CardNumber { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed.")]
        public double Price { get; set; }

        [PaymentCurrencyAttribute(ErrorMessage = "Currency must be EUR!")]
        public string Currency { get; set; }
        public Guid UserId { get; set; }
    }
}
