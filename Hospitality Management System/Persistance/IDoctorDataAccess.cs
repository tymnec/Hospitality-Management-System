using System.Collections.Generic;
using Hospitality_Management_System.Models;

namespace Hospitality_Management_System.Persistence
{
    public interface IDoctorDataAccess
    {
        List<Doctor> GetDoctors();
        Doctor GetDoctorById(string doctorId);
        void InsertDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(string doctorId);
    }
}
