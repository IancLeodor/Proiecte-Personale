namespace SuperStoreAPI.Views
{
    public class ProductForUpdateView
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public int Inventory { get; set; }
    }
}
