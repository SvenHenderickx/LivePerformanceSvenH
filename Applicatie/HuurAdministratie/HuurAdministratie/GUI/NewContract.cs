using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuurAdministratie.Models;

namespace HuurAdministratie.GUI
{
    public partial class NewContract : Form
    {
        private Bedrijf bedrijf;
        public NewContract()
        {
            InitializeComponent();
            bedrijf = new Bedrijf();
            GetInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void NewContract_Load(object sender, EventArgs e)
        {

        }

        private void GetInfo()
        {
            cbVaargebieden.Items.Clear();
            cbArtikelen.Items.Clear();
            cbBoten.Items.Clear();
            
            foreach (Boot b in bedrijf.Boten)
            {
                cbBoten.Items.Add(b.Naam);
            }
            foreach (Artikel a in bedrijf.Artikelen)
            {
                cbArtikelen.Items.Add(a.Naam);
            }
            foreach (Vaargebied vg in bedrijf.Vaargebieden)
            {
                cbVaargebieden.Items.Add(vg.Naam);
            }
            cbArtikelen.SelectedIndex = 0;
            cbBoten.SelectedIndex = 0;
            cbVaargebieden.SelectedIndex = 0;
        }
    }
}
