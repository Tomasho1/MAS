using MAS_Final;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Skauci : Form
    {
        public Skauci()
        {
            InitializeComponent();

            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Imię", typeof(string));
            dt.Columns.Add("Nazwisko", typeof(string));
            dt.Columns.Add("Narodowość", typeof(string)); 

            var extent = Skaut.Extent;

            foreach (Skaut skaut in extent)
            {
                dt.Rows.Add(skaut.IdPracownik, skaut.Imie, skaut.Nazwisko, skaut.Narodowosc);
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int idSkaut = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Skaut skaut = Skaut.Extent.FirstOrDefault(s => s.IdPracownik == idSkaut);

            ZawodnicySkauta f3 = new ZawodnicySkauta(skaut);
            Hide();
            f3.ShowDialog();
            Close();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
