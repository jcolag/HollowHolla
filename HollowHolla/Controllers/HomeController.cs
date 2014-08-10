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
                        List<string> lines = HomeController.GetPlay(null);
                        Session.Add("Lines", lines);
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
                        int counter = 0;
                        if (session["Counter"] is int)
                        {
                                counter = (int)session["Counter"];
                                session["Counter"] = counter + 1;
                        }
                        else
                        {
                                session.Add("Counter", counter + 1);
                        }

                        var lines = (List<string>)session["Lines"];
                        if (counter >= lines.Count)
                        {
                                this.Response.Write(null);
                        }
                        else
                        {
                                this.Response.Write(lines[counter]);
                        }
                        return null;
                }

                /// <summary>
                /// Gets the play.
                /// </summary>
                /// <returns>The play.</returns>
                /// <param name="filename">Filename containing the formatted play.</param>
                private static List<string> GetPlay(string filename)
                {
                        string[] delimiters = { Environment.NewLine };
                        string filePath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
                        string fname = filePath + "Content/play.txt";
                        if (!string.IsNullOrWhiteSpace(filename))
                        {
                                fname = filename;
                        }

                        var read = new System.IO.StreamReader(fname);
                        string text = read.ReadToEnd();
                        string[] lines = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                        var result = new List<string>(lines);
                        return result;
                }
        }
}