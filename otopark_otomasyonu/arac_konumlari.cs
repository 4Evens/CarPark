﻿using System;
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
    public partial class arac_konumlari : Form
    {
        public arac_konumlari()
        {
            InitializeComponent();
        }
        public SqlConnection bag = new SqlConnection("server=.; Initial Catalog=otopark;Integrated Security=SSPI");
        public SqlCommand kmt = new SqlCommand();
        public SqlDataAdapter adtr = new SqlDataAdapter();
        public DataSet dtst = new DataSet();
        public  arac_giris frm1;
        public arac_konumlari frm2;
        public void plakayaz()
        {


            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select * from musbil";
            SqlDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                
                switch (oku[9].ToString())
                {
                    case "A1":
                        {
                            button1.Text = oku[5].ToString();
                           button1.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A2":
                        {
                           button2.Text = oku[5].ToString();
                           button2.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A3":
                        {
                           button3.Text = oku[5].ToString();
                           button3.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A4":
                        {
                            button4.Text = oku[5].ToString();
                           button4.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "A5":
                        {
                          button5.Text = oku[5].ToString();
                           button5.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B1":
                        {
                           button6.Text = oku[5].ToString();
                           button6.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B2":
                        {
                            button7.Text = oku[5].ToString();
                           button7.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B3":
                        {
                            button8.Text = oku[5].ToString();
                          button8.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B4":
                        {
                            button9.Text = oku[5].ToString();
                           button9.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "B5":
                        {
                            button10.Text = oku[5].ToString();
                            button10.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C1":
                        {

                            button11.Text = oku[5].ToString();
                            button11.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C2":
                        {
                           button12.Text = oku[5].ToString();
                            button12.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C3":
                        {
                            button13.Text = oku[5].ToString();
                           button13.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C4":
                        {
                           button14.Text = oku[5].ToString();
                           button14.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "C5":
                        {
                            button15.Text = oku[5].ToString();
                           button15.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D1":
                        {
                            button16.Text = oku[5].ToString();
                            button16.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D2":
                        {
                           button17.Text = oku[5].ToString();
                           button17.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D3":
                        {
                           button18.Text = oku[5].ToString();
                           button18.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D4":
                        {
                            button19.Text = oku[5].ToString();
                            button19.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                    case "D5":
                        {
                            button20.Text = oku[5].ToString();
                            button20.BackColor = System.Drawing.Color.Red;
                            break;
                        }
                }

            }
            bag.Close();
            oku.Dispose();
        }
        private void arac_konumlari_Load(object sender, EventArgs e)
        {

           plakayaz();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            personel per = new personel();
            per.Show();
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
