﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Model
{
    public class reise
    {
        public int id { get; set; }

        public string utreise { get; set; }
        
        public string hjemreise { get; set; }
        
        public string turtid{ get; set; }
        
        public string returtid { get; set; }

        public int billettpris{ get; set; }

        public int antall { get; set; }
        public int? antallbarn { get; set; }
    }
}