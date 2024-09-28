using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StateManagement.Models;

namespace StateManagement.Controllers
{
    public class CustomerController : Controller
    {

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult DisplayCustomers()
        {
            Customer c1 = new Customer
            {
                CustId = 1,
                Account = "Saving Account",
                Balance = 232342,
                City = "Veck",
                Name = "Customer-1",
                Photo = "~/Images/Img-1.jpg",
                Status = "Active"
            };
            Customer c2 = new Customer
            {
                CustId = 2,
                Account = "Saving Account",
                Balance = 23234342,
                City = "Veck",
                Name = "Customer-2",
                Photo = "~/Images/Img-2.jpg",
                Status = "Active"
            };
            Customer c3 = new Customer
            {
                CustId = 3,
                Account = "Saving Account",
                Balance = 23342342,
                City = "Veck-3",
                Name = "Customer-3",
                Photo = "~/Images/Img-3.jpg",
                Status = "Active"
            };
            Customer c4 = new Customer
            {
                CustId = 4,
                Account = "Saving Account",
                Balance = 23233442 - 4,
                City = "Veck-4",
                Name = "Customer-4",
                Photo = "~/Images/Img-4.jpg",
                Status = "Active"
            };
            Customer c5 = new Customer
            {
                CustId = 5,
                Account = "Saving Account",
                Balance = 23234452,
                City = "Veck-5",
                Name = "Customer-5",
                Photo = "~/Images/Img-5.jpg",
                Status = "Active"
            };
            List<Customer> customers = new List<Customer> { c1, c2, c3, c4, c5 };
            return View(customers);
        }
    }
}