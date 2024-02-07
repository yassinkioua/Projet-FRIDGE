namespace SAE_FRIGO
{
    partial class FormTypeDeRecette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTypeDeRecette));
            this.grpTypeDePlat = new System.Windows.Forms.GroupBox();
            this.grpBudget = new System.Windows.Forms.GroupBox();
            this.grpTempsDeCuisson = new System.Windows.Forms.GroupBox();
            this.btnPageSuivanteAfficherLesRecettes = new SAE_FRIGO.bouton();
            this.SuspendLayout();
            // 
            // grpTypeDePlat
            // 
            this.grpTypeDePlat.Location = new System.Drawing.Point(145, 65);
            this.grpTypeDePlat.Name = "grpTypeDePlat";
            this.grpTypeDePlat.Size = new System.Drawing.Size(544, 223);
            this.grpTypeDePlat.TabIndex = 0;
            this.grpTypeDePlat.TabStop = false;
            this.grpTypeDePlat.Text = "Type de plat";
            // 
            // grpBudget
            // 
            this.grpBudget.Location = new System.Drawing.Point(145, 345);
            this.grpBudget.Name = "grpBudget";
            this.grpBudget.Size = new System.Drawing.Size(544, 94);
            this.grpBudget.TabIndex = 1;
            this.grpBudget.TabStop = false;
            this.grpBudget.Text = "Budget";
            // 
            // grpTempsDeCuisson
            // 
            this.grpTempsDeCuisson.Location = new System.Drawing.Point(145, 497);
            this.grpTempsDeCuisson.Name = "grpTempsDeCuisson";
            this.grpTempsDeCuisson.Size = new System.Drawing.Size(544, 105);
            this.grpTempsDeCuisson.TabIndex = 2;
            this.grpTempsDeCuisson.TabStop = false;
            this.grpTempsDeCuisson.Text = "Temps de cuisson";
            // 
            // btnPageSuivanteAfficherLesRecettes
            // 
            this.btnPageSuivanteAfficherLesRecettes.Appearance = System.Windows.Forms.Appearance.Button;
            this.btnPageSuivanteAfficherLesRecettes.AutoSize = true;
            this.btnPageSuivanteAfficherLesRecettes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPageSuivanteAfficherLesRecettes.BackgroundImage")));
            this.btnPageSuivanteAfficherLesRecettes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPageSuivanteAfficherLesRecettes.FlatAppearance.BorderSize = 0;
            this.btnPageSuivanteAfficherLesRecettes.FlatAppearance.CheckedBackColor = System.Drawing.Color.Red;
            this.btnPageSuivanteAfficherLesRecettes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnPageSuivanteAfficherLesRecettes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPageSuivanteAfficherLesRecettes.Location = new System.Drawing.Point(851, 579);
            this.btnPageSuivanteAfficherLesRecettes.Name = "btnPageSuivanteAfficherLesRecettes";
            this.btnPageSuivanteAfficherLesRecettes.Size = new System.Drawing.Size(41, 23);
            this.btnPageSuivanteAfficherLesRecettes.TabIndex = 3;
            this.btnPageSuivanteAfficherLesRecettes.TabStop = true;
            this.btnPageSuivanteAfficherLesRecettes.Text = "Suite";
            this.btnPageSuivanteAfficherLesRecettes.UseVisualStyleBackColor = true;
            this.btnPageSuivanteAfficherLesRecettes.CheckedChanged += new System.EventHandler(this.btnPageSuivanteAfficherLesRecettes_CheckedChanged);
            // 
            // FormTypeDeRecette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 660);
            this.Controls.Add(this.btnPageSuivanteAfficherLesRecettes);
            this.Controls.Add(this.grpTempsDeCuisson);
            this.Controls.Add(this.grpBudget);
            this.Controls.Add(this.grpTypeDePlat);
            this.Name = "FormTypeDeRecette";
            this.Text = "FormTypeDeRecette";
            this.Load += new System.EventHandler(this.FormTypeDeRecette_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTypeDePlat;
        private System.Windows.Forms.GroupBox grpBudget;
        private System.Windows.Forms.GroupBox grpTempsDeCuisson;
        private bouton btnPageSuivanteAfficherLesRecettes;
    }
}