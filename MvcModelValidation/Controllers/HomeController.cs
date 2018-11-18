using Microsoft.AspNetCore.Mvc;
using MvcModelValidation.Models;
using System;

namespace MvcModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View("MakeBooking", new Appointment{ Date = DateTime.Now});

        [HttpPost]
        public ViewResult MakeBooking(Appointment appointment) => View("Completed", appointment);
    }
}
