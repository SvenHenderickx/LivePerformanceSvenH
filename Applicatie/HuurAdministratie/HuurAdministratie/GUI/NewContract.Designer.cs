namespace HuurAdministratie.GUI
{
    partial class NewContract
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbNaam = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBeginDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpEindDatum = new System.Windows.Forms.DateTimePicker();
            this.cbVaargebieden = new System.Windows.Forms.ComboBox();
            this.lbVaargebieden = new System.Windows.Forms.ListBox();
            this.cbArtikelen = new System.Windows.Forms.ComboBox();
            this.lbArtikelen = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddArtikel = new System.Windows.Forms.Button();
            this.btnAddVaargebied = new System.Windows.Forms.Button();
            this.btnCalculateBudget = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.nmBudget = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.cbBoten = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblBoot = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nmBudget)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(86, 12);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(100, 20);
            this.tbEmail.TabIndex = 0;
            // 
            // tbNaam
            // 
            this.tbNaam.Location = new System.Drawing.Point(86, 38);
            this.tbNaam.Name = "tbNaam";
            this.tbNaam.Size = new System.Drawing.Size(100, 20);
            this.tbNaam.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Naam";
            // 
            // dtpBeginDatum
            // 
            this.dtpBeginDatum.Location = new System.Drawing.Point(12, 64);
            this.dtpBeginDatum.Name = "dtpBeginDatum";
            this.dtpBeginDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpBeginDatum.TabIndex = 4;
            // 
            // dtpEindDatum
            // 
            this.dtpEindDatum.Location = new System.Drawing.Point(13, 108);
            this.dtpEindDatum.Name = "dtpEindDatum";
            this.dtpEindDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpEindDatum.TabIndex = 5;
            // 
            // cbVaargebieden
            // 
            this.cbVaargebieden.FormattingEnabled = true;
            this.cbVaargebieden.Location = new System.Drawing.Point(86, 204);
            this.cbVaargebieden.Name = "cbVaargebieden";
            this.cbVaargebieden.Size = new System.Drawing.Size(121, 21);
            this.cbVaargebieden.TabIndex = 7;
            // 
            // lbVaargebieden
            // 
            this.lbVaargebieden.FormattingEnabled = true;
            this.lbVaargebieden.Location = new System.Drawing.Point(238, 28);
            this.lbVaargebieden.Name = "lbVaargebieden";
            this.lbVaargebieden.Size = new System.Drawing.Size(156, 56);
            this.lbVaargebieden.TabIndex = 8;
            // 
            // cbArtikelen
            // 
            this.cbArtikelen.FormattingEnabled = true;
            this.cbArtikelen.Location = new System.Drawing.Point(87, 257);
            this.cbArtikelen.Name = "cbArtikelen";
            this.cbArtikelen.Size = new System.Drawing.Size(121, 21);
            this.cbArtikelen.TabIndex = 9;
            // 
            // lbArtikelen
            // 
            this.lbArtikelen.FormattingEnabled = true;
            this.lbArtikelen.Location = new System.Drawing.Point(238, 109);
            this.lbArtikelen.Name = "lbArtikelen";
            this.lbArtikelen.Size = new System.Drawing.Size(156, 56);
            this.lbArtikelen.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "artikelen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Vaargebieden";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Aantal Meren";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Vaargebieden";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Artikelen";
            // 
            // btnAddArtikel
            // 
            this.btnAddArtikel.Location = new System.Drawing.Point(132, 284);
            this.btnAddArtikel.Name = "btnAddArtikel";
            this.btnAddArtikel.Size = new System.Drawing.Size(75, 23);
            this.btnAddArtikel.TabIndex = 17;
            this.btnAddArtikel.Text = "Toevoegen";
            this.btnAddArtikel.UseVisualStyleBackColor = true;
            // 
            // btnAddVaargebied
            // 
            this.btnAddVaargebied.Location = new System.Drawing.Point(132, 228);
            this.btnAddVaargebied.Name = "btnAddVaargebied";
            this.btnAddVaargebied.Size = new System.Drawing.Size(75, 23);
            this.btnAddVaargebied.TabIndex = 18;
            this.btnAddVaargebied.Text = "Toevoegen";
            this.btnAddVaargebied.UseVisualStyleBackColor = true;
            // 
            // btnCalculateBudget
            // 
            this.btnCalculateBudget.Location = new System.Drawing.Point(319, 284);
            this.btnCalculateBudget.Name = "btnCalculateBudget";
            this.btnCalculateBudget.Size = new System.Drawing.Size(75, 23);
            this.btnCalculateBudget.TabIndex = 19;
            this.btnCalculateBudget.Text = "Bereken prijs";
            this.btnCalculateBudget.UseVisualStyleBackColor = true;
            this.btnCalculateBudget.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 315);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(378, 32);
            this.button4.TabIndex = 21;
            this.button4.Text = "Accepteer";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // nmBudget
            // 
            this.nmBudget.Location = new System.Drawing.Point(238, 260);
            this.nmBudget.Name = "nmBudget";
            this.nmBudget.Size = new System.Drawing.Size(120, 20);
            this.nmBudget.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(86, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "label9";
            // 
            // cbBoten
            // 
            this.cbBoten.FormattingEnabled = true;
            this.cbBoten.Location = new System.Drawing.Point(86, 152);
            this.cbBoten.Name = "cbBoten";
            this.cbBoten.Size = new System.Drawing.Size(121, 21);
            this.cbBoten.TabIndex = 24;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(132, 175);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Kies";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lblBoot
            // 
            this.lblBoot.AutoSize = true;
            this.lblBoot.Location = new System.Drawing.Point(238, 180);
            this.lblBoot.Name = "lblBoot";
            this.lblBoot.Size = new System.Drawing.Size(29, 13);
            this.lblBoot.TabIndex = 26;
            this.lblBoot.Text = "Boot";
            // 
            // NewContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 359);
            this.Controls.Add(this.lblBoot);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cbBoten);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nmBudget);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnCalculateBudget);
            this.Controls.Add(this.btnAddVaargebied);
            this.Controls.Add(this.btnAddArtikel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbArtikelen);
            this.Controls.Add(this.cbArtikelen);
            this.Controls.Add(this.lbVaargebieden);
            this.Controls.Add(this.cbVaargebieden);
            this.Controls.Add(this.dtpEindDatum);
            this.Controls.Add(this.dtpBeginDatum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNaam);
            this.Controls.Add(this.tbEmail);
            this.Name = "NewContract";
            this.Load += new System.EventHandler(this.NewContract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmBudget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbNaam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpBeginDatum;
        private System.Windows.Forms.DateTimePicker dtpEindDatum;
        private System.Windows.Forms.ComboBox cbVaargebieden;
        private System.Windows.Forms.ListBox lbVaargebieden;
        private System.Windows.Forms.ComboBox cbArtikelen;
        private System.Windows.Forms.ListBox lbArtikelen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddArtikel;
        private System.Windows.Forms.Button btnAddVaargebied;
        private System.Windows.Forms.Button btnCalculateBudget;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown nmBudget;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbBoten;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblBoot;
    }
}