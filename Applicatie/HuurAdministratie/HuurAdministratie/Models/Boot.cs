namespace HuurAdministratie.Models
{
    public abstract class Boot
    {
        public string Naam { get; set; }
        public string Type { get; set; }
        public string Soort { get; set; }
        public double Prijs { get; set; }

        protected Boot(string naam, string type, string soort, double prijs)
        {
            Naam = naam;
            Type = type;
            Soort = soort;
            Prijs = prijs;
        }
    }
}