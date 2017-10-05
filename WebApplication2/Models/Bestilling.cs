using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{


    public class Bestilling
    {
    
        public int Id { get; set; }
        public int reiseId { get; set; }
        public int kundeId { get; set; }
        public virtual Kunde Kunde { get; set; }

        public virtual Reise Reise { get; set; }
    }

}

