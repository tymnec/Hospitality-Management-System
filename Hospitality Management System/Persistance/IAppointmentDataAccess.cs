using System.Collections.Generic;
using Hospitality_Management_System.Models;

namespace Hospitality_Management_System.Persistence
{
    public interface IAppointmentDataAccess
    {
        List<Appointment> GetAppointments();
        Appointment GetAppointmentById(string appointmentId);
        void InsertAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(string appointmentId);
    }
}
