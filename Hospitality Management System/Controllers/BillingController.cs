using Hospitality_Management_System.Models;
using Hospitality_Management_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospitality_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly BillingService _billingService;

        public BillingController(BillingService billingService)
        {
            _billingService = billingService;
        }

        // Get all billing records
        [HttpGet]
        public async Task<ActionResult<List<Billing>>> GetAllBillings()
        {
            var billings = await _billingService.GetAllBillingsAsync();
            return Ok(billings);
        }

        // Get a billing record by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Billing>> GetBillingById(string id)
        {
            var billing = await _billingService.GetBillingByIdAsync(id);
            if (billing == null)
            {
                return NotFound(new { Message = "Billing record not found" });
            }
            return Ok(billing);
        }

        // Create a new billing record
        [HttpPost]
        public async Task<ActionResult> CreateBilling([FromBody] Billing billing)
        {
            if (billing == null)
            {
                return BadRequest(new { Message = "Invalid billing data" });
            }

            await _billingService.CreateBillingAsync(billing);
            return CreatedAtAction(nameof(GetBillingById), new { id = billing.Id }, billing);
        }

        // Update a billing record
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBilling(string id, [FromBody] Billing updatedBilling)
        {
            var existingBilling = await _billingService.GetBillingByIdAsync(id);
            if (existingBilling == null)
            {
                return NotFound(new { Message = "Billing record not found" });
            }

            updatedBilling.Id = id; // Ensure the ID remains the same
            var updateResult = await _billingService.UpdateBillingAsync(id, updatedBilling);

            if (!updateResult)
            {
                return StatusCode(500, new { Message = "Failed to update billing record" });
            }

            return NoContent();
        }

        // Delete a billing record
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBilling(string id)
        {
            var existingBilling = await _billingService.GetBillingByIdAsync(id);
            if (existingBilling == null)
            {
                return NotFound(new { Message = "Billing record not found" });
            }

            var deleteResult = await _billingService.DeleteBillingAsync(id);
            if (!deleteResult)
            {
                return StatusCode(500, new { Message = "Failed to delete billing record" });
            }

            return NoContent();
        }
    }
}
