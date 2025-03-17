using System.Collections.Generic;
using Hospitality_Management_System.Models;
using Hospitality_Management_System.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality_Management_System.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientDataAccess _dataAccess;

        public PatientController(IPatientDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetPatients()
        {
            var patients = _dataAccess.GetPatients();
            return Ok(patients);
        }

        [HttpPost]
        public ActionResult<Patient> AddPatient(Patient patient)
        {
            _dataAccess.InsertPatient(patient);
            return CreatedAtAction(nameof(GetPatients), new { id = patient.PatientID }, patient);
        }
    }
}
