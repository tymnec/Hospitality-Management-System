using Hospitality_Management_System.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Hospitality_Management_System.Services
{
    public class PatientService
    {
        private readonly IMongoCollection<Patient> _patients;

        public PatientService(IMongoDatabase database)
        {
            _patients = database.GetCollection<Patient>("Patients");
        }

        // Create a new patient
        public async Task CreatePatientAsync(Patient patient)
        {
            await _patients.InsertOneAsync(patient);
        }

        // Get patient by ID
        public async Task<Patient?> GetPatientByIdAsync(string id)
        {
            return await _patients.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        // Get all patients
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _patients.Find(_ => true).ToListAsync();
        }

        // Update a patient's information
        public async Task UpdatePatientAsync(string id, Patient updatedPatient)
        {
            await _patients.ReplaceOneAsync(p => p.Id == id, updatedPatient);
        }

        // Delete a patient by ID
        public async Task DeletePatientAsync(string id)
        {
            await _patients.DeleteOneAsync(p => p.Id == id);
        }
    }
}
