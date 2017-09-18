using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrer(Models.Kunde innKunde, Models.Reise innReise)
        {
            using (var db = new Models.DB())
            {
                try
                {
                    db.Kunder.Add(innKunde);
                    db.SaveChanges();
                    db.Reiser.Add(innReise);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return View("Noe gikk feil med registeringen av din reise prøv igjen");

                }
                return RedirectToAction("Liste");
            }
        }
        public ActionResult Liste()
        {
            using (var db = new Models.DB())
            {
                List<Models.Kunde> alleKunder = db.Kunder.ToList();
                List<Models.Reise> alleReiser = db.Reiser.ToList();
                return View(alleKunder);
            }
            
        }
    }
}