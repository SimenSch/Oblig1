using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Reise
    {
        public int Id { get; set; }

        public string Utreise { get; set; }

        public string Hjemreise { get; set; }

        public int TurTid{ get; set; }

        public int ReturTid { get; set; }

        public int Pris{ get; set; }

        public virtual List<Bestilling> Bestilling{ get; set; }
    }
}