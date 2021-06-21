using MAS_Final;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class SkauciZawodnika : Form
    {

        private Zawodnik zawodnik;
        public Zawodnik Zawodnik
        {
            get
            {
                return zawodnik;
            }
            set
            {
                zawodnik = value;
            }
        }
        public SkauciZawodnika(Zawodnik zawodnik)
        {
            
            InitializeComponent();

            Zawodnik = zawodnik;

            var obserwujacy = zawodnik.Raporty.Select(x => x.Key).OrderBy(p => p.IdPracownik).Distinct().ToList();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Imię", typeof(string));
            dt.Columns.Add("Nazwisko", typeof(string));
            dt.Columns.Add("Narodowość", typeof(string));
            dt.Columns.Add("Wiek", typeof(int));

            label1.Text = $"Skauci obserwujący {zawodnik.Imie} {zawodnik.Nazwisko}";
            foreach (Skaut skaut in obserwujacy)
            {
                dt.Rows.Add(skaut.IdPracownik, skaut.Imie, skaut.Nazwisko, skaut.Narodowosc, skaut.Wiek);
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
