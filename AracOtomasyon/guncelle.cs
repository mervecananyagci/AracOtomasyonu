using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AracOtomasyon
{
    public partial class guncelle : Form
    {
        public guncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void guncelle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult onay = MessageBox.Show("Geri dönmek istediğinize emin misiniz?", "Onay İsteği", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                AracIcerik arac = new AracIcerik();
                arac.Show();
                this.Close();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5TQN0SS\\SQLEXPRESS;Initial Catalog=aracTakip;Integrated Security=True");
            baglanti.Open();
            SqlCommand duzenleme = new SqlCommand("Update bilgi set plaka_no=@plaka_no,model=@model,m_baslangic=@m_baslangic,m_bitis=@m_bitis,s_baslangic=@s_baslangic,s_bitis=@s_bitis,db_tanker=@db_tanker,dolum_tarih=@dolum_tarih,bosaltma_tarih=@bosaltma_tarih,nereye=@nereye where id=@id", baglanti);
            duzenleme.Parameters.AddWithValue("@plaka_no", textBox1.Text);
            duzenleme.Parameters.AddWithValue("@model", textBox2.Text);
            duzenleme.Parameters.AddWithValue("@db_tanker", textBox3.Text);
            duzenleme.Parameters.AddWithValue("@nereye", textBox4.Text);
            duzenleme.Parameters.AddWithValue("@m_baslangic", dateTimePicker1.Value.ToString("yyyy-MM-dd")); // Tarihi "yyyy-MM-dd" formatında biçimlendir
            duzenleme.Parameters.AddWithValue("@m_bitis", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            duzenleme.Parameters.AddWithValue("@s_baslangic", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
            duzenleme.Parameters.AddWithValue("@s_bitis", dateTimePicker4.Value.ToString("yyyy-MM-dd"));
            duzenleme.Parameters.AddWithValue("@dolum_tarih", dateTimePicker5.Value.ToString("yyyy-MM-dd"));    
            duzenleme.Parameters.AddWithValue("@bosaltma_tarih", dateTimePicker6.Value.ToString("yyyy-MM-dd"));
            duzenleme.Parameters.AddWithValue("@id", Program.DuzenlenecekId);
            duzenleme.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Düzenleme Başarılı..");
            AracIcerik aracIcerik = new AracIcerik();
            aracIcerik.Show();
            this.Close();
        }

        private void bunifuDatePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
