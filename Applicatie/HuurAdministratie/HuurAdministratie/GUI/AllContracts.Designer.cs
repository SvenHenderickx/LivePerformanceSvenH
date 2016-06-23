namespace HuurAdministratie.GUI
{
    partial class AllContracts
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
            this.lbContracts = new System.Windows.Forms.ListBox();
            this.lblNaam = new System.Windows.Forms.Label();
            this.lblAantalMeren = new System.Windows.Forms.Label();
            this.lblPrijs = new System.Windows.Forms.Label();
            this.lbArtikel = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblBootnaam = new System.Windows.Forms.Label();
            this.lblBoottype = new System.Windows.Forms.Label();
            this.lblBoot = new System.Windows.Forms.Label();
            this.lblBootsoort = new System.Windows.Forms.Label();
            this.lblActieradius = new System.Windows.Forms.Label();
            this.lbVaargebieden = new System.Windows.Forms.ListBox();
            this.btnExporteer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbContracts
            // 
            this.lbContracts.FormattingEnabled = true;
            this.lbContracts.Location = new System.Drawing.Point(13, 13);
            this.lbContracts.Name = "lbContracts";
            this.lbContracts.Size = new System.Drawing.Size(162, 290);
            this.lbContracts.TabIndex = 0;
            this.lbContracts.SelectedIndexChanged += new System.EventHandler(this.lbContracts_SelectedIndexChanged);
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(192, 13);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(35, 13);
            this.lblNaam.TabIndex = 1;
            this.lblNaam.Text = "label1";
            // 
            // lblAantalMeren
            // 
            this.lblAantalMeren.AutoSize = true;
            this.lblAantalMeren.Location = new System.Drawing.Point(195, 40);
            this.lblAantalMeren.Name = "lblAantalMeren";
            this.lblAantalMeren.Size = new System.Drawing.Size(35, 13);
            this.lblAantalMeren.TabIndex = 2;
            this.lblAantalMeren.Text = "label1";
            // 
            // lblPrijs
            // 
            this.lblPrijs.AutoSize = true;
            this.lblPrijs.Location = new System.Drawing.Point(195, 70);
            this.lblPrijs.Name = "lblPrijs";
            this.lblPrijs.Size = new System.Drawing.Size(35, 13);
            this.lblPrijs.TabIndex = 3;
            this.lblPrijs.Text = "label1";
            // 
            // lbArtikel
            // 
            this.lbArtikel.FormattingEnabled = true;
            this.lbArtikel.Location = new System.Drawing.Point(195, 245);
            this.lbArtikel.Name = "lbArtikel";
            this.lbArtikel.Size = new System.Drawing.Size(265, 56);
            this.lbArtikel.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(385, 308);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Terug";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblBootnaam
            // 
            this.lblBootnaam.AutoSize = true;
            this.lblBootnaam.Location = new System.Drawing.Point(425, 13);
            this.lblBootnaam.Name = "lblBootnaam";
            this.lblBootnaam.Size = new System.Drawing.Size(0, 13);
            this.lblBootnaam.TabIndex = 6;
            // 
            // lblBoottype
            // 
            this.lblBoottype.AutoSize = true;
            this.lblBoottype.Location = new System.Drawing.Point(405, 13);
            this.lblBoottype.Name = "lblBoottype";
            this.lblBoottype.Size = new System.Drawing.Size(35, 13);
            this.lblBoottype.TabIndex = 7;
            this.lblBoottype.Text = "label1";
            // 
            // lblBoot
            // 
            this.lblBoot.AutoSize = true;
            this.lblBoot.Location = new System.Drawing.Point(405, 40);
            this.lblBoot.Name = "lblBoot";
            this.lblBoot.Size = new System.Drawing.Size(35, 13);
            this.lblBoot.TabIndex = 8;
            this.lblBoot.Text = "label1";
            // 
            // lblBootsoort
            // 
            this.lblBootsoort.AutoSize = true;
            this.lblBootsoort.Location = new System.Drawing.Point(405, 70);
            this.lblBootsoort.Name = "lblBootsoort";
            this.lblBootsoort.Size = new System.Drawing.Size(35, 13);
            this.lblBootsoort.TabIndex = 9;
            this.lblBootsoort.Text = "label1";
            // 
            // lblActieradius
            // 
            this.lblActieradius.AutoSize = true;
            this.lblActieradius.Location = new System.Drawing.Point(405, 100);
            this.lblActieradius.Name = "lblActieradius";
            this.lblActieradius.Size = new System.Drawing.Size(35, 13);
            this.lblActieradius.TabIndex = 10;
            this.lblActieradius.Text = "label1";
            // 
            // lbVaargebieden
            // 
            this.lbVaargebieden.FormattingEnabled = true;
            this.lbVaargebieden.Location = new System.Drawing.Point(195, 183);
            this.lbVaargebieden.Name = "lbVaargebieden";
            this.lbVaargebieden.Size = new System.Drawing.Size(265, 56);
            this.lbVaargebieden.TabIndex = 11;
            // 
            // btnExporteer
            // 
            this.btnExporteer.Location = new System.Drawing.Point(195, 308);
            this.btnExporteer.Name = "btnExporteer";
            this.btnExporteer.Size = new System.Drawing.Size(75, 23);
            this.btnExporteer.TabIndex = 12;
            this.btnExporteer.Text = "Exporteer";
            this.btnExporteer.UseVisualStyleBackColor = true;
            this.btnExporteer.Click += new System.EventHandler(this.btnExporteer_Click);
            // 
            // AllContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 343);
            this.Controls.Add(this.btnExporteer);
            this.Controls.Add(this.lbVaargebieden);
            this.Controls.Add(this.lblActieradius);
            this.Controls.Add(this.lblBootsoort);
            this.Controls.Add(this.lblBoot);
            this.Controls.Add(this.lblBoottype);
            this.Controls.Add(this.lblBootnaam);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lbArtikel);
            this.Controls.Add(this.lblPrijs);
            this.Controls.Add(this.lblAantalMeren);
            this.Controls.Add(this.lblNaam);
            this.Controls.Add(this.lbContracts);
            this.Name = "AllContracts";
            this.Text = "AllContracts";
            this.Load += new System.EventHandler(this.AllContracts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbContracts;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.Label lblAantalMeren;
        private System.Windows.Forms.Label lblPrijs;
        private System.Windows.Forms.ListBox lbArtikel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblBootnaam;
        private System.Windows.Forms.Label lblBoottype;
        private System.Windows.Forms.Label lblBoot;
        private System.Windows.Forms.Label lblBootsoort;
        private System.Windows.Forms.Label lblActieradius;
        private System.Windows.Forms.ListBox lbVaargebieden;
        private System.Windows.Forms.Button btnExporteer;
    }
}