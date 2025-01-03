﻿using StateManagement.Models;
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

        #region PracticeCookies


        #region CookieNotes
        /*
         * Cookie is a small piece of information that is stored in the client computer 
         * To create a cookie we are going to use HttpCookie Class.
         * Then assign value to the cookie object
         * To add the cookie in the client side computer : Response.Cookies.Add(your_cookie);
         * Be default, Every cookie is an in-memory cookie. That means cookie will be destroyed after the browser has been closed.
         * If you want to make the cookie persistant : your_cookie.Expires = DateTime.Now.AddDays(2);
         * To read a cookie : HttpCookie your_cookie = Request.Cookies["login cookie"];
         * cookies can store only string data types. 
         * Cookie is accessible in all the pages
        */
        #endregion

        #region CookieDrawBacks
        /*
         * We can only store 50 cookies per website
         * If we add a 51st cookie 1st cookie will be deleted.
         * Cookies can store max 4KB of data
         * Cookies are not secured as they are stored in the client computer
         * End users can disable or delete the cookies 
        */
        #endregion

        [HttpGet]
        public ViewResult FavouriteSingerDetails()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult FavouriteSingerDetails(string sname, string sethnicity, int sage)
        {
            // Create a cookie here
            HttpCookie Singer_Cookie = new HttpCookie("Singer_Cookie");

            // Store the values in a cookie
            Singer_Cookie["Name"] = sname;
            Singer_Cookie["Country"] = sethnicity;

            // This is because cookeis can only store string datatypes
            Singer_Cookie["Age"] = sage.ToString();

            // Make this cookie a persistant cookie
            Singer_Cookie.Expires = DateTime.Now.AddDays(1);


            // Finally, store this cookie in the client's browser
            Response.Cookies.Add(Singer_Cookie);


            return RedirectToAction("DisplaySinger", "Test");
        }


        #endregion

        #region PracticeSessions

        #region SessionNotes
        /*
         * Session is some memory allocated for every user connected to the server. 
         * The Main difference between a session and a cookie is session is stored on the server while a cookie is stored in the client computer
         * Unlike cookies, clients don't have any control over the sessions
         * sessions can store any type of data. Not Just strings
         * There is no size limit for sessions and one session can't be accessible in another session. Session : Single user global data.
         * Storing and accessing the values from session is same as storing and accessing the values from temp data and view data.
         *                          HOW SESSIONS WORK IF REST APIS ARE STATELESS            
         * In stateless Architecture, If a client sends a requests and the servers responds back to the client then the connection will be cut off b/w the client and the server.
         * So, How does the server know to associate a session that has already been created to a user if he again sends a new request. Or how will the server to create a 
         * new session for the user (if he is requesting for the first time).
         * Here comes the role of Session-ID
         * This Session-ID is an alpha numeric string stored in the form of in-memory cookie. So, whenever a client comes with a subsequent request, he comes with this 
         * Session-ID, and server reads this Session-ID from the cookie and associates the user with his session.
         * Every session is going to have a expiration time (a.k.a sliding expiration). Generally, it is 20minutes. But it varies from server to server.
         * If a user fails to send a request within 20minutes from the last request, then the server is going to destroy the session. 
         * We can explicitly destroy the session though by calling the abandon method. Session.Abandon(); We do this in variety of scenarios. (Like when a user logs out)
         * so where exactly the server is going to store these session values? There are three places actually
         * 
         *              (i) In-Proc
         *              (ii) State Server
         *              (iii) Sql Server
         * 
         * 
         * In proc : session values can be stored directly under the webservers memory. Meaning, when we are talking about websites that are deployed in IIS, one more more 
         * websites can be placed under an application pool. Application pool is like a container of applications. You can have one or more applications inside one application
         * pool. So, we have something known as worker process inside an application pool that manages the applications in the inside an application pool. If an application pool
         * has more than one application then worker process has to manage all the applications inside that application pool. If the session values are stored in the memory of 
         * the worker process (w3wp.exe), If you stop the worker process and give a refresh, then all the sessions values for that particular application will be gone. If a worker
         * process is managing more than one application then all the session values in all the applications under that worker process will be gone. That is why, It is usually a
         * good idea to store one application in an application pool.
         * 
         * 
         * State Server : This is altogether a separate software provided by the microsoft to store the session values. Checkout the line in web.config file. Recyle the state
         * server and the sesssion values will be gone.
         * 
         * SQL Server : If you are storing the values in the sql server then you have two options. (i) Persisted (ii) Temporary
         * In temporary, if you restart the SQL server, then all the session values will be gone.
         * checkout the line the web.config file.
         * 
        */
        #endregion
        [HttpGet]
        public ViewResult FavouriteCricketerDetails()
        {
            return View();
        }


        [HttpPost]
        public RedirectToRouteResult FavouriteCricketerDetails(string cname, int cage)
        {
            Session["Cricketer Name"] = cname;
            Session["Cricketer Age"] = cage;
            return RedirectToAction("DisplayCricketer", "Test");
        }



        #endregion

        #region LearnApplications

        #region ApplicationsNotes
        /*
         * Sessions are single user global data, whereas Applications are multiple user global data.
         * User's - 1 data stored in the application memory can be accessed by User-2.
         * Here we need to consider thread safety. If mutliple users are accessing the same memory we need to take thread safety into the account.
         * Application state data is not thread safe. So, when we are using application memory it is our responsibility to lock and unlock. 
         * Application state data is stored in the memory of the web server and is faster than storing and retrieving information from the database. 
         * This data doesn't have any expiration date like session data. When we recycle the worker process or restart the webserver then application state data will be lost.
        */
        #endregion
        [HttpGet]
        public ViewResult App()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AppAction()
        {
            return View("~/Views/Home/Facts.cshtml");
        }

        [HttpPost]
        public RedirectToRouteResult App(string es, string sr, string pwd)
        {
            HttpContext.Application.Lock();
            HttpContext.Application["es"] = es;
            HttpContext.Application["sr"] = sr;
            HttpContext.Application["pwd"] = pwd;
            HttpContext.Application.UnLock();
            return RedirectToAction("AppAction");
        }

        #endregion

        #region LearnAnonymousTypes

        #region Notes
        /*
         * This is another mechanism using which we can transfer the values from action method to action method (of another class or of same class) without using
         * view data, view bag, temp data, session. 
         * An Anonymous type is a class without a name that contains read only properties for which we can create an instance with the help of new keyword.
         * var emp = new {...object initializer...}
         * The class is defined for you by the compiler with all the attributes. 
         * When you want the usage for only one time then Anonymous Types are better
        */
        #endregion


        [HttpGet]
        public ViewResult AnonymousTypes()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AnonymousTypes(string EmpName, int EmpAge, string Department)
        {
            var Emp = new { EmpName, EmpAge, Department };
            return View("ProcessAnonType", Emp);
            // can't we pass this object to another action method and from there can't we send it another view?
        }




        #endregion

        #region LearnModels

        #region Notes
        /*
         * In Anonymous types we have created an instance without a class and used it only once. While with Models we will be having classes under Models folder.
         * We will use Models for multi purpose
         * With Models we will Intellisense support and type safety (remember we have type safety with ViewBags)
        */
        #endregion

        [HttpGet]
        public ViewResult Product()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Product(Product Product)
        {
            return View("ProcessProduct", Product);
        }


        #endregion

        #region FormCollections
        [HttpGet]
        public ViewResult Cricketer()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Cricketer(FormCollection FC)
        {
            ViewData["cname"] = FC["cname"];
            ViewData["cage"] = FC["cage"];
            ViewData["cethnicity"] = FC["cethnicity"];
            return View("ProcessCricketer");
        }
        #endregion

        #region HTMLHelpers
        #region Notes
        /*
         * We can design views by using HTML controls, HTML helpers and Strongly Typed HTML Helpers
         * To help us simplify the UI designing process MVC provides HTML Helper Methods and these helper methods render the required HTML code
         * @Html.TextBox("Job") => <input type = "text" id = "Job" name = "Job"/>
         * @{Html.BeginForm(); Html.EndForm();} or @using(Html.BeginForm()) {....}
         * HTML form => default method is get, HTML Helper Form => default method is post 
         * Submit and reset don't have any helper methods 
         * You can pass additional HTML attributes as anonymous types
        */
        #endregion

        [HttpGet]
        public ViewResult Person()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Person(FormCollection Fc)
        {
            ViewData["pname"] = Fc["pname"];
            ViewData["page"] = Fc["page"];
            ViewData["pdept"] = Fc["dept"];
            ViewData["pgender"] = Fc["pgender"];
            ViewData["pcheckbox"] = Fc["pcheck"];
            ViewData["ppwd"] = Fc["pwd"];
            return View("~/Views/Home/DisplayPerson.cshtml");
        }
        #endregion

        #region StronglyTypedHTMLHelpers
        #region Notes
        /*
         * With strongly typed HTML helpers we get the intellisense support. Put all the id and name attribute values in a Model class.
        */
        #endregion

        [HttpGet]
        public ViewResult Animal()
        {
            return View();
        }


        [HttpPost]
        public ViewResult Animal(Animal animal)
        {
            return View("~/Views/Home/DisplayAnimal.cshtml", animal);
        }

        #endregion

        #region PartialView
        /*
         * A partial view is also a view that can be used in other view(s).
         *  They provide reusability 
         *  partial views are stored in the shared folder because they are consumed by other views in an application.
         *  Naming convention for partial views : starts with an underscore (to differentiated them from other views)
         *  partial views don't have a head tag or a body tag
         *  To render a partial view, we write @{ Html.RenderPartial("_pviewname"); }
         *  There are three ways to render a partial view : 
         *  @{ Html.RenderPartial("_pviewname"); }
         *  @{ Html.Partial("_pviewname"); }
         *  @{Html.RenderAction("ActionMethodName")}
        */
        [HttpGet]
        public PartialViewResult PartialAction()
        {
            return PartialView("_Welcome");
        }

        #endregion

        #region LearnLayoutViews
        /*
         * Layout view will be only one and content views will come and sit in the layout view
         * To include a content view into a particular location of a layout view we need to call a method called RenderBody.
         * A layout view can contain only 1 RenderBody method call.
         * To include a piece of text inside a layout view we need to call RenderSection method. n number of these methods can be present.
         * RenderSection(string name, bool required) required = true, value to the rendersection is mandatory else optional.
         * Just like partial views layout views are also stored in shared folder and starts with underscore (general naming convention).
         * If you want to apply any Layout to a view, we can do in two different ways : 
         * (i) Page Level Binding : @{Layout = "~/Views/Shared/_SiteMaster.cshtml"}
         * (ii) Application level binding :  @{Layout = "~/Views/Shared/_SiteMaster.cshtml"} in _ViewStart.cshtml file
        */
        #endregion

        #region LearnBundling&Minification
        /*
         * Bundling and Minification are two techniques we use in web applications to reduce the load time. 
         * Bundling : Reducing the no of requests to the server (to get the assets)
         * Minification : Reducing the size of the assets (css & js) [Removing unnecessary white spaces, line breaks, comments, shortening variable names]
         * Most of the modern browsers are capable of sending 6 simultaneous requests to the server. 
         * That means while 6 requests are being processed additional requests are queued by the browser.
         * To perform bundling we need to take the help of "Web Optimization Framework" library (install via nugget package manager)
         * This library has set of classes
         * Style Bundle : This represents a collection of style sheet files
         * Script Bundle : This represents a collection of script files
         * Bundle Collection : This represents a set of style bundles and script bundles
         * Bundle Table : This is a holder class for the Bundle collection
         * In Asp.Net MVC projects you have to manually include files in the project (show all files -> include in the project)
        */
        #endregion

        #region Areas
        /*
         * It is an appraoch of dividing a large mvc application into smaller units where each unit will have its own model, view and controller.
        */
        #endregion

        #region DataAnnotations 
        [HttpGet]
        public ViewResult Member()
        {
            return View();
        }


        [HttpPost]
        public ViewResult Member(Member Mem)
        {
            // If client side validations are failed for some reason 
            // server will again do all the validations. Look at the property below 
            if(ModelState.IsValid) return View("ProcessMember", Mem);
            return View("Member");
        }


        public JsonResult AgeValidator(DateTime DOB)
        {
            bool Status = (DOB > DateTime.Now.AddYears(-18)) ? false : true;
            return Json(Status, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}



/*
Home controller is the default controller and the Index is the default Action Method. You can view this in RouteConfig.cs 
By convention, controller classes must end with Controller. So, for a URL like /Home/Index, the framework looks for a class named HomeController 
*/