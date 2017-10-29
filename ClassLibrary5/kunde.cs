using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model
{
    public class kunde
    {
        [Required(ErrorMessage = "Id kreves for å kunne endre")]
        public int id { get; set; }
        
        public string fornavn { get; set; }
       
        public string etternavn { get; set; }
       
        public string adresse { get; set; }
       
        public int telefon { get; set; }


    }
}