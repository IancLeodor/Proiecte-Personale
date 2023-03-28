using SuperStore.Data.Models;
using SuperStoreAPI.Views;
using System.ComponentModel.DataAnnotations;

namespace SuperStoreAPI.ResourceParameters
{
    public class PaymentCurrencyAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var view = (PaymentViewForManipulation)validationContext.ObjectInstance;
            if (!view.Currency.ToUpper().Equals("EUR"))
            {
                return new ValidationResult(ErrorMessage, new[] { nameof(PaymentViewForManipulation) });
            }

            return ValidationResult.Success;
        }
    }
}
