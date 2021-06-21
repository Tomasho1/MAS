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
    public partial class ZawodnicySkauta : Form
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
        public ZawodnicySkauta(Skaut skaut)
        {
            InitializeComponent();

            Skaut = skaut;

            var obserwowani = skaut.Raporty.Select(x => x.Key).OrderBy(p => p.IdZawodnik).Distinct().ToList();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Imię", typeof(string));
            dt.Columns.Add("Nazwisko", typeof(string));
            dt.Columns.Add("Narodowość", typeof(string));
            dt.Columns.Add("Wiek", typeof(int));

            label1.Text = $"Zawodnicy obserwowani przez {skaut.Imie} {skaut.Nazwisko}";

            foreach (Zawodnik zawodnik in obserwowani)
            {
                dt.Rows.Add(zawodnik.IdZawodnik, zawodnik.Imie, zawodnik.Nazwisko, zawodnik.Narodowosc, zawodnik.Wiek);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SzczegolyZawodnika f1 = new SzczegolyZawodnika(Skaut);

            int idZawodnik = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Zawodnik zawodnik = Zawodnik.Extent.FirstOrDefault(z => z.IdZawodnik == idZawodnik);

            f1.label8.Text = $"Profil {zawodnik.Imie} {zawodnik.Nazwisko}";

            f1.textBox1.Text = zawodnik.Imie;
            f1.textBox2.Text = zawodnik.Nazwisko;
            f1.textBox3.Text = zawodnik.Narodowosc;
            f1.textBox8.Text = zawodnik.Pozycja;
            f1.textBox4.Text = zawodnik.Wiek.ToString();
            f1.textBox9.Text = $"{zawodnik.DataUrodzenia.Day}.{zawodnik.DataUrodzenia.Month}.{zawodnik.DataUrodzenia.Year}";
            f1.textBox5.Text = zawodnik.AktualnyKlub;
            f1.textBox6.Text = zawodnik.Wartosc.ToString();
            f1.textBox7.Text = zawodnik.Status;

            Hide();
            f1.ShowDialog();
            Close();
        }
    }
}
