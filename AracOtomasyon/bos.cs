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

namespace AracOtomasyon
{
    public partial class bos : Form
    {
        public bos()
        {
            InitializeComponent();
        }
        void goster()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-5TQN0SS\\SQLEXPRESS;Initial Catalog=aracTakip;Integrated Security=True");
            baglanti.Open();
            SqlDataAdapter vericek = new SqlDataAdapter("SELECT *  FROM bilgi  WHERE db_tanker = 'BOŞ'", baglanti);
            DataSet ds = new DataSet();
            vericek.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void bos_Load(object sender, EventArgs e)
        {
            goster();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
