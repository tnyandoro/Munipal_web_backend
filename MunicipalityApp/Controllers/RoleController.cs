using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MunicipalityApp.Models;
using MunicipalityApp.Repositories;

namespace MunicipalityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET: api/role/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return Ok(roles);
        }

        // POST: api/role
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Role cannot be null.");
            }

            await _roleRepository.AddAsync(role);

            // Option 1: Use Ok to debug
            return Ok(role);

            // Option 2: Manually generate URL for Created response
            /*
            var locationUrl = Url.Action(nameof(GetByIdAsync), new { id = role.Id });
            return Created(locationUrl, role);
            */
        }

        // PUT: api/role
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] Role role)
        {
            if (role == null)
            {
                return BadRequest("Role cannot be null.");
            }

            var existingRole = await _roleRepository.GetByIdAsync(role.Id);
            if (existingRole == null)
            {
                return NotFound("Role not found.");
            }

            await _roleRepository.UpdateAsync(role);
            return NoContent();
        }

        // DELETE: api/role/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var existingRole = await _roleRepository.GetByIdAsync(id);
            if (existingRole == null)
            {
                return NotFound("Role not found.");
            }

            await _roleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
