using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mladacina.Models
{
    public class PatientDoctor
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required(ErrorMessage = "Please select Doctor")]
        [DisplayName("Doctor")]
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }


    }
}
