using System.Collections.Generic;
using Hospitality_Management_System.Models;
using Hospitality_Management_System.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality_Management_System.Controllers
{
    [Route("api/billing")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingDataAccess _dataAccess;

        public BillingController(IBillingDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Billing>> GetBillings()
        {
            var billings = _dataAccess.GetBillings();
            return Ok(billings);
        }

        [HttpGet("{id}")]
        public ActionResult<Billing> GetBillingById(string id)
        {
            var billing = _dataAccess.GetBillingById(id);

            if (billing == null)
            {
                return NotFound();
            }

            return Ok(billing);
        }
    }
}
