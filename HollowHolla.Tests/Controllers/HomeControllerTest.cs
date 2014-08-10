// <copyright file="HomeControllerTest.cs" company="John Colagioia">
//     John.Colagioia.net. Licensed under the GPLv3
// </copyright>
// <author>John Colagioia</author>
namespace HollowHolla.Tests
{
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Web.Mvc;
        using HollowHolla;
        using HollowHolla.Controllers;
        using NUnit.Framework;

        /// <summary>
        /// Home controller tests.
        /// </summary>
        [TestFixture]
        public class HomeControllerTest
        {
                /// <summary>
                /// Index for this instance.
                /// </summary>
                [Test]
                public void Index()
                {
                        // Arrange
                        var controller = new HomeController();

                        // Act
                        var result = controller.Index() as ViewResult;

                        // Assert
                        Assert.AreEqual("Welcome to ASP.NET MVC on Mono!", result.ViewData["Message"]);
                }
        }
}
