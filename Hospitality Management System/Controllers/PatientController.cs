using Hospitality_Management_System.Models;
using Hospitality_Management_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hospitality_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        // POST: api/patient
        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient data is null.");
            }

            await _patientService.CreatePatientAsync(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
        }

        // GET: api/patient/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(string id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }
            return Ok(patient);
        }

        // GET: api/patient
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        // PUT: api/patient/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(string id, [FromBody] Patient updatedPatient)
        {
            if (updatedPatient == null)
            {
                return BadRequest("Updated patient data is null.");
            }

            var existingPatient = await _patientService.GetPatientByIdAsync(id);
            if (existingPatient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            updatedPatient.Id = id; // Ensure the updated patient retains the same ID
            await _patientService.UpdatePatientAsync(id, updatedPatient);
            return NoContent(); // Successfully updated
        }

        // DELETE: api/patient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound($"Patient with ID {id} not found.");
            }

            await _patientService.DeletePatientAsync(id);
            return NoContent(); // Successfully deleted
        }
    }
}
