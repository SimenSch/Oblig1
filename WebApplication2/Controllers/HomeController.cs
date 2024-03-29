﻿using System;
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

        public ActionResult Index()
        {
            var db = new CryanairBLL();
            List<destinasjoner> destinasjoner = db.AlleDestinasjoner();
            return View(destinasjoner);
        }

        public ActionResult AdminSide()
        {
            var db = new DbBestilling();
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Innlogging");
        }
        //innlogging:
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
        public ActionResult InnLoggetSideLog()
        {
            var db = new DbBestilling();
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View(db.AlleLog());
                }
            }
            return RedirectToAction("Innlogging");

        }
            public ActionResult InnLoggetSideKunde()
        {
            var db = new DbBestilling();
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View(db.alleBestillinger());
                }
            }
            return RedirectToAction("Innlogging");


        }
        public ActionResult InnLoggetSideDestinasjon()
        {
            var db = new DbBestilling();
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View(db.AlleDestinasjoner());
                }
            }
            return RedirectToAction("Innlogging");


        }
        //registreringsobjekter:
        public ActionResult RegDestinasjon(destinasjoner innDestinasjon)
        {

            var db = new DbBestilling();
            bool OK = db.LagreDestinasjon(innDestinasjon);
            if (OK)
            {
                return RedirectToAction("InnloggetSideDestinasjon");
            }
            return View();
        }
        public ActionResult RegKunde(kunde innKunde)
        {

            var db = new DbBestilling();
            bool OK = db.LagreKunden(innKunde);
            if (OK)
            {
                return RedirectToAction("InnloggetSideKunde");
            }
            return View();
        }
        public ActionResult Reg(reise innReise)
        {

            var db = new DbBestilling();
            bool OK = db.LagreReise(innReise);
            if (OK)
            {
                return RedirectToAction("InnloggetSide");
            }
            return View();
        }
        //endreobjekter
        [HttpPost]
        public ActionResult EndreDestinasjon(destinasjoner innDestinasjon)
        {
            var db = new DbBestilling();
            var DB = new DB();
            try
            {
                
                Destinasjoner endreDestinasjon = DB.Destinasjoner.Find(innDestinasjon.id);
                endreDestinasjon.Flyplass = innDestinasjon.flyplass;
                endreDestinasjon.Pris = innDestinasjon.pris;
              
               
                DB.SaveChanges();
                return RedirectToAction("InnloggetSideDestinasjon");
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EndreReisen(reise innReise)
        {
            var db = new DbBestilling();
            var DB = new DB();
            try
            {
                Reise endreReise = DB.Reiser.Find(innReise.id);
                //burde ha lagd en for hver endring, men det ble nedprioritert.
                db.LagreLog(innReise.id);
                DB.SaveChanges();
                endreReise.Utreise = innReise.utreise;
                endreReise.Hjemreise = innReise.hjemreise;
                endreReise.Turtid = innReise.turtid;
                endreReise.Returtid = innReise.returtid;
                endreReise.Billettpris = innReise.billettpris;
                DB.SaveChanges();
                return RedirectToAction("InnloggetSide");
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EndreKunden(kunde innKunde)
        {
            var db = new DbBestilling();
            var DB = new DB();
            try
            {
                Kunde endreKunde = DB.alleBestillinger.Find(innKunde.id);
                endreKunde.Fornavn = innKunde.fornavn;
                endreKunde.Etternavn = innKunde.etternavn;
                endreKunde.Adresse = innKunde.adresse;
                endreKunde.Telefon= innKunde.telefon;
               
                DB.SaveChanges();
                return RedirectToAction("InnloggetSideKunde");
            }
            catch (Exception)
            {
                return View();
            }
        }
        //sletteobjekter:
        public ActionResult SlettKunden(int id)
        {
            var db = new DbBestilling();
            bool OK = db.SlettKunde(id);
            if (OK)
            {
                return RedirectToAction("InnloggetSideKunde");
            }
            return View();
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
        public ActionResult SlettDestinasjon(int id)
        {
            var db = new DbBestilling();
            bool OK = db.SlettDestinasjon(id);
            if (OK)
            {
                return RedirectToAction("InnloggetSideDestinasjon");
            }
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
      
          
    
        /*
        public string HentPris(string fraDest)
        {

            List<Destinasjoner> alleDest = db.Destinasjoner.ToList();
            List<Destinasjoner> valgtDest = new List<Destinasjoner>();

            valgtDest = alleDest.Where(alle => alle.Flyplass.Equals(fraDest)).ToList();

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(valgtDest);
            return json;
            
        }
       
        */
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
                catch (Exception )
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