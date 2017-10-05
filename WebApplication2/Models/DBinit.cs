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
                forNavn = "fredrik",
                etterNavn = "tremann",
                telefon = 33445569,
                epost = "tremanntoman@bajseflass.cem",

            };
            var nyReise = new Reise
            {
            Utreise = "",

            Hjemreise = "",

            TurTid = "0",

            ReturTid = "0",

            Pris = 0,

            };;
            var nybestilling = new Bestilling
            {
                reiseId = nyReise.Id,
                kundeId = nyKunde.Id
            };
            context.Kunder.Add(nyKunde);
            context.Reiser.Add(nyReise);
            context.Bestillinger.Add(nybestilling);
            base.Seed(context);
           
               
           
        }
    }
}
