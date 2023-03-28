using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.Repositories;
using SuperStoreAPI.ResourceParameters;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductView> GetProduct(Guid productId)
        {
            var product = await _productRepository.GetProduct(productId);
            return _mapper.Map<ProductView>(product);
        }

        public async Task<List<ProductView>> GetProducts(ProductResourceParameters productResourceParameters)
        {
            var products = await _productRepository.GetProducts(productResourceParameters);
            return _mapper.Map<List<ProductView>>(products);
        }

        public async Task UpdateProduct(ProductForUpdateView productFromView)
        {
            var product = await _productRepository.GetProduct(productFromView.ProductId);
            _mapper.Map(productFromView, product);
            //_productRepository.UpdateProduct(product);
            await _productRepository.SaveAsync();
        }
        public async Task<ProductView> AddProduct(ProductForCreationView productForCreationView)
        {
            var productModel = _mapper.Map<Product>(productForCreationView);
            var product = await _productRepository.AddProduct(productModel);
            await _productRepository.SaveAsync();
            return _mapper.Map<ProductView>(product);
        }

        public async Task DeleteProduct(Guid productId)
        {
            _productRepository.DeleteProduct(productId);
            await _productRepository.SaveAsync();
        }
    }
}
