using System.ComponentModel.DataAnnotations;

namespace SuperStoreAPI.Views
{
    public class OrderView
    {
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double PaymentAmount { get; set; }
        [Required]
        public string Currency { get; set; }
        public ICollection<OrderProductView> OrderProducts { get; set; } = new List<OrderProductView>();
    }
}
