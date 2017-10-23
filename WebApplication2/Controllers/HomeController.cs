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
        /* Disse fungerer desverre ikke
        public ActionResult lagreKunde()
        {
            return View();
        }
        [HttpPost]
        public ActionResult lagreKunde(kunde innkunde)
        {
            var db = new DbBestilling();
            bool ok = db.Lagrekunde(innkunde);
            return View();
        }*/
        // GET: Home
        public ActionResult Index()
        {
            List<Destinasjoner> destinasjoner = db.Destinasjoner.ToList();
            return View(destinasjoner);
        }

        public ActionResult Registrer()
        {
            return View();
        }

        public string HentFlyplass()
        {
                List<Destinasjoner> alleFly = db.Destinasjoner.ToList();

                var alleFraFly = new List<string>();

                foreach (Destinasjoner d in alleFly)
                {
                    string funnetStrekning = alleFraFly.FirstOrDefault(fl => fl.Contains(d.Flyplass));
                    if (funnetStrekning == null)
                    {
                        // ikke funnet strekning i listen, legg den inn i listen
                        alleFraFly.Add(d.Flyplass);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                return jsonSerializer.Serialize(alleFraFly);
            
        }
        [HttpPost]
        public string HentPris(string fraDest)
        {

            List<Destinasjoner> alleDest = db.Destinasjoner.ToList();
            List<Destinasjoner> valgtDest = new List<Destinasjoner>();

            valgtDest = alleDest.Where(alle => alle.Flyplass.Equals(fraDest)).ToList();

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(valgtDest);
            return json;
            
        }
       
        
        /* public string HentPrisen()
         {
             List<Destinasjoner> alleFly = db.Destinasjoner.ToList();

             var Prisen = new List<int>();

             foreach (Destinasjoner d in alleFly)
             {
                 int funnetPris = Prisen.FirstOrDefault(fl => fl.Contains(d.Pris));
                 if (funnetPris == null)
                 {
                     // ikke funnet strekning i listen, legg den inn i listen
                     Prisen.Add(d.Pris);
                 }
             }
             var jsonSerializer = new JavaScriptSerializer();
             return jsonSerializer.Serialize(Prisen);

         }*/

        /*
         */

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
        public ActionResult BrukerRegisstrering()
        {
            return View();
        }
        //tor sin kode for å registrere Hashet passord med bruker
        [HttpPost]
        public ActionResult BrukerRegisstrering(bruker innBruker)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
           
            
                try
                {
                    var nyBruker = new dbBruker();
                    byte[] passordDb = Funksjoner.lagHash(innBruker.passord);
                    nyBruker.Passord = passordDb;
                    nyBruker.BrukerId = innBruker.brukerId;
                    db.Brukere.Add(nyBruker);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception feil)
                {
                    return View();
                }
            
        }
        public ActionResult Liste()
        {
        
            {
                List<Kunde> alleKunder = db.alleBestillinger.ToList();
                List<Reise> alleReiser = db.Reiser.ToList();
                return View(alleKunder);
            }
            
        }
        public ActionResult Kunde()
        {
           
            {
                List<Reise> alleReiser = db.Reiser.ToList();
                return View(alleReiser);
            }

        }
        public ActionResult destinasjoner()
        {
            var db = new DbBestilling();
            
           
            return View();
            
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