﻿using System;
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
         * Every session is going to a expiration time (aka sliding expiration). Generally, it is 20minutes. But it varies from server to server.
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


    }
}



/*
Home controller is the default controller and the Index is the default Action Method. You can view this in RouteConfig.cs 
By convention, controller classes must end with Controller. So, for a URL like /Home/Index, the framework looks for a class named HomeController 
*/