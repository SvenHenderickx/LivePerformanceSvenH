namespace HuurAdministratie.Models
{
    public class Account
    {
        /// <summary>
        /// Gets or sets the emailadres
        /// </summary>
        public string Emailadres { get; set; }
        /// <summary>
        /// gets or sets the wachtwoord
        /// </summary>
        public string Wachtwoord { get; set; }

        public Account(string emailadres, string wachtwoord)
        {
            Emailadres = emailadres;
            Wachtwoord = wachtwoord;
        }
    }
}