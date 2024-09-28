using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class LayoutController : Controller
    {
        public ViewResult Home()
        {
            return View();
        }
        public ViewResult Register()
        {
            return View();
        }
        public ViewResult Login()
        {
            return View();
        }
        public ViewResult Courses()
        {
            return View();
        }
        public ViewResult About()
        {
            return View();
        }
    }
}