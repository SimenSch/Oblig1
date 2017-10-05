using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Kunde
    {
        public int Id { get; set; }

        public string forNavn { get; set; }

        public string etterNavn { get; set; }

        public int telefon { get; set; }

        public string epost { get; set; }

        public virtual List<Bestilling> Bestilling {get; set;}
        
    }
}