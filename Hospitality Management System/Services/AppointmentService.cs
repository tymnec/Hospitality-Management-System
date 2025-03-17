using Hospitality_Management_System.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospitality_Management_System.Services
{
    public class AppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointments;

        public AppointmentService(IMongoDatabase database)
        {
            _appointments = database.GetCollection<Appointment>("Appointments");
        }

        // Create a new appointment
        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            await _appointments.InsertOneAsync(appointment);
        }

        // Get appointment by ID
        public async Task<Appointment?> GetAppointmentByIdAsync(string id)
        {
            return await _appointments.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        // Get all appointments
        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _appointments.Find(_ => true).ToListAsync();
        }

        // Update an appointment
        public async Task<bool> UpdateAppointmentAsync(string id, Appointment updatedAppointment)
        {
            var result = await _appointments.ReplaceOneAsync(a => a.Id == id, updatedAppointment);
            return result.ModifiedCount > 0;
        }

        // Delete an appointment by ID
        public async Task<bool> DeleteAppointmentAsync(string id)
        {
            var result = await _appointments.DeleteOneAsync(a => a.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
