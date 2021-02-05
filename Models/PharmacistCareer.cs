using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class PharmacistCareer
    {
        public Guid Id { get; set; }
        public Guid PharmacistId { get; set; }
        public Pharmacist Pharmacist { get; set; }
        [Required(ErrorMessage = "Please select Pharmacy")]
        [DisplayName("Pharmacy")]
        public Guid PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
