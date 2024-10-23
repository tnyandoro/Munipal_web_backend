using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Repositories;

namespace MunicipalityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var newsItem = await _newsRepository.GetByIdAsync(id);
            if (newsItem == null) return NotFound();
            return Ok(newsItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var newsItems = await _newsRepository.GetAllAsync();
            return Ok(newsItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] News newsItem)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _newsRepository.AddAsync(newsItem);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newsItem.Id }, newsItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] News newsItem)
        {
            if (id != newsItem.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _newsRepository.UpdateAsync(newsItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _newsRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
