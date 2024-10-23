using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Repositories;

namespace MunicipalityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReaderController : ControllerBase
    {
        private readonly IMeterReaderRepository _meterReaderRepository;

        public MeterReaderController(IMeterReaderRepository meterReaderRepository)
        {
            _meterReaderRepository = meterReaderRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeterReader>> GetByIdAsync(int id)
        {
            var meterReader = await _meterReaderRepository.GetByIdAsync(id);
            if (meterReader == null) return NotFound();
            return Ok(meterReader);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeterReader>>> GetAllAsync()
        {
            var meterReaders = await _meterReaderRepository.GetAllAsync();
            return Ok(meterReaders);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync(MeterReader meterReader)
        {
            await _meterReaderRepository.AddAsync(meterReader);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = meterReader.Id }, meterReader);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync(MeterReader meterReader)
        {
            await _meterReaderRepository.UpdateAsync(meterReader);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _meterReaderRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
