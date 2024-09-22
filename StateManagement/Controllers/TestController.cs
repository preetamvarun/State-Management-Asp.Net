using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Web.UI.WebControls;

namespace StateManagement.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public ViewResult DisplaySinger()
        {
            return View("~/Views/Test/DisplaySinger.cshtml");
        }

        [HttpGet]
        public ViewResult DisplayCricketer()
        {
            return View("~/Views/Test/DisplayCricketer.cshtml");
        }
    }
}