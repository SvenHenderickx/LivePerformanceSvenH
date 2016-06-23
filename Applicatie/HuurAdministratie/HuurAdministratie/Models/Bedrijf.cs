using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// gets the accounts
        /// </summary>
        public List<Account> Accounts { get; private set; }
        /// <summary>
        /// gets the vaargebieden
        /// </summary>
        public List<Vaargebied> Vaargebieden { get; private set; }

        private static Bedrijf instance;

        public Bedrijf()
        {
            GetAllForBedrijf();
        }

        public static Bedrijf Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bedrijf();
                }
                return instance;
            }
        }

        public void GetAllForBedrijf()
        {
            HuurContracten = GetHuurContracten();
            Artikelen = GetArtikelen();
            Boten = GetBoten();
            Vaargebieden = GetVaargebieden();
        }

        /// <summary>
        /// Geeft alle vaargebieden
        /// </summary>
        /// <returns></returns>
        public List<Vaargebied> GetVaargebieden()
        {
            return DatabaseManager.GetAllVaargebieden();
        }

        /// <summary>
        /// GEeft alle artikelen
        /// </summary>
        /// <returns></returns>
        public List<Artikel> GetArtikelen()
        {
            return DatabaseManager.GetAllArtikelen();
        }

        /// <summary>
        /// geeft alle boten
        /// </summary>
        /// <returns></returns>
        public List<Boot> GetBoten()
        {
            return DatabaseManager.GetAlleBoten();
        }

        /// <summary>
        /// Geeft alle huurcontracten
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Geeft de huurder van een contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Huurder GetHuurderFromContract(int id)
        {
            return DatabaseManager.GetHuurderFromContract(id);
        }

        /// <summary>
        /// Geeft alle artikelen van een contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Artikel> GetArtikelsFromContract(int id)
        {
            return DatabaseManager.GetArtikelFromContract(id);
        }

        /// <summary>
        /// Geeft de boot van een contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Boot GetBootFromContract(int id)
        {
            return DatabaseManager.GetBootFromContract(id);
        }
        
        /// <summary>
        /// Geeft alle vaargebieden van een contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Vaargebied> GetVaargebiedFromContract(int id)
        {
            return DatabaseManager.GetVaargebiedFromContract(id);
        }

        /// <summary>
        /// Voegt het huurcontract toe aan de database
        /// </summary>
        /// <param name="beginDatum"></param>
        /// <param name="eindDatum"></param>
        /// <param name="bedrag"></param>
        /// <param name="vaargebieden"></param>
        /// <param name="artikelen"></param>
        /// <param name="boot"></param>
        /// <param name="naam"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool AddHuurcontract(DateTime beginDatum, DateTime eindDatum, double bedrag, List<Vaargebied> vaargebieden, List<Artikel> artikelen, Boot boot, string naam, string email)
        {
            HuurContract newHuurContract = new HuurContract(beginDatum, eindDatum, artikelen, vaargebieden, boot);
            int aantalMeren = newHuurContract.CheckBudget(bedrag);
            if (aantalMeren != -1)
            {
                double teBetalen = newHuurContract.PriceCheck();
                 newHuurContract = new HuurContract(HuurContract.highestId + 1, beginDatum, eindDatum,
                    aantalMeren, teBetalen, artikelen, new Huurder(Huurder.HighestId + 1, naam, email), vaargebieden, boot);
                return DatabaseManager.AddFullContract(newHuurContract);
            }
            return false;
        }
    }
}
