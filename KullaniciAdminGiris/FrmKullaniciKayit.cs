using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KullaniciAdminGiris
{
    public partial class FrmKullaniciKayit : Form
    {
        public FrmKullaniciKayit()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmAna frmAna = new FrmAna();
            frmAna.Show();
            this.Hide();
        }

        SqlConnection connection = new SqlConnection("Server= TRN00352; Initial Catalog= KayitIslem; Integrated Security= True");
        
        public void Save()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                SqlCommand command = new SqlCommand("Insert into Users (UserName,Password,UserType) values (@kullanici, @sifre,@type)", connection);

                command.Parameters.AddWithValue("@kullanici", tbxKullanici.Text);
                command.Parameters.AddWithValue("@sifre", tbxKullaniciSifre.Text);
                command.Parameters.AddWithValue("@type", "kullanici");

                command.ExecuteNonQuery();

                if (connection.State == ConnectionState.Open)
                    connection.Close();

                MessageBox.Show("Kayıt işmeniniz başarıyla gerçekleşti!!");
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen kullanıcı adı seçerken 15 karakterden fazla kullanmadığınızdan emin olun");
                
            }
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            tbxKullanici.Clear();
            tbxKullaniciSifre.Clear();
        }
    }
}
