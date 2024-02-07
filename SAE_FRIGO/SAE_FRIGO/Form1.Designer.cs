namespace SAE_FRIGO
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlChoixIngredient = new System.Windows.Forms.Panel();
            this.btnSuivantUnToDeux = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlChoixIngredient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlChoixIngredient
            // 
            this.pnlChoixIngredient.Controls.Add(this.btnSuivantUnToDeux);
            this.pnlChoixIngredient.Location = new System.Drawing.Point(12, 12);
            this.pnlChoixIngredient.Name = "pnlChoixIngredient";
            this.pnlChoixIngredient.Size = new System.Drawing.Size(1000, 633);
            this.pnlChoixIngredient.TabIndex = 5;
            this.pnlChoixIngredient.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChoixIngredient_Paint);
            // 
            // btnSuivantUnToDeux
            // 
            this.btnSuivantUnToDeux.Location = new System.Drawing.Point(903, 569);
            this.btnSuivantUnToDeux.Name = "btnSuivantUnToDeux";
            this.btnSuivantUnToDeux.Size = new System.Drawing.Size(75, 23);
            this.btnSuivantUnToDeux.TabIndex = 8;
            this.btnSuivantUnToDeux.Text = "Suivant";
            this.btnSuivantUnToDeux.UseVisualStyleBackColor = true;
            this.btnSuivantUnToDeux.Click += new System.EventHandler(this.btnSuivantUnToDeux_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1496, 573);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Load);
            this.pnlChoixIngredient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChoixIngredient;
        private System.Windows.Forms.Button btnSuivantUnToDeux;
        private System.Windows.Forms.Timer timer1;
    }
}

