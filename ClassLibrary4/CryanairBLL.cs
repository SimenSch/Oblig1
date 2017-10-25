using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.DAL;
using WebApplication2.Model;

namespace WebApplication2.BLL
{
    public class CryanairBLL
    {
        public List<destinasjoner> AlleDestinasjoner() {

            var DAL = new DbBestilling();
            return DAL.AlleDestinasjoner();
         }
        public List<kunde> alleBestillinger()
        {

            var DAL = new DbBestilling();
            return DAL.alleBestillinger();
        }
        public static Byte[] lagHash(string innPassord)
        {
            var DAL = new DbBestilling();
            return lagHash(innPassord);
        }
        public static bool BrukerInnloggingsjekk_i_DB(bruker innBruker)
        {
            var model = new DB();
            var DAL = new DbBestilling();
            return BrukerInnloggingsjekk_i_DB(innBruker);
        }
    }
}
