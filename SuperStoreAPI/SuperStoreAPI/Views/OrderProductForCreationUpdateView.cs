using System.ComponentModel.DataAnnotations;

namespace SuperStoreAPI.Views
{
    public class OrderProductForCreationUpdateView
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double TotalPrice { get; set; }
    }
}
