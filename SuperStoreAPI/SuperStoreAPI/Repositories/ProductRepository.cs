using Microsoft.EntityFrameworkCore;
using SuperStore.Data;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.ResourceParameters;

namespace SuperStoreAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> GetProduct(Guid productId)
        {
            if(productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }
            return await _context.Products.Where(c => c.ProductId == productId).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductResourceParameters productResourceParameters)
        {
            if (productResourceParameters == null) { 
                throw new ArgumentNullException(nameof(productResourceParameters));
            }

            if(string.IsNullOrWhiteSpace(productResourceParameters.NameQuery) &&
                string.IsNullOrWhiteSpace(productResourceParameters.DescriptionQuery) &&
                string.IsNullOrWhiteSpace(productResourceParameters.Category))
            {
                return await GetProducts();
            }

            var collection = _context.Products as IQueryable<Product>;

            if (!string.IsNullOrWhiteSpace(productResourceParameters.Category)) {
                var category = productResourceParameters.Category.Trim();
                collection = collection.Where(p => p.Category.Equals(category));
            }

            if (!string.IsNullOrWhiteSpace(productResourceParameters.NameQuery))
            {
                var nameQuery = productResourceParameters.NameQuery.Trim();
                collection = collection.Where(p => p.Name.Contains(nameQuery));
            }

            if (!string.IsNullOrWhiteSpace(productResourceParameters.DescriptionQuery))
            {
                var descriptionQuery = productResourceParameters.DescriptionQuery.Trim();
                collection = collection.Where(p => p.Description.Contains(descriptionQuery));
            }

            return collection.ToList();
        }

        public async Task<Product> AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            await _context.Products.AddAsync(product);
            return product;
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public void DeleteProduct(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }
            Product removedProduct = _context.Products.Where(a => a.ProductId == productId).FirstOrDefault();
            _context.Products.Remove(removedProduct);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
