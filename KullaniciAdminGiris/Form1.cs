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
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKullaniciKayit frmKullaniciKayit = new FrmKullaniciKayit();
            frmKullaniciKayit.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            textBox1.Visible = true;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "1234")
            {
                FrmYoneticiKayit frmYoneticiKayit = new FrmYoneticiKayit();
                frmYoneticiKayit.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yönetici kodu yanlış. Tekrar deneyiniz!!");
            }
        }

        //******************************************************

        SqlConnection connection = new SqlConnection("Server= TRN00352; Initial Catalog= KayitIslem; Integrated Security= True");

        private void Ekran()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            SqlCommand command = new SqlCommand("Select * from Users", connection);
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                if (reader["UserName"].ToString()==tbxKullanici.Text && reader["Password"].ToString()==tbxSifre.Text)
                {
                    if (reader["UserType"].ToString()=="kullanici")
                    {
                        FrmKullaniciEkran kullaniciEkran = new FrmKullaniciEkran();
                        kullaniciEkran.Show();
                    }
                    else 
                    {
                         FrmYoneticiEkran yoneticiEkran= new FrmYoneticiEkran();
                        yoneticiEkran.Show();
                    }
                   
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış. Tekrar deneyiniz!!");
                    break;
                }


            }
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Ekran();
            tbxKullanici.Clear();
            tbxSifre.Clear();
        }
    }
}
