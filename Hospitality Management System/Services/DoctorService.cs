using Hospitality_Management_System.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Hospitality_Management_System.Services
{
    public class DoctorService
    {
        private readonly IMongoCollection<Doctor> _doctors;

        public DoctorService(IMongoDatabase database)
        {
            _doctors = database.GetCollection<Doctor>("Doctors");
        }

        // Create a new doctor
        public async Task CreateDoctorAsync(Doctor doctor)
        {
            await _doctors.InsertOneAsync(doctor);
        }

        // Get doctor by ID
        public async Task<Doctor?> GetDoctorByIdAsync(string id)
        {
            return await _doctors.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        // Get all doctors
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctors.Find(_ => true).ToListAsync();
        }

        // Update a doctor's information
        public async Task UpdateDoctorAsync(string id, Doctor updatedDoctor)
        {
            await _doctors.ReplaceOneAsync(d => d.Id == id, updatedDoctor);
        }

        // Delete a doctor by ID
        public async Task DeleteDoctorAsync(string id)
        {
            await _doctors.DeleteOneAsync(d => d.Id == id);
        }
    }
}