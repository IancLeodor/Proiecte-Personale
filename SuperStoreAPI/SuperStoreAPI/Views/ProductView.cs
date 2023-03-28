namespace SuperStoreAPI.Views
{
    public class ProductView
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public bool InInventory { get; set; }
    }
}
