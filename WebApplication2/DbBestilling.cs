using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2
{
    //Listeobjekter til bruk i databasen
    public class DbBestilling
    {
        //bruk av dispose se DB.cs
        private DB db = new DB();

        //destinasjoner
        public List<destinasjoner> AlleDestinasjoner()
        {

            {
                List<destinasjoner> alleDestinasjoner = db.Destinasjoner.Select(d => new destinasjoner
                {
                   id = d.Id,
                   flyplass = d.Flyplass,
                   pris = d.Pris
                    
                }).ToList();
                return alleDestinasjoner;
            }
        }
        //om det skulle trenges viser vi kunden her
            public List<kunde> alleBestillinger()
        {
             
            {
                List<kunde> alleKunder = db.alleBestillinger.Select(k => new kunde
                {
                    id = k.Id,
                    fornavn = k.Fornavn,
                    etternavn = k.Etternavn,
                    epost = k.Kontaktinfo.Epost,
                    telefon = k.Kontaktinfo.Telefon
                }).ToList();
                return alleKunder;
            }
          
               
        }
        //til oppgave 2
        public int Innpris(int billettpris1, int billettpris2, int antall, int? antall_barn)
        {
            if (antall_barn > 0)
            {
                var billettpris = (billettpris1 + billettpris2 * antall) + (billettpris1 + billettpris2 *  (int)antall_barn / 2);
                return billettpris;
            }
            else
            {
                var billettpris = (billettpris1 + billettpris2 * antall);
                return billettpris;
            }
            
        }
        //lagrer hele bestillingen.
        public bool Lagrebestilling(kunde innbestilling, reise innreise)
        {
            
            //setter inn hele bestillingen, tar inn modellen kunde og reise
            //i form via ajax innpris1 er tatt fra destinasjon databasen og fremvises som en verdi på skjermen.
            try
            {
                var nyKundeRad = new Kunde();
                var nyBestillingsRad = new Bestilling();
                var nyReiseRad = new Reise();
                var nyDestinasjon = new Destinasjoner();              
     
                nyReiseRad.Hjemreise = innreise.hjemreise;
                nyReiseRad.Utreise = innreise.utreise;
                nyReiseRad.Turtid = innreise.turtid;
                nyReiseRad.Returtid = innreise.returtid;
                nyReiseRad.Antall = innreise.antall;
                nyReiseRad.Antallbarn = innreise.antallbarn;
                nyReiseRad.Billettpris = innreise.billettpris;
                nyKundeRad.Fornavn = innbestilling.fornavn;
                nyKundeRad.Etternavn = innbestilling.etternavn;
                nyKundeRad.Kontaktinfo.Epost = innbestilling.epost;
                nyKundeRad.Kontaktinfo.Telefon = innbestilling.telefon;
                /*
               if (sjekkEpost == null)
                {
                    var Kontaktinforad = new Kontaktinfo();
                    Kontaktinforad.Epost = innbestilling.epost;
                    Kontaktinforad.Telefon = innbestilling.telefon;

                }*/
                db.alleBestillinger.Add(nyKundeRad);
                db.Reiser.Add(nyReiseRad);
                db.Bestillinger.Add(nyBestillingsRad);                         
                db.SaveChanges();
                
                return true;
            }
            catch (Exception feil)
            {
                return false;
            }
        }
         
    }
}
            
 