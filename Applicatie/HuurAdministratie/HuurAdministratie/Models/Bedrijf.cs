using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuurAdministratie.Models
{
    public class Bedrijf
    {
        /// <summary>
        /// Gets the huurcontracten
        /// </summary>
        public List<HuurContract> HuurContracten { get; private set; }
        /// <summary>
        /// Gets the boten
        /// </summary>
        public List<Boot> Boten { get; private set; }
        /// <summary>
        /// Gets the artikelen
        /// </summary>
        public List<Artikel> Artikelen { get; private set; }

        public List<Account> Accounts { get; private set; }

        public Bedrijf()
        {
            HuurContracten = GetHuurContracten();
        }

        public List<HuurContract> GetHuurContracten()
        {
            List<HuurContract> huurcontracten = DatabaseManager.GetHuurContracten();
            foreach (HuurContract hc in huurcontracten)
            {
                hc.AddHuurder(GetHuurderFromContract(hc.HuurderId));
                hc.AddArtikelen(GetArtikelsFromContract(hc.Id));
                hc.AddBoot(GetBootFromContract(hc.Id));
                hc.AddVaargebieden(GetVaargebiedFromContract(hc.Id));
            }
            return huurcontracten;
        }

        public Huurder GetHuurderFromContract(int id)
        {
            return DatabaseManager.GetHuurderFromContract(id);
        }

        public List<Artikel> GetArtikelsFromContract(int id)
        {
            return DatabaseManager.GetArtikelFromContract(id);
        }

        public Boot GetBootFromContract(int id)
        {
            return DatabaseManager.GetBootFromContract(id);
        }

        public List<Vaargebied> GetVaargebiedFromContract(int id)
        {
            return DatabaseManager.GetVaargebiedFromContract(id);
        }
    }
}
