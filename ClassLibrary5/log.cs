using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication2.Model
{
    public class log
    {
        public int id { get; set; }

        public string utreise { get; set; }

        public string hjemreise { get; set; }

        public string turtid { get; set; }

        public string returtid { get; set; }

        public int billettpris { get; set; }

        public DateTime logdato { get; set; }
    }
}
