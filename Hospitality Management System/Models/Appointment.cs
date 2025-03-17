using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospitality_Management_System.Models
{
    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Cancelled
    }

    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("patientId")]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string PatientId { get; set; }

        [BsonElement("doctorId")]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string DoctorId { get; set; }

        [BsonElement("appointmentDate")]
        [Required]
        [BsonRepresentation(BsonType.DateTime)]
        public required DateTime AppointmentDate { get; set; }

        [BsonElement("status")]
        [Required]
        public required AppointmentStatus Status { get; set; }
    }
}
