using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuurAdministratie.Models
{
    class Motor : Boot
    {
        public int TankInhoud { get; set; }

        public Motor(string naam, string type, string soort, double prijs, int tankInhoud) : base( naam, type, soort, prijs)
        {
            TankInhoud = tankInhoud;
        }
    }
}
