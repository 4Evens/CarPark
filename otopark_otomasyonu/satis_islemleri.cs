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
namespace otopark_otomasyonu
{
    public partial class satis_islemleri : Form
    {
        public satis_islemleri()
        {
            InitializeComponent();
        }
        public SqlConnection baglanti = new SqlConnection("server=.; Initial Catalog=otopark;Integrated Security=SSPI");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public DataSet dtst = new DataSet();
        DataTable dt = new DataTable();

        void doldur()
        {
           
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                dt.Clear();
                SqlDataAdapter listele = new SqlDataAdapter("select * from satis ", baglanti);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
              dataGridView1.Columns[0].Visible = false;
                /*    dataGridView1.RowHeadersVisible = false;
                  dataGridView1.Columns[1].Width = 80;
                  dataGridView1.Columns[2].Width = 120;
                  dataGridView1.Columns[3].Width = 77;
                  dataGridView1.Columns[4].Width = 76;
                  dataGridView1.Columns[5].Width = 76;
                  dataGridView1.Columns[6].Width = 80;
                  baglanti.Close();
                  maskedTextBox1.Text = "";
                  textBox2.Text = "";
                  textBox3.Text = "";
                  textBox4.Text = "";
                  textBox5.Text = "";
                  textBox6.Text = "";
                  textBox8.Text = "";
                  textBox9.Text = "";
                  comboBox1.Text = "";*/
            
    }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime bTarih = Convert.ToDateTime(textBox3.Text);
            DateTime kTarih = Convert.ToDateTime(textBox2.Text);
            TimeSpan Sonuc = bTarih - kTarih;
            label9.Text = Sonuc.TotalHours.ToString();
            label10.Text = Sonuc.TotalDays.ToString();
            label11.Text = Sonuc.TotalMinutes.ToString();
        }

        private void satis_islemleri_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = (double.Parse(textBox4.Text) * double.Parse(label9.Text)).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand satis = new SqlCommand("update satis set ucret='" + textBox5.Text + "' where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);
            satis.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
            textBox5.Clear();
            doldur();
            MessageBox.Show("Ücretlendirme İşlemi Başarılı");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            teknik_servis tk = new teknik_servis();
            tk.Show();
            this.Hide();
        }
    }
}

