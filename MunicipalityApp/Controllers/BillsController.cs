using System.Collections.Generic;
using System.Threading.Tasks;
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
        private readonly ICustomerRepository _customerRepository; // Add customer repository for validation

        public BillController(
            IBillRepository billRepository,
            ICustomerRepository customerRepository
        )
        {
            _billRepository = billRepository;
            _customerRepository = customerRepository; // Initialize customer repository
        }

        // GET api/bill/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetByIdAsync(int id)
        {
            var bill = await _billRepository.GetByIdAsync(id);
            if (bill == null)
            {
                return NotFound("Bill not found.");
            }
            return Ok(bill);
        }

        // GET api/bill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetAllAsync()
        {
            var bills = await _billRepository.GetAllAsync();
            return Ok(bills);
        }

        // POST api/bill
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] Bill bill)
        {
            // Validate the incoming bill object
            if (bill == null)
            {
                return BadRequest("Bill cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validate CustomerId
            if (bill.CustomerId <= 0)
            {
                return BadRequest("Invalid Customer ID.");
            }

            // Check if the customer exists in the database
            var customerExists = await _customerRepository.GetByIdAsync(bill.CustomerId);
            if (customerExists == null)
            {
                return BadRequest("Customer with the provided ID does not exist.");
            }

            // Add the bill
            await _billRepository.AddAsync(bill);

            // Ensure the ID is set after insertion
            if (bill.Id <= 0)
            {
                return BadRequest("Bill creation failed, ID is not set.");
            }

            // Return the created bill with the appropriate response
            return Created($"/api/bill/{bill.Id}", bill);
        }

        // PUT api/bill
        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] Bill bill)
        {
            if (bill == null)
            {
                return BadRequest("Bill cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the bill exists before updating
            var existingBill = await _billRepository.GetByIdAsync(bill.Id);
            if (existingBill == null)
            {
                return NotFound("Bill not found.");
            }

            // Ensure CustomerId is valid before updating
            var customerExists = await _customerRepository.GetByIdAsync(bill.CustomerId);
            if (customerExists == null)
            {
                return BadRequest("Invalid Customer ID.");
            }

            // Update the bill
            await _billRepository.UpdateAsync(bill);
            return NoContent();
        }

        // DELETE api/bill/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            // Check if the bill exists before deletion
            var existingBill = await _billRepository.GetByIdAsync(id);
            if (existingBill == null)
            {
                return NotFound("Bill not found.");
            }

            // Delete the bill
            await _billRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
