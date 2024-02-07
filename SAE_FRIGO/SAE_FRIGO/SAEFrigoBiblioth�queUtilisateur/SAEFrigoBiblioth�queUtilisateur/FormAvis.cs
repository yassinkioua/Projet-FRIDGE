using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAEFrigoBibliothèqueUtilisateur
{
    public partial class FormAvis : Form
    {
        string ImageRecette;
        string NomPlat;
        public FormAvis(string ImageRecette_,string NomPlat_)
        {
            
            InitializeComponent();
            this.ImageRecette = ImageRecette_;
            this.NomPlat = NomPlat_;
        }

        private void FormAvis_Load(object sender, EventArgs e)
        {
            this.Font = new Font("Aileron heavy", 17);
            this.Size = new Size(1920, 1080);
            this.WindowState = FormWindowState.Maximized;

            this.BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\IUT\SEMESTRE_2\A21\SAEWIN\saewinform\SAE_FRIGO\SAE_FRIGO\bin\Debug\BackgroundNoteRecetteSansImage.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            Panel pnlImageRecette = new Panel();
            if (ImageRecette != "")
            {
                pnlImageRecette.BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\IUT\SEMESTRE_2\A21\SAEWIN\saewinform\SAE_FRIGO\SAE_FRIGO\bin\Debug\" + ImageRecette);
                pnlImageRecette.BackgroundImageLayout = ImageLayout.Stretch;
                pnlImageRecette.Size = new Size(400,400);
                pnlImageRecette.Location = new Point(100, 280);
            }

            Label lblNomPlat = new Label();
            lblNomPlat.Font = new Font("Aileron heavy", 22);
            lblNomPlat.Text = NomPlat;
            lblNomPlat.Location = new Point(100,700);
            lblNomPlat.Size = new Size(500, 100);

           

            TextBox txtPseudo = new TextBox();
            txtPseudo.Location = new Point(800,390);
            txtPseudo.Size = new Size(400,30);
            txtPseudo.BorderStyle = BorderStyle.None;
            txtPseudo.BackColor = Color.FromArgb(217, 217, 217);

            

            TextBox txtAvis = new TextBox();
            txtAvis.Location = new Point(800,650);
            txtAvis.Size = new Size(930,210);
            txtAvis.BorderStyle = BorderStyle.None;
            txtAvis.Multiline = true;

            Button btnQuitter = new Button();
            btnQuitter.Size = new Size(90, 90);
            btnQuitter.Location = new Point(1780, 920);
            btnQuitter.Click += new EventHandler(Quitter);
            btnQuitter.Text = "Quitter";
            
            txtAvis.BackColor = Color.FromArgb(217, 217, 217);

            this.Controls.Add(pnlImageRecette);
            this.Controls.Add(lblNomPlat);
            this.Controls.Add(txtAvis);
            this.Controls.Add(txtPseudo);
            this.Controls.Add(btnQuitter);
            
        }
        private void Quitter(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
