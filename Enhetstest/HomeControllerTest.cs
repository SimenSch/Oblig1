using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.BLL;
using WebApplication2.DAL;
using WebApplication2.Model;
using WebApplication2.Controllers;
using System.Web.Mvc;

namespace Enhetstest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Liste_i_view()
        {
            var controller = new HomeController(new DbBestilling());
                    var innReise = new reise()
                        {
                        utreise= "Trondheim",
                        hjemreise = "Oslo",
                        turtid = "2017-11-05",
                        returtid = "2017-11-12",
                        billettpris = 499
                    };
                    // Act
                    var resultat = (RedirectToRouteResult)controller.Reg(innReise);
                    // Assert
                    Assert.AreEqual(resultat.RouteName, "");
                    Assert.AreEqual(resultat.RouteValues.Values.First(), "Liste");
        }
        public void Registrer_feil_validering_Post()
        {
            // Arrange
            var controller = new HomeController(new DbBestilling());
            var innReise = new reise();
            controller.ViewData.ModelState.AddModelError("fornavn", "Ikke oppgitt fornavn");
            // Act
            var resultat = (ViewResult)controller.Reg(innReise);
            // Assert
            Assert.IsTrue(resultat.ViewData.ModelState.Count == 1);
            Assert.AreEqual(resultat.ViewName, "");
        }
        [TestMethod]
        public void Registrer_feil_Post()
        {
            // Arrange
            var controller = new HomeController(new DbBestilling());
            var kunde = new kunde();
            kunde.fornavn = ""; // gir en feil i innsetingen fra stub.
                                // Act
            var actionResult = (ViewResult)controller.RegKunde(kunde);
            // Assert
            Assert.AreEqual(actionResult.ViewName, "");
        }


    }
}
