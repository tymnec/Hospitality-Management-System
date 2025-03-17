using System.Collections.Generic;
using Hospitality_Management_System.Models;
using Hospitality_Management_System.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality_Management_System.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentDataAccess _dataAccess;

        public AppointmentController(IAppointmentDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        [HttpPost]
        public ActionResult<Appointment> CreateAppointment(Appointment appointment)
        {
            _dataAccess.InsertAppointment(appointment);
            return CreatedAtAction(nameof(CreateAppointment), new { id = appointment.AppointmentID }, appointment);
        }
    }
}
