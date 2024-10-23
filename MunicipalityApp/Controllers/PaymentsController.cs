using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Repositories;

namespace MunicipalityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Payment payment)
        {
            await _paymentRepository.AddAsync(payment);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = payment.Id }, payment);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Payment payment)
        {
            await _paymentRepository.UpdateAsync(payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
