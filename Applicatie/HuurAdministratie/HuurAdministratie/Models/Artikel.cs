namespace HuurAdministratie.Models
{
    public class Artikel
    {
        /// <summary>
        /// gets or sets the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// gets or sets the naam
        /// </summary>
        public string Naam { get; set; }
        /// <summary>
        /// gets or sets the prijs
        /// </summary>
        public double Prijs { get; set; }

        public Artikel(int id, string naam, double prijs)
        {
            Id = id;
            Naam = naam;
            Prijs = prijs;
        }
    }
}