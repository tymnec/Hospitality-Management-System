using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitality_Management_System.Models
{
    public class Billing
    {
        [Key]
        public string BillID { get; set; }

        [ForeignKey("Patient")]
        public string PatientID { get; set; }
        public Patient Patient { get; set; }

        [ForeignKey("Appointment")]
        public string AppointmentID { get; set; }
        public Appointment Appointment { get; set; }

        public double Amount { get; set; }
        public DateTime BillDate { get; set; }
        public string PaymentStatus { get; set; }
    }
}