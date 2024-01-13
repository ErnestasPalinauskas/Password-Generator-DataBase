using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Egzaminas
{
    public partial class Prisijungimas : Form
    {
        // Tėvo formos nuoroda
        public Pagrindinis Pagrindinis { get; set; }

        // Konstruktorius
        public Prisijungimas()
        {
            InitializeComponent();
        }

        // Funkcija, kuri vykdoma paspaudus mygtuką "Accept"
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string password = textBoxMaster.Text;
            try
            {
                // Gaunamas "salt" iš duomenų bazės
                string saltString = GetSaltFromDB();

                // "Salt" konvertuojamas iš string formato į byte masyvą
                byte[] saltBytes = ConvertSaltStringToByteArray(saltString);

                // Sukuriamas "hash" naudojant "salt"
                password = CreateHash(password, saltBytes);

                // Gaunamas "hash" iš duomenų bazės
                string hash = GetHashFromDB();

                // Patikrinama ar sukurtas "hash" sutampa su "hash" iš duomenų bazės
                if (password == hash)
                {
                    this.Pagrindinis.allowConnection = true;
                    this.Pagrindinis.GetConnectionPassword(textBoxMaster.Text);
                    this.Close();
                }
                else
                {
                    this.Pagrindinis.allowConnection = false;
                    MessageBox.Show("Neteisingas slaptažodis");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Įvyko klaida");
            }
        }

        // Funkcija, kuri grąžina salt iš duomenų bazės
        private string GetSaltFromDB()
        {
            string query = "SELECT salt FROM masterPassword";
            SqlCommand sql = new SqlCommand(query, Pagrindinis.sqlconnection);
            return Convert.ToString(sql.ExecuteScalar());
        }

        // Funkcija, kuri konvertuoja salt iš string formato į byte masyvą
        private byte[] ConvertSaltStringToByteArray(string saltString)
        {
            String[] arr = saltString.Split('-');
            byte[] saltBytes = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++) saltBytes[i] = Convert.ToByte(arr[i], 16);
            return saltBytes;
        }

        // Funkcija, kuri sukuria hash naudojant salt
        private string CreateHash(string password, byte[] saltBytes)
        {
            SHA256Hash.Hashing hashing = new SHA256Hash.Hashing();
            return hashing.Hash(password, saltBytes);
        }

        // Funkcija, kuri grąžina "hash" iš duomenų bazės
        private string GetHashFromDB()
        {
            string query = "SELECT PasswordHash FROM masterPassword";
            SqlCommand sql = new SqlCommand(query, Pagrindinis.sqlconnection);
            return Convert.ToString(sql.ExecuteScalar());
        }

        // Funkcija, kuri vykdoma paspaudus mygtuką "Cancel"
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConnect_Load(object sender, EventArgs e)
        {

        }
    }
}
