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
            if (ModelState.GetValidationState(nameof(appointment.Date)) == ModelValidationState.Valid &&
                ModelState.GetValidationState(nameof(appointment.ClientName)) == ModelValidationState.Valid &&
                appointment.ClientName.Equals("Joe", StringComparison.OrdinalIgnoreCase) &&
                appointment.Date.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError("", "You can't book appointments on Mondays because you're always late");
            }

            return !ModelState.IsValid ? View() : View("Completed", appointment);
        }

        public JsonResult ValidateDate(string Date)
        {
            if (!DateTime.TryParse(Date, out var parsedDate))
            {
                return Json("Please enter a valid date (mm/dd/yyyy)");
            }

            if (DateTime.Now > parsedDate)
            {
                return Json("Please enter a date in the future");
            }

            return Json(true);
        }
    }
}
