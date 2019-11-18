using CookieStore.Common;
using CookieStore.Interfaces;
using CookieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.Repositories
{
    public class CustomerRepository : IRepository<Customer>, ISearchCustomer
    {
        ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Customer obj)
        {
            if (obj != null)
            {
                _db.Customers.Add(obj);
                Save();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new NotFoundHandler("Searching Id doesn't exist");
            }
            return customer;
        }

        public (string, string) GetNameCityById(int id)
        {
            var customer = _db.Customers.FirstOrDefault(c => c.Id == id);
            return (customer.Name, customer.City);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
