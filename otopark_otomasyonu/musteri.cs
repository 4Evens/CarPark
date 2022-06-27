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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }
        public SqlConnection bag = new SqlConnection("server=.; Initial Catalog=otopark;Integrated Security=SSPI");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public DataSet dtst = new DataSet();
        public void listelesene()
        {
            DataView dv = new DataView();
            bag.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * From musteri", bag);
            adtr.Fill(dtst, "musteri");

            dv.Table = dtst.Tables[0];
           
            adtr.Dispose();
            bag.Close();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void musteri_Load(object sender, EventArgs e)
        {
            listelesene();
            textBox1.DataBindings.Add("Text", dtst, "musteri.TcKimlik");
            textBox2.DataBindings.Add("Text", dtst, "musteri.Ad");
            textBox3.DataBindings.Add("Text", dtst, "musteri.Soyad");
            textBox4.DataBindings.Add("Text", dtst, "musteri.CepTel");
            textBox5.DataBindings.Add("Text", dtst, "musteri.PlakaNo");
            textBox6.DataBindings.Add("Text", dtst, "musteri.Marka");
            textBox7.DataBindings.Add("Text", dtst, "musteri.Model");
            textBox8.DataBindings.Add("Text", dtst, "musteri.Renk");
            textBox9.DataBindings.Add("Text", dtst, "musteri.Sifre");
            textBox10.DataBindings.Add("Text", dtst, "musteri.Sifre");
            comboBox1.DataBindings.Add("Text", dtst, "musteri.Gizli_Soru");
            textBox11.DataBindings.Add("Text", dtst, "musteri.Yanit");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox10.PasswordChar = '\0';
                textBox9.PasswordChar = '\0';
            }
            else
            {
                textBox10.PasswordChar = '*';
                textBox9.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand("update musteri set TcKimlik='"+textBox1.Text+ "',Ad='"+textBox2.Text+ "',Soyad='"+textBox3.Text+ "',CepTel='"+textBox4.Text+ "',PlakaNo='"+textBox5.Text+ "',Marka='"+textBox6.Text+ "',Model='"+textBox7.Text+ "',Renk='"+textBox8.Text+ "',Sifre='"+textBox9.Text+ "',Gizli_Soru='"+comboBox1.Text+"',Yanit='"+textBox11.Text+ "' where TcKimlik='"+Form1.musteritc+"'", bag);
            bag.Open();
            guncelle.ExecuteNonQuery();
            bag.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from musbil where TcKimlik='" + textBox1.Text + "' and PlakaNo ='" + textBox5.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                MessageBox.Show("Aracınız Otoparktadır Konumu "+oku[9].ToString());// uyari verir
                bag.Close();//bağlantıyı kapar
               
            }
            else
            {
                MessageBox.Show("Aracınız Otoparkta Bulunmamaktadır");//uyari verir
                bag.Close();//bağlantıyı kapar

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
