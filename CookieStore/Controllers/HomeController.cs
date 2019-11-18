using CookieStore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieStore.Models;
using CookieStore.ViewModel;
using AutoMapper;

namespace CookieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public HomeController(IRepository<Customer> customerRepository, IMapper mapper)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            ViewBag.PageTitle = "Index Customer";
            var customers = _customerRepository.GetAll();
            return View(customers);           
        }

        public IActionResult Details(int? id)
        {            
            var Customer = _customerRepository.GetById(id.Value);
            ViewData["Customer"] = Customer;
            ViewBag.PageTitle = "Customer Details";
            return View(Customer);
        }

        [HttpGet]
        public IActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public IActionResult Create(CustomerViewModel customerFromView)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
         
            Customer customer = _mapper.Map<Customer>(customerFromView);

            _customerRepository.Add(customer);
            return RedirectToAction("Index");
        }
    }
}
