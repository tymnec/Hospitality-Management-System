using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospitality_Management_System.Models
{
    public class Billing
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("patientId")]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string PatientID { get; set; }

        [BsonElement("appointmentId")]
        [Required]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string AppointmentID { get; set; }

        [BsonElement("amount")]
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public required double Amount { get; set; }

        [BsonElement("billDate")]
        [Required]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public required DateTime BillDate { get; set; }

        [BsonElement("paymentStatus")]
        [Required]
        [StringLength(50, ErrorMessage = "Payment status cannot be longer than 50 characters.")]
        public required string PaymentStatus { get; set; }
    }
}