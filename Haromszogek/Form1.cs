using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haromszogek
{
    public partial class FrmFo : Form
    {
        private double aOldal;
        private double bOldal;
        private double cOldal;

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
            try
            {
                aOldal = Convert.ToDouble(tbAoldal.Text);
                bOldal = Convert.ToDouble(tbBoldal.Text);
                cOldal = Convert.ToDouble(tbColdal.Text);

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
            catch ( Exception ex)
            {
                MessageBox.Show("Számot adjon meg", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbAoldal.Focus();
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

        private void btnfajlbol_Click(object sender, EventArgs e)
        {
            lbHaromszogLista.Items.Clear();
            if (ofMegnyitas.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader file = new StreamReader(ofMegnyitas.FileName);
                    try
                    {
                        while (!file.EndOfStream)
                        {
                            string sor = file.ReadLine();
                            var h = new Haromszog(sor);

                            lbHaromszogLista.Items.Add("Fájlból olvasás: ");
                            foreach (var a in h.AdatokSzöveg())
                            {
                                lbHaromszogLista.Items.Add(a);
                            }
                            lbHaromszogLista.Items.Add("---------------------------------------------");
                        }
                        file.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        file.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
