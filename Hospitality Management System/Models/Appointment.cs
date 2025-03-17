using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospitality_Management_System.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("patientId")]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string PatientID { get; set; }

        [BsonElement("doctorId")]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string DoctorID { get; set; }

        [BsonElement("appointmentDate")]
        [Required]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public required DateTime AppointmentDate { get; set; }

        [BsonElement("status")]
        [Required]
        [StringLength(50, ErrorMessage = "Status cannot be longer than 50 characters.")]
        public required string Status { get; set; }
    }
}