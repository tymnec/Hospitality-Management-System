using Hospitality_Management_System.Models;
using Hospitality_Management_System.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospitality_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // Get all appointments
        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        // Get an appointment by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointmentById(string id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound(new { Message = "Appointment not found" });
            }
            return Ok(appointment);
        }

        // Create a new appointment
        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest(new { Message = "Invalid appointment data" });
            }

            await _appointmentService.CreateAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment);
        }

        // Update an appointment
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(string id, [FromBody] Appointment updatedAppointment)
        {
            var existingAppointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (existingAppointment == null)
            {
                return NotFound(new { Message = "Appointment not found" });
            }

            updatedAppointment.Id = id; // Ensure the ID remains the same
            var updateResult = await _appointmentService.UpdateAppointmentAsync(id, updatedAppointment);

            if (!updateResult)
            {
                return StatusCode(500, new { Message = "Failed to update appointment" });
            }

            return NoContent();
        }

        // Delete an appointment
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(string id)
        {
            var existingAppointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (existingAppointment == null)
            {
                return NotFound(new { Message = "Appointment not found" });
            }

            var deleteResult = await _appointmentService.DeleteAppointmentAsync(id);
            if (!deleteResult)
            {
                return StatusCode(500, new { Message = "Failed to delete appointment" });
            }

            return NoContent();
        }
    }
}
