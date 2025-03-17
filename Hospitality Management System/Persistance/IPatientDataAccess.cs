using System.Collections.Generic;
using Hospitality_Management_System.Models;

namespace Hospitality_Management_System.Persistence
{
    public interface IPatientDataAccess
    {
        List<Patient> GetPatients();
        Patient GetPatientById(string patientId);
        void InsertPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(string patientId);
    }
}
