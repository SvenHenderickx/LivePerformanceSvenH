using System;
using System.Collections.Generic;

namespace HuurAdministratie.Models
{
    public class HuurContract
    {
        public int Id { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int AantalMeren { get; set; }
        public double Bedrag { get; set; }
        public int HuurderId { get; set; }
        public List<Artikel> Artikelen { get; set; }
        public Huurder Huurder { get; set; }
        public List<Vaargebied> BevaardeGebieden{ get; set; }
        public Boot Boot { get; set; }
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

        public string ToString()
        {
            return Huurder.Naam + ": " + BeginDatum;
        }

        public void AddHuurder(Huurder huurder)
        {
            this.Huurder = huurder;
        }

        public void AddArtikelen(List<Artikel> artikelen)
        {
            this.Artikelen = artikelen;
        }

        public void AddBoot(Boot boot)
        {
            this.Boot = boot;
        }

        public void AddVaargebieden(List<Vaargebied> vaargebieden)
        {
            this.BevaardeGebieden = vaargebieden;
        }
    }
}