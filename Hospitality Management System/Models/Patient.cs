using System.ComponentModel.DataAnnotations;

namespace Hospitality_Management_System.Models
{
    public class Patient
    {
        [Key]
        public string PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Billing> Billings { get; set; }
    }
}