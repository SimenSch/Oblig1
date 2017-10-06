using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication2.Models;
namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private DB db = new DB();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Home
        public ActionResult Index()
        {
          var alleReiser = db.Reiser.ToList();
            return View(alleReiser);
        }

        
        [HttpPost]
        public ActionResult Registrer(Kunde innKunde)
        {
            
            
                try
                {
                    db.alleBestillinger.Add(innKunde);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return View("Noe gikk feil med registeringen av din reise prøv igjen");

                }
                return RedirectToAction("Liste");
            
        }
        public ActionResult Liste()
        {
        
            {
                List<Kunde> alleKunder = db.alleBestillinger.ToList();
                List<Reise> alleReiser = db.Reiser.ToList();
                return View(alleKunder);
            }
            
        }

        public ActionResult Slett(int Id)
        {
            using (var db = new DB())
            {
                try
                {
                    Kunde slettKunde = db.alleBestillinger.Find(Id);
                    db.alleBestillinger.Remove(slettKunde);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    // her bør det komme noe mer
                }
            }
            return RedirectToAction("Liste");
        }
    }
}