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
    }
}



/*
Home controller is the default controller and the Index is the default Action Method. You can view this in RouteConfig.cs 
By convention, controller classes must end with Controller. So, for a URL like /Home/Index, the framework looks for a class named HomeController 
*/