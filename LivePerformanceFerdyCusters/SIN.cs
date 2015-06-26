namespace LivePerformanceFerdyCusters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SIN : Missie
    {

        #region Fields
        public int AantalPolitie { get; set; }
        public DateTime StartDatum { get; set; }
        public string Eindverslag { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// De constructor van SIN
        /// </summary>
        /// <param name="missiecode"></param>
        /// <param name="naam"></param>
        /// <param name="locatie"></param>
        /// <param name="beschrijving"></param>
        /// <param name="isSjabloon"></param>
        /// <param name="type"></param>
        /// <param name="aantalPolitie"></param>
        /// <param name="startDatum"></param>
        /// <param name="eindverslag"></param>
        public SIN(int missiecode, string naam, string locatie, string beschrijving, bool isSjabloon, string type,
            int aantalPolitie, DateTime startDatum, string eindverslag) : base(missiecode, naam, locatie, beschrijving, isSjabloon, type)
        {
            this.AantalPolitie = aantalPolitie;
            this.StartDatum = startDatum;
            this.Eindverslag = eindverslag;
        }
        #endregion

        #region methods

        /// <summary>
        /// Deze methode voegt een SIN missie toe aan de database.
        /// </summary>
        /// <returns></returns>
        public bool VoegSinToe()
        {
            DBConnect.AddMissie(this);
            this.Missiecode = DBConnect.GetMissieCode(this);
            DBConnect.AddSin(this);
            return true;
        }

        #endregion
    }
}
