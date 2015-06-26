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
        /// Initializeert de database connectie.
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
                MessageBox.Show("Connectie met de database gaat mis. Kijk of u met VPN bent verbonden of probeer het later nog eens.");
                return false;
            }
        }

        /// <summary>
        /// Returned True als er succesvol connectie met de database kan worden gemaakt.
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

        #region Sjabloon

        /// <summary>
        /// Haalt alle sjablonen (Missieprofielen) uit de database.
        /// </summary>
        /// <returns></returns>
        public static List<Missie> GetSjablonen()
        {
            try
            {
                List<Missie> rtrn = null;

                conn.Open();
                cmd.CommandText = "SELECT MISSIECODE, NAAM, LOCATIE, BESCHRIJVING, ISSJABLOON, TYPE FROM MISSIE WHERE ISSJABLOON = 'True'";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<Missie>();
                    while (dr.Read())
                    {
                        rtrn.Add(new Missie(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToBoolean(dr[4]), dr[5].ToString()));
                    }
                }

                return rtrn;
            }
            catch (OracleException msg)
            {
                MessageBox.Show(msg.Message + "\n Het ziet ernaar uit dat de connectie met de database niet werkt. Toch is er wat testdata ingevoerd voor het geval dat dit zou gebeuren");

                // Data om toch iets in het programma te kunnen doen, ondanks een eventueel defectie database.

                List<Missie> catchList = new List<Missie>();
                Missie catchSjabloonSIN = new Missie(1001, "Sin", "(100,100)", "", true, "Sin");
                Missie catchSjabloonHOPE = new Missie(1002, "Hope", "(100,100)", "", true, "Hope");
                catchList.Add(catchSjabloonSIN);
                catchList.Add(catchSjabloonHOPE);
                return catchList;
            }
            catch
            {
                return null;
            }
            finally
            {
                try
                {
                    dr.Close();
                    conn.Close();
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Haalt één sjabloon uit de database
        /// </summary>
        /// <param name="naam"></param>
        /// <returns></returns>
        public static Missie GetSjabloon(string naam)
        {
            try
            {
                conn.OpenAsync();
                cmd.CommandText = "SELECT MISSIECODE, NAAM, LOCATIE, BESCHRIJVING, ISSJABLOON, TYPE FROM MISSIE WHERE ISSJABLOON = 'True' AND Naam = '" + naam + "'";
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return new Missie(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToBoolean(dr[4]), dr[5].ToString());
                }
                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        #endregion

        #region Missie

        /// <summary>
        /// Voegt Missie toe an de database
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static bool AddMissie(Missie m)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO MISSIE (NAAM, LOCATIE, BESCHRIJVING, ISSJABLOON, TYPE) VALUES ('" + m.Naam + "', '" + m.Locatie + "', '" + m.Beschrijving + "', '" + m.IsSjabloon + "', '" + m.Type + "')";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (OracleException msg)
            {
                MessageBox.Show(msg.Message);
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Haalt de juiste missiecode uit de database
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int GetMissieCode(Missie m)
        {
            try
            {
                int rtrn = -1;
                conn.Open();
                cmd.CommandText = "SELECT MISSIECODE FROM MISSIE WHERE NAAM = '" + m.Naam + "'";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        rtrn = (Convert.ToInt32(dr[0].ToString()));
                    }
                }

                return rtrn;
            }
            catch (OracleException msg)
            {
                MessageBox.Show(msg.Message);
                return 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
                try
                {
                    dr.Close();
                    conn.Close();
                }
                catch
                {

                }
            }
        }

        #endregion 

        #region HOPE

        /// <summary>
        /// Haalt alle Hope missies uit de database
        /// </summary>
        /// <returns></returns>
        public static List<HOPE> GetHopeMissies()
        {
            try
            {
                List<HOPE> rtrn = new List<HOPE>();

                conn.Open();
                cmd.CommandText = "SELECT M.MISSIECODE, M.NAAM, M.LOCATIE, M.BESCHRIJVING, M.ISSJABLOON, M.TYPE, H.STARTDATUM, H.EINDDATUM, H.GOEDGEKEURD FROM MISSIE M, HOPE H WHERE M.MISSIECODE = H.MISSIECODE AND M.ISSJABLOON = 'False'";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<HOPE>();
                    while (dr.Read())
                    {
                        rtrn.Add(new HOPE(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToBoolean(dr[4]), dr[5].ToString(), Convert.ToDateTime(dr[6]), Convert.ToDateTime(dr[7]), Convert.ToBoolean(dr[8])));
                    }
                }

                return rtrn;
            }
            catch
            {
                return null;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        /// <summary>
        /// Voegt een hope missie toe aan de database
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static bool AddHope(HOPE h)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO HOPE (MISSIECODE, STARTDATUM, EINDDATUM, GOEDGEKEURD) VALUES ('" + h.Missiecode + "', TO_DATE('" + h.StartDatum + "', 'DD:MM:YYYY HH24:MI:SS'), TO_DATE('" + h.EindDatum + "', 'DD:MM:YYYY HH24:MI:SS'), '" + h.GoedGekeurd + "')";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (OracleException msg)
            {
                MessageBox.Show(msg.Message);
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch
                {

                }
            }
        }
        #endregion

        #region SIN

        /// <summary>
        /// Haalt alle SIN missies uit de database
        /// </summary>
        /// <returns></returns>
        public static List<SIN> GetSinMissies()
        {
            try
            {
                List<SIN> rtrn = new List<SIN>();

                conn.Open();
                cmd.CommandText = "SELECT M.MISSIECODE, M.NAAM, M.LOCATIE, M.BESCHRIJVING, M.ISSJABLOON, M.TYPE, S.AANTALPOLITIE, S.STARTDATUM, S.EINDVERSLAG FROM MISSIE M, SIN S WHERE M.ISSJABLOON = 'False' AND M.MISSIECODE = S.MISSIECODE";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<SIN>();
                    while (dr.Read())
                    {
                        rtrn.Add(new SIN(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToBoolean(dr[4]), dr[5].ToString(), Convert.ToInt32(dr[6]), Convert.ToDateTime(dr[7]), dr[8].ToString()));
                    }
                }

                return rtrn;
            }
            catch
            {
                return null;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        /// <summary>
        /// Voegt een Sin missie toe aan de database.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool AddSin(SIN s)
        {
            try
            {
                conn.Open();
                cmd.CommandText = "INSERT INTO SIN (MISSIECODE, AANTALPOLITIE, STARTDATUM, EINDVERSLAG) VALUES ('" + s.Missiecode + "', '" + s.AantalPolitie + "', TO_DATE('" + s.StartDatum + "', 'DD:MM:YYYY HH24:MI:SS'), '" + s.Eindverslag + "')";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (OracleException msg)
            {
                MessageBox.Show(msg.Message);
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch
                {

                }
            }
        }
        #endregion

        #region personen

        /// <summary>
        /// Haalt alle personen aan land op uit de database
        /// </summary>
        /// <param name="missie"></param>
        /// <returns></returns>
        public static List<Persoon> GetPersonenAanLand(Missie missie)
        {
            try
            {
                List<Persoon> rtrn = null;

                conn.Open();
                cmd.CommandText = "SELECT PERSONEEL.PERSONEELCODE, PERSONEEL.NAAM, GEBRUIKERSNAAM, WACHTWOORD, GEBOORTEDATUM, FUNCTIE FROM PERSONEEL";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<Persoon>();
                    while (dr.Read())
                    {
                        rtrn.Add(new Persoon(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[4]), dr[5].ToString()));
                    }
                }

                return rtrn;
            }
            catch (OracleException msg)
            {
                MessageBox.Show("Ophalen van bestaande personen niet gelukt!");

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                try
                {
                    dr.Close();
                    conn.Close();
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Haalt alle personen aan boord op uit de database.
        /// </summary>
        /// <param name="missie"></param>
        /// <returns></returns>
        public static List<Persoon> GetPersonenAanBoord(Missie missie)
        {
            try
            {
                List<Persoon> rtrn = null;

                conn.Open();
                cmd.CommandText = "SELECT PERSONEEL.PERSONEELCODE, PERSONEEL.NAAM, GEBRUIKERSNAAM, WACHTWOORD, GEBOORTEDATUM, FUNCTIE FROM PERSONEEL, MISSIE, MISSIE_PERSONEEL WHERE PERSONEEL.PERSONEELCODE = MISSIE_PERSONEEL.PERSONEELCODE AND MISSIE_PERSONEEL.MISSIECODE = MISSIE.MISSIECODE AND MISSIE.MISSIECODE = '" + missie.Missiecode + "'";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<Persoon>();
                    while (dr.Read())
                    {
                        rtrn.Add(new Persoon(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToDateTime(dr[4]), dr[5].ToString()));
                    }
                }

                return rtrn;
            }
            catch (OracleException msg)
            {
                MessageBox.Show("Ophalen van bestaande personen niet gelukt!");

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                try
                {
                    dr.Close();
                    conn.Close();
                }
                catch
                {

                }
            }
        }

        #endregion

        #region Boot

        /// <summary>
        /// Haalt alle boten uit de database
        /// </summary>
        /// <returns></returns>
        public static List<Boot> GetBoten()
        {
            try
            {
                List<Boot> rtrn = new List<Boot>();

                conn.Open();
                cmd.CommandText = "SELECT BOOTCODE, NAAM, MAXSNELHEID, MAXPERSONEN, LOCATIE FROM BOOT";
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    rtrn = new List<Boot>();
                    while (dr.Read())
                    {
                        rtrn.Add(new Boot(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), Convert.ToInt32(dr[3]), dr[4].ToString()));
                    }
                }

                return rtrn;
            }
            catch
            {
                return null;
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        #endregion

    }
}
