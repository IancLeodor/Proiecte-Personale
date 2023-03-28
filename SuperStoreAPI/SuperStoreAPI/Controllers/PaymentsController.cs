using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SuperStore.Data.Models;
using SuperStoreAPI.Interfaces;
using SuperStoreAPI.Views;

namespace SuperStoreAPI.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;

        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }

        [HttpGet]
        [Route("users/{userId}")]
        public async Task<IActionResult> GetPayments(Guid userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            return Ok(await _paymentsService.GetPayments(userId));
        }

        [HttpGet]
        [Route("{paymentId}")]
        public async Task<IActionResult> GetPayment(Guid paymentId)
        {
            var payment = await _paymentsService.GetPayment(paymentId);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpDelete]
        [Route("{paymentId}")]
        public async Task<ActionResult> DeletePayment(Guid paymentId)
        {

            var paymentToDelete = await _paymentsService.GetPayment(paymentId);
            if (paymentToDelete == null)
            {
                return NotFound();
            }
            await _paymentsService.DeletePayment(paymentId);
            return Ok();
        }

        [HttpPost]
        [Route("users/{userId}")]
        public async Task<IActionResult> AddPayment([FromRoute] Guid userId, [FromBody] CreatePaymentView createPaymentView)
        {
            if (createPaymentView.UserId == null)
            {
                throw new ArgumentNullException(nameof(createPaymentView.UserId));
            }

            createPaymentView.UserId = userId;
            return Ok(await _paymentsService.AddPayment(createPaymentView));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment(UpdatePaymentView updatePaymentView)
        {
            if (updatePaymentView == null)
            {
                throw new ArgumentNullException(nameof(updatePaymentView));
            }
            await _paymentsService.UpdatePayment(updatePaymentView);
            return Ok();
        }
    }
}
