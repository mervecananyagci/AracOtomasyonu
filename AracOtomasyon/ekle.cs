using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AracOtomasyon
{
    public partial class ekle : Form
    {
        public ekle()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           


        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void ekle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AracIcerik aracIcerik = new AracIcerik();
            aracIcerik.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5TQN0SS\\SQLEXPRESS;Initial Catalog=aracTakip;Integrated Security=True");
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from bilgi where plaka_no=@plaka_no", baglanti);
            komut.Parameters.AddWithValue("@plaka_no", textBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Kayıtlı plaka numarası ..");
            }
            else
            {
                dr.Close();
                SqlCommand kmt = new SqlCommand("insert into bilgi(plaka_no,model,m_baslangic,m_bitis,s_baslangic,s_bitis,db_tanker,dolum_tarih,bosaltma_tarih,nereye) values (@plaka_no,@model,@m_baslangic,@m_bitis,@s_baslangic,@s_bitis,@db_tanker,@dolum_tarih,@bosaltma_tarih,@nereye)", baglanti);
                kmt.Parameters.AddWithValue("@plaka_no", textBox2.Text);
                kmt.Parameters.AddWithValue("@model", textBox1.Text);
                kmt.Parameters.AddWithValue("@db_tanker", textBox3.Text);
                kmt.Parameters.AddWithValue("@nereye", textBox4.Text);
                kmt.Parameters.AddWithValue("@m_baslangic", dateTimePicker2.Value);
                kmt.Parameters.AddWithValue("@m_bitis", dateTimePicker1.Value);
                kmt.Parameters.AddWithValue("@s_baslangic", dateTimePicker3.Value);
                kmt.Parameters.AddWithValue("@s_bitis", dateTimePicker4.Value);
                kmt.Parameters.AddWithValue("@dolum_tarih", dateTimePicker5.Value);
                kmt.Parameters.AddWithValue("@bosaltma_tarih", dateTimePicker6.Value);
                kmt.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı.");
                baglanti.Close();
                AracIcerik aracIcerik = new AracIcerik();
                aracIcerik.Show();
                this.Close();
            }
        }
    }
}
