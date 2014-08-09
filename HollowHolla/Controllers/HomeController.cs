using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace HollowHolla.Controllers
{
        public class HomeController : Controller
        {
                public ActionResult Index()
                {
                        ViewData["Message"] = "Welcome to ASP.NET MVC on Mono!";
                        return View();
                }

                [AcceptVerbs(HttpVerbs.Get)]
                public ActionResult Next()
                {
                        HttpSessionStateBase session = this.Session;
                        int counter = 1;
                        if (session["Counter"] is int)
                        {
                                counter = (int)session["Counter"];
                                session["Counter"] = counter + 1;
                        }
                        else
                        {
                                session.Add("Counter", counter + 1);
                        }

                        this.Response.Write("Item #" + counter.ToString());
                        return null;
                }
        }
}