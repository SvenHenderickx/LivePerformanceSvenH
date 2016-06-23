namespace HuurAdministratie.Models
{
    public class Account
    {
        public string Emailadres { get; set; }
        public string Wachtwoord { get; set; }

        public Account(string emailadres, string wachtwoord)
        {
            Emailadres = emailadres;
            Wachtwoord = wachtwoord;
        }
    }
}