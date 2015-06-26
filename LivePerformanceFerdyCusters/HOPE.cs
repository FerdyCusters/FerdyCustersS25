namespace LivePerformanceFerdyCusters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HOPE : Missie
    {

        #region Fields
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public bool GoedGekeurd { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van een HOPE missie.
        /// </summary>
        /// <param name="missiecode"></param>
        /// <param name="naam"></param>
        /// <param name="locatie"></param>
        /// <param name="beschrijving"></param>
        /// <param name="isSjabloon"></param>
        /// <param name="type"></param>
        /// <param name="startDatum"></param>
        /// <param name="eindDatum"></param>
        /// <param name="goedGekeurd"></param>
        public HOPE(int missiecode, string naam, string locatie, string beschrijving, bool isSjabloon, string type,
            DateTime startDatum, DateTime eindDatum, bool goedGekeurd) : base(missiecode, naam, locatie, beschrijving, isSjabloon, type)
        {
            this.StartDatum = startDatum;
            this.EindDatum = eindDatum;
            this.GoedGekeurd = goedGekeurd;
        }
        #endregion

        #region methods

        /// <summary>
        /// Voegt een HOPE missie toe aan de database.
        /// </summary>
        /// <returns></returns>
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
