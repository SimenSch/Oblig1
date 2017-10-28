using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApplication2.Model;
using System.Web.Script.Serialization;
using WebApplication2.DAL;
using WebApplication2.BLL;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        private DB db = new DB();

        
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
            var db = new CryanairBLL();
            List<destinasjoner> destinasjoner = db.AlleDestinasjoner();
            return View(destinasjoner);
        }
        
        //tor sin kode for innlogging ViewBag.Innlogget brukes i Innlogging for å sjekke om vi er innlogget eller ikke. se Innlogging.cshtml linje 40
        public ActionResult Innlogging()
        {
            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

            return View();
        }
        [HttpPost]
        public ActionResult Innlogging(bruker innBruker)
        {
            if (Funksjoner.BrukerInnloggingsjekk_i_DB(innBruker))
            {
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return View();
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }
        // tors Innloggingskode
        public ActionResult InnLoggetSide()
        {
            var db = new DbBestilling();
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View(db.AlleReiser());
                }
            }
            return RedirectToAction("Innlogging");


        }
        public ActionResult SlettReisen(int id)
        {
            var db = new DbBestilling();
            bool OK = db.SlettReise(id);
            if (OK)
            {
                return RedirectToAction("InnloggetSide");
            }
            return View();
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
         /*
        [HttpPost]
        public ActionResult Registrer(Kunde innKunde)
        {
            var db = new CryanairBLL();
                try
                {
                    db.AlleBestillinger.Add(innKunde);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    return View("Noe gikk feil med registeringen av din reise prøv igjen");

                }
                return RedirectToAction("Liste");
            
        }*/
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
            var nyBruker = new dbBruker();
            if (DbBestilling.BrukerRegisteringSjekk_i_DB(nyBruker.BrukerId))
                {


                try
                {
                    
                    byte[] passordDb = DbBestilling.lagHash(innBruker.passord);
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
            else
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
       
    }
}