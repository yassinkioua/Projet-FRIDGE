using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SAEFrigoBibliothèqueUtilisateur;
using static System.Net.WebRequestMethods;


namespace SAEFrigoBibliothèqueUtilisateur
{
    public partial class UserControlRecette : UserControl
    {
        private string nomRecette;
        private String Budget;
        private int duree;
        private string ImageRecette;
        private int CodeRecette;
        OleDbConnection cx;


        public UserControlRecette(string nomRecette_, string budget_, int duree_, string ImageRecette_, int CodeRecette_)
        {
            InitializeComponent();
            this.Budget = budget_;
            this.duree = duree_;
            this.ImageRecette = ImageRecette_;
            this.nomRecette = nomRecette_;
            this.CodeRecette = CodeRecette_;
            string chaine = @"Provider=Microsoft.jet.OLEDB.4.0; Data Source=" + System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\baseFrigo.mdb";
            cx = new OleDbConnection(chaine);
        }

        private void UserControlRecette_Load(object sender, EventArgs e)
        {
            lblNomRecette.Text = nomRecette;
            lblPrix.Text = Budget;
            lblTemps.Text = duree.ToString();
            pctImageRecette.SizeMode = PictureBoxSizeMode.StretchImage;

            pnlAfficheRecette.BackgroundImage = System.Drawing.Image.FromFile("BackgroundUserControlsRecette.png");
            pnlAfficheRecette.BackgroundImageLayout = ImageLayout.Stretch;


            btnRecettePdf.BackgroundImage = System.Drawing.Image.FromFile("ImageLogoPDF.png");
            btnRecettePdf.BackgroundImageLayout = ImageLayout.Stretch;
            btnRecettePdf.Click += btnRecettePdf_Click;

            btnAvis.BackgroundImage = System.Drawing.Image.FromFile("ImageAvis.png");
            btnAvis.BackgroundImageLayout = ImageLayout.Stretch;
            btnAvis.Click += btnAvis_Click;


            btnRecette.BackgroundImage = System.Drawing.Image.FromFile("Imageplat.png");
            btnRecette.BackgroundImageLayout = ImageLayout.Stretch;


            lblNomRecette.BackColor = Color.White;
            lblPrix.BackColor = Color.White;
            lblTemps.BackColor = Color.White;
            try
            {
                if (ImageRecette != "")
                {
                    pctImageRecette.Image = System.Drawing.Image.FromFile(ImageRecette);
                }
            }
            catch { }
            try
            {
                cx.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnRecettePdf_Click(object sender, EventArgs e)
        {
            string req = "SELECT nbPersonnes,categPrix,description,imageDesc,tempsCuisson FROM Recettes WHERE codeRecette =" + CodeRecette.ToString();
            OleDbCommand cmd = new OleDbCommand(req, cx);
            OleDbDataReader read = cmd.ExecuteReader();
            string requestEtape = "SELECT texteEtape,imageEtape FROM EtapesRecette WHERE codeRecette = " + CodeRecette.ToString();
            OleDbCommand cmdEtape = new OleDbCommand(requestEtape, cx);
            OleDbDataReader readerEtape = cmdEtape.ExecuteReader();
            string requestIngredients = "SELECT libIngredient FROM Ingrédients WHERE codeIngredient IN (SELECT codeIngredient FROM IngrédientsRecette WHERE codeRecette =" + CodeRecette.ToString() + ")";
            OleDbCommand cmdIngredients = new OleDbCommand(requestIngredients, cx);
            OleDbDataReader readerIngredients = cmdIngredients.ExecuteReader();
            genererPDF(read, readerEtape, readerIngredients);

        }

        private void pctImageRecette_Click(object sender, EventArgs e)
        {

        }

        private void btnRecette_Click(object sender, EventArgs e)
        {
            FormRecetteComplete frmrecette = new FormRecetteComplete(CodeRecette, ImageRecette, duree);
            frmrecette.ShowDialog();

        }

        private void btnAvis_Click(object sender, EventArgs e)
        {
            FormAvis frmAvis = new FormAvis(ImageRecette, nomRecette);
            frmAvis.ShowDialog();
        }
        private void genererPDF(OleDbDataReader readerTitre, OleDbDataReader readerEtape, OleDbDataReader readerIngrédient)
        {
            Document document = new Document();
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Fichiers PDF (.pdf)|.pdf",
                FileName = "document.pdf"
            };
            saveFileDialog.ShowDialog();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
            document.Open();
            PdfPTable tableTitre = new PdfPTable(4);
            tableTitre.WidthPercentage = 100; // Définir la largeur totale de la table (ici, 100% de la largeur disponible)
            Paragraph saut = new Paragraph(" ");
            while (readerTitre.Read())
            {
                string nom = readerTitre["description"].ToString();
                string cuisson = readerTitre["tempsCuisson"].ToString();
                string nbPersonne = readerTitre["nbPersonnes"].ToString();
                string image = readerTitre["imageDesc"].ToString();
                string cate_prix = readerTitre["categPrix"].ToString();

                iTextSharp.text.Font fontTitre = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 20f);
                Chunk chunkTitre = new Chunk("Recette : " + nom, fontTitre);
                chunkTitre.SetUnderline(1f, -2f);
                Paragraph Titre = new Paragraph(chunkTitre);
                Titre.Alignment = Element.ALIGN_MIDDLE;
                document.Add(chunkTitre);
                document.Add(saut);
            }
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100; // Définir la largeur totale de la table (ici, 100% de la largeur disponible)
            int etape = 1;
            while (readerEtape.Read())
            {
                string texteEtape = "Étape " + etape + " :\n \n" + readerEtape["texteEtape"].ToString();
                string imagePath = readerEtape["imageEtape"].ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imagePath);
                    float Width = image.Width / 3;
                    float Height = image.Height / 3;
                    image.ScaleToFit(Width, Height);
                    PdfPCell imageCell = new PdfPCell(image);
                    imageCell.Border = PdfPCell.NO_BORDER;
                    imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    imageCell.VerticalAlignment = Element.ALIGN_CENTER;
                    imageCell.FixedHeight = 100; // Définir la hauteur de la cellule de l'image (ici, 100 unités)
                    table.AddCell(imageCell);
                }
                Paragraph paragraph = new Paragraph(texteEtape);
                PdfPCell textCell = new PdfPCell(paragraph);
                textCell.Border = PdfPCell.NO_BORDER;
                textCell.FixedHeight = 100; // Définir la hauteur de la cellule de l'image (ici, 100 unités)
                textCell.HorizontalAlignment = Element.ALIGN_LEFT;
                textCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                table.AddCell(textCell);
                etape = etape + 1;
            }
            document.Add(table);
            string sep = "----------------------------------------------------------------------------------------------------------------------------------";
            Paragraph separateur = new Paragraph(sep);
            document.Add(saut);
            iTextSharp.text.Font font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f);
            Chunk chunk = new Chunk("Ingrédients :", font);
            chunk.SetUnderline(1f, -2f);
            document.Add(chunk);
            document.Add(saut);
            while (readerIngrédient.Read())
            {
                string texteIngrediant = "- " + readerIngrédient["libIngredient"].ToString();
                Paragraph ing = new Paragraph(texteIngrediant);
                document.Add(ing);
            }
            MessageBox.Show("Pdf exporter avec succès");
            document.Close();
        }
    }
}