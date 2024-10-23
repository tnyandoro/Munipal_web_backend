using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Repositories;

namespace MunicipalityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffController : ControllerBase
    {
        private readonly ITariffRepository _tariffRepository;

        public TariffController(ITariffRepository tariffRepository)
        {
            _tariffRepository = tariffRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var tariff = await _tariffRepository.GetByIdAsync(id);
            if (tariff == null) return NotFound();
            return Ok(tariff);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var tariffs = await _tariffRepository.GetAllAsync();
            return Ok(tariffs);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Tariff tariff)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _tariffRepository.AddAsync(tariff);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = tariff.Id }, tariff);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Tariff tariff)
        {
            if (id != tariff.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _tariffRepository.UpdateAsync(tariff);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _tariffRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
