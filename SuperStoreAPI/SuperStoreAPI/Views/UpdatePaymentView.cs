using SuperStoreAPI.ResourceParameters;
using System.ComponentModel.DataAnnotations;

namespace SuperStoreAPI.Views
{
    public class UpdatePaymentView: PaymentViewForManipulation
    {
       public Guid Id { get; set; } 
    }
}
