namespace SAEFrigoBibliothèqueUtilisateur
{
    partial class UCEtapeRecette
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
            this.lblEtape = new System.Windows.Forms.Label();
            this.lblNumEtape = new System.Windows.Forms.Label();
            this.pctImageRecette = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctImageRecette)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEtape
            // 
            this.lblEtape.AutoSize = true;
            this.lblEtape.ForeColor = System.Drawing.Color.Black;
            this.lblEtape.Location = new System.Drawing.Point(131, 56);
            this.lblEtape.Name = "lblEtape";
            this.lblEtape.Size = new System.Drawing.Size(35, 13);
            this.lblEtape.TabIndex = 1;
            this.lblEtape.Text = "label1";
            // 
            // lblNumEtape
            // 
            this.lblNumEtape.AutoSize = true;
            this.lblNumEtape.Location = new System.Drawing.Point(209, 19);
            this.lblNumEtape.Name = "lblNumEtape";
            this.lblNumEtape.Size = new System.Drawing.Size(35, 13);
            this.lblNumEtape.TabIndex = 2;
            this.lblNumEtape.Text = "label1";
            // 
            // pctImageRecette
            // 
            this.pctImageRecette.Location = new System.Drawing.Point(18, 13);
            this.pctImageRecette.Name = "pctImageRecette";
            this.pctImageRecette.Size = new System.Drawing.Size(107, 101);
            this.pctImageRecette.TabIndex = 3;
            this.pctImageRecette.TabStop = false;
            this.pctImageRecette.Click += new System.EventHandler(this.pctImageRecette_Click);
            // 
            // UCEtapeRecette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pctImageRecette);
            this.Controls.Add(this.lblNumEtape);
            this.Controls.Add(this.lblEtape);
            this.Name = "UCEtapeRecette";
            this.Size = new System.Drawing.Size(500, 126);
            this.Load += new System.EventHandler(this.UCEtapeRecette_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctImageRecette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEtape;
        private System.Windows.Forms.Label lblNumEtape;
        private System.Windows.Forms.PictureBox pctImageRecette;
    }
}
