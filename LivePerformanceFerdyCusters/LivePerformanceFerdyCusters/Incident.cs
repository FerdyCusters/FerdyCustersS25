using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformanceFerdyCusters
{
    public class Incident
    {

        #region Fields
        public int Incidentcode { get; set; }
        public string Beschrijving { get; set; }
        public Missie missie { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van Incident
        /// </summary>
        /// <param name="incidentcode"></param>
        /// <param name="beschrijving"></param>
        public Incident(int incidentcode, string beschrijving)
        {
            this.Incidentcode = incidentcode;
            this.Beschrijving = beschrijving;
        }
        #endregion

        #region Methods

        /// <summary>
        /// ToString() methode van Incident
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Beschrijving;
        }

        #endregion
    }
}
