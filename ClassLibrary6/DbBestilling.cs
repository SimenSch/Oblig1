using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Model;


namespace WebApplication2.DAL
{
    
    public class DbBestilling
    {



        //listeobjekter:
        public List<destinasjoner> AlleDestinasjoner()
        {
            var db = new DB();
            List<destinasjoner> alleDestinasjoner = db.Destinasjoner.Select(d => new destinasjoner()
            {
                id = d.Id,
                flyplass = d.Flyplass,
                pris = d.Pris

            }).ToList();
            return alleDestinasjoner;
        }
        public List<reise> AlleReiser()
        {
            var db = new DB();
            List<reise> alleReiser = db.Reiser.Select(r => new reise()
            {
                id = r.Id,
                utreise = r.Utreise,
                hjemreise = r.Hjemreise,
                turtid = r.Turtid,
                returtid = r.Returtid,
                billettpris = r.Billettpris


            }).ToList();
            return alleReiser;
        }
        
        public List<kunde> alleBestillinger()
        {

            var db = new DB();
            List<kunde> alleKunder = db.alleBestillinger.Select(k => new kunde
            {
                id = k.Id,
                fornavn = k.Fornavn,
                etternavn = k.Etternavn,
                adresse = k.Adresse,
                telefon = k.Telefon


            }).ToList();
            return alleKunder;



        }
        //sletteobjekter:
        public bool SlettReise(int id)
        {
            using (var db = new DB())
            {
                try
                {
                    var slettReise = db.Reiser.Find(id);

                    db.Reiser.Remove(slettReise);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        
        public bool SlettKunde(int id)
        {
            using (var db = new DB())
            {
                try
                {
                    var slettKunde = db.alleBestillinger.Find(id);

                    db.alleBestillinger.Remove(slettKunde);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool SlettDestinasjon(int id)
        {
            using (var db = new DB())
            {
                try
                {
                    var slettDestinasjon = db.Destinasjoner.Find(id);

                    db.Destinasjoner.Remove(slettDestinasjon);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //lagreobjekter:
        public bool LagreKunden(kunde innKunde)
        {
            using (var db = new DB())
            {
                try
                { 
                    var nyKunde = new Kunde();
                    nyKunde.Fornavn = innKunde.fornavn;
                    nyKunde.Etternavn = innKunde.etternavn;
                    nyKunde.Adresse = innKunde.adresse;
                    nyKunde.Telefon = innKunde.telefon;    

                    db.alleBestillinger.Add(nyKunde);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        public bool LagreReise(reise innReise)
        {
            using (var db = new DB())
            {
                try
                {
                    var nyReise = new Reise();
                    nyReise.Utreise = innReise.utreise;
                    nyReise.Hjemreise = innReise.hjemreise;
                    nyReise.Turtid = innReise.turtid;
                    nyReise.Returtid = innReise.returtid;
                    nyReise.Billettpris = innReise.billettpris;

                    db.Reiser.Add(nyReise);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception )
                {
                    return false;
                }
            }
        }
        public bool LagreDestinasjon(destinasjoner innDestinasjon)
        {
            using (var db = new DB())
            {
                try
                {
                    var nyDestinasjon = new Destinasjoner();
                    nyDestinasjon.Flyplass = innDestinasjon.flyplass;
                    nyDestinasjon.Pris = innDestinasjon.pris;
                    db.Destinasjoner.Add(nyDestinasjon);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        //Testeobjekter:
        //tor sin kode
        public static Byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA256.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }
        public static bool BrukerRegisteringSjekk_i_DB(string innBruker)
        {
            using (var db = new DB())
            {

                dbBruker funnetBruker = db.Brukere.FirstOrDefault
              (b => b.BrukerId == innBruker);
                if (funnetBruker != null)
                {
                    return false;
                }
                else if (funnetBruker == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        //tor sin kode. 

        public static bool BrukerInnloggingsjekk_i_DB(bruker innBruker)
        {

            using (var db = new DB())
            {if (innBruker.passord != null)
                {
                    byte[] passordDb = lagHash(innBruker.passord);
                    dbBruker funnetBruker = db.Brukere.FirstOrDefault
                    (b => b.Passord == passordDb && b.BrukerId == innBruker.brukerId);

                    if (funnetBruker == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
 