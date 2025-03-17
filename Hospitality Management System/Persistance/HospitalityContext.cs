using Microsoft.EntityFrameworkCore;

namespace Hospitality_Management_System.Persistence
{
    using MongoDB.Driver;
    using Hospitality_Management_System.Models;

    public class HospitalityContext : DbContext
    {
        private readonly IMongoDatabase _database;

        public HospitalityContext()
        {
            var connectionString = "mongodb+srv://singhtanay0409:0J7mF8SIwWjR3LZu@cluster0.madxp.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";
            var databaseName = "Hospitality Management System";

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Patient> Patients => _database.GetCollection<Patient>("Patients");
        public IMongoCollection<Doctor> Doctors => _database.GetCollection<Doctor>("Doctors");
        public IMongoCollection<Appointment> Appointments => _database.GetCollection<Appointment>("Appointments");
        public IMongoCollection<Billing> Billings => _database.GetCollection<Billing>("Billings");
    }
}