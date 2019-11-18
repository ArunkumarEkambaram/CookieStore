using CookieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.ViewModel
{
    public class ExampleViewModel
    {
        public Object ObjectType { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
