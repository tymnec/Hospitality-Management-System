using System.Collections.Generic;
using Hospitality_Management_System.Models;
using Hospitality_Management_System.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality_Management_System.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorDataAccess _dataAccess;

        public DoctorController(IDoctorDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetDoctors()
        {
            var doctors = _dataAccess.GetDoctors();
            return Ok(doctors);
        }
    }
}
