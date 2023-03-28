using SuperStore.Data.Models;
using SuperStoreAPI.ResourceParameters;

namespace SuperStoreAPI.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> GetProduct(Guid id);
        public Task<List<Product>> GetProducts();
        public Task<IEnumerable<Product>> GetProducts(ProductResourceParameters productResourceParameters);
        public Task<Product> AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Guid product);
        public Task SaveAsync();
    }
}
