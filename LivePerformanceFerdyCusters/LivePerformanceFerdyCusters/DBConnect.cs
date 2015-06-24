using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace LivePerformanceFerdyCusters
{
    public static class DBConnect
    {

        #region Fields
        private static OracleConnection conn;
        private static OracleCommand cmd = new OracleCommand();
        private static OracleDataReader dr;
        #endregion

        #region General
        /// <summary>
        /// Initializes the database connection
        /// </summary>
        public static bool InitializeConnection()
        {
            try
            {
                string user = "dbi327664";
                string pw = "ryCIAFqFBz";
                string connstring = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //fhictora01.fhict.local:1521/fhictora" + ";";
                conn = new OracleConnection(connstring);
                cmd.Connection = conn;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true when we are connected to the database.
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Connectie met de database gaat mis. Kijk of u met VPN bent verbonden of probeer het later nog eens.");
                return false;
            }
        }
        #endregion

    }
}
