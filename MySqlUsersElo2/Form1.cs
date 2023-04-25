using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MySqlUsersElo2
{
    public partial class Form1 : Form
    {
        #region Változók definiálása
        // Kapcsolat property
        private MySqlConnection msqlConn;
        private MySqlDataReader msqlDr;

        private string userTeljesLista = "usersTeljesLista";
        private string userInsert = "UserInsert";
        private string userUpdate = "UserUpdate";
        private string userDelete = "UserDelete";

        // A Form és az adatbázis állapotai
        private enum FormState
        {
            Closed, // Zárva, nincs csatlakozva
            Opened,     // Adatbázishoz csatlakozva, de olvasásra nincs megnyitva
            Reading,    // Olvasás közben
            EditInsert,  // Beszúrás adatainak beírása közben
            EditUpdate  // Rekord szerkesztése közben
        }
        private FormState formState = FormState.Closed;

        // Gomb feliratok
        private string insBasic = "Beszúrás";
        private string insEdit = "Szerkesztés vége";
        private string updBasic = "Módosítás";
        private string updEdit = "Módosítás vége";

        // Üzenet szövegek
        private string openSikeres = "A kapcsolódás az adatbázishoz sikeres!",
            openNemSikeres = "A kapcsolódás az adatbázishoz sikertelen!",
            canToRead = "Az olvasás megkezdődhet!",
            closedDB = "Az adatbázis bezárva";

        // Gombok kollekciója
        private List<Button> lstButtons = new List<Button>();

        #endregion Változók definiálása


        public Form1()
        {
            InitializeComponent();
            // Gomb lista feltöltése
            lstButtons.Add(btnConn);
            lstButtons.Add(btnOpen);
            lstButtons.Add(btnRead);
            lstButtons.Add(btnInsert);
            lstButtons.Add(btnUpdate);
            lstButtons.Add(btnDelete);
            lstButtons.Add(btnClose);
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            mysqlConnect();
        }

        #region Kapcsolódás az adatbázishoz
        private void mysqlConnect()
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.UserID = "root";
            sb.Password = "";
            sb.Database = "iktat";

            try
            {
                msqlConn = new MySqlConnection(sb.ToString());
                msqlConn.Open();
                MessageBox.Show(openSikeres);

                formState = FormState.Opened;
                buttonSwitch(formState);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"{openNemSikeres} \n {ex.Message}");
            }
        }
        #endregion Kapcsolódás az adatbázishoz

        #region Gombok elérhetőségének beállítása
        private void buttonSwitch(FormState fs)
        {
            switch (fs)
            {
                case FormState.Closed:
                    foreach (var item in lstButtons)
                        item.Enabled = false;
                    btnConn.Enabled = true;
                    break;

                case FormState.Opened:
                    foreach (var item in lstButtons)
                        item.Enabled = true;
                    btnConn.Enabled = false;
                    btnRead.Enabled = false;

                    tbxID.Enabled = false;
                    tbxNev.Enabled = false;
                    tbxJelszo.Enabled = false;
                    cbxAdmin.Enabled = false;

                    // Gomb feliratok
                    btnInsert.Text = insBasic;
                    btnUpdate.Text = updBasic;
                    break;

                case FormState.Reading:
                    foreach (var item in lstButtons)
                        item.Enabled = true;
                    btnConn.Enabled = false;
                    btnOpen.Enabled = false;
                    break;

                case FormState.EditInsert:
                    foreach (var item in lstButtons)
                        item.Enabled = false;
                    btnInsert.Enabled = true;
                    btnClose.Enabled = true;

                    // Beviteli mezők elérhetősége
                    tbxNev.Enabled = true;
                    tbxJelszo.Enabled = true;
                    cbxAdmin.Enabled = true;

                    // Beviteli mezők ürítése
                    tbxNev.Text = String.Empty;
                    tbxJelszo.Text = String.Empty;
                    cbxAdmin.Checked = false;

                    // Gomb feliratok
                    btnInsert.Text = insEdit;
                    break;

                case FormState.EditUpdate:
                    foreach (var item in lstButtons)
                        item.Enabled = false;
                    btnUpdate.Enabled = true;
                    btnClose.Enabled = true;

                    tbxNev.Enabled = true;
                    tbxJelszo.Enabled = true;
                    cbxAdmin.Enabled = true;

                    // Gomb feliratok
                    btnUpdate.Text = updEdit;
                    break;
            }
        }
        #endregion Gombok elérhetőségének beállítása

        #region Adatbázis megnyitása
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (MySqlCommand sqlComm = new MySqlCommand(userTeljesLista, msqlConn))
            {
                sqlComm.CommandType = CommandType.StoredProcedure;

                try
                {
                    // Olvasás a táblából
                    msqlDr = sqlComm.ExecuteReader();

                    MessageBox.Show(canToRead);

                    formState = FormState.Reading;
                    buttonSwitch(formState);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion Adatbázis megnyitása

        private void btnRead_Click(object sender, EventArgs e)
        {
            NextUser();
        }

        #region A következő rekord olvasása
        private void NextUser()
        {
            // A következő rekord olvasása
            msqlDr.Read();
            tbxID.Text = msqlDr[0].ToString().Trim();
            tbxNev.Text = msqlDr[1].ToString().Trim();
            tbxJelszo.Text = msqlDr[2].ToString().Trim();
            cbxAdmin.Checked = (bool)msqlDr[3];
        }
        #endregion A következő rekord olvasása

        private void btnInsert_Click(object sender, EventArgs e)
        {
            switch (formState)
            {
                case FormState.Opened:
                    formState = FormState.EditInsert;
                    buttonSwitch(formState);
                    break;
                case FormState.Reading:
                    msqlDr.Close();
                    formState = FormState.EditInsert;
                    buttonSwitch(formState);
                    break;
                case FormState.EditInsert:
                    InsertUser(tbxNev.Text, tbxJelszo.Text, (cbxAdmin.Checked) ? 1 : 0);
                    formState = FormState.Opened;
                    buttonSwitch(formState);
                    break;
            }
        }

        #region Rekord beszúrása
        private void InsertUser(string pNev, string pJelszo, int pAdmin)
        {
            using (MySqlCommand sqlComm = new MySqlCommand(userInsert, msqlConn))
            {
                sqlComm.CommandType = CommandType.StoredProcedure;

                // Paraméterek beállítása
                MySqlParameter p = new MySqlParameter();
                p.ParameterName = "pNev";
                p.Value = pNev;
                p.MySqlDbType = MySqlDbType.String;
                sqlComm.Parameters.Add(p);

                sqlComm.Parameters.AddWithValue("pJelszo", pJelszo);
                sqlComm.Parameters.AddWithValue("pAdmin", pAdmin);

                try
                {
                    // Végrehajtás a táblán
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("Az rekord felvétele sikeres.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion Rekord beszúrása

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            switch (formState)
            {
                case FormState.Opened:
                    formState = FormState.EditUpdate;
                    buttonSwitch(formState);
                    break;
                case FormState.Reading:
                    msqlDr.Close();
                    formState = FormState.EditUpdate;
                    buttonSwitch(formState);
                    break;
                case FormState.EditUpdate:
                    UpdateUser(Convert.ToInt32(tbxID.Text), tbxNev.Text, tbxJelszo.Text, (cbxAdmin.Checked) ? 1 : 0);
                    formState = FormState.Opened;
                    buttonSwitch(formState);
                    break;
            }
        }

        #region Rekord módosítása
        private void UpdateUser(int pID, string pNev, string pJelszo, int pAdmin)
        {
            using (MySqlCommand sqlComm = new MySqlCommand(userUpdate, msqlConn))
            {
                sqlComm.CommandType = CommandType.StoredProcedure;

                // Paraméterek beállítása
                sqlComm.Parameters.AddWithValue("ID", pID);

                MySqlParameter p = new MySqlParameter();
                p.ParameterName = "Nev";
                p.Value = pNev;
                p.MySqlDbType = MySqlDbType.String;
                sqlComm.Parameters.Add(p);

                sqlComm.Parameters.AddWithValue("Jelszo", pJelszo);
                sqlComm.Parameters.AddWithValue("Admin", pAdmin);

                try
                {
                    // Írás a táblába
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("Az rekord módosítása sikeres.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion Rekord módosítása

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (formState)
            {
                case FormState.Reading:
                    break;
            }
            if (formState == FormState.Reading)
            {
                msqlDr.Close();
                formState = FormState.Opened;
                buttonSwitch(formState);
            }
            DeleteUser(Convert.ToInt32(tbxID.Text));
        }

        #region Rekord törlése
        private void DeleteUser(int pID)
        {
            using (MySqlCommand sqlComm = new MySqlCommand(userDelete, msqlConn))
            {
                sqlComm.CommandType = CommandType.StoredProcedure;

                // Paraméterek beállítása
                sqlComm.Parameters.AddWithValue("ID", pID);

                try
                {
                    // Törlés a táblából
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show("A rekord törlése sikeres.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion Rekord törlése

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (msqlConn != null) msqlConn.Close();
            MessageBox.Show(closedDB);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            msqlConn.Close();
            MessageBox.Show(closedDB);

            formState = FormState.Closed;
            buttonSwitch(formState);
        }
    }
}
