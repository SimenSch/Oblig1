using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Model
{
    public class destinasjoner
    {
        [Required(ErrorMessage = "Id kreves for endring")]
        public int id { get; set; }
      
        public string flyplass { get; set; }
        
        public int pris { get; set; }
    }
}