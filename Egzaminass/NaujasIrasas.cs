using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Egzaminas
{
    public partial class NaujasIrasas : Form
    {
        //tėvo forma
        public Pagrindinis Pagrinidnis { get; set; }


        //generuojamo slaptažodžio parametrai
        public int Length = 16;
        public int upperCase = -1;
        public int lowerCase = -1;
        public int numbers = -1;
        public int symbols = -1;

        private string connectionPassword = string.Empty;

        private string selectedId = string.Empty;

        public NaujasIrasas()
        {
            InitializeComponent();
        }


        //Sugeneruojamas slaptažodis, pagal slaptažodžio parametrus
        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            SlaptGen.PasswordGenerator generator = new SlaptGen.PasswordGenerator();
            textBoxPassword.Text = generator.Generate(this.Length, this.upperCase, this.lowerCase, this.numbers, this.symbols);
        }



        //Prideda naują įrašą į duomenų baz

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (textBoxProgram.Text != "" && textBoxPassword.Text != "")
            {
                // Gaunamas Salt
                Salt.Salt saltGen = new Salt.Salt();
                byte[] salt = saltGen.GenerateSalt();

                // Gaunamas koduotas slaptažuodis
                AES.CreateAES aesClass = new AES.CreateAES();
                string encrypted = aesClass.EncryptAES(textBoxPassword.Text, connectionPassword, salt);

                // Konvertuojama salt į string
                string saltString = BitConverter.ToString(salt);

                // Sukuriamas įrašas DB
                SqlCommand cmd;


                // Duomenu iterpimas

                if (selectedId == string.Empty)
                {
                    cmd = new SqlCommand("INSERT INTO UserPassword (Paskirtis, Slaptazodis, Data) VALUES (@abc, @cba, @date)", Pagrinidnis.sqlconnection);
                    cmd.Parameters.AddWithValue("@abc", textBoxProgram.Text);
                    cmd.Parameters.AddWithValue("@cba", textBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                }
                else
                {
                    cmd = new SqlCommand($"UPDATE UserPassword SET Paskirtis = @abc, Slaptazodis = @cba, Data = @date where id = {selectedId}; ", Pagrinidnis.sqlconnection);
                    cmd.Parameters.AddWithValue("@abc", textBoxProgram.Text);
                    cmd.Parameters.AddWithValue("@cba", textBoxPassword.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                }


                try
                {

                    cmd.ExecuteNonQuery();
                    this.Close();
                }

                catch (SqlException ex)
                {
                    MessageBox.Show("Įvyko klaida!!!" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Neteisingai įvesti duomenys!!!");
            }
        }


        // Mygtukas uždarantis langą
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Gaunanama prisijungimo slaptažodį
        public void GetConnectionPassword(string text, string selectedId = "")
        {
            this.connectionPassword = text;

            if (selectedId == "")
            {
                this.selectedId = string.Empty;
            }
            else
            {
                this.selectedId = selectedId;
                this.Text = "Atnaujinti įrašą";
                updateValues();
            }
        }

        public void updateValues()
        {
            textBoxProgram.Text = Pagrinidnis.selectedPaskirtis;
            textBoxPassword.Text = Pagrinidnis.selectedPassword;
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}