using Hospitality_Management_System.Models;
using HospitalityManagementSystem.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalityManagementSystem.Services
{
    public class AppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointments;

        public AppointmentService(IMongoDatabase database)
        {
            _appointments = database.GetCollection<Appointment>("Appointments");
        }

        // Get all appointments
        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            return await _appointments.Find(_ => true).ToListAsync();
        }

        // Get appointment by ID
        public async Task<Appointment?> GetAppointmentByIdAsync(string id)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.AppointmentID, id);
            return await _appointments.Find(filter).FirstOrDefaultAsync();
        }

        // Create a new appointment
        public async Task<bool> CreateAppointmentAsync(Appointment appointment)
        {
            // Check if an appointment already exists with the same ID (if necessary)
            var existingAppointment = await _appointments.Find(a => a.AppointmentID == appointment.AppointmentID).FirstOrDefaultAsync();
            if (existingAppointment != null) return false;

            await _appointments.InsertOneAsync(appointment);
            return true;
        }

        // Update an existing appointment
        public async Task<bool> UpdateAppointmentAsync(Appointment appointment)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.AppointmentID, appointment.AppointmentID);
            var updateResult = await _appointments.ReplaceOneAsync(filter, appointment);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        // Delete an appointment by ID
        public async Task<bool> DeleteAppointmentAsync(string id)
        {
            var filter = Builders<Appointment>.Filter.Eq(a => a.AppointmentID, id);
            var deleteResult = await _appointments.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        internal void UpdateAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
