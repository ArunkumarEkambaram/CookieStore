using CookieStore.Repositories;
using CookieStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.Controllers
{
    [Route("Doctors")]
    public class DoctorsController : Controller
    {
        private readonly IDoctor _doctor;

        public DoctorsController(IDoctor doctor)
        {
            this._doctor = doctor;
        }

        [Route("GetDoctors/{LocationId?}/{DoctorId?}")]
        public IActionResult GetDoctors(int? LocationId, int? DoctorId)
        {
            GetDoctorsViewModel viewModel = new GetDoctorsViewModel();
            viewModel.LocationList = new SelectList(_doctor.GetLocations(), "Id", "LocationName");
            if (LocationId.HasValue)
            {

                viewModel.DoctorList = new SelectList(_doctor.GetDoctorsByLocation(LocationId.Value), "Id", "Name");
            }

            if (DoctorId.HasValue)
            {
                var doctor = _doctor.GetDoctorsByLocation(LocationId.Value).FirstOrDefault(c => c.Id == DoctorId);
                viewModel.Name = doctor.Name;
                viewModel.Specialisation = doctor.Specilisation;
            }
            return View(viewModel);
        }
    }
}
