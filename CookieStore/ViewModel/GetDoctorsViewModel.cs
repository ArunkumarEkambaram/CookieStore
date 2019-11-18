using CookieStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.ViewModel
{
    public class GetDoctorsViewModel
    {
        public SelectList LocationList{ get; set; }
        public SelectList DoctorList { get; set; }

        public int LocationId { get; set; }

        public Doctor Doctor{ get; set; }

        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialisation { get; set; }
    }
}
