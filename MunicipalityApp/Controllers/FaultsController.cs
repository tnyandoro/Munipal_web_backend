using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Repositories;

namespace MunicipalityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaultController : ControllerBase
    {
        private readonly IFaultRepository _faultRepository;

        public FaultController(IFaultRepository faultRepository)
        {
            _faultRepository = faultRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var fault = await _faultRepository.GetByIdAsync(id);
            if (fault == null) return NotFound();
            return Ok(fault);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var faults = await _faultRepository.GetAllAsync();
            return Ok(faults);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Fault fault)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _faultRepository.AddAsync(fault);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = fault.Id }, fault);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Fault fault)
        {
            if (id != fault.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _faultRepository.UpdateAsync(fault);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _faultRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
