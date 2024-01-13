using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Egzaminas
{
    public partial class Registracija : Form
    {
        // Tėvo formos nuoroda
        public Pagrindinis Pagrindinis { get; set; }

        // Parametrai slaptažodžio generavimui
        public int Length { get; set; }
        public int UpperCase { get; set; }
        public int LowerCase { get; set; }
        public int Numbers { get; set; }
        public int Symbols { get; set; }

        // Konstruktorius
        public Registracija()
        {
            InitializeComponent();
        }

        // Funkcija, kuri vykdoma paspaudus mygtuką "Generate"
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            GeneratePassword();
        }

        // Funkcija, kuri vykdoma paspaudus mygtuką "Accept"
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            AcceptPassword();
        }

        // Funkcija, kuri vykdoma paspaudus mygtuką "Cancel"
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Funkcija, kuri generuoja slaptažodį
        private void GeneratePassword()
        {
            SlaptGen.PasswordGenerator generator = new SlaptGen.PasswordGenerator();
            textBoxPassword.Text = generator.Generate(this.Length, this.UpperCase, this.LowerCase, this.Numbers, this.Symbols);
        }

        // Funkcija, kuri patvirtina slaptažodį ir įrašo jį į duomenų bazę
        private void AcceptPassword()
        {
            string password = textBoxPassword.Text;

            Salt.Salt saltObj = new Salt.Salt();
            byte[] salt = saltObj.GenerateSalt();

            SHA256Hash.Hashing hashing = new SHA256Hash.Hashing();
            password = hashing.Hash(password, salt);

            string stringSalt = BitConverter.ToString(salt, 0);

            InsertPasswordIntoDB(password, stringSalt);
        }

        // Funkcija, kuri įrašo slaptažodį į duomenų bazę
        private void InsertPasswordIntoDB(string password, string stringSalt)
        {
            string query = "INSERT INTO masterPassword (PasswordHash,salt) VALUES (@hash,@salt)";
            try
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, Pagrindinis.sqlconnection))
                {
                    sqlCommand.Parameters.AddWithValue("@hash", password);
                    sqlCommand.Parameters.AddWithValue("@salt", stringSalt);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Įvyko klaida");
            }
            this.Close();
        }
    }
}
