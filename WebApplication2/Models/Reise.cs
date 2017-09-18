using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Reise
    {
        public int Id { get; set; }
        public int KundeId { get; set; }
        public string Utreise { get; set; }
        public string Hjemreise { get; set; }
    }
}