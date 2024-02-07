namespace SAEFrigoBibliothèqueUtilisateur
{
    partial class UserControlRecette
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNomRecette = new System.Windows.Forms.Label();
            this.lblPrix = new System.Windows.Forms.Label();
            this.lblTemps = new System.Windows.Forms.Label();
            this.pnlAfficheRecette = new System.Windows.Forms.Panel();
            this.pctImageRecette = new System.Windows.Forms.PictureBox();
            this.btnRecettePdf = new System.Windows.Forms.Button();
            this.btnRecette = new System.Windows.Forms.Button();
            this.btnAvis = new System.Windows.Forms.Button();
            this.pnlAfficheRecette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctImageRecette)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNomRecette
            // 
            this.lblNomRecette.AutoSize = true;
            this.lblNomRecette.Location = new System.Drawing.Point(208, 30);
            this.lblNomRecette.Name = "lblNomRecette";
            this.lblNomRecette.Size = new System.Drawing.Size(35, 13);
            this.lblNomRecette.TabIndex = 0;
            this.lblNomRecette.Text = "label1";
            // 
            // lblPrix
            // 
            this.lblPrix.AutoSize = true;
            this.lblPrix.Location = new System.Drawing.Point(231, 93);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(35, 13);
            this.lblPrix.TabIndex = 1;
            this.lblPrix.Text = "label1";
            // 
            // lblTemps
            // 
            this.lblTemps.AutoSize = true;
            this.lblTemps.Location = new System.Drawing.Point(231, 56);
            this.lblTemps.Name = "lblTemps";
            this.lblTemps.Size = new System.Drawing.Size(35, 13);
            this.lblTemps.TabIndex = 2;
            this.lblTemps.Text = "label1";
            // 
            // pnlAfficheRecette
            // 
            this.pnlAfficheRecette.Controls.Add(this.lblNomRecette);
            this.pnlAfficheRecette.Controls.Add(this.pctImageRecette);
            this.pnlAfficheRecette.Controls.Add(this.lblTemps);
            this.pnlAfficheRecette.Controls.Add(this.lblPrix);
            this.pnlAfficheRecette.Location = new System.Drawing.Point(0, 0);
            this.pnlAfficheRecette.Name = "pnlAfficheRecette";
            this.pnlAfficheRecette.Size = new System.Drawing.Size(459, 150);
            this.pnlAfficheRecette.TabIndex = 4;
            // 
            // pctImageRecette
            // 
            this.pctImageRecette.Location = new System.Drawing.Point(13, 3);
            this.pctImageRecette.Name = "pctImageRecette";
            this.pctImageRecette.Size = new System.Drawing.Size(151, 144);
            this.pctImageRecette.TabIndex = 3;
            this.pctImageRecette.TabStop = false;
            this.pctImageRecette.Click += new System.EventHandler(this.pctImageRecette_Click);
            // 
            // btnRecettePdf
            // 
            this.btnRecettePdf.Location = new System.Drawing.Point(465, 40);
            this.btnRecettePdf.Name = "btnRecettePdf";
            this.btnRecettePdf.Size = new System.Drawing.Size(70, 68);
            this.btnRecettePdf.TabIndex = 6;
            this.btnRecettePdf.UseVisualStyleBackColor = true;
            this.btnRecettePdf.Click += new System.EventHandler(this.btnRecettePdf_Click);
            // 
            // btnRecette
            // 
            this.btnRecette.Location = new System.Drawing.Point(541, 40);
            this.btnRecette.Name = "btnRecette";
            this.btnRecette.Size = new System.Drawing.Size(70, 68);
            this.btnRecette.TabIndex = 7;
            this.btnRecette.UseVisualStyleBackColor = true;
            this.btnRecette.Click += new System.EventHandler(this.btnRecette_Click);
            // 
            // btnAvis
            // 
            this.btnAvis.Location = new System.Drawing.Point(617, 40);
            this.btnAvis.Name = "btnAvis";
            this.btnAvis.Size = new System.Drawing.Size(70, 68);
            this.btnAvis.TabIndex = 8;
            this.btnAvis.UseVisualStyleBackColor = true;
            this.btnAvis.Click += new System.EventHandler(this.btnAvis_Click);
            // 
            // UserControlRecette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAvis);
            this.Controls.Add(this.btnRecette);
            this.Controls.Add(this.btnRecettePdf);
            this.Controls.Add(this.pnlAfficheRecette);
            this.Name = "UserControlRecette";
            this.Size = new System.Drawing.Size(690, 150);
            this.Load += new System.EventHandler(this.UserControlRecette_Load);
            this.pnlAfficheRecette.ResumeLayout(false);
            this.pnlAfficheRecette.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctImageRecette)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNomRecette;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.Label lblTemps;
        private System.Windows.Forms.PictureBox pctImageRecette;
        private System.Windows.Forms.Panel pnlAfficheRecette;
        private System.Windows.Forms.Button btnRecettePdf;
        private System.Windows.Forms.Button btnRecette;
        private System.Windows.Forms.Button btnAvis;
    }
}
