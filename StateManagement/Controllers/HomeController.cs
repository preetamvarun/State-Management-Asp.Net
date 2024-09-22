using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        #region
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
        #endregion


        #region ViewData

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
       
        [HttpPost]
        public ViewResult Login(string uname, string pwd)
        {
            ViewData["username"] = uname;
            ViewData["password"] = pwd;
            return View("ProcessLogin");

            /*
                ViewData is private in scope meaning, data here can be transferred from a controllers action method to it's corresponding view only. Here in this case
                data can be transferred from Homecontroller's login action method to its corresponding view only which is ProcessLogin View.

            */
        }

        #endregion


        #region PracticeViewBag
        [HttpGet]
        public ViewResult Registration()
        {
            return View();
        }


        [HttpPost]
        public ViewResult Registration(string fname, string lname, int age)
        {
            ViewBag.fname = fname;
            ViewBag.lname = lname;
            ViewBag.age = age;
            return View("ProcessRegistration");

            /*
             * ViewBags came after ViewData
             * ViewBag internally uses ViewData
             * ViewBag has also limited scope only just like ViewData
            */

        }
        #endregion


        #region PracticeTempData

        /*
        The only difference between the TempData and the ViewData is the scope.
        Temp Data has got better scope than ViewData.
        Values in Temp Data can persist across multiple http requests. 
         */


        [HttpGet]
        public ViewResult PurchaseProduct()
        {
            return View();
        }

        [HttpGet]
        public ViewResult DisplayProductDetails()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult PurchaseProduct(string pname, double pprice, string cname)
        {
            TempData["ProductName"] = pname;
            TempData["ProductPrice"] = pprice;
            TempData["CountryName"] = cname;
            return RedirectToAction("DisplayProductDetails");
        }

        #endregion


    }
}



/*
Home controller is the default controller and the Index is the default Action Method. You can view this in RouteConfig.cs 
By convention, controller classes must end with Controller. So, for a URL like /Home/Index, the framework looks for a class named HomeController 
*/