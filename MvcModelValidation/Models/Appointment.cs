using Microsoft.AspNetCore.Mvc;
using MvcModelValidation.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace MvcModelValidation.Models
{
    public class Appointment
    {
        [Required]
        [Display(Name = "name")]
        public string ClientName { get; set; }
        [UIHint("Date")]
        [Required(ErrorMessage = "Please enter a date")]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }
        [MustBeTrue(ErrorMessage = "You must accept the terms")]
        public bool TermsAccepted { get; set; }
    }
}
