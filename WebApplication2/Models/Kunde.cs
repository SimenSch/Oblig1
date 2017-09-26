using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string ForNavn { get; set; }
        public string EtterNavn { get; set; }

        public int Telefon { get; set; }
        public string Epost { get; set; }
        
    }
}