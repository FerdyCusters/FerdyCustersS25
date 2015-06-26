using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformanceFerdyCusters
{
    public class HOPE : Missie
    {

        #region Fields
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public bool GoedGekeurd { get; set; }
        #endregion

        #region Constructor
        public HOPE(int missiecode, string naam, string locatie, string beschrijving, bool isSjabloon, string type,
            DateTime startDatum, DateTime eindDatum, bool goedGekeurd) : base(missiecode, naam, locatie, beschrijving, isSjabloon, type)
        {
            this.StartDatum = startDatum;
            this.EindDatum = eindDatum;
            this.GoedGekeurd = goedGekeurd;
        }
        #endregion

        #region methods

        public bool VoegHopeToe()
        {
            DBConnect.AddMissie(this);
            this.Missiecode = DBConnect.GetMissieCode(this);
            DBConnect.AddHope(this);
            return true;
        }
        #endregion
    }
}
