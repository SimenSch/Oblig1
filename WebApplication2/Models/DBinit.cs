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
            var nyReise = new Reise
            {
            Utreise = "",

            Hjemreise = "",

            TurTid = 0,

            ReturTid = 0,

            Pris = 0,

            };
            
        }
    }
}
