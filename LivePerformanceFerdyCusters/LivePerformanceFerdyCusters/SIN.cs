using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformanceFerdyCusters
{
    public class SIN : Missie
    {

        #region Fields
        public int AantalPolitie { get; set; }
        public DateTime StartDatum { get; set; }
        public string Eindverslag { get; set; }
        #endregion

        #region Constructor
        public SIN(int missiecode, string naam, string locatie, string beschrijving, bool isSjabloon, string type,
            int aantalPolitie, DateTime startDatum, string eindverslag) : base(missiecode, naam, locatie, beschrijving, isSjabloon, type)
        {
            this.AantalPolitie = aantalPolitie;
            this.StartDatum = startDatum;
            this.Eindverslag = eindverslag;
        }
        #endregion

        #region methods

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
