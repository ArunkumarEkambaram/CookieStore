using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specilisation { get; set; }
        public virtual Location Location { get; set; }
        public int LocationId { get; set; }
    }
}
