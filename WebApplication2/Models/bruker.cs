using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApplication2.Models
{
    public class bruker
    {
        
        public string brukerId { get; set; }
        public string passord { get; set; }
    }
}