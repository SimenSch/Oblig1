using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2
{
    public class DbBestilling
    {
        private DB db = new DB();

        public List<destinasjoner> alleDestinasjoner()
        {

            {
                List<destinasjoner> alleDestinasjoner = db.Destinasjoner.Select(d => new destinasjoner
                {
                   flyplass = d.Flyplass,
                   pris = d.Pris
                    
                }).ToList();
                return alleDestinasjoner;
            }
        }
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
        public bool lagrebestilling(kunde innkunde)
            {
            try
            {
                var nyKundeRad = new Kunde();
                nyKundeRad.Fornavn = innkunde.fornavn;
                nyKundeRad.Etternavn = innkunde.etternavn;
                nyKundeRad.Kontaktinfo.Epost = innkunde.epost;
                nyKundeRad.Kontaktinfo.Telefon = innkunde.telefon;

                var sjekkEpost = db.Kontaktinfo.Find(innkunde.id);
                if(sjekkEpost == null)
                {
                    var Kontaktinforad = new Kontaktinfo();
                    Kontaktinforad.Epost = innkunde.epost;
                    Kontaktinforad.Telefon = innkunde.telefon;
                    
                }
                if(nyKundeRad.Id==nyKundeRad.Kontaktinfo.Id)
                db.alleBestillinger.Add(nyKundeRad);
                db.SaveChanges();
                return true;
            }
            catch(Exception feil)
            {
                return false;
            }
            }
    }
}