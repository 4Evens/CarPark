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
    public partial class sifremi_unuttum : Form
    {
        public sifremi_unuttum()
        {
            InitializeComponent();
        }

        public SqlConnection baglanti = new SqlConnection("server=.; Initial Catalog=otopark;Integrated Security=SSPI");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public DataSet dtst = new DataSet();

        public void gizlisoru()
        {

            SqlCommand komut = new SqlCommand("select * from musteri where TcKimlik='" + textBox1.Text + "'", baglanti);
            //mysql komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            baglanti.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                panel1.Visible = false;
                textBox2.Text = oku["Gizli_Soru"].ToString();
                baglanti.Close();//bağlantıyı kapar


            }
            else
            {
                MessageBox.Show("Kullanıcı Adınız Yada Şifreniz Yanlış Yazılmıştır");//hayır veri okuyamadıysa uyarı verir
                textBox1.Text = "";
                textBox2.Text = "";
                //verileri temizler
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gizlisoru();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            SqlCommand komut = new SqlCommand("select * from musteri where TcKimlik='" + textBox1.Text + "' and Yanit ='" + textBox3.Text + "'", baglanti);
            //mysql komutumuzu yazdık komutta veritabanındaki admin tablosunda kullanıcı adı textbox1.text olan şifresi textbox2.text olan veriyi
            // çekmesini istedik
            
            baglanti.Open();//bağlantıyı açdık

            SqlDataReader oku = komut.ExecuteReader();//veriyi okutma emrini verdik
            if (oku.Read())//if eğer veriyi okumuşsa yani böyle bir kullanıcı veritabanında kayıtlıysa
            {
                panel2.Visible = false;
                textBox4.Text = oku["sifre"].ToString();

            }
            else
            {
                MessageBox.Show("Hatalı Bilgiler");//hayır veri okuyamadıysa uyarı verir

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 FRM1 = new Form1();
            FRM1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Clipboard.SetText(textBox4.Text);
            MessageBox.Show("Kopyalama İşlemi Başarılı");
        }
    }
}
