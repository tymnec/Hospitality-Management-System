using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Hospitality_Management_System.Models
{
    public class Patient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("firstName")]
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public required string FirstName { get; set; }

        [BsonElement("lastName")]
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public required string LastName { get; set; }

        [BsonElement("dateOfBirth")]
        [Required]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public required DateTime DOB { get; set; }

        [BsonElement("gender")]
        [Required]
        [BsonRepresentation(BsonType.String)]
        public required Gender Gender { get; set; }

        [BsonElement("contactNumber")]
        [Required]
        [StringLength(20, ErrorMessage = "Contact number cannot be longer than 20 characters.")]
        [RegularExpression(@"^(\d{10}|\(\d{3}\)\s\d{3}\-\d{4})$", ErrorMessage = "Contact number is not in a correct format.")]
        public required string ContactNumber { get; set; }

        [BsonElement("email")]
        [Required]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [EmailAddress]
        public required string Email { get; set; }

        [BsonElement("address")]
        [Required]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public required string Address { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}

