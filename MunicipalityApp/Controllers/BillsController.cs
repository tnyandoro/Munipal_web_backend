using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Repositories;

namespace MunicipalityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetByIdAsync(int id)
        {
            var bill = await _billRepository.GetByIdAsync(id);
            if (bill == null) return NotFound();
            return Ok(bill);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetAllAsync()
        {
            var bills = await _billRepository.GetAllAsync();
            return Ok(bills);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(Bill bill)
        {
            await _billRepository.AddAsync(bill);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = bill.Id }, bill);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(Bill bill)
        {
            await _billRepository.UpdateAsync(bill);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _billRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
