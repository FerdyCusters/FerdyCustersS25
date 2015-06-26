namespace LivePerformanceFerdyCusters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Klasse Boot.
    /// </summary>
    public class Boot
    {
        #region Fields 

        public int Bootcode { get; set; }
        public string Naam { get; set; }
        public int MaxSnelheid { get; set; }
        public int MaxPersonen { get; set; }
        public string Locatie { get; set; }
        public Missie Missie { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor van Boot
        /// </summary>
        /// <param name="bootcode"></param>
        /// <param name="naam"></param>
        /// <param name="maxSnelheid"></param>
        /// <param name="maxPersonen"></param>
        /// <param name="Locatie"></param>
        public Boot(int bootcode, string naam, int maxSnelheid, int maxPersonen, string Locatie)
        {
            this.Bootcode = bootcode;
            this.Naam = naam;
            this.MaxSnelheid = maxSnelheid;
            this.MaxPersonen = maxPersonen;
            this.Locatie = Locatie;
        }
        #endregion

        #region Methods

        /// <summary>
        /// ToString() methode van boot.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Naam + " " + this.Locatie;
        }

        /// <summary>
        /// Methode om afstand te berekenen m.b.v. stelling van pythagoras.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public int calculate(int x1, int y1, int x2, int y2)
        {
            int afstandX = Math.Abs(x1 - x2);
            int afstandY = Math.Abs(y1 - y2);
            int cKwadraat = (afstandX ^ 2) + (afstandY ^ 2);
            int c = (int)Math.Sqrt(cKwadraat);
            return c;
        }
        #endregion
    }
}
