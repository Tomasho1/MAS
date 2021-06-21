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
    public partial class Zawodnicy : Form
    {
        public Zawodnicy()
        {
            InitializeComponent();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Imię", typeof(string));
            dt.Columns.Add("Nazwisko", typeof(string));
            dt.Columns.Add("Narodowość", typeof(string));

            List<Zawodnik> zawodnicy = new List<Zawodnik>();

            foreach (Raport raport in Raport.Extent)
            {
                var zawodnik = raport.Zawodnik;
                zawodnicy.Add(zawodnik);
            }

            zawodnicy = zawodnicy.OrderBy(p => p.IdZawodnik).Distinct().ToList();

            foreach (Zawodnik zawodnik in zawodnicy)
            {
                dt.Rows.Add(zawodnik.IdZawodnik, zawodnik.Imie, zawodnik.Nazwisko, zawodnik.Narodowosc);
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idZawodnik = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Zawodnik zawodnik = Zawodnik.Extent.FirstOrDefault(s => s.IdZawodnik == idZawodnik);

            SkauciZawodnika f1 = new SkauciZawodnika(zawodnik);
            Hide();
            f1.ShowDialog();
            Close();
        }
    }
}
