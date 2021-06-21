using MAS_Final;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class SzczegolyZawodnika : Form
    {
        private Skaut skaut;
        public Skaut Skaut
        {
            get
            {
                return skaut;
            }
            set
            {
                skaut = value;
            }
        }
        public SzczegolyZawodnika(Skaut skaut)
        {
            InitializeComponent();

            Skaut = skaut;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ZawodnicySkauta f1 = new ZawodnicySkauta(Skaut);
            Hide();
            f1.ShowDialog();
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Skauci f1 = new Skauci();
            Hide();
            f1.ShowDialog();
            Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Zawodnicy f1 = new Zawodnicy();
            Hide();
            f1.ShowDialog();
            Close();
        }
    }
}
