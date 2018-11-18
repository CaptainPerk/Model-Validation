using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MvcModelValidation.Models;
using System;

namespace MvcModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("MakeBooking", new Appointment{ Date = DateTime.Now});

        [HttpPost]
        public ViewResult MakeBooking(Appointment appointment)
        {
            if (string.IsNullOrEmpty(appointment.ClientName))
            {
                ModelState.AddModelError(nameof(appointment.ClientName), "Please enter your name");
            }

            if (ModelState.GetValidationState(nameof(appointment.Date)) == ModelValidationState.Valid && DateTime.Now > appointment.Date)
            {
                ModelState.AddModelError(nameof(appointment.Date), "Please enter a date in the future");
            }

            if (!appointment.TermsAccepted)
            {
                ModelState.AddModelError(nameof(appointment.TermsAccepted), "You must accept the terms");
            }

            if (ModelState.GetValidationState(nameof(appointment.Date)) == ModelValidationState.Valid &&
                ModelState.GetValidationState(nameof(appointment.ClientName)) == ModelValidationState.Valid &&
                appointment.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase) &&
                appointment.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "You can't book appointments on Mondays because you're always late");
            }

            return !ModelState.IsValid ? View() : View("Completed", appointment);
        }
    }
}
