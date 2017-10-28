using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Model;


namespace WebApplication2.DAL
{
    //Listeobjekter til bruk i databasen
    public class DbBestilling
    {



        //destinasjoner
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
        //om det skulle trenges viser vi kunden her
        public List<kunde> alleBestillinger()
        {

            var db = new DB();
            List<kunde> alleKunder = db.alleBestillinger.Select(k => new kunde
            {
                id = k.Id,
                fornavn = k.Fornavn,
                etternavn = k.Etternavn,


            }).ToList();
            return alleKunder;



        }
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
        //experimentell Priskalkulering kommer i oppgave 2
        public int Innpris(int billettpris1, int billettpris2, int antall, int? antall_barn)
        {
            if (antall_barn > 0)
            {
                var billettpris = (billettpris1 + billettpris2 * antall) + (billettpris1 + billettpris2 * (int)antall_barn / 2);
                return billettpris;
            }
            else
            {
                var billettpris = (billettpris1 + billettpris2 * antall);
                return billettpris;
            }

        }
        // lagrer hele reisen
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
        //tor sin kode. Dette vil sendes til homekontroller og brukes i en sjekk for å finne ut om brukeren er i systemet (da må passord også være korrekt. en modifisert versjon av denne skal også brukes til å håndtere opptatte brukernavn i databasen (kun dbBruker funnetBruker = db.Brukere.FirstOrDefault. 

        public static bool BrukerInnloggingsjekk_i_DB(bruker innBruker)
        {
            using (var db = new DB())
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
        }

        //lagrer kunden
        public bool Lagrekunde(kunde innKunde)
        {

            //setter inn hele bestillingen, tar inn modellen kunde og reise

            try
            {


                var db = new DB();
                var nyKundeRad = new Kunde();
                nyKundeRad.Fornavn = innKunde.fornavn;
                nyKundeRad.Etternavn = innKunde.etternavn;

                /* til senere oppgave
               if (sjekkEpost == null)
                {
                    var Kontaktinforad = new Kontaktinfo();
                    Kontaktinforad.Epost = innbestilling.epost;
                    Kontaktinforad.Telefon = innbestilling.telefon;

                }*/
                db.alleBestillinger.Add(nyKundeRad);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }






    }
}
 