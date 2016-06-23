namespace HuurAdministratie.Models
{
    public class Artikel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }

        public Artikel(int id, string naam, double prijs)
        {
            Id = id;
            Naam = naam;
            Prijs = prijs;
        }
    }
}