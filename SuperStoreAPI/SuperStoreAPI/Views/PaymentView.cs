namespace SuperStoreAPI.Views
{
    public class PaymentView
    {
        public Guid Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime EndSubscriptionDate { get; set; }
        public string CardNumber { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }
}
