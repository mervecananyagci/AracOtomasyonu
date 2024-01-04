using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AracOtomasyon
{
    public partial class AracIcerik : Form
    {


        public AracIcerik()
        {
            InitializeComponent();
        }

        void goster()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5TQN0SS\\SQLEXPRESS;Initial Catalog=aracTakip;Integrated Security=True");
            baglanti.Open();
            SqlDataAdapter vericek = new SqlDataAdapter("select * from bilgi bilgi order by m_baslangic", baglanti);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }



        private void AracIcerik_Load(object sender, EventArgs e)
        {
            P1.Visible = true; // P1 kontrolünü görünür hale getir
            flowLayoutPanel1.Visible = true;
            goster();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        public string SeciliKayitNo;
        public int seciliKayit;
        public Boolean tiklama_kontrol = false;

        private void button1_Click(object sender, EventArgs e)
        {
            P1.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                seciliKayit = e.RowIndex;
                if (seciliKayit >= 0 && seciliKayit < dataGridView1.Rows.Count)
                {
                    textBox2.Text = dataGridView1.Rows[seciliKayit].Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.Rows[seciliKayit].Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[seciliKayit].Cells[7].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[seciliKayit].Cells[10].Value.ToString();
                    dateTimePicker8.Text = dataGridView1.Rows[seciliKayit].Cells[3].Value.ToString();
                    dateTimePicker7.Text = dataGridView1.Rows[seciliKayit].Cells[4].Value.ToString();
                    dateTimePicker6.Text = dataGridView1.Rows[seciliKayit].Cells[5].Value.ToString();
                    dateTimePicker5.Text = dataGridView1.Rows[seciliKayit].Cells[6].Value.ToString();
                    dateTimePicker4.Text = dataGridView1.Rows[seciliKayit].Cells[8].Value.ToString();
                    dateTimePicker3.Text = dataGridView1.Rows[seciliKayit].Cells[9].Value.ToString();
                    tiklama_kontrol = true;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ekle eklee = new ekle();
            eklee.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int seciliKayit = dataGridView1.SelectedCells[0].RowIndex;
            SeciliKayitNo = dataGridView1.Rows[seciliKayit].Cells[0].Value.ToString();
            DialogResult onay = MessageBox.Show(SeciliKayitNo + " nolu kayıtı silmek istediğinize emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (onay == DialogResult.Yes)
            {
                SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5TQN0SS\\SQLEXPRESS;Initial Catalog=aracTakip;Integrated Security=True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from bilgi where id=@id", baglanti);
                komut.Parameters.AddWithValue("@id", dataGridView1.Rows[seciliKayit].Cells[0].Value);
                komut.ExecuteNonQuery();
                MessageBox.Show("Silme işlemi başarıyla tamamlandı...");
                baglanti.Close();
                goster();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker8.Text = null;
                dateTimePicker7.Text = null;
                dateTimePicker6.Text = null;
                dateTimePicker5.Text = null;
                dateTimePicker4.Text = null;
                dateTimePicker3.Text = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            guncelle guncel = new guncelle();
            guncel.textBox1.Text = textBox2.Text;
            guncel.textBox2.Text = textBox3.Text;
            guncel.textBox3.Text = textBox4.Text;
            guncel.textBox4.Text = textBox5.Text;
            guncel.dateTimePicker1.Text = dateTimePicker8.Text;
            guncel.dateTimePicker2.Text = dateTimePicker7.Text;
            guncel.dateTimePicker3.Text = dateTimePicker6.Text;
            guncel.dateTimePicker4.Text = dateTimePicker5.Text;
            guncel.dateTimePicker5.Text = dateTimePicker4.Text;
            guncel.dateTimePicker6.Text = dateTimePicker3.Text;
            Program.DuzenlenecekId = dataGridView1.Rows[seciliKayit].Cells[0].Value.ToString();
            guncel.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;

            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = workbook.Sheets[1];

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                }
            }

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
        }

        private void P1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5TQN0SS\\SQLEXPRESS;Initial Catalog=aracTakip;Integrated Security=True");
            baglanti.Open();
            SqlDataAdapter arama = new SqlDataAdapter("select * from bilgi where plaka_no like '" + textBox1.Text + "' order by plaka_no", baglanti);
            DataSet dg = new DataSet();
            arama.Fill(dg);
            dataGridView1.DataSource = dg.Tables[0];
            baglanti.Close();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
 
        private void button3_Click(object sender, EventArgs e)
        {
            

            try
            {
               
                    // Excel uygulamasını başlat
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                    // Excel dosyasını aç
                    Workbook workbook = excelApp.Workbooks.Open("C:\\Users\\merve\\OneDrive\\Masaüstü\\yen\\AracOtomasyon\\aractakip.xlsx");

                    // Excel uygulamasını göster
                    excelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel dosyası açılırken bir hata oluştu: " + ex.Message);
                }

            
            
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5TQN0SS\\SQLEXPRESS;Initial Catalog=aracTakip;Integrated Security=True");
            baglanti.Open();
            SqlDataAdapter arama = new SqlDataAdapter("select * from bilgi where plaka_no like '" + textBox1.Text + "%' order by plaka_no", baglanti);
            DataSet dg = new DataSet();
            arama.Fill(dg);
            dataGridView1.DataSource = dg.Tables[0];
            baglanti.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            dolu dolu = new dolu();
            dolu.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            bos bos = new bos();
            bos.ShowDialog();
        }
    }
}

