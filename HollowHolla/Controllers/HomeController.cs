// <copyright file="HomeController.cs" company="John Colagioia">
//     John.Colagioia.net. Licensed under the GPLv3
// </copyright>
// <author>John Colagioia</author>
namespace HollowHolla.Controllers
{
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        using System.Web.Mvc.Ajax;

        /// <summary>
        /// Home controller.
        /// </summary>
        public class HomeController : Controller
        {
                /// <summary>
                /// Index for this session.
                /// </summary>
                /// <returns>The HTTP Action Result.</returns>
                public ActionResult Index()
                {
                        this.ViewData["Message"] = "Welcome to ASP.NET MVC on Mono!";
                        return this.View();
                }

                /// <summary>
                /// Get this session's next post.
                /// </summary>
                /// <returns>The HTTP Action Result.</returns>
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