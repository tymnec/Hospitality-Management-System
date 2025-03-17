using System.Collections.Generic;
using MongoDB.Driver;
using Hospitality_Management_System.Models;

namespace Hospitality_Management_System.Persistence
{
    public class AppointmentEF : IAppointmentDataAccess
    {
        private readonly HospitalityContext _context = new HospitalityContext();

        public List<Appointment> GetAppointments()
        {
            return _context.Appointments.Find(_ => true).ToList();
        }

        public Appointment GetAppointmentById(string id)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.AppointmentID, id);
            return _context.Appointments.Find(filter).FirstOrDefault();
        }

        public void InsertAppointment(Appointment appointment)
        {
            _context.Appointments.InsertOne(appointment);
        }

        public void UpdateAppointment(Appointment appointment)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.AppointmentID, appointment.AppointmentID);
            _context.Appointments.ReplaceOne(filter, appointment);
        }

        public void DeleteAppointment(string id)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.AppointmentID, id);
            _context.Appointments.DeleteOne(filter);
        }
    }
}
