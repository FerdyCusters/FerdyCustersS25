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
    public partial class HomePagina : Form
    {
        public HomePagina()
        {
            InitializeComponent();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aan deze functionaliteit wordt momenteel nog gewerkt");
        }

        private void btnMetingen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aan deze functionaliteit wordt momenteel nog gewerkt");
        }

        private void btnMissie_Click(object sender, EventArgs e)
        {
            new MissiePagina().Show();
            this.Hide();
        }

        private void btnLogUit_Click(object sender, EventArgs e)
        {
            new LogIn().Show();
            this.Hide();
        }


    }
}
