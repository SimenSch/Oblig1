using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models
{
    public class bruker
    {
        [Required(ErrorMessage ="Brukernavn Kreves for registrering")]
        public string brukerId { get; set; }
        [Required(ErrorMessage = "Passord Kreves for registrering")]
        public string passord { get; set; }
    }
}