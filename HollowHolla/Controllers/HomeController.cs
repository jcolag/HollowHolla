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
                        HttpSessionStateBase session = this.Session;
                        int counter = 0;
                        string storySoFar = string.Empty;
                        List<string> lines;
                        char[] delims = { '#' };

                        if (session["Counter"] is int)
                        {
                                counter = (int)session["Counter"];
                        }

                        lines = HomeController.GetPlay(null);
                        session.Add("Lines", lines);

                        for (int idx = 0; idx < counter; idx++)
                        {
                                string line = lines[idx];
                                string post;
                                string[] elements = line.Split(delims, StringSplitOptions.None);

                                post = "<li class='hh-post'><h2>" + elements[0] + "</h2>";
                                if (elements.Length > 3)
                                {
                                        var when = DateTime.ParseExact(
                                                elements[3],
                                                "MMddHHmm",
                                                System.Globalization.CultureInfo.InvariantCulture);
                                        post += "<i><small>" + when.ToShortDateString()
                                                + " " + when.ToLongTimeString() + "</small></i><br>";
                                }

                                post += "<i>" + elements[1].Replace("*", string.Empty) + "</i><br>"
                                        + elements[2] + "</li>";
                                storySoFar += post;
                        }

                        this.ViewData["Message"] = storySoFar;
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
                        }
                        else
                        {
                                session.Add("Counter", counter);
                                session.Add("RealStart", DateTime.Now);
                        }

                        var lines = (List<string>)session["Lines"];
                        if (counter >= lines.Count)
                        {
                                this.Response.Write(null);
                        }
                        else
                        {
                                char[] delims = { '#' };
                                string line = lines[counter];
                                string[] elements = line.Split(delims, StringSplitOptions.None);
                                string timecode = elements.Length > 3 ? elements[3] : null;
                                if (HomeController.IsReadyToPost(session, timecode))
                                {
                                        this.Response.Write(line);
                                        session["Counter"] = counter + 1;
                                }
                        }

                        return null;
                }

                /// <summary>
                /// Determines whether this instance is ready to post the specified message now.
                /// </summary>
                /// <returns><c>true</c> if this instance is ready to post the specified session when; otherwise, <c>false</c>.</returns>
                /// <param name="session">User session.</param>
                /// <param name="when">Time code of post.</param>
                private static bool IsReadyToPost(HttpSessionStateBase session, string when)
                {
                        if (session == null || string.IsNullOrWhiteSpace(when))
                        {
                                return true;
                        }

                        if (session["Start"] == null)
                        {
                                session.Add("Start", HomeController.FindTime(when));
                                Console.WriteLine("Set -Start- to " + session["Start"].ToString());
                        }

                        var start = (DateTime)session["Start"];
                        var wait = HomeController.Elapsed(start, when);
                        var real = DateTime.Now - (DateTime)session["RealStart"];
                        return real >= wait;
                }

                /// <summary>
                /// Gets the play.
                /// </summary>
                /// <returns>The list of play's lines.</returns>
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

                /// <summary>
                /// Finds the time.
                /// </summary>
                /// <returns>The time.</returns>
                /// <param name="when">The current time code.</param>
                private static DateTime FindTime(string when)
                {
                        DateTime result = default(DateTime);

                        if (string.IsNullOrWhiteSpace(when))
                        {
                                return result;
                        }

                        try
                        {
                                result = DateTime.ParseExact(
                                        when,
                                        "MMddHHmm",
                                        System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch (FormatException e)
                        {
                                Console.WriteLine(e.Message);
                        }

                        return result;
                }

                /// <summary>
                /// Time elapsed from the original time and now.
                /// </summary>
                /// <param name="first">First time.</param>
                /// <param name="when">Current time code.</param>
                /// <returns>Duration between time and time code.</returns>
                private static TimeSpan Elapsed(DateTime first, string when)
                {
                        DateTime now = HomeController.FindTime(when);
                        return now - first;
                }
        }
}