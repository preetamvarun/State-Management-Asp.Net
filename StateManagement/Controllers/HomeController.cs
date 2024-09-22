using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        /* Home controller is the default controller and the Index is the default Action Method.
        You can view this in RouteConfig.cs */
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }
    }
}



/*
 
By convention, controller classes must end with Controller. So, for a URL like /Home/Index, the framework looks for a class named HomeController 
 
*/