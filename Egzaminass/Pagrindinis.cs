using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace Egzaminas
{
    public partial class Pagrindinis : Form
    {
        // Prisijungimo prie DB string
        private SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-ER3RDKH\\SQLEXPRESS",
            InitialCatalog = "Egzaminass",
            IntegratedSecurity = true,
        };

        public SqlConnection sqlconnection { get; private set; }

        // Pradinės reikšmės su get; set  metodais, jog sutrumpintu aprašyti savybę su tiek gavimo tiek nustatymo metodais
        public bool allowConnection { get; set; } = false;
        public string connectionPassword { get; set; } = string.Empty;
        public int selectedRow { get; set; }
        public string selectedId { get; set; } = string.Empty;
        public string selectedPaskirtis { get; set; } = string.Empty;
        public string selectedPassword { get; set; } = string.Empty;


        // Prisijungimas prie DB
        private void ConnectDB()
        {
            try
            {
                sqlconnection = new SqlConnection(connectionStringBuilder.ConnectionString);
                sqlconnection.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Nepavyko pasiekti duomenų bazės: {ex.Message}", "Klaida");
            }
        }

        // Panaikina prisijungimo prie DB duomenis
        private void DisconnectDB()
        {
            try
            {
                // Patikriname, ar sqlconnection yra ne null ir ar būsena yra atidaryta
                if (sqlconnection?.State == ConnectionState.Open)
                {
                    sqlconnection.Close();
                }
            }
            catch (Exception ex)
            {
                //  Klaidos pranešimas
                MessageBox.Show($"Nepavyko Atsijungti: {ex.Message}", "Klaida");
            }
            finally
            {
                // Nustatome visus mygtukus ir laukus į pradinę būseną, nepriklausomai nuo to, ar atsijungimas buvo sėkmingas
                buttonNewEntry.Enabled = false;
                dataGridView.DataSource = null;
                this.connectionPassword = string.Empty;
                buttonDisconnect.Enabled = false;
                textBoxSelectData.Text = string.Empty;
                buttonNewEntry.Enabled = false;
                buttonUpdateEntry.Enabled = false;
                buttonDeleteEntry.Enabled = false;
                buttonCopypPaskirtis.Enabled = false;
                buttonCopyPassword.Enabled = false;
            }
        }


        public Pagrindinis()
        {
            ActivateComponents();
        }

        // Atjungimas nuo DB, kai forma uždaroma
        private void PagrindineClose(object sender, FormClosedEventArgs e)
        {
            DisconnectDB();
        }



        // Prisijungimas prie DB, reikia įvesti MASTER slaptažodį
        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            ConnectDB();
            allowConnection = false;
            try
            {
                // Tikrinama, ar yra master slaptažodis
                string query = "SELECT COUNT(*) FROM masterPassword";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlconnection))
                {
                    // Return Value
                    int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                    // Pirmo karto MASTER slaptažodžio patikrinimas
                    if (count == 0)
                    {
                        using (Registracija Registracija = new Registracija())
                        {
                            Registracija.Pagrindinis = this;
                            Registracija.ShowDialog();
                        }
                    }
                    else if (count == 1)
                    {
                        using (Prisijungimas Prisijungimas = new Prisijungimas())
                        {
                            Prisijungimas.Pagrindinis = this;
                            Prisijungimas.ShowDialog();
                        }
                    }

                    // Jei leidžiama prisijungti, atnaujinamas duomenų tinklelis ir įjungiami mygtukai
                    if (allowConnection)
                    {
                        UpdateDataGrid();
                        buttonNewEntry.Enabled = true;
                        buttonDisconnect.Enabled = true;
                    }
                    // Jei neleidžiama prisijungti, atjungiama
                    else
                    {
                        DisconnectDB();
                    }
                }
            }
            catch (Exception ex)
            {
                // Jei įvyksta klaida, parodomas pranešimas
                MessageBox.Show(ex.Message, "Įvyko klaida");
            }
        }

        // Atjungia nuo DB
        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            DisconnectDB();
        }

        //Gauna slaptažodį, kuris buvo panaudotas prisijungiant
        public void GetConnectionPassword(string text)
        {
            this.connectionPassword = text;
        }



        // Atidaro formą, kurioje galima sukurti naują įrašą
        private void ButtonNewEntry_Click(object sender, EventArgs e)
        {
            using (NaujasIrasas NaujasIrasas = new NaujasIrasas())
            {
                NaujasIrasas.Pagrinidnis = this;
                NaujasIrasas.GetConnectionPassword(connectionPassword);
                NaujasIrasas.ShowDialog();
            }
            UpdateDataGrid();
        }

        // Atidaro formą, kurioje galima atnaujinti pasirinktą įrašą
        private void ButtonUpdateEntry_Click(object sender, EventArgs e)
        {
            GetPassword();
            using (NaujasIrasas NaujasIrasas = new NaujasIrasas())
            {
                NaujasIrasas.Pagrinidnis = this;
                NaujasIrasas.GetConnectionPassword(connectionPassword, selectedId);
                NaujasIrasas.ShowDialog();
            }
            UpdateDataGrid();
        }

        //Ištrina pasirinktą įrašą
        private void ButtonDeleteEntry_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ar tikrai pašalinti?", "Patvirtinti", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //gaunami eilutės duomenys
                int selectedRow = dataGridView.CurrentRow.Index;
                string selectedId = Convert.ToString(dataGridView[0, selectedRow].Value);

                SqlCommand sqlCommand = new SqlCommand("DeleteUser", sqlconnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@id", selectedId);
                sqlCommand.ExecuteNonQuery();

                UpdateDataGrid();
            }

        }

        // Nukopijuoja pasrenkta paskirti
        private void ButtonCopyUser_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(selectedPaskirtis, true, 10, 10);
            }
            catch
            {
                MessageBox.Show("Nepavyko nukopijuoti, bandykite dar kartą");
            }
        }


        // Nukopijuoja pasirinkta salptažodį
        private void ButtonCopyPassword_Click(object sender, EventArgs e)
        {
            GetPassword();
            try
            {
                Clipboard.SetDataObject(selectedPassword, true, 10, 10);
            }
            catch
            {
                MessageBox.Show("Nepavyko nukopijuoti, bandykite dar kartą");
            }

        }


        // Stebi ar rodyti slaptažodį ar ne
        private void ShowPassword_Box(object sender, EventArgs e)
        {
            if (dataGridView.DataSource != null)
            {
                UpdateSelected();
            }
        }

        // Stebi, kada paspaudžiama ant DataGridView laukelio
        private void DataGridView_Click(object sender, DataGridViewCellEventArgs e)
        {
            bool IsRowSelected = dataGridView.CurrentRow != null;
            buttonUpdateEntry.Enabled = IsRowSelected;
            buttonDeleteEntry.Enabled = IsRowSelected;
            buttonCopypPaskirtis.Enabled = IsRowSelected;
            buttonCopyPassword.Enabled = IsRowSelected;

            if (IsRowSelected)
            {
                UpdateSelected();
            }
            else
            {
                textBoxSelectData.Text = string.Empty;
            }
        }

        // Atnaujina DataGridView su naujais duomenimis nuskaitant duomenų bazės lentelę
        private void UpdateDataGrid()
        {
            dataGridView.BackgroundColor = Color.White;
            string query = "SELECT * FROM UserPassword";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlconnection))
            {
                DataTable full = new DataTable();
                adapter.Fill(full);
                dataGridView.DataSource = full.DefaultView;
                dataGridView.Columns["id"].Visible = false;
                for (int i = 0; i < dataGridView.RowCount; i++)
                {
                    dataGridView[2, i].Value = "********";
                }
                bool IsDataPresent = dataGridView.DataSource != null;
                buttonUpdateEntry.Enabled = IsDataPresent;
                buttonDeleteEntry.Enabled = IsDataPresent;
                buttonCopypPaskirtis.Enabled = IsDataPresent;
                buttonCopyPassword.Enabled = IsDataPresent;
                buttonNewEntry.Enabled = IsDataPresent;
            }
        }

        // Atnaujina teksto lauką, kuris rodo informaciją apie pasirinktą eilutę
        // Šiame lauke gali būti rodomas slaptažodis
        private void UpdateSelected()
        {
            // Gaunami eilutės duomenys
            selectedRow = dataGridView.CurrentRow.Index;
            selectedId = Convert.ToString(dataGridView[0, selectedRow].Value);
            selectedPaskirtis = Convert.ToString(dataGridView[1, selectedRow].Value);
            string SelectedPassword = checkBoxShowPassword.Checked ? GetPassword() : "********";

            this.Invoke((MethodInvoker)delegate
            {
                textBoxSelectData.Text = $"Paskirtis: {selectedPaskirtis}   Slaptažodis: {SelectedPassword}";
            });
        }

        //
        private string GetPassword()
        {
            // Kuriamas SQL užklausa, kad gauti užšifruotą slaptažodį
            string query = "SELECT Slaptazodis FROM UserPassword WHERE id = @id;";
            SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

            // Pridedamas parametras į SqlCommand
            sqlCommand.Parameters.AddWithValue("@id", selectedId);

            // Vykdome užklausą ir gauname užšifruotą slaptažodį
            string encrypted = Convert.ToString(sqlCommand.ExecuteScalar());
            selectedPassword = encrypted;
            return encrypted;
        }




        private void textBoxProgram_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSelectedData_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {

        }
    }
}