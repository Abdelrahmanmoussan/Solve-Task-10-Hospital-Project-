using ContactDoctor.Models;
using Hospital.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        ApplecationDbContext dbContext = new ApplecationDbContext();
        public IActionResult BookAppointment()
        {
            var doctors = dbContext.Doctors;
            return View(doctors.ToList());
        }


        public IActionResult CompleteAppointment(string doctorName)
        {
            var doctor = dbContext.Doctors.FirstOrDefault(d => d.Name == doctorName);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }
    }
}
