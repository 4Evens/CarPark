﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otopark_otomasyonu
{
    public partial class teknik_servis : Form
    {
        public teknik_servis()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            satis_islemleri sat = new satis_islemleri();
            sat.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            personel_islemleri per = new personel_islemleri();
            per.Show();
            this.Hide();
        }
    }
}
