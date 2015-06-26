﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePerformanceFerdyCusters
{
    public class Missie
    {
        #region Fields
        public int Missiecode { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public string Beschrijving { get; set; }
        public bool IsSjabloon { get; set; }
        public string Type { get; set; }
        public Boot Boot { get; set; }
        public List<Meting> Metingen { get; set; }
        public List<Persoon> Personen { get; set; }
        public List<Item> Items { get; set; }
        public List<Incident> Incidenten { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor van Missie
        /// </summary>
        /// <param name="missiecode"></param>
        /// <param name="naam"></param>
        /// <param name="locatie"></param>
        /// <param name="beschrijving"></param>
        /// <param name="isSjabloon"></param>
        /// <param name="type"></param>
        public Missie(int missiecode, string naam, string locatie, string beschrijving, bool isSjabloon, string type)
        {
            this.Missiecode = missiecode;
            this.Naam = naam;
            this.Locatie = locatie;
            this.Beschrijving = beschrijving;
            this.IsSjabloon = isSjabloon;
            this.Type = type;
        }
        #endregion

        #region Methodes
        /// <summary>
        /// ToString() Methode van Missie.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Naam + " " + this.Locatie + " " + this.Type;
        }

        public bool VoegMetingToe()
        {
            //TODO
            return false;
        }

        public bool VoegPersoonToe()
        {
            //TODO
            return false;
        }

        public bool VoegItemToe()
        {
            //TODO
            return false;
        }

        public bool VoegBootToe()
        {
            //TODO
            return false;
        }

        public bool BerekenAfstand()
        {
            //TODO
            return false;
        }
        #endregion
    }
}
