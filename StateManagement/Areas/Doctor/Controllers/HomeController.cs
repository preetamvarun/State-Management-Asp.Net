using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Areas.Doctor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Doctor/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}