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

            var obserwowani = skaut.Raporty.Select(x => x.Key).Distinct().ToList();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Imię", typeof(string));
            dt.Columns.Add("Nazwisko", typeof(string));
            dt.Columns.Add("Narodowość", typeof(string));

            label1.Text = $"Zawodnicy obserwowani przez {skaut.Imie} {skaut.Nazwisko}";
            foreach (Zawodnik zawodnik in obserwowani)
            {
                dt.Rows.Add(zawodnik.IdZawodnik, zawodnik.Imie, zawodnik.Nazwisko, zawodnik.Narodowosc);
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SzczegolyZawodnika f2 = new SzczegolyZawodnika(Skaut);

            int idZawodnik = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Zawodnik zawodnik = Zawodnik.Extent.FirstOrDefault(z => z.IdZawodnik == idZawodnik);

            f2.label8.Text = $"Profil {zawodnik.Imie} {zawodnik.Nazwisko}";

            f2.textBox1.Text = zawodnik.Imie;
            f2.textBox2.Text = zawodnik.Nazwisko;
            f2.textBox3.Text = zawodnik.Narodowosc;
            f2.textBox4.Text = zawodnik.Wiek.ToString();
            f2.textBox5.Text = zawodnik.AktualnyKlub;
            f2.textBox6.Text = zawodnik.Wartosc.ToString();
            f2.textBox7.Text = zawodnik.Status;

            Hide();
            f2.ShowDialog();
            Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Skauci f1 = new Skauci();
            Hide();
            f1.ShowDialog();
            Close();
        }
    }
}
