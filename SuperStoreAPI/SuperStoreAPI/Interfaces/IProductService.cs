using Microsoft.AspNetCore.Mvc;
using SuperStoreAPI.ResourceParameters;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductView>> GetProducts(ProductResourceParameters productResourceParameters);
        public Task<ProductView> GetProduct(Guid productId);
        public Task<ProductView> AddProduct(ProductForCreationView productForCreationView);
        public Task UpdateProduct(ProductForUpdateView product);
        public Task DeleteProduct(Guid productId);
    }
}
