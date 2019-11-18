using CookieStore.Models;
using CookieStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieStore.Controllers
{
    public class CSharp7Controller : Controller
    {
        public IActionResult Index()
        {
            ExampleViewModel viewModel = new ExampleViewModel();
           
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(ExampleViewModel viewModel)
        {
            if(viewModel is null)
            {
                throw new ArgumentNullException();
            }

            if(viewModel.ObjectType is  Customer customer)
            {
                return Content("Customer");
            }

            if(viewModel.ObjectType is Orders orders)
            {
                return Content("Orders");
            }
            return View();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{Id=1, Name="Kannan"},
                new Customer{Id=2,Name="Kumar"},
                new Customer{Id=3,Name="Senthil"},
                new Customer{Id=4,Name="Jameel"},
                new Customer{Id=5,Name="Vinoth"}
            };

            return customers;
        }

        public IEnumerable<Orders> GetOrders()
        {
            List<Orders> orders = new List<Orders>
            {
                new Orders{OrderId=1, OrderDate=DateTime.Now.AddDays(2)},
                new Orders{OrderId=2, OrderDate=DateTime.Now.AddDays(-2)},
                new Orders{OrderId=3, OrderDate=DateTime.Now.AddDays(3)},
                new Orders{OrderId=4, OrderDate=DateTime.Now.AddDays(3)},
                new Orders{OrderId=5, OrderDate=DateTime.Now.AddDays(3)},
                new Orders{OrderId=6, OrderDate=DateTime.Now.AddDays(3)},
            };
            return orders;
        }
    }
}