using System.Collections.Generic;
using MongoDB.Driver;
using Hospitality_Management_System.Models;

namespace Hospitality_Management_System.Persistence
{
    public class DoctorEF : IDoctorDataAccess
    {
        private readonly HospitalityContext _context = new HospitalityContext();

        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.Find(_ => true).ToList();
        }

        public Doctor GetDoctorById(string id)
        {
            var filter = Builders<Doctor>.Filter.Eq(d => d.DoctorID, id);
            return _context.Doctors.Find(filter).FirstOrDefault();
        }

        public void InsertDoctor(Doctor doctor)
        {
            _context.Doctors.InsertOne(doctor);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            var filter = Builders<Doctor>.Filter.Eq(d => d.DoctorID, doctor.DoctorID);
            _context.Doctors.ReplaceOne(filter, doctor);
        }

        public void DeleteDoctor(string id)
        {
            var filter = Builders<Doctor>.Filter.Eq(d => d.DoctorID, id);
            _context.Doctors.DeleteOne(filter);
        }
    }
}
