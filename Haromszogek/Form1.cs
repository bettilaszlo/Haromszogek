using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haromszogek
{
    public partial class FrmFo : Form
    {
        private int aOldal;
        private int bOldal;
        private int cOldal;

        public FrmFo()
        {
            aOldal = 0;
            bOldal = 0;
            cOldal = 0;

            InitializeComponent();

            tbAoldal.Text = aOldal.ToString();
            tbBoldal.Text = bOldal.ToString();
            tbColdal.Text = cOldal.ToString();

            lbHaromszogLista.Items.Clear();
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSzamol_Click(object sender, EventArgs e)
        {
            aOldal = Convert.ToInt32(tbAoldal.Text);
            bOldal = Convert.ToInt32(tbBoldal.Text);
            cOldal = Convert.ToInt32(tbColdal.Text);

            if (aOldal == 0 || bOldal == 0 || cOldal == 0)
            {
                MessageBox.Show("Nem lehet a háromszög oldala 0!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var h = new Haromszog(aOldal, bOldal, cOldal);

                List<string> adatok = h.AdatokSzöveg();
                foreach (var i in adatok)
                {
                    lbHaromszogLista.Items.Add(i);
                }
            }
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (lbHaromszogLista.Items.Count > 0)
            {
                lbHaromszogLista.Items.Clear();
            }
            else
            {
                MessageBox.Show("Nincs mit törölni!");
            }
        }
    }
}
