using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Controllers
{
    [ApiController]
    [Route("public/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateOrder(Guid userId, [FromBody] OrderForCreationUpdateView orderForCreationUpdateView)
        {
            return Ok( await _orderService.Update(userId, orderForCreationUpdateView));
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetOrders(Guid userId)
        {
            return Ok(await _orderService.GetOrders(userId));
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> CreateOrder(Guid userId, [FromBody] OrderForCreationUpdateView orderForCreationUpdateView)
        {
            return Ok(await _orderService.AddOrder(userId, orderForCreationUpdateView));
        }

        [HttpDelete]
        [Route("{orderId}/{userId}")]
        public async Task Delete(Guid userId, Guid orderId)
        {
           await _orderService.Delete(userId, orderId);
        }
    }
}
