using Hospitality_Management_System.Models;
using HospitalityManagementSystem.Models;
using HospitalityManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalityManagementSystem.Controllers
{
    [Route("api/billing")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly BillingService _billingService;
        private readonly IConfiguration _config;

        public BillingController(BillingService billingService, IConfiguration config)
        {
            _billingService = billingService;
            _config = config;
        }

        // Get all Billings
        [HttpGet]
        public ActionResult<IEnumerable<Billing>> GetBillings()
        {
            var billings = _billingService.GetBillingsAsync();
            if (billings == null || billings.Equals(null))
            {
                return NotFound("No billings found.");
            }
            return Ok(billings);
        }

        // Get Billing By ID
        [HttpGet("{id}")]
        public ActionResult<Billing> GetBillingById(string id)
        {
            var billing = _billingService.GetBillingByIdAsync(id);

            if (billing == null)
            {
                return NotFound($"Billing with ID {id} not found.");
            }

            return Ok(billing);
        }

        // Create Billing
        [HttpPost]
        public ActionResult<Billing> CreateBilling([FromBody] Billing billing)
        {
            if (billing == null)
            {
                return BadRequest("Billing data is required.");
            }

            _ = _billingService.CreateBillingAsync(billing);
            return CreatedAtAction(nameof(GetBillingById), new { id = billing.Id }, billing);
        }

        // Update Billing
        [HttpPut("{id}")]
        public ActionResult UpdateBilling(string id, [FromBody] Billing billing)
        {
            if (billing == null || billing.Id != id)
            {
                return BadRequest("Billing ID mismatch.");
            }

            var existingBilling = _billingService.GetBillingByIdAsync(id);
            if (existingBilling == null)
            {
                return NotFound($"Billing with ID {id} not found.");
            }

            _ = _billingService.UpdateBillingAsync(billing);
            return NoContent();  // HTTP 204 No Content, indicating successful update
        }

        // Delete Billing
        [HttpDelete("{id}")]
        public ActionResult DeleteBilling(string id)
        {
            var billing = _billingService.GetBillingByIdAsync(id);
            if (billing == null)
            {
                return NotFound($"Billing with ID {id} not found.");
            }

            _ = _billingService.DeleteBillingAsync(id);
            return NoContent();  // HTTP 204 No Content, indicating successful deletion
        }
    }
}
