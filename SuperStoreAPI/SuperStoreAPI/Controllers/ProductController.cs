using Microsoft.AspNetCore.Mvc;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.Repositories;
using SuperStoreAPI.ResourceParameters;
using SuperStoreAPI.Services;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductResourceParameters productResourceParameters) {
            return Ok(await _productService.GetProducts(productResourceParameters));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            var product = await _productService.GetProduct(productId);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] ProductForUpdateView product) {
            
            var prod = await _productService.GetProduct(productId);
            if (prod == null)
            {
                return NotFound();
            }
            await _productService.UpdateProduct(product);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationView productView)
        {
            return Ok(await _productService.AddProduct(productView));
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveProduct(Guid productId)
        {
            var productFromRepo = await _productService.GetProduct(productId);
            if (productFromRepo == null)
            {
                return NotFound();
            }
            await _productService.DeleteProduct(productId);
            return NoContent();
        }
    }
}
