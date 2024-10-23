using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Repositories;

namespace MunicipalityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityServiceUpdateController : ControllerBase
    {
        private readonly ICommunityServiceUpdateRepository _updateRepository;

        public CommunityServiceUpdateController(ICommunityServiceUpdateRepository updateRepository)
        {
            _updateRepository = updateRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var update = await _updateRepository.GetByIdAsync(id);
            if (update == null) return NotFound();
            return Ok(update);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var updates = await _updateRepository.GetAllAsync();
            return Ok(updates);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CommunityServiceUpdate update)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _updateRepository.AddAsync(update);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = update.Id }, update);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CommunityServiceUpdate update)
        {
            if (id != update.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _updateRepository.UpdateAsync(update);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _updateRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
