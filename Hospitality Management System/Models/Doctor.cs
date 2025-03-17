using System.ComponentModel.DataAnnotations;

namespace Hospitality_Management_System.Models
{
    public class Doctor
    {
        [Key]
        public string DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
