using System;
using System.Collections.Generic;
using System.IO;

namespace HuurAdministratie.Models
{
    public class HuurContract
    {
        /// <summary>
        /// gets or sets the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// gets or sets the begindatum
        /// </summary>
        public DateTime BeginDatum { get; set; }
        /// <summary>
        /// gets or sets the einddatum
        /// </summary>
        public DateTime EindDatum { get; set; }
        /// <summary>
        /// gets or sets the aantalmeren
        /// </summary>
        public int AantalMeren { get; set; }
        /// <summary>
        /// gets or sets the bedrag
        /// </summary>
        public double Bedrag { get; set; }
        /// <summary>
        /// gets or sets the huurder
        /// </summary>
        public int HuurderId { get; set; }
        /// <summary>
        /// Gets or sets the artikelen
        /// </summary>
        public List<Artikel> Artikelen { get; set; }
        /// <summary>
        /// Gets or sets the huurder
        /// </summary>
        public Huurder Huurder { get; set; }
        /// <summary>
        /// gets or sets the bevaardegebieden
        /// </summary>
        public List<Vaargebied> BevaardeGebieden{ get; set; }
        /// <summary>
        /// gets or sets the boot
        /// </summary>
        public Boot Boot { get; set; }
        /// <summary>
        /// the highest id of all objects
        /// </summary>
        public static int highestId = 0;

        public HuurContract(int id, DateTime beginDatum, DateTime eindDatum, int aantalMeren, double bedrag, int huurderId)
        {
            Id = id;
            BeginDatum = beginDatum;
            EindDatum = eindDatum;
            AantalMeren = aantalMeren;
            Bedrag = bedrag;
            HuurderId = huurderId;
            BevaardeGebieden = new List<Vaargebied>();
            if (id > highestId)
            {
                highestId = id;
            }
        }

        public HuurContract(int id, DateTime beginDatum, DateTime eindDatum, int aantalMeren, double bedrag, List<Artikel> artikelen, Huurder huurder, List<Vaargebied> bevaardeGebieden, Boot boot)
        {
            Id = id;
            BeginDatum = beginDatum;
            EindDatum = eindDatum;
            AantalMeren = aantalMeren;
            Bedrag = bedrag;
            Artikelen = artikelen;
            Huurder = huurder;
            BevaardeGebieden = bevaardeGebieden;
            Boot = boot;
        }

        public HuurContract(DateTime beginDatum, DateTime eindDatum, List<Artikel> artikelen, List<Vaargebied> bevaardeGebieden, Boot boot)
        {
            BeginDatum = beginDatum;
            EindDatum = eindDatum;
            Artikelen = artikelen;
            BevaardeGebieden = bevaardeGebieden;
            Boot = boot;
        }

        public string ToString()
        {
            return Huurder.Naam + ": " + BeginDatum;
        }

        /// <summary>
        /// Voeg een huurder toe aan het huurcontract
        /// </summary>
        /// <param name="huurder"></param>
        public void AddHuurder(Huurder huurder)
        {
            this.Huurder = huurder;
        }

        /// <summary>
        /// voeg artikelen toe aan het huurcontract
        /// </summary>
        /// <param name="artikelen"></param>
        public void AddArtikelen(List<Artikel> artikelen)
        {
            this.Artikelen = artikelen;
        }

        /// <summary>
        /// voegt een boot toe
        /// </summary>
        /// <param name="boot"></param>
        public void AddBoot(Boot boot)
        {
            this.Boot = boot;
        }

        /// <summary>
        /// Voegt vaargebieden toe aan huurcontract
        /// </summary>
        /// <param name="vaargebieden"></param>
        public void AddVaargebieden(List<Vaargebied> vaargebieden)
        {
            this.BevaardeGebieden = vaargebieden;
        }


        /// <summary>
        /// Geeft het aantal meren dat je mag bevaren
        /// </summary>
        /// <param name="bedrag"></param>
        /// <returns></returns>
        public int CheckBudget(double bedrag)
        {
            double hasToPay = 0;
            int amountOfMeren = 0;
            hasToPay += BevaardeGebieden.Count * 2;
            hasToPay += Artikelen.Count * 1.25;
            hasToPay += Boot.Prijs;
            if (bedrag - hasToPay > 0)
            {
                while (bedrag - hasToPay > 0 && amountOfMeren < 13)
                {
                    hasToPay += 1;
                    if (amountOfMeren % 5 == 0)
                    {
                        if (Boot.Soort != "Kano")
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

        /// <summary>
        /// Geeft de daadwerkelijke prijs die je moet betalen
        /// </summary>
        /// <param name="vaargebieden"></param>
        /// <param name="artikelen"></param>
        /// <param name="boot"></param>
        /// <param name="aantalMeren"></param>
        /// <returns></returns>
        public double PriceCheck()
        {
            double hasToPay = 0;
            int amountOfMeren = 0;
            hasToPay += BevaardeGebieden.Count * 2;
            hasToPay += Artikelen.Count * 1.25;
            hasToPay += Boot.Prijs;
            hasToPay += AantalMeren * 1;
            if (AantalMeren > 4)
            {
                hasToPay += 0.50;
                if (AantalMeren > 10)
                {
                    hasToPay += 0.50;
                }
            }
            return hasToPay;
        }

        /// <summary>
        /// Exporteerd een bestand met alle informatie
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contract"></param>
        public void Exporteer(string path)
        {

            using (StreamWriter stream = new StreamWriter(path + "/contract.txt"))
            {
                stream.WriteLine("Naam:" + Huurder.Naam);
                stream.WriteLine("Email: " + Huurder.EmailAdres);
                stream.WriteLine("Prijs: " + Bedrag);
                stream.WriteLine("Datumbegin: " + BeginDatum);
                stream.WriteLine("Datumeind: " + EindDatum);
                stream.WriteLine("Boot:" + Boot.Naam + " " + Boot.Soort + " " + Boot.Type);
                stream.WriteLine("Aantal meren: " + AantalMeren);
                stream.WriteLine("Gehuurd:");
                foreach (Artikel a in Artikelen)
                {
                    stream.WriteLine(a.Naam + " " + a.Prijs);
                }
                stream.WriteLine("Vaargebied:");
                foreach (Vaargebied vg in BevaardeGebieden)
                {
                    stream.WriteLine(vg.Naam);
                }
            }
        }
    }
}