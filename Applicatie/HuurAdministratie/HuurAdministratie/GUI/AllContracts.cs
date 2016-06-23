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
    public partial class AllContracts : Form
    {
        private Bedrijf bedrijf;
        public AllContracts()
        {
            InitializeComponent();
            bedrijf = new Bedrijf();
            GetInfo();
            GiveInfoSelected();
        }

        private void AllContracts_Load(object sender, EventArgs e)
        {

        }

        private void GetInfo()
        {
            lbContracts.Items.Clear();
            foreach (HuurContract hc in bedrijf.HuurContracten)
            {
                lbContracts.Items.Add(hc.ToString());
            }
            lbContracts.SelectedIndex = 0;
        }

        public void GiveInfoSelected()
        {
            if (lbContracts.SelectedIndex >= 0)
            {
                HuurContract tempContract = bedrijf.HuurContracten[lbContracts.SelectedIndex];
                lblAantalMeren.Text = tempContract.AantalMeren.ToString();
                lblNaam.Text = tempContract.Huurder.Naam;
                lblPrijs.Text = tempContract.Bedrag.ToString();
                lbArtikel.Items.Clear();
                lblBoot.Text = tempContract.Boot.Naam;
                lblBootsoort.Text = tempContract.Boot.Soort;
                lblBoottype.Text = tempContract.Boot.Type;
                lbVaargebieden.Items.Clear();
                if (tempContract.Boot is Motor)
                {
                    lblActieradius.Visible = true;
                    Motor motorboot = tempContract.Boot as Motor;
                    lblActieradius.Text = (motorboot.TankInhoud*15).ToString();
                }
                else
                {
                    lblActieradius.Visible = false;
                }
                foreach (Artikel ar in tempContract.Artikelen)
                {
                    lbArtikel.Items.Add(ar.Naam);
                }
                foreach (Vaargebied vg in tempContract.BevaardeGebieden)
                {
                    lbVaargebieden.Items.Add(vg.Naam);
                }
            }
        }

        private void lbContracts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GiveInfoSelected();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 beginForm = new Form1();
            beginForm.Show();
            this.Close();
        }
    }
}
