using System.ComponentModel.DataAnnotations;

namespace SuperStoreAPI.Views
{
    public class OrderProductView
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
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public string Category { get; set; }
        public ProductView Product { get; set; }
    }
}
