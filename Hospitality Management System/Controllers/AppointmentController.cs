using Hospitality_Management_System.Models;
using HospitalityManagementSystem.Models;
using HospitalityManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalityManagementSystem.Controllers
{
    [Route("api/appointments")]
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
        public ActionResult<IEnumerable<Appointment>> GetAppointments()
        {
            var appointments = _appointmentService.GetAppointmentsAsync();
            if (appointments == null || appointments.Equals(null))
            {
                return NotFound("No appointments found.");
            }
            return Ok(appointments);
        }

        // Get appointment by ID
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetAppointmentById(string id)
        {
            var appointment = _appointmentService.GetAppointmentByIdAsync(id);

            if (appointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }

            return Ok(appointment);
        }

        // Create an appointment
        [HttpPost]
        public ActionResult<Appointment> CreateAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment data is required.");
            }

            _ = _appointmentService.CreateAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, appointment);
        }

        // Update an appointment
        [HttpPut("{id}")]
        public ActionResult UpdateAppointment(string id, [FromBody] Appointment appointment)
        {
            if (appointment == null || appointment.Id != id)
            {
                return BadRequest("Appointment ID mismatch.");
            }

            var existingAppointment = _appointmentService.GetAppointmentByIdAsync(id);
            if (existingAppointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }

            _appointmentService.UpdateAppointment(appointment);
            return NoContent();  // HTTP 204 No Content, indicating successful update
        }

        // Delete an appointment
        [HttpDelete("{id}")]
        public ActionResult DeleteAppointment(string id)
        {
            var appointment = _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound($"Appointment with ID {id} not found.");
            }

            _ = _appointmentService.DeleteAppointmentAsync(id);
            return NoContent();  // HTTP 204 No Content, indicating successful deletion
        }
    }
}

// {
//   "patientID": "67d7d55eb46950136437d272",
//   "doctorID": "67d7d504b46950136437d271",
//   "appointmentDate": "2025-03-17T07:55:12.342Z",
//   "status": "Scheduled"
// }