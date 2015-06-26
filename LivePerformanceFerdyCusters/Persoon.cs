namespace LivePerformanceFerdyCusters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Persoon
    {
        #region Fields
        public int Persooncode { get; set; }
        public string Naam { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Wachtwoord { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Functie { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor voor Persoon.
        /// </summary>
        /// <param name="persooncode"></param>
        /// <param name="naam"></param>
        /// <param name="gebruikersnaam"></param>
        /// <param name="wachtwoord"></param>
        /// <param name="geboortedatum"></param>
        /// <param name="functie"></param>
        public Persoon(int persooncode, string naam, string gebruikersnaam, string wachtwoord, DateTime geboortedatum, string functie)
        {
            this.Persooncode = persooncode;
            this.Naam = naam;
            this.Gebruikersnaam = gebruikersnaam;
            this.Wachtwoord = wachtwoord;
            this.Geboortedatum = geboortedatum;
            this.Functie = functie;
        }
        #endregion

        #region Methodes

        /// <summary>
        /// ToString() Methode van Persoon.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Naam + " Functie:" + this.Functie;
        }

        #endregion
    }
}
