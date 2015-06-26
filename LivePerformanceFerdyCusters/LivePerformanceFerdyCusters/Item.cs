using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformanceFerdyCusters
{
    public class Item
    {
        #region Fields
        public int Itemcode { get; set; }
        public string Naam { get; set; }
        public Missie Missie { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van Item
        /// </summary>
        /// <param name="itemcode"></param>
        /// <param name="naam"></param>
        public Item(int itemcode, string naam)
        {
            this.Itemcode = itemcode;
            this.Naam = naam;
        }
        #endregion

        #region Methods

        /// <summary>
        /// ToString() methode van Item
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Naam;
        }

        #endregion


    }
}
