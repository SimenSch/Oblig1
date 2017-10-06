using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{ 
    public class DBinit : DropCreateDatabaseAlways<DB>
    {
	    protected override void Seed(DB context)
	    {
            var nyKunde = new Kunde
            {
                Fornavn = "fredrik",
                Etternavn = "tremann",
                

            };
            var nyKontaktInfo = new Kontaktinfo
            {
                Telefon = 33445569,
                Epost = "tremanntoma@bajseflass.cem"
            };
            var nyReise = new Reise
            {
            Utreise = "",

            Hjemreise = "",

            Turtid = "0",

            Returtid = "0",

            Billettpris = 0,

            };;
            var nybestilling = new Bestilling
            {
                Reiseid = nyReise.Id,
                Kundeid = nyKunde.Id
            };
            var nyDestinasjon1 = new Destinasjoner
            {
                Flyplass = "Oslo",
                Pris = 599
            };
            
            var nyDestinasjon2 = new Destinasjoner
            {
                Flyplass = "Trondheim",
                Pris = 399
            };
            var nyDestinasjon3 = new Destinasjoner
            {
                Flyplass = "Tromsø",
                Pris = 799
            };
            var nyDestinasjon4 = new Destinasjoner
            {
                Flyplass = "Bergen",
                Pris = 499
            };
            var nyDestinasjon5 = new Destinasjoner
            {
                Flyplass = "Stavanger",
                Pris = 399
            };
            var nyDestinasjon6 = new Destinasjoner
            {
                Flyplass = "Torp",
                Pris = 299
            };
            context.Destinasjoner.Add(nyDestinasjon1);
            context.Destinasjoner.Add(nyDestinasjon2);
            context.Destinasjoner.Add(nyDestinasjon3);
            context.Destinasjoner.Add(nyDestinasjon4);
            context.Destinasjoner.Add(nyDestinasjon5);
            context.Destinasjoner.Add(nyDestinasjon6);
            context.alleBestillinger.Add(nyKunde);
            context.Reiser.Add(nyReise);
            context.Bestillinger.Add(nybestilling);
            base.Seed(context);
           
               
           
        }
    }
}
