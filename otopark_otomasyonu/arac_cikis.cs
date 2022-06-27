using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace otopark_otomasyonu
{
    public partial class arac_cikis : Form
    {
        public arac_giris frm1;
        public arac_cikis()
        {
            InitializeComponent();
        }
        void texteyaz()
        {
            textBox9.Text = (this.BindingContext[dtst, "musbil"].Position + 1) + " / " + this.BindingContext[dtst, "musbil"].Count;
        }
        public SqlConnection bag = new SqlConnection("server=.; Initial Catalog=otopark;Integrated Security=SSPI");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public DataSet dtst = new DataSet();
        public void combo2()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from dolu";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0].ToString());
            }
            bag.Close();
            oku.Dispose();
            comboBox1.Sorted = true;
        }
       public void listelesene()
        {
            DataView dv = new DataView();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From musbil", bag);
            adtr.Fill(dtst, "musbil");

            dv.Table = dtst.Tables[0];
          dataGrid1.DataSource = dv;
            adtr.Dispose();
            bag.Close();
        }
        private void arac_cikis_Load(object sender, EventArgs e)
        {
            combo2();
           listelesene();
            textBox1.DataBindings.Add("Text", dtst, "musbil.TcKimlik");
            textBox2.DataBindings.Add("Text", dtst, "musbil.Ad");
            textBox3.DataBindings.Add("Text", dtst, "musbil.Soyad");
            textBox4.DataBindings.Add("Text", dtst, "musbil.CepTel");
            textBox5.DataBindings.Add("Text", dtst, "musbil.PlakaNo");
            textBox6.DataBindings.Add("Text", dtst, "musbil.Marka");
            textBox7.DataBindings.Add("Text", dtst, "musbil.Model");
            textBox8.DataBindings.Add("Text", dtst, "musbil.Renk");
            comboBox1.DataBindings.Add("Text", dtst, "musbil.Konumu");
            texteyaz();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtst, "musbil"].Position = 0;
            texteyaz();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtst, "musbil"].Position -= 1;
            texteyaz();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.BindingContext[dtst, "musbil"].Position += 1;
            texteyaz();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.BindingContext[dtst, "musbil"].Position = this.BindingContext[dtst, "musbil"].Count;
            texteyaz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
            {
                DialogResult cevap;
                cevap = MessageBox.Show("Kaydı silmek istediğinizden eminmisiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                   // plakasil();
                   bag.Open();
                    kmt.Connection = bag;
                   kmt.CommandText = "DELETE from musbil WHERE TcKimlik='" + textBox1.Text + "'";
                    kmt.ExecuteNonQuery();
                   kmt.CommandText = "INSERT INTO bos(bosyerler) VALUES ('" + comboBox1.Text + "') ";
                   kmt.ExecuteNonQuery();
                    kmt.CommandText = "DELETE from dolu WHERE doluyerler='" + comboBox1.Text + "'";
                    kmt.ExecuteNonQuery();
                   kmt.Dispose();
                   bag.Close();
                    
                    bag.Open();
                    SqlCommand satis = new SqlCommand("update satis set cikis_tarih='" + dateTimePicker1.Value.ToLongDateString() + "' where plaka='" + textBox5.Text + "'", bag);
                    satis.ExecuteNonQuery();
                    bag.Close();

                    // frm1.combo();

                    dtst.Clear();
                  


                    //

                   
                    combo2();
                    listelesene();
                    comboBox1.Items.Clear();
                    comboBox1.Items.Clear();
                    comboBox1.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz !!!");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            personel per = new personel();
            per.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
