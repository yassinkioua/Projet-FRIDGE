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
    public partial class UCEtapeRecette : UserControl
    {
        private int nbEtape;
        private string Etape;
        private string nomImage;
        public UCEtapeRecette(string Etape_, int numEtape_,string nomImage_)
        {
            InitializeComponent();
            this.Etape = Etape_;
            this.nbEtape = numEtape_;
            this.nomImage = nomImage_;
            
            
        }

        private void UCEtapeRecette_Load(object sender, EventArgs e)
        {
            

            lblEtape.Text = Etape;
            lblEtape.Size = new Size(700, 120);
            lblEtape.AutoSize = false;
            this.BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\IUT\SEMESTRE_2\A21\SAEWIN\saewinform\SAE_FRIGO\SAE_FRIGO\bin\Debug\ImageEtape.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            lblNumEtape.Text = nbEtape.ToString();
            try
            {
                if (nomImage != "")
                {
                    pctImageRecette.Image = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\IUT\SEMESTRE_2\A21\SAEWIN\saewinform\SAE_FRIGO\SAE_FRIGO\bin\Debug\" + nomImage);
                    pctImageRecette.SizeMode = PictureBoxSizeMode.Zoom;


                }
            }
            catch { }
        }

        private void pctImageRecette_Click(object sender, EventArgs e)
        {

        }
    }
}
