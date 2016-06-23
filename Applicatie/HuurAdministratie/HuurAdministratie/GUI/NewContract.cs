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
        private Boot chosenBoot;
        private List<Artikel> chosenArtikels;
        private List<Vaargebied> chosenVaargebied;

        public NewContract()
        {
            InitializeComponent();
            bedrijf = new Bedrijf();
            chosenBoot = null;
            chosenArtikels = new List<Artikel>();
            chosenVaargebied = new List<Vaargebied>();
            GetInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckBudgetInput())
            {
                if (
                    bedrijf.CheckBudget(Convert.ToDouble(tbBudget.Text), chosenVaargebied, chosenArtikels, chosenBoot) ==
                    -1)
                {
                    MessageBox.Show("Niet genoeg budget voor te huren");
                }
                else
                {
                    lblAantalMeren.Text =
                        Convert.ToString(bedrijf.CheckBudget(Convert.ToDouble(tbBudget.Text), chosenVaargebied,
                            chosenArtikels, chosenBoot));
                }
            }
        }

        private bool CheckBudgetInput()
        {
            double budget;
            if (double.TryParse(tbBudget.Text, out budget))
            {
                if (dtpBeginDatum.Value >= DateTime.Today || dtpEindDatum.Value >= DateTime.Today)
                {
                    if (chosenBoot != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void NewContract_Load(object sender, EventArgs e)
        {

        }

        private void GetInfo()
        {
            cbVaargebieden.Items.Clear();
            cbArtikelen.Items.Clear();
            lbArtikelen.Items.Clear();
            lbVaargebieden.Items.Clear();
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

            foreach (Vaargebied vg in chosenVaargebied)
            {
                lbVaargebieden.Items.Add(vg.Naam);
            }
            foreach (Artikel a in chosenArtikels)
            {
                lbArtikelen.Items.Add(a.Naam);
            }

            cbArtikelen.SelectedIndex = 0;
            cbBoten.SelectedIndex = 0;
            cbVaargebieden.SelectedIndex = 0;

        }

        private void btnChooseBoot_Click(object sender, EventArgs e)
        {
            if (cbBoten.SelectedIndex >= 0)
            {
                foreach (Boot b in bedrijf.Boten)
                {
                    if (b.Naam == cbBoten.SelectedItem.ToString())
                    {
                        chosenBoot = b;
                        lblBoot.Text = b.Naam;
                    }
                }
            }
        }

        private void btnAddVaargebied_Click(object sender, EventArgs e)
        {
            if (cbVaargebieden.SelectedIndex >= 0)
            {
                foreach (Vaargebied vg in bedrijf.Vaargebieden)
                {
                    if (vg.Naam == cbVaargebieden.SelectedItem.ToString())
                    {
                        foreach (Vaargebied vgd in chosenVaargebied)
                        {
                            if (vgd.Naam == vg.Naam)
                            {
                                MessageBox.Show("Deze is al toegevoegd");
                                return;
                            }
                        }
                        chosenVaargebied.Add(vg);
                        GetInfo();
                    }
                }
            }
        }

        private void btnAddArtikel_Click(object sender, EventArgs e)
        {
            if (cbArtikelen.SelectedIndex >= 0)
            {
                foreach (Artikel a in bedrijf.Artikelen)
                {
                    if (a.Naam == cbArtikelen.SelectedItem.ToString())
                    {
                        foreach (Artikel al in chosenArtikels)
                        {
                            if (al.Naam == a.Naam)
                            {
                                MessageBox.Show("Deze is al toegevoegd");
                                return;
                            }
                        }
                        chosenArtikels.Add(a);
                        GetInfo();
                    }
                }
            }
        }

        private void nmBudget_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckAllInput())
            {
                if (bedrijf.AddHuurcontract(dtpBeginDatum.Value, dtpEindDatum.Value, Convert.ToDouble(tbBudget.Text),
                    chosenVaargebied,
                    chosenArtikels, chosenBoot, tbNaam.Text, tbEmail.Text))
                {
                    MessageBox.Show("Contract aangemaakt!");
                    Form1 beginForm = new Form1();
                    beginForm.Show();
                    this.Close();
                }
            }
        }

        private bool CheckAllInput()
        {
            double budget;
            if (double.TryParse(tbBudget.Text, out budget) && tbNaam.Text.Length > 0 && tbEmail.Text.Length > 0)
            {
                if (dtpBeginDatum.Value >= DateTime.Today || dtpEindDatum.Value >= DateTime.Today)
                {
                    if (chosenBoot != null)
                    {
                        if (chosenBoot is Spierkrachtaangedreven)
                        {
                            if (chosenVaargebied.Count == 0)
                            {
                                return true;
                            }
                            MessageBox.Show("Kan niet worden bevaren met gekozen boot.");
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
