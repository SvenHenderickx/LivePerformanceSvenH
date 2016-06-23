namespace HuurAdministratie.Models
{
    public class Huurder
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string EmailAdres { get; set; }

        public Huurder(int id, string naam, string emailAdres)
        {
            Id = id;
            Naam = naam;
            EmailAdres = emailAdres;
        }
    }
}