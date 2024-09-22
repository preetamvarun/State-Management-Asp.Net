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



    }
}



/*
Home controller is the default controller and the Index is the default Action Method. You can view this in RouteConfig.cs 
By convention, controller classes must end with Controller. So, for a URL like /Home/Index, the framework looks for a class named HomeController 
*/