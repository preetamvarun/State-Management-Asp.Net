using StateManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    public class ActionResultsController : Controller
    {

        #region LearnActionResults
        /*
         * Action Methods In Asp.Net MVC5 can return various types of results which are known as ActionResults. 
         * In MVC, "Action Result" is a class and this class has various child classes under it and an Action Method can return any of those classes.
         * Either parent classs "Action Result" or its child class. 
         * Controller class (The parent of all the controllers that we define) provides various helper methods to return a result, where each method returns
         * a different Action Result.
         * Action Result                <---->                  Helper Method
         * File Result                                          File
         * Json Result                                          Json
         * View Result                                          View
         * EmptyResult                                         ----- (No Helper Method, You just return an instance of the Empty Result class)
         * Content Result                                       Content
         * Redirect Result                                      Redirect
         * Javascript Result                                    Javascript (No Longer Supported)
         * PartialView Result                                   PartialView
         * HttpNotFoundResult                                   HttpNotFound
         * HttpUnauthorizedResult                               HttpStatusCodeResult
         * RedirectToRouteResult                                RedirectToRoute
         * RedirectToRouteResult                                RedirectToAction
        */
        #endregion
        // GET: ActionResults
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEmployees()
        {
            Employee e1 = new Employee { Id = 101, Name = "Scott", Job = "CEO", Salary = 25000, Status = true };
            Employee e2 = new Employee { Id = 102, Name = "Smith", Job = "President", Salary = 22000, Status = true };
            Employee e3 = new Employee { Id = 103, Name = "Parker", Job = "Manager", Salary = 18000, Status = true };
            Employee e4 = new Employee { Id = 104, Name = "John", Job = "Salesman", Salary = 10000, Status = true };
            Employee e5 = new Employee { Id = 105, Name = "David", Job = "Clerk", Salary = 5000, Status = true };
            Employee e6 = new Employee { Id = 106, Name = "Maria", Job = "Analyst", Salary = 12000, Status = true };
            List<Employee> employees = new List<Employee> {e1,e2,e3,e4,e5,e6};
            return Json(employees,JsonRequestBehavior.AllowGet); // AllowGet : GetRequest, DenyGet : PostRequest
        }

        [HttpGet]
        public FileResult DownloadPdf()
        {
            return File("~/Downloads/Pcv.pdf", "application/pdf");
        }

        [HttpGet]
        public RedirectResult OpenFacebook()
        {
            return Redirect("https://www.facebook.com");
        }

        [HttpGet]
        public ContentResult GetDate()
        {
            return Content("Current Date is : " + DateTime.Now.ToString());
        }

        [HttpGet]
        public ContentResult SayHello()
        {
            return Content("नमस्तेआप कैसेहैं", "text/plain", Encoding.Unicode);
        }

        [HttpGet]
        public JavaScriptResult Alert()
        {
            return JavaScript("alert('Hello! How are you?')"); // No Longer Supported : Script will be shown to the user
        }

        [HttpGet]
        public EmptyResult ReturnEmpty()
        {
            return new EmptyResult();
        }
    }
}