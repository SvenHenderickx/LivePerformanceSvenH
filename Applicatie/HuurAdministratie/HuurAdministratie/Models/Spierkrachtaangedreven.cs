using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuurAdministratie.Models
{
    public class Spierkrachtaangedreven : Boot
    {
      
        public Spierkrachtaangedreven(string naam, string type, string soort, double prijs) : base(naam, type, soort, prijs)
        {
            
        }
    }
}
