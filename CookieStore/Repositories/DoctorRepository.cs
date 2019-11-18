using CookieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CookieStore.Repositories
{
    public interface IDoctor
    {
        IEnumerable<Doctor> GetDoctorsByLocation(int id);
        IEnumerable<Location> GetLocations();
    }

    public class DoctorRepository : IDoctor
    {
        private ApplicationDbContext _dbContext = null;

        public DoctorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Doctor> GetDoctorsByLocation(int LocationId)
        {
            var doctors = from d in _dbContext.Doctors
                          join l in _dbContext.Locations
                          on d.LocationId equals l.Id
                          where d.LocationId == LocationId
                          select d;

            return doctors;

        }

        public IEnumerable<Location> GetLocations()
        {
            return _dbContext.Locations.ToList();
        }
    }
}
