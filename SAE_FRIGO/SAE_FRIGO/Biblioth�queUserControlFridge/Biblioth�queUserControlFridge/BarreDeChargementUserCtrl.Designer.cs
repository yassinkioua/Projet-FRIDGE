namespace BibliothèqueUserControlFridge
{
    partial class BarreDeChargementUserCtrl
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
            pnl1 = new Panel();
            button1 = new Button();
            label1 = new Label();
            pnl1.SuspendLayout();
            SuspendLayout();
            // 
            // pnl1
            // 
            pnl1.Controls.Add(label1);
            pnl1.Controls.Add(button1);
            pnl1.Location = new Point(73, 161);
            pnl1.Name = "pnl1";
            pnl1.Size = new Size(767, 82);
            pnl1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(599, 45);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(673, 27);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // BarreDeChargementUserCtrl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnl1);
            Name = "BarreDeChargementUserCtrl";
            Size = new Size(903, 344);
            Load += BarreDeChargementUserCtrl_Load;
            pnl1.ResumeLayout(false);
            pnl1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl1;
        private Button button1;
        private Label label1;
    }
}
