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
using System.Data;
namespace otopark_otomasyonu
{
    public partial class arac_giris : Form
    {
        public arac_cikis frm3;
        public arac_konumlari frm2;
        public arac_giris()
        {
            InitializeComponent();

            frm2 = new arac_konumlari();
            frm3 = new arac_cikis();
           
            frm2.frm1 = this;
            frm3.frm1 = this;
        }

       
        public SqlConnection bag = new SqlConnection("server=.; Initial Catalog=otopark;Integrated Security=SSPI");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public DataSet dtst = new DataSet();
    
        public void combo()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from bos";
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
        public void combo2()
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from musteri";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku[1].ToString());
            }
            bag.Close();
            oku.Dispose();
            comboBox2.Sorted = true;
        }
        public void plakayaz()
        {


            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from musbil";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                
                switch (oku[8].ToString())
                {
                   
                    case "A1":
                        {
                            frm2.button1.Text = oku[4].ToString();
                            frm2.button1.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A2":
                        {
                            frm2.button2.Text = oku[4].ToString();
                            frm2.button2.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A3":
                        {
                            frm2.button3.Text = oku[4].ToString();
                            frm2.button3.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A4":
                        {
                            frm2.button4.Text = oku[4].ToString();
                            frm2.button4.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A5":
                        {
                            frm2.button5.Text = oku[4].ToString();
                            frm2.button5.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B1":
                        {
                            frm2.button6.Text = oku[4].ToString();
                            frm2.button6.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B2":
                        {
                            frm2.button7.Text = oku[4].ToString();
                            frm2.button7.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B3":
                        {
                            frm2.button8.Text = oku[4].ToString();
                            frm2.button8.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B4":
                        {
                            frm2.button9.Text = oku[4].ToString();
                            frm2.button9.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B5":
                        {
                            frm2.button10.Text = oku[4].ToString();
                            frm2.button10.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C1":
                        {

                            frm2.button11.Text = oku[4].ToString();
                            frm2.button11.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C2":
                        {
                            frm2.button12.Text = oku[4].ToString();
                            frm2.button12.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C3":
                        {
                            frm2.button13.Text = oku[4].ToString();
                            frm2.button13.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C4":
                        {
                            frm2.button14.Text = oku[4].ToString();
                            frm2.button14.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C5":
                        {
                            frm2.button15.Text = oku[4].ToString();
                            frm2.button15.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D1":
                        {
                            frm2.button16.Text = oku[4].ToString();
                            frm2.button16.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D2":
                        {
                            frm2.button17.Text = oku[4].ToString();
                            frm2.button17.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D3":
                        {
                            frm2.button18.Text = oku[4].ToString();
                            frm2.button18.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D4":
                        {
                            frm2.button19.Text = oku[4].ToString();
                            frm2.button19.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D5":
                        {
                            frm2.button20.Text = oku[4].ToString();
                            frm2.button20.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                }

            }
            bag.Close();
            oku.Dispose();
        }
       
        

        private void arac_giris_Load(object sender, EventArgs e)
        {
            combo();
            combo2();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            personel per = new personel();
            per.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from musteri where TcKimlik='" + comboBox2.Text  + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                textBox1.Text = oku[1].ToString();
                textBox2.Text = oku[2].ToString();
                textBox3.Text = oku[3].ToString();
                textBox4.Text = oku[4].ToString();
                textBox5.Text = oku[5].ToString();
                textBox6.Text = oku[6].ToString();
                textBox7.Text = oku[7].ToString();
                textBox8.Text = oku[8].ToString();
               

            }
            bag.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox5.Text != "" && comboBox1.Text != "")
            {
                bag.Open();
                kmt.Connection = bag;
                kmt.CommandText = "INSERT INTO musbil(TcKimlik,Ad,Soyad,CepTel,PlakaNo,Marka,Model,Renk,Konumu) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + comboBox1.Text + "') ";
                kmt.ExecuteNonQuery();
                kmt.CommandText = "INSERT INTO dolu(doluyerler) VALUES ('" + comboBox1.Text + "') ";
                kmt.ExecuteNonQuery();
                kmt.CommandText = "DELETE from bos WHERE bosyerler='" + comboBox1.Text + "'";
                kmt.ExecuteNonQuery();
                kmt.Dispose();
                bag.Close();
               
                
                //satis
                bag.Open();
                SqlCommand satis = new SqlCommand("insert into satis(plaka,giris_tarih) values('"+textBox5.Text+"','"+DateTime.Now.ToLongDateString()+"')",bag);
                satis.ExecuteNonQuery();
                bag.Close();

                comboBox1.Items.Clear();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
                textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
                comboBox1.Text = "";


                combo();
                plakayaz();
                MessageBox.Show("Kayıt işlemi tamamlandı ! ");

            }
            else
            {
                MessageBox.Show("Boş alanları doldurunuz !!!");
            }

        }
    }
}
