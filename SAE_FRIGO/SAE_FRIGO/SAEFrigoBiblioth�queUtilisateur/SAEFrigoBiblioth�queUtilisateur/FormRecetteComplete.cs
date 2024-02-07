using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SAEFrigoBibliothèqueUtilisateur
{
    public partial class FormRecetteComplete : Form
    {
        BindingSource bs = new BindingSource();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int numCat;
        Panel pnlEtapee = new Panel();
        string chaine = @"Provider=Microsoft.jet.OLEDB.4.0; Data Source=" + System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\baseFrigo.mdb";
        OleDbConnection cx = new OleDbConnection();
        int CodeRecette;
        string ImageRecette;
        int duree;
        string nbPersonne;
        string Prix;
        string nom;
        Panel pnlRecetteComplete = new Panel();
        Panel pnlIngredients = new Panel();
        Panel pnlEtapeRecette = new Panel();
        Panel pnlRecetteEtapeParEtape = new Panel();
        Button btnEtapeParEtape = new Button();
        Button btnRecetteComplete = new Button();
        public FormRecetteComplete(int codeRecette_, string ImageRecette_, int duree_)
        {
            InitializeComponent();

            this.Font = new Font("Aileron heavy", 17);
            this.FormBorderStyle = FormBorderStyle.None;
            
            
            this.CodeRecette = codeRecette_;
            this.ImageRecette = ImageRecette_;
            this.duree = duree_;
            
        }

        private void FormRecetteComplete_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(1920, 1080);
            this.WindowState = FormWindowState.Maximized;
            cx.ConnectionString = chaine;
            try
            {
                cx.Open();
                AfficheRecette(sender, e);
                Ingredients();
                Etapes();
                this.ChargementDsLocal();
            }
            
            catch (OleDbException)
            {
                MessageBox.Show("Erreur dans la requête SQL");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Erreur d'accès à la base de données");
            }
            finally
            {
                if (cx.State == ConnectionState.Open)
                {
                    cx.Close();
                }
            }

            
        }
        private void ChargementDsLocal()
        {
            // Obtient le schéma des tables de la base de données à l'aide de la connexion OleDb
            DataTable dt = cx.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });

            // Parcourt chaque ligne dans le schéma des tables
            foreach (DataRow dr in dt.Rows)
            {
                // Obtient le nom de la table à partir de la colonne "TABLE_NAME" de la ligne
                string nomTable = dr["TABLE_NAME"].ToString();

                // Vérifie si le nom de la table n'est pas "Table des erreurs"
                if (nomTable != "Table des erreurs")
                {
                    // Crée un OleDbDataAdapter pour sélectionner toutes les données de la table
                    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + nomTable, cx);

                    // Remplit l'objet DataSet "ds" avec les données de la table
                    da.Fill(ds, nomTable);
                }
            }
            foreach(DataRow drEtapes in ds.Tables["EtapesRecette"].Rows)
            {
                if (drEtapes[0].ToString() != CodeRecette.ToString())
                {
                    drEtapes.Delete(); // Supprime la ligne si le code de recette ne correspond pas à celui sélectionné
                }
            }


        }

        private void AfficheRecette(object sender, EventArgs e)
        {
            string req = "SELECT nbPersonnes,categPrix,description FROM Recettes WHERE codeRecette =" + CodeRecette.ToString();
            OleDbCommand cmd = new OleDbCommand(req, cx);
            OleDbDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                nbPersonne = read[0].ToString();
                Prix = read[1].ToString();
                nom = read[2].ToString();
            }


            pnlRecetteComplete.Dock = DockStyle.Fill;
            pnlRecetteComplete.BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\IUT\SEMESTRE_2\A21\SAEWIN\saewinform\SAE_FRIGO\SAE_FRIGO\bin\Debug\BackgroundEtapes.png");
            pnlRecetteComplete.BackgroundImageLayout = ImageLayout.Stretch;

            if (Convert.ToInt32(Prix) == 1)
            {
                Prix = "Bon Marché";
            }
            else if (Convert.ToInt32(Prix) == 2)
            {
                Prix = "Coût Moyen";
            }
            else
            {
                Prix = "Assez Cher";
            }

            Label lblPrix = new Label();
            lblPrix.Text = Prix;
            lblPrix.Location = new Point(1100, 330);
            lblPrix.Size = new Size(200, 60);

            Label lblNom = new Label();
            lblNom.Text = nom;
            lblNom.Location = new Point(50, 600);
            lblNom.Size = new Size(200, 60);

            Label lblPersonne = new Label();
            lblPersonne.Text = nbPersonne.ToString();
            lblPersonne.Location = new Point(1530, 330);

            pnlIngredients.Size = new Size(500, 400);
            pnlIngredients.Location = new Point(50, 620);
            pnlIngredients.BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\IUT\SEMESTRE_2\A21\SAEWIN\saewinform\SAE_FRIGO\SAE_FRIGO\bin\Debug\RecapIngredientsEtape.png");
            pnlIngredients.BackgroundImageLayout = ImageLayout.Stretch;
            pnlIngredients.AutoScroll = true;

            Label lblDuree = new Label();
            lblDuree.Text = duree.ToString();
            lblDuree.Location = new Point(840, 330);

            Panel pnlImageRecette = new Panel();
            pnlImageRecette.BackgroundImage = Image.FromFile(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + @"\IUT\SEMESTRE_2\A21\SAEWIN\saewinform\SAE_FRIGO\SAE_FRIGO\bin\Debug\" + ImageRecette);
            pnlImageRecette.BackgroundImageLayout = ImageLayout.Stretch;
            pnlImageRecette.Size = new Size(300, 300);
            pnlImageRecette.Location = new Point(100, 200);

            




            this.Controls.Add(pnlRecetteComplete);
            pnlRecetteComplete.Controls.Add(pnlImageRecette);
            pnlRecetteComplete.Controls.Add(lblPrix);
            pnlRecetteComplete.Controls.Add(pnlIngredients);
            pnlRecetteComplete.Controls.Add(lblDuree);
            pnlRecetteComplete.Controls.Add(lblPersonne);

            RecetteComplete(sender, e);
            btnRecetteComplete.Click += new EventHandler(RecetteComplete);
            btnEtapeParEtape.Click += new EventHandler(EtapeParEtape);




        }
        private void Ingredients()
        {
            string requestIngredients = "SELECT libIngredient FROM Ingrédients WHERE codeIngredient IN (SELECT codeIngredient FROM IngrédientsRecette WHERE codeRecette =" + CodeRecette.ToString() + ")";
            OleDbCommand cmdIngredients = new OleDbCommand(requestIngredients, cx);
            OleDbDataReader readerIngredients = cmdIngredients.ExecuteReader();

            int x = 20;
            int y = 80;
            while (readerIngredients.Read())
            {
                Label lblIngredient = new Label();
                lblIngredient.Location = new Point(x, y);
                lblIngredient.Text = readerIngredients[0].ToString();
                lblIngredient.Size = new Size(270, 40);
                lblIngredient.BackColor = Color.FromArgb(129, 139, 160);
                lblIngredient.ForeColor = Color.White;

                pnlIngredients.Controls.Add(lblIngredient);
                y = y + 50;
            }
        }
        private void Etapes()
        {
            string requestEtape = "SELECT texteEtape,imageEtape FROM EtapesRecette WHERE codeRecette = " + CodeRecette.ToString();
            OleDbCommand cmdEtape = new OleDbCommand(requestEtape, cx);
            OleDbDataReader readerEtape = cmdEtape.ExecuteReader();
            int x = 20;
            int y = 50;
            int numEtape = 0;
            while (readerEtape.Read())
            {

                UCEtapeRecette UCEtape = new UCEtapeRecette(readerEtape[0].ToString(), numEtape, readerEtape[1].ToString());
                UCEtape.Location = new Point(x, y);
                UCEtape.Size = new Size(500, 126);
                pnlEtapeRecette.Controls.Add((Control)UCEtape);
                y = y + 150;
                numEtape++;
            }
        }
        private void EtapeParEtape(object sender, EventArgs e)
        {
            try
            {
                cx.Open();
                int nb;
                pnlRecetteEtapeParEtape.Controls.Clear();
                pnlEtapee.Controls.Clear();
                pnlEtapeRecette.Visible = false;
                btnEtapeParEtape.Visible = false;

                pnlRecetteEtapeParEtape.Visible = true;
                btnRecetteComplete.Visible = true;

                

                btnRecetteComplete.Text = "Recette Complete";
                btnRecetteComplete.Location = new Point(1700, 280);
                btnRecetteComplete.Size = new Size(150, 100);
                btnRecetteComplete.BackColor = Color.FromArgb(239, 239, 239);



                
                pnlRecetteEtapeParEtape.Size = new Size(1300, 650);
                pnlRecetteEtapeParEtape.Location = new Point(620, 400);
                pnlRecetteEtapeParEtape.BackColor = Color.FromArgb(239, 239, 239);
                pnlRecetteEtapeParEtape.BorderStyle = BorderStyle.FixedSingle;
                pnlRecetteEtapeParEtape.AutoScroll = true;


                pnlEtapee.Size = new Size(1200, 400);
                pnlEtapee.Location = new Point(67,100);
                pnlEtapee.BackgroundImage = Image.FromFile("ImageEtapeParEtape.png");
                pnlEtapee.BackgroundImageLayout = ImageLayout.Stretch;



                pnlRecetteComplete.Controls.Add(btnRecetteComplete);
                pnlRecetteComplete.Controls.Add(pnlRecetteEtapeParEtape);
                
                PictureBox pctImageEtape = new PictureBox();
                pctImageEtape.Size = new Size(300, 300);
                pctImageEtape.Location = new Point(800, 50);
                

                Button btnSuivant = new Button();
                btnSuivant.Size = new Size(200, 80);
                btnSuivant.Location = new Point(712, 500);
                
                btnSuivant.Tag = 1; 
                btnSuivant.BackgroundImage = Image.FromFile("ImageSuivant.png");
                btnSuivant.BackgroundImageLayout = ImageLayout.Stretch;


                Button btnPrecedent = new Button();
                btnPrecedent.Size = new Size(200, 80);
                btnPrecedent.Location = new Point(387, 500);
               
                btnPrecedent.Tag = 0; 
                btnPrecedent.BackgroundImage = Image.FromFile("ImagebtnRetourEtpae.png");
                btnPrecedent.BackgroundImageLayout = ImageLayout.Stretch;


                Button btnPremiereEtape = new Button();
                btnPremiereEtape.Size = new Size(200, 80);
                btnPremiereEtape.Location = new Point(62, 500);
                
                btnPremiereEtape.Tag = 2;
                btnPremiereEtape.BackgroundImage = Image.FromFile("ImageEtape1.png");
                btnPremiereEtape.BackgroundImageLayout = ImageLayout.Stretch;


                Button btnDernier = new Button();
                btnDernier.Size = new Size(200, 80);
                btnDernier.Location = new Point(1027, 500);
                
                btnDernier.Tag = 3;
                btnDernier.BackgroundImage = Image.FromFile("ImageFinal.png");
                btnDernier.BackgroundImageLayout = ImageLayout.Stretch;



                btnPrecedent.Click += new EventHandler(btnSuivant_Click);
                btnSuivant.Click += new EventHandler(btnSuivant_Click);
                btnPremiereEtape.Click += new EventHandler(btnSuivant_Click);
                btnDernier.Click += new EventHandler(btnSuivant_Click);

                Label lblEtapes = new Label();
                lblEtapes.Size = new Size(100, 40);
                lblEtapes.Location = new Point(500, 70);
                lblEtapes.BackColor = Color.White;

                Label lbldescEtape = new Label();
                lbldescEtape.Size = new Size(600, 150);
                lbldescEtape.Location = new Point(150, 200);
                lbldescEtape.BackColor = Color.White;


                string requestEtape = "SELECT texteEtape,imageEtape FROM EtapesRecette WHERE codeRecette = " + CodeRecette.ToString();
                OleDbCommand cmdEtape = new OleDbCommand(requestEtape, cx);
                OleDbDataReader readerEtape = cmdEtape.ExecuteReader();

                bs.DataSource = ds.Tables["EtapesRecette"];

                if (numCat == 0) // GAUCHE
                {
                    bs.MovePrevious();
                }
                else if (numCat == 1) // DROITE
                {
                    bs.MoveNext();
                }
                else if (numCat == 2) // DEBUT
                {
                    bs.MoveFirst();
                }
                else // FIN
                {
                    bs.MoveLast();
                }
                lblEtapes.Text = ((DataRowView)bs.Current)["NumEtape"].ToString();
                lbldescEtape.Text = ((DataRowView)bs.Current)["TexteEtape"].ToString();
                pctImageEtape.Image = Image.FromFile(((DataRowView)bs.Current)["imageEtape"].ToString());

                pnlRecetteEtapeParEtape.Controls.Add(pnlEtapee);
                pnlRecetteEtapeParEtape.Controls.Add(btnPrecedent);
                pnlEtapee.Controls.Add(lblEtapes);
                pnlEtapee.Controls.Add(pctImageEtape);
                pnlRecetteEtapeParEtape.Controls.Add(btnDernier);
                pnlRecetteEtapeParEtape.Controls.Add(btnPremiereEtape);
                pnlRecetteEtapeParEtape.Controls.Add(btnSuivant);
                pnlEtapee.Controls.Add(lbldescEtape);

            }
            catch { MessageBox.Show("erreur"); }
            finally { cx.Close(); }
           


        }
        private void RecetteComplete(object sender, EventArgs e)
        {
            pnlRecetteEtapeParEtape.Visible = false;
            btnRecetteComplete.Visible = false;

            pnlEtapeRecette.Visible = true;
            btnEtapeParEtape.Visible = true;

            pnlEtapeRecette.Size = new Size(1300, 650);
            pnlEtapeRecette.Location = new Point(620, 400);
            pnlEtapeRecette.BackColor = Color.FromArgb(239, 239, 239);
            pnlEtapeRecette.BorderStyle = BorderStyle.FixedSingle;
            pnlEtapeRecette.AutoScroll = true;


            btnEtapeParEtape.Text = "Etape par Etape";
            btnEtapeParEtape.Location = new Point(1700, 280);
            btnEtapeParEtape.Size = new Size(150, 100);
            btnEtapeParEtape.BackColor = Color.FromArgb(239, 239, 239);


            pnlRecetteComplete.Controls.Add(btnEtapeParEtape);
            pnlRecetteComplete.Controls.Add(pnlEtapeRecette);


        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            Button btnEtapeEtape = (Button)sender;
            if(int.Parse(btnEtapeEtape.Tag.ToString()) == 0)
            {
                numCat = 0;
            }
            else if (int.Parse(btnEtapeEtape.Tag.ToString()) == 1)
            {
                numCat = 1;
            }
            else if (int.Parse(btnEtapeEtape.Tag.ToString()) == 2)
            {
                numCat = 2;
            }
            else
            {
                numCat = 3;
            }
            EtapeParEtape(sender, e);


        }

    }
}
