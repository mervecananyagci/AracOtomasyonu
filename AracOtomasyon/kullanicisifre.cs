using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace AracOtomasyon
{
    public partial class Kullanicisifre : Form
    {
        public Kullanicisifre()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5TQN0SS\\SQLEXPRESS;Initial Catalog=aracTakip;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from kullanici where kullanici=@kullanici and sifre=@sifre", baglanti);
            komut.Parameters.AddWithValue("@kullanici", textBox1.Text);
            komut.Parameters.AddWithValue("@sifre", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                baglanti.Close();
                AracIcerik frm = new AracIcerik();
                frm.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı veya şifre !");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
