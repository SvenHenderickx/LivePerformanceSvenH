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

        public List<Account> Accounts { get; private set; }

        public List<Vaargebied> Vaargebieden { get; private set; }

        public Bedrijf()
        {
            HuurContracten = GetHuurContracten();
            Artikelen = GetArtikelen();
            Boten = GetBoten();
            Vaargebieden = GetVaargebieden();
        }

        public List<Vaargebied> GetVaargebieden()
        {
            return DatabaseManager.GetAllVaargebieden();
        }

        public List<Artikel> GetArtikelen()
        {
            return DatabaseManager.GetAllArtikelen();
        }

        public List<Boot> GetBoten()
        {
            return DatabaseManager.GetAlleBoten();
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
            int aantalMeren = CheckBudget(bedrag, vaargebieden, artikelen, boot);
            if (aantalMeren != -1)
            {
                double teBetalen = PriceCheck(vaargebieden, artikelen, boot, aantalMeren);
                HuurContract newHuurContract = new HuurContract(HuurContract.highestId + 1, beginDatum, eindDatum,
                    aantalMeren, teBetalen, artikelen, new Huurder(Huurder.HighestId + 1, naam, email), vaargebieden, boot);
                bool succes = true;
                if (!DatabaseManager.AddHuurder(newHuurContract))
                    succes = false;
                if (!DatabaseManager.AddHuurcontract(newHuurContract))
                    succes = false;
                foreach (Vaargebied vg in vaargebieden)
                {
                    if (!DatabaseManager.AddVaargebiedToContract(newHuurContract, vg.Id))
                        succes = false;
                }
                foreach (Artikel a in artikelen)
                {
                    if (!DatabaseManager.AddArtikelenToContract(newHuurContract, a.Id))
                        succes = false;
                }
                return succes;
            }
            return false;
        }

        /// <summary>
        /// Geeft de daadwerkelijke prijs die je moet betalen
        /// </summary>
        /// <param name="vaargebieden"></param>
        /// <param name="artikelen"></param>
        /// <param name="boot"></param>
        /// <param name="aantalMeren"></param>
        /// <returns></returns>
        public double PriceCheck(List<Vaargebied> vaargebieden, List<Artikel> artikelen, Boot boot, int aantalMeren)
        {
            double hasToPay = 0;
            int amountOfMeren = 0;
            hasToPay += vaargebieden.Count * 2;
            hasToPay += artikelen.Count * 1.25;
            hasToPay += boot.Prijs;
            hasToPay += aantalMeren*1;
            if (aantalMeren > 4)
            {
                hasToPay += 0.50;
                if (aantalMeren > 10)
                {
                    hasToPay += 0.50;
                }
            }
            return hasToPay;
        }

        /// <summary>
        /// Geeft het aantal meren terug wat je kunt betalen
        /// </summary>
        /// <param name="bedrag"></param>
        /// <param name="vaargebieden"></param>
        /// <param name="artikelen"></param>
        /// <param name="boot"></param>
        /// <returns>Als het -1 is betekend dat je niet genoeg heb om je andere spullen te betalen</returns>
        public int CheckBudget(double bedrag, List<Vaargebied> vaargebieden, List<Artikel> artikelen, Boot boot)
        {
            double hasToPay = 0;
            int amountOfMeren = 0;
            hasToPay += vaargebieden.Count*2;
            hasToPay += artikelen.Count*1.25;
            hasToPay += boot.Prijs;
            if (bedrag - hasToPay > 0)
            {
                while (bedrag - hasToPay > 0 && amountOfMeren < 13)
                {
                    hasToPay += 1;
                    if (amountOfMeren%5 == 0)
                    {
                        if (boot.Soort != "Kano")
                        {
                            hasToPay += 0.50;
                        }
                    }
                    amountOfMeren++;
                }
                amountOfMeren--;
            }
            else
            {
                return -1;
            }
            return amountOfMeren;
        }

        public void Exporteer(string path, HuurContract contract)
        {

            using (StreamWriter stream = new StreamWriter(path + "/contract.txt"))
            {
                stream.WriteLine("Naam:" + contract.Huurder.Naam);
                stream.WriteLine("Email: " + contract.Huurder.EmailAdres);
                stream.WriteLine("Prijs: " + contract.Bedrag);
                stream.WriteLine("Datumbegin: " + contract.BeginDatum);
                stream.WriteLine("Datumeind: " + contract.EindDatum);
                stream.WriteLine("Boot:" + contract.Boot.Naam + " " + contract.Boot.Soort + " " + contract.Boot.Type);
                stream.WriteLine("Aantal meren: " + contract.AantalMeren);
                stream.WriteLine("Gehuurd:");
                foreach (Artikel a in contract.Artikelen)
                {
                    stream.WriteLine(a.Naam + " " + a.Prijs); 
                }
                stream.WriteLine("Vaargebied:");
                foreach (Vaargebied vg in contract.BevaardeGebieden)
                {
                    stream.WriteLine(vg.Naam);
                }
            }
        }
    }
}
