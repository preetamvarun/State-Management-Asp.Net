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
        // GET: Test
        public ViewResult DisplaySinger()
        {
            return View("~/Views/Test/DisplaySinger.cshtml");
        }
    }
}