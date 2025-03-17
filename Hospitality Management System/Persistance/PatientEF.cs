using System.Collections.Generic;
using MongoDB.Driver;
using Hospitality_Management_System.Models;

namespace Hospitality_Management_System.Persistence
{
    public class PatientEF : IPatientDataAccess
    {
        private readonly HospitalityContext _context = new HospitalityContext();

        public List<Patient> GetPatients()
        {
            return _context.Patients.Find(_ => true).ToList();
        }

        public Patient GetPatientById(string id)
        {
            var filter = Builders<Patient>.Filter.Eq(p => p.PatientID, id);
            return _context.Patients.Find(filter).FirstOrDefault();
        }

        public void InsertPatient(Patient patient)
        {
            _context.Patients.InsertOne(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            var filter = Builders<Patient>.Filter.Eq(p => p.PatientID, patient.PatientID);
            _context.Patients.ReplaceOne(filter, patient);
        }

        public void DeletePatient(string id)
        {
            var filter = Builders<Patient>.Filter.Eq(p => p.PatientID, id);
            _context.Patients.DeleteOne(filter);
        }
    }
}
