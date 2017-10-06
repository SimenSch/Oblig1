using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication2.Models;
using System.Web.Script.Serialization;

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
        
        public string HentFlyplass()
        {
            using (var db = new DB())
            {
                List<Reise> alleFly = db.Reiser.ToList();

                var alleFraFly = new List<string>();

                foreach (Reise f in alleFly)
                {
                    string funnetStrekning = alleFraFly.FirstOrDefault(fl => fl.Contains(f.Utreise));
                    if (funnetStrekning == null)
                    {
                        // ikke funnet strekning i listen, legg den inn i listen
                        alleFraFly.Add(f.Utreise);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFraFly);
            }
        }
        /*
         */

        [HttpPost]
        public ActionResult Registrer(Models.Kunde innKunde)
        {
            using (var db = new Models.DB())
            {
                try
                {
                    db.Kunder.Add(innKunde);
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
        public ActionResult Kunde()
        {
            using (var db = new Models.DB())
            {
                List<Models.Reise> alleReiser = db.Reiser.ToList();
                return View(alleReiser);
            }

        }

        public ActionResult Slett(int Id)
        {
            using (var db = new Models.DB())
            {
                try
                {
                    Models.Kunde slettKunde = db.Kunder.Find(Id);
                    db.Kunder.Remove(slettKunde);
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