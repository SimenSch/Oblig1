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
                Fornavn = "Tor",
                Etternavn = "Krattebøl",
                Adresse = "Krattebølveienen 1",
                Telefon = 99887767

            };
            var nyKunde2 = new Kunde
            {
                Fornavn = "Torkil",
                Etternavn = "Krattebølil",
                Adresse = "Krattebølveien 2",
                Telefon = 99887768

            };
           var nyKunde3 = new Kunde
            {
                Fornavn = "Torleif",
                Etternavn = "Krattebøleif",
                Adresse = "Krattebølveien 3",
                Telefon = 99887769

            };
            var nyKunde4 = new Kunde
            {
                Fornavn = "Toralf",
                Etternavn = "Krattebalf",
                Adresse = "Krattebølveien 4",
                Telefon = 99887766

            };
            var nyKunde5 = new Kunde
            {
                Fornavn = "Tormod",
                Etternavn = "Krattebølmod",
                Adresse = "Krattebølveien 5",
                Telefon = 99887761

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

            Turtid = "2017.05.11",

            Returtid = "2017.12.11",

            Billettpris = 499,

            };;
            var nyReise2 = new Reise
            {
                Utreise = "Oslo",

                Hjemreise = "Bergen",

                Turtid = "2017.06.12",

                Returtid = "2017.13.11",

                Billettpris = 499,

            };;
            var nyReise3 = new Reise
            {
                Utreise = "Trondheim",

                Hjemreise = "Bergen",

                Turtid = "2017.06.11",

                Returtid = "2017.12.11",

                Billettpris = 349,

            };;
            var nyReise4 = new Reise
            {
                Utreise = "Trondheim",

                Hjemreise = "Oslo",

                Turtid = "2017.07.11",

                Returtid = "2017.14.11",

                Billettpris = 449,

            }; ;
            var nyReise5 = new Reise
            {
                Utreise = "Bergen",

                Hjemreise = "Oslo",

                Turtid = "2017.08.11",

                Returtid = "2017.15.11",

                Billettpris = 599,

            }; ;
            var nyReise6 = new Reise
            {
                Utreise = "Bergen",

                Hjemreise = "Trondheim",

                Turtid = "2017.09.11",

                Returtid = "2017.17.11",

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
            context.alleBestillinger.Add(nyKunde);
            context.alleBestillinger.Add(nyKunde2);
            context.alleBestillinger.Add(nyKunde3);
            context.alleBestillinger.Add(nyKunde4);
            context.alleBestillinger.Add(nyKunde5);
            base.Seed(context);
           
               
           
        }
    }
}
