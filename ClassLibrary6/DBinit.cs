using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace WebApplication2.DAL
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
            
            
           
            var nyBruker1 = new dbBruker
            {
                BrukerId = "Tormann",
                Passord = Funksjoner.lagHash("TorErKjempeKul123")
            };
            var nyBruker2 = new dbBruker
            {
                BrukerId = "Devranmann",
                Passord = Funksjoner.lagHash("DevranErKjempeKul123")
            };
            var nyBruker3 = new dbBruker
            {
                BrukerId = "Simenmann",
                Passord = Funksjoner.lagHash("SimenErKjempeKul123")
            };

            var nyReise1 = new Reise
            {
            Utreise = "Oslo",

            Hjemreise = "Trondheim",

            Turtid = "05.11.2017",

            Returtid = "12.11.2017",

            Billettpris = 499,

            };;
            var nyReise2 = new Reise
            {
                Utreise = "Oslo",

                Hjemreise = "Bergen",

                Turtid = "06.11.2017",

                Returtid = "13.11.2017",

                Billettpris = 499,

            };;
            var nyReise3 = new Reise
            {
                Utreise = "Trondheim",

                Hjemreise = "Bergen",

                Turtid = "06.11.2017",

                Returtid = "12.11.2017",

                Billettpris = 349,

            };;
            var nyReise4 = new Reise
            {
                Utreise = "Trondheim",

                Hjemreise = "Oslo",

                Turtid = "07.11.2017",

                Returtid = "14.11.2017",

                Billettpris = 449,

            }; ;
            var nyReise5 = new Reise
            {
                Utreise = "Bergen",

                Hjemreise = "Oslo",

                Turtid = "08.11.2017",

                Returtid = "15.11.2017",

                Billettpris = 599,

            }; ;
            var nyReise6 = new Reise
            {
                Utreise = "Bergen",

                Hjemreise = "Trondheim",

                Turtid = "09.11.2017",

                Returtid = "17.11.2017",

                Billettpris = 599,

            }; ;
            context.Reiser.Add(nyReise1);
            context.Reiser.Add(nyReise2);
            context.Reiser.Add(nyReise3);
            context.Reiser.Add(nyReise4);
            context.Reiser.Add(nyReise5);
            context.Reiser.Add(nyReise6);

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
            context.Brukere.Add(nyBruker1);
            context.Brukere.Add(nyBruker2);
            context.Brukere.Add(nyBruker3);
            base.Seed(context);
           
               
           
        }
    }
}
