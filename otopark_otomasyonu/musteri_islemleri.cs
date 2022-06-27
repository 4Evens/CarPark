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
    public partial class musteri_islemleri : Form
    {
        public musteri_islemleri()
        {
            InitializeComponent();
        }
        public SqlConnection bag = new SqlConnection("server=.; Initial Catalog=otopark;Integrated Security=SSPI");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public void listelesene()
        {
            try
            {
                if (bag.State == ConnectionState.Closed)
                {
                    bag.Open();
                }
                dt.Clear();
                SqlDataAdapter listele = new SqlDataAdapter("select * from musteri", bag);
                listele.Fill(dt);
                dataGridView1.DataSource = dt;
                listele.Dispose();
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.Columns[0].Visible = false;
                bag.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                comboBox1.Text = "";
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void musteri_islemleri_Load(object sender, EventArgs e)
        {
            listelesene();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox10.Text == textBox9.Text)
            {
                SqlCommand komut = new SqlCommand("insert into musteri(TcKimlik,Ad,Soyad,CepTel,PlakaNo,Marka,Model,Renk,Sifre,Gizli_Soru,Yanit) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox10.Text + "','" + comboBox1.Text + "','" + textBox11.Text + "')", bag);
                //
                // 
                if (bag.State == ConnectionState.Closed)
                {
                    bag.Open();
                }

                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Olma İşleminiz Başarılı");
                bag.Close();
                textBox1.Clear();
                textBox11.Clear();
                textBox10.Clear();
                textBox9.Clear();
                textBox8.Clear();
                textBox7.Clear();
                textBox6.Clear();
                textBox5.Clear();
                textBox4.Clear();
                textBox3.Clear();
                textBox2.Clear();
                comboBox1.Text = "Seçiniz";
                listelesene();
            }
            else
            {
                MessageBox.Show("Şifreler Eşleşmiyor");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            personel pers = new personel();
            pers.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            textBox11.Text= dataGridView1.CurrentRow.Cells[11].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand guncelle = new SqlCommand("update musteri set TcKimlik='" + textBox1.Text + "',Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',CepTel='" + textBox4.Text + "',PlakaNo='" + textBox5.Text + "',Marka='" + textBox6.Text + "',Model='" + textBox7.Text + "',Renk='" + textBox8.Text + "',Sifre='" + textBox9.Text + "',Gizli_Soru='" + comboBox1.Text + "',Yanit='" + textBox11.Text + "' where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag);
            bag.Open();
            guncelle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
            textBox1.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            comboBox1.Text = "Seçiniz";
            listelesene();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("delete from musteri where id='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", bag);
            bag.Open();
            guncelle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Silme İşlemi Başarılı");
            textBox1.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            comboBox1.Text = "Seçiniz";
            listelesene();

        }
    }
}
