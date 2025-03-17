using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitality_Management_System.Models
{
    public class Appointment
    {
        [Key]
        public string AppointmentID { get; set; }

        [ForeignKey("Patient")]
        public string PatientID { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorID { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}
