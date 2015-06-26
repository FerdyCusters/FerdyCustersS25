namespace LivePerformanceFerdyCusters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Homepagina.
    /// </summary>
    public partial class HomePagina : Form
    {
        public HomePagina()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Verwijst door naar de accountpagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccounts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aan deze functionaliteit wordt momenteel nog gewerkt");
        }

        /// <summary>
        /// Verwijst door naar de metingen pagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMetingen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aan deze functionaliteit wordt momenteel nog gewerkt");
        }

        /// <summary>
        /// Verwijst door naar de missie pagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMissie_Click(object sender, EventArgs e)
        {
            new MissiePagina().Show();
            this.Hide();
        }

        /// <summary>
        /// Gaat terug naar de inlogpagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogUit_Click(object sender, EventArgs e)
        {
            new LogIn().Show();
            this.Hide();
        }


    }
}
