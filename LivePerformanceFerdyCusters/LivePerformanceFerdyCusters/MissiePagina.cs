using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LivePerformanceFerdyCusters
{
    public partial class MissiePagina : Form
    {

        public List<Missie> sjablonen = new List<Missie>();
        public List<SIN> bestaandeSins = new List<SIN>();
        public List<HOPE> bestaandeHopes = new List<HOPE>();
        public List<Persoon> landPersonen = new List<Persoon>();
        public List<Persoon> zeePersonen = new List<Persoon>();
        public List<Item> landMateriaal = new List<Item>();
        public List<Item> zeeMateriaal = new List<Item>();
        public List<Incident> bestaandeIncidenten = new List<Incident>();
        public List<Meting> bestaandeMetingen = new List<Meting>();
        public List<Boot> bestaandeBoten = new List<Boot>();
        

        public MissiePagina()
        {
            InitializeComponent();
            Refresh("None");
        }

        private void btnGaTerug_Click(object sender, EventArgs e)
        {
            new HomePagina().Show();
            this.Hide();
        }

        #region Refresh Methode
        /// <summary>
        /// Deze methode refreshed alle listboxen in het form. In deze methode moet ik functionaliteit in de GUI laag stoppen.
        /// Dit is de enige manier om de listboxen up-to-date te houden met de huidige situatie.
        /// </summary>
        /// <param name="indicator"></param>
        public void Refresh(string indicator)
        {
            pnBasis.Visible = false;
            pnHOPE.Visible = false;
            pnSIN.Visible = false;
            lbPersonenAanBoord.Items.Clear();
            lbPersonenAanLand.Items.Clear();
            lbMissies.Items.Clear();

            if(indicator.Contains("Sin"))
            {
                pnBasis.Visible = true;
                pnSIN.Visible = true;
                lblMissieText.Text = "Lopende SIN Missies:";
                bestaandeSins = DBConnect.GetSinMissies();
                if(bestaandeSins != null)
                {
                    foreach(SIN sin in bestaandeSins)
                    {
                        lbMissies.Items.Add(sin.ToString());
                    }
                }
            }

            if(indicator.Contains("Hope"))
            {
                pnBasis.Visible = true;
                pnHOPE.Visible = true;
                lblMissieText.Text = "Lopende HOPE Missies:";
                bestaandeHopes = DBConnect.GetHopeMissies();
                if (bestaandeHopes != null)
                {
                    foreach (HOPE hope in bestaandeHopes)
                    {
                        lbMissies.Items.Add(hope.ToString());
                    }
                }
            }

            if (sjablonen.Count < 1)
            {
                sjablonen = DBConnect.GetSjablonen();

                foreach (Missie missie in sjablonen)
                {
                    cbProfiel.Items.Add(missie.Naam);
                }
            }

            if (bestaandeBoten.Count < 1)
            {
                bestaandeBoten = DBConnect.GetBoten();

                foreach(Boot b in bestaandeBoten)
                {
                    cbBoot.Items.Add(b.Naam);
                }
            }

            Missie huidigeMissie = DBConnect.GetSjabloon(indicator);

            landPersonen = DBConnect.GetPersonenAanLand(huidigeMissie);
            if (landPersonen != null)
            {
                foreach (Persoon persoon in landPersonen)
                {
                    lbPersonenAanLand.Items.Add(persoon.ToString());
                }
            }

            zeePersonen = DBConnect.GetPersonenAanBoord(huidigeMissie);
            if (zeePersonen != null)
            {
                foreach (Persoon persoon in zeePersonen)
                {
                    lbPersonenAanBoord.Items.Add(persoon.ToString());
                }
            }
        }

        #endregion


        /// <summary>
        /// Event Handler voor het afhandelen van de verandere combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbProfiel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cbProfiel.SelectedItem.ToString();
            Refresh(selectedType);
        }

        /// <summary>
        /// Missie wordt toegevoegd.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoegMissieToe_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProfiel.Text.Contains("Hope"))
                {
                    bool goedgekeurd = false;
                    if (cbGoedGekeurd.Checked == true)
                    {
                        goedgekeurd = true;
                    }
                    HOPE hope = new HOPE(-1, txtMissieNaam.Text, "(" + txtLocatieX.Text + "," + txtLocatieY.Text + ")", txtMissieBeschrijving.Text, false, "Hope", Convert.ToDateTime(dtpStartDatum.Value), Convert.ToDateTime(dtpEindDatum.Value), goedgekeurd);
                    hope.VoegHopeToe();
                    MessageBox.Show("Hope missie toegevoegd!");
                }
            }      
            catch
            {
                MessageBox.Show("Vul juiste informatie in!");
            }


            try
            {
                if (cbProfiel.Text.Contains("Sin"))
                {
                    SIN sin = new SIN(-1, txtMissieNaam.Text, "(" + txtLocatieX.Text + "," + txtLocatieY.Text + ")", txtMissieBeschrijving.Text, false, "Sin", Convert.ToInt32(txtAantalPolitie.Text), Convert.ToDateTime(dtpStartDatum.Value), txtEindverslag.Text);
                    sin.VoegSinToe();
                    MessageBox.Show("Sin missie toegevoegd!");
                }
            }
            catch
            {
                MessageBox.Show("Vul alle informatie juist in!");
            }
            Refresh("None");
        }
    }
}
