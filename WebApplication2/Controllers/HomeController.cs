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
            List<Destinasjoner> destinasjoner = db.Destinasjoner.ToList();
            return View(destinasjoner);
        }

        //legger inn hele bestillingen
        [HttpPost]
        public string Registrer(kunde innKunde, reise innReise)
        {
            var db = new DbBestilling();
            db.Lagrebestilling(innKunde,innReise);
            var jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize("OK");
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
       /* public ActionResult Slett(int Id)
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
            return 
        }*/
    }
}