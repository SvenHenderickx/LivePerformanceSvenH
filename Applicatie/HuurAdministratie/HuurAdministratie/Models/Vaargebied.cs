namespace HuurAdministratie.Models
{
    public class Vaargebied
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Vaargebied(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }
    }
}