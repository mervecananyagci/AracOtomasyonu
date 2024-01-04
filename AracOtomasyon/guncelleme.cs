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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class guncelleme : Form
    {
        public guncelleme()
        {
            InitializeComponent();
        }

        private void guncelleme_Load(object sender, EventArgs e)
        {
        }

        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Properties\\aractakip.mdf;Integrated Security=True");
            baglanti.Open();
            SqlCommand duzenleme = new SqlCommand("Update Icerik set plaka_no=@plaka_no,model=@model,muayene_baslangic=@muayene_baslangic,muayene_bitis=@muayene_bitis,sigorta_baslangic=@sigorta_baslangic,sigorta_bitis=@sigorta_bitis where ID=@Id",baglanti);
            duzenleme.Parameters.Add("@plaka_no", textBox1.Text);
            duzenleme.Parameters.Add("@model", textBox2.Text);
            duzenleme.Parameters.Add("@muayene_baslangic", textBox3.Text);
            duzenleme.Parameters.Add("@muayene_bitis", textBox4.Text);
            duzenleme.Parameters.Add("@sigorta_baslangic", textBox5.Text);
            duzenleme.Parameters.Add("@sigorta_bitis", textBox6.Text);
            duzenleme.Parameters.Add("@Id", Program.DuzenlenecekId);
            duzenleme.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Düzenleme Başarılı..");
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Properties\\aractakip.mdf;Integrated Security=True");
            baglanti.Open();
            SqlCommand duzenleme = new SqlCommand("Update Icerik set plaka_no=@plaka_no,model=@model,muayene_baslangic=@muayene_baslangic,muayene_bitis=@muayene_bitis,sigorta_baslangic=@sigorta_baslangic,sigorta_bitis=@sigorta_bitis where ID=@Id", baglanti);
            duzenleme.Parameters.Add("@plaka_no", textBox1.Text);
            duzenleme.Parameters.Add("@model", textBox2.Text);
            duzenleme.Parameters.Add("@muayene_baslangic", textBox3.Text);
            duzenleme.Parameters.Add("@muayene_bitis", textBox4.Text);
            duzenleme.Parameters.Add("@sigorta_baslangic", textBox5.Text);
            duzenleme.Parameters.Add("@sigorta_bitis", textBox6.Text);
            duzenleme.Parameters.Add("@Id", Program.DuzenlenecekId);
            duzenleme.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Düzenleme Başarılı..");
            
        }
    }
}
