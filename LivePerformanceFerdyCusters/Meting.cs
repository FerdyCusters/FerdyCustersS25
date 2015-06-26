namespace LivePerformanceFerdyCusters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Meting
    {

        #region Fields
        public int Metingcode { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public DateTime Datum { get; set; }
        public Missie missie { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor van Meting
        /// </summary>
        /// <param name="metingcode"></param>
        /// <param name="naam"></param>
        /// <param name="locatie"></param>
        /// <param name="datum"></param>
        public Meting(int metingcode, string naam, string locatie, DateTime datum)
        {
            this.Metingcode = metingcode;
            this.Naam = naam;
            this.Locatie = locatie;
            this.Datum = datum;
        }
        #endregion

        #region Methodes
        public override string ToString()
        {
            return this.Naam + " " + this.Locatie;
        }
        #endregion
    }
}
