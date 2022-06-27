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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public SqlConnection bag = new SqlConnection("server=.; Initial Catalog=otopark;Integrated Security=SSPI");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public DataSet dtst = new DataSet();
        public static string musteritc = null;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from musteri where TcKimlik='" + textBox1.Text + "' and sifre ='" + textBox2.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                musteritc = textBox1.Text;
                MessageBox.Show("Giriş Başarılı !");//giriş başarılı diye uyari verir
                bag.Close();//bağlantıyı kapar
                musteri menu = new musteri();//yeni bir menü sayfası oluşturur
                menu.Show();//menü sayfasını açar
                this.Hide();////mevcut sayfayı gizler

            }
            else
            {
                bag.Close();//bağlantıyı kapar
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox1.Text = "";
                textBox2.Text = "";
                //verileri temizler
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifremi_unuttum unuttum = new sifremi_unuttum();
            unuttum.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from personel where tc='" + textBox3.Text + "' and sifre ='" + textBox4.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
        
                MessageBox.Show("Giriş Başarılı !");//giriş başarılı diye uyari verir
                bag.Close();//bağlantıyı kapar
                personel menu = new personel();//yeni bir menü sayfası oluşturur
                menu.Show();//menü sayfasını açar
                this.Hide();////mevcut sayfayı gizler

            }
            else
            {
                bag.Close();//bağlantıyı kapar
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox3.Text = "";
                textBox4.Text = "";
                //verileri temizler
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from admin where k_adi='" + textBox5.Text + "' and sifre ='" + textBox6.Text + "'", bag);
            //access komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            bag.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {

                MessageBox.Show("Giriş Başarılı !");//giriş başarılı diye uyari verir
                bag.Close();//bağlantıyı kapar
                teknik_servis menu = new teknik_servis();//yeni bir menü sayfası oluşturur
                menu.Show();//menü sayfasını açar
                this.Hide();////mevcut sayfayı gizler

            }
            else
            {
                bag.Close();//bağlantıyı kapar
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox5.Text = "";
                textBox6.Text = "";
                //verileri temizler
            }
        }
    }
}
