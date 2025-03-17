using Hospitality_Management_System.Models;
using Hospitality_Management_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hospitality_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // POST: api/doctor
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest("Doctor data is null.");
            }

            await _doctorService.CreateDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        // GET: api/doctor/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(string id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound($"Doctor with ID {id} not found.");
            }
            return Ok(doctor);
        }

        // GET: api/doctor
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        // PUT: api/doctor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(string id, [FromBody] Doctor updatedDoctor)
        {
            if (updatedDoctor == null)
            {
                return BadRequest("Updated doctor data is null.");
            }

            var existingDoctor = await _doctorService.GetDoctorByIdAsync(id);
            if (existingDoctor == null)
            {
                return NotFound($"Doctor with ID {id} not found.");
            }

            updatedDoctor.Id = id; // Ensure the updated doctor retains the same ID
            await _doctorService.UpdateDoctorAsync(id, updatedDoctor);
            return NoContent(); // Successfully updated
        }

        // DELETE: api/doctor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound($"Doctor with ID {id} not found.");
            }

            await _doctorService.DeleteDoctorAsync(id);
            return NoContent(); // Successfully deleted
        }
    }
}