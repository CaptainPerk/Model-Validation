using System;
using System.ComponentModel.DataAnnotations;

namespace MvcModelValidation.Models
{
    public class Appointment
    {
        public string ClientName { get; set; }
        [UIHint("Date")]
        public DateTime Date { get; set; }
        public bool TermsAccepted { get; set; }
    }
}
