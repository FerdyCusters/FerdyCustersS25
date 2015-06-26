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
    public partial class LogIn : Form
    {
        /// <summary>
        /// Login Form
        /// </summary>
        public LogIn()
        {
            InitializeComponent();
            DBConnect.InitializeConnection();
        }

        /// <summary>
        /// Verwijst door naar de homepagina.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            new HomePagina().Show();
            this.Hide();
        }
    }
}
