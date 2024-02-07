using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Schema;
using SAEFrigoBibliothèqueUtilisateur;

namespace SAE_FRIGO
{
    public partial class Form1 : Form
    {
        
        
        OleDbConnection cx;
        List<string> listrecap = new List<string>();
        List<string> RecapTypeDeRecette = new List<string>();
        List<int> RecapIngredientsEnInt = new List<int>();
        List<int> RecapTypeDeRecetteEnInt = new List<int>();
        int budget = -1;
        int temps = -1;
        DataSet ds;
        

        const int COEFFICIENT_TAILLE = 1;

        Panel pnlAccueil = new Panel();
        
        Panel pChargement2 = new Panel();
        Panel pChargement = new Panel();

        Panel pnlEtape1 = new Panel();
        Panel pnlFamilles = new Panel();
        Panel pnlIngredients = new Panel();
        Panel pnlRecap = new Panel();

        Panel pnlFiltres = new Panel();
        Panel pnlTypeDePlat = new Panel();
        Panel pnlPrix = new Panel();
        Panel pnlTemps = new Panel();

        Panel pnlRecette = new Panel();

        string requete;


        public Form1()
        {
            this.Font = new Font("Aileron heavy", 17);
            this.FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();
            string chaine = @"Provider=Microsoft.jet.OLEDB.4.0; Data Source="+ System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\baseFrigo.mdb";

           

            cx = new OleDbConnection(chaine);
            ds = new DataSet();
            pChargement.Location = new Point(100, 700);
            


            pChargement.Height = 70;
            pChargement.Width = 30;


            pChargement2.Location = new Point(100, 700);
            pChargement2.Height = 70;
            pChargement2.Width = 800;


        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
                
            this.Size = new Size(1920 * COEFFICIENT_TAILLE, 1080 * COEFFICIENT_TAILLE);
            this.WindowState = FormWindowState.Maximized;
            



            try
            {
                cx.Open();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.ChargementDsLocal();


            pageAccueil();
           

        }

        private void AffichageIngredient(object sender, EventArgs e)
        {
           
            pnlIngredients.Controls.Clear();
            int nbIngredient = 0;
            int x = 30;
            int y = 60;

            RadioButton rbIngredients = (RadioButton)sender;

            //string requestIngredients = "SELECT libIngredient FROM Ingrédients WHERE codeFamille=(SELECT codeFamille FROM Famille WHERE libFamille='" + rbIngredients.Text + "')";
            //OleDbCommand cmdIngredients = new OleDbCommand(requestIngredients, cx);
            //OleDbDataReader readerIngredients = cmdIngredients.ExecuteReader();fgfg

            string codeFamille = "";
            foreach (DataRow dr in ds.Tables["Famille"].Rows)
            {
                if (dr[1].ToString().CompareTo(rbIngredients.Text) == 0)
                {
                    codeFamille = dr[0].ToString();
                }
            } 
            foreach (DataRow dtr in ds.Tables["Ingrédients"].Rows)
            {
                    if (dtr[2].ToString().CompareTo(codeFamille) == 0)
                    { 
                        if (nbIngredient % 4 == 0)
                        {
                            x = 40;
                            y += 40;

                        }
                        CheckBox ckb = new CheckBox();

                        ckb.Size = new Size(270, 40);
                        ckb.Location = new Point(x, y);
                        ckb.Text = dtr[1].ToString();
                        ckb.BackColor = Color.White;
                        pnlIngredients.Controls.Add(ckb);
                        pnlIngredients.AutoScroll = true;

                        if (listrecap.Contains(ckb.Text) == true)
                        {
                            ckb.Checked = true;
                        }
                        x += 270;
                        nbIngredient++;
                        ckb.CheckedChanged += new System.EventHandler(recapIngrediant);
                    }
                
            }


        }

        private void AfficheRecapIngredient(object sender, EventArgs e)
        {


            int x = 30;
            int y = 100;
            pnlRecap.Controls.Clear();
            


            for (int j = 0; j < listrecap.Count; j++)
            {

                CheckBox newIngre = new CheckBox();

                newIngre.Size = new Size(300, 60);
                newIngre.Checked = true;
                newIngre.Location = new Point(x, y);
                newIngre.Text = listrecap[j].ToString();
                newIngre.BackColor = Color.FromArgb(129, 139, 160);
                newIngre.ForeColor = Color.White;
                pnlRecap.Controls.Add(newIngre);

                x += 300;
                newIngre.CheckedChanged += new System.EventHandler(enleveRecapIngredient);
            }






        }
        private void recapIngrediant(object sender, EventArgs e)
        {

            foreach (Control ancieningr in pnlRecap.Controls)
            {
                if (ancieningr is CheckBox)
                {
                    CheckBox ckb = (CheckBox)ancieningr;
                    if (listrecap.Contains(ancieningr.Text) == false)
                    { ckb.Checked = false; }
                }

            }
            foreach (Control ckbIngreChoisi in pnlIngredients.Controls)
            {

                CheckBox ckb = (CheckBox)ckbIngreChoisi;


                if (ckbIngreChoisi is CheckBox)
                {


                    if (ckb.Checked == true)
                    {
                        if (listrecap.Contains(ckbIngreChoisi.Text) == false)
                        {
                            if (listrecap.Count < 3)
                            {
                               
                                listrecap.Add(ckbIngreChoisi.Text);
                            }
                            else
                            {
                                ckb.Checked = false;
                            }

                        }

                    }
                    else if (ckb.Checked == false)
                    {
                        if (listrecap.Contains(ckbIngreChoisi.Text) == true)
                        {
                            listrecap.Remove(ckbIngreChoisi.Text);
                            ckb.Checked = false;

                        }
                    }


                }
                //ckb.CheckedChanged += new System.EventHandler(AfficheRecapIngredient);
                AfficheRecapIngredient(sender, e);

            }
        }
        private void enleveRecapIngredient(object sender, EventArgs e)
        {
            CheckBox chkb = (CheckBox)sender;
            if (chkb.Checked == false)
            {
                pnlRecap.Controls.Remove(chkb);
                listrecap.Remove(chkb.Text);

            }
            foreach (Control ancieningr in pnlIngredients.Controls)
            {
                CheckBox ckb = (CheckBox)ancieningr;
                if (listrecap.Contains(ancieningr.Text) == false)
                { ckb.Checked = false; }
            }

            foreach (Control newIngre in pnlRecap.Controls)
            {
                CheckBox ckb = (CheckBox)newIngre;
                if (newIngre is CheckBox)
                {
                    if (ckb.Checked == false)
                    {
                        if (listrecap.Contains(newIngre.Text) == true)
                        {
                            listrecap.Remove(newIngre.Text);
                            pnlRecap.Controls.Remove(newIngre);
                            ckb.Checked = false;


                        }
                    }


                }
                AfficheRecapIngredient(sender, e);

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
        }

        private void freePage()
        {
            this.Controls.Clear();
        }

        private void generationAccueilIngredients(object sender, EventArgs e)
        {
            freePage();
            pnlEtape1.Dock = DockStyle.Fill;
            pnlEtape1.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ImageBackgroundEtape1.png");
            pnlEtape1.BackgroundImageLayout = ImageLayout.Stretch;
            pnlEtape1.Size = new Size(350 * COEFFICIENT_TAILLE, 700 * COEFFICIENT_TAILLE);
            

            pnlFamilles.Size = new Size(375 * COEFFICIENT_TAILLE, 730 * COEFFICIENT_TAILLE);
            pnlFamilles.Location = new Point(100 * COEFFICIENT_TAILLE, 300 * COEFFICIENT_TAILLE);
            pnlFamilles.Name = "Text";
            pnlFamilles.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\BackgrondFamilleIngredients.png");
            pnlFamilles.BackgroundImageLayout = ImageLayout.Stretch;
           

            Button btnSuivant1 = new Button();
            
            btnSuivant1.Size = new Size(500, 100);
            btnSuivant1.FlatStyle = FlatStyle.Flat;
            btnSuivant1.FlatAppearance.BorderSize = 0;
            btnSuivant1.Location = new Point(1450, 890);
            btnSuivant1.BackColor = Color.FromArgb(129, 139, 160);
            btnSuivant1.Visible = true; 
            btnSuivant1.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\bouttonSuivant1to2.png");
            btnSuivant1.BackgroundImageLayout = ImageLayout.Stretch;
            btnSuivant1.Click += new System.EventHandler(pageFiltre);
            this.Controls.Add(btnSuivant1);
            this.Controls.Add(pnlFamilles);
            
            


            int x = 35;
            int y = 125;

            foreach (DataRow dr in ds.Tables["Famille"].Rows)
            {
                bouton b = new bouton();
                b.Size = new Size(300 * COEFFICIENT_TAILLE, 33 * COEFFICIENT_TAILLE);
                b.Location = new Point(x, y);
                y = y + 42;
                b.Text = dr[1].ToString();
                pnlFamilles.Controls.Add(b);
                b.CheckedChanged += new System.EventHandler(AffichageIngredient);
            }


            pnlIngredients.Size = new Size(1150 * COEFFICIENT_TAILLE, 400 * COEFFICIENT_TAILLE);
            pnlIngredients.Location = new Point(650 * COEFFICIENT_TAILLE,300  * COEFFICIENT_TAILLE);
            pnlIngredients.Name = "Text";
            pnlIngredients.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ImageIngredients.png");
            pnlIngredients.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(pnlIngredients);

            pnlRecap.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\ImageRecap.png");
            pnlRecap.BackgroundImageLayout = ImageLayout.Stretch;
            pnlRecap.Size = new Size(1300 * COEFFICIENT_TAILLE, 250 * COEFFICIENT_TAILLE);
            pnlRecap.Location = new Point(650 * COEFFICIENT_TAILLE,750* COEFFICIENT_TAILLE);
            pnlRecap.Name = "Text";
            pnlRecap.BackColor = Color.White;
            this.Controls.Add(pnlRecap);
            this.Controls.Add(pnlEtape1);

        }
        private void pageAccueil()
        {
            
            
            pnlAccueil.Dock = DockStyle.Fill;


            pChargement.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\imageBarreDeChargement2.png");
            pChargement.BackgroundImageLayout = ImageLayout.Stretch;

            pChargement2.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\imageBarreDeChargement1.png");
            pChargement2.BackgroundImageLayout = ImageLayout.Stretch;
            

            

            pnlAccueil.Location = new Point(0 * COEFFICIENT_TAILLE, 0 * COEFFICIENT_TAILLE);
            pnlAccueil.Name = "Text";
           
           pnlAccueil.BackgroundImage = Image.FromFile("BackgroundAcceuil.png");
            pnlAccueil.BackgroundImageLayout = ImageLayout.Zoom;
            this.Controls.Add(pChargement);
            this.Controls.Add(pChargement2);
            this.Controls.Add(pnlAccueil);
            
        }

        private void pageFiltre(object sender, EventArgs e)
        {
            freePage();

            Button btnSuivant2 = new Button();
            Button btnRetour1 = new Button();

            btnRetour1.Click += new System.EventHandler(generationAccueilIngredients);
            btnRetour1.BackgroundImage = Image.FromFile("ImageBtnRetour.png");
            btnRetour1.BackgroundImageLayout = ImageLayout.Stretch;
            btnRetour1.FlatAppearance.BorderSize = 0;
            btnRetour1.FlatStyle = FlatStyle.Flat;
            btnRetour1.Size = new Size(100, 80);
            btnRetour1.Location = new Point(20, 850);

            btnSuivant2.Click += new System.EventHandler(pageFiltre);
            btnSuivant2.BackgroundImage = Image.FromFile("BackgroundBouttonAfficherRecette.png");
            btnSuivant2.BackgroundImageLayout = ImageLayout.Stretch;
            btnSuivant2.FlatAppearance.BorderSize = 0;
            btnSuivant2.FlatStyle = FlatStyle.Flat;
            btnSuivant2.Size = new Size(430, 90);
            btnSuivant2.Location = new Point(1450, 850);
            btnSuivant2.Visible = true;

            pnlFiltres.Location = new Point(0 * COEFFICIENT_TAILLE, 0 * COEFFICIENT_TAILLE);
            pnlFiltres.Size = new Size(1920 * COEFFICIENT_TAILLE, 1080 * COEFFICIENT_TAILLE);
            pnlFiltres.Name = "Text";
            pnlFiltres.BackColor = Color.White;
            pnlFiltres.BackgroundImage = Image.FromFile("BackgroundEtape2.png");
            pnlFiltres.BackgroundImageLayout = ImageLayout.Stretch;

            pnlTypeDePlat.Controls.Clear();
            pnlTypeDePlat.Location = new Point(140, 350);
            pnlTypeDePlat.Size = new Size(500, 700);
            pnlTypeDePlat.BackgroundImage = Image.FromFile("BackgroundTypeDeRecette.png");
            pnlTypeDePlat.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTypeDePlat.Name = "Type";

            pnlPrix.Location = new Point(740, 350);
            pnlPrix.Size = new Size(350, 350);
            pnlPrix.BackgroundImage = Image.FromFile("BackgroundBudgetpetit.png");
            pnlPrix.BackgroundImageLayout = ImageLayout.Stretch;
            pnlPrix.Name = "Type";

            pnlTemps.Location = new Point(1200, 350);
            pnlTemps.Size = new Size(350, 350);
            pnlTemps.BackgroundImageLayout = ImageLayout.Stretch;
            pnlTemps.BackgroundImage = Image.FromFile("BackgroundTempsEnMin.png");
            pnlTemps.Name = "Type";

            TypeDeRecette();
            PrixRecette();
            FiltreTemps();

            btnSuivant2.Click += new System.EventHandler(PageRecette);

            this.Controls.Add(btnSuivant2);
            this.Controls.Add(btnRetour1);
            this.Controls.Add(pnlTypeDePlat);
            this.Controls.Add(pnlPrix);
            this.Controls.Add(pnlTemps);
            this.Controls.Add(pnlFiltres);  

        }


        private void grpIngredients_Enter(object sender, EventArgs e)
        {

        }
        private void PrixRecette()
        {
            RadioButton rdbPrixHaut  = new RadioButton();
            RadioButton rdbPrixMoyen = new RadioButton();
            RadioButton rdbPrixBas = new RadioButton();


            rdbPrixHaut.Size = new Size(300, 40);
            rdbPrixHaut.Location = new Point(30, 100);
            rdbPrixHaut.Text = "Bon Marché";
            rdbPrixHaut.BackColor = Color.White;

            rdbPrixMoyen.Size = new Size(300, 40);
            rdbPrixMoyen.Location = new Point(30, 150);
            rdbPrixMoyen.Text = "Coût Moyen";
            rdbPrixMoyen.BackColor = Color.White;

            rdbPrixBas.Size = new Size(300, 40);
            rdbPrixBas.Location = new Point(30, 200);
            rdbPrixBas.Text = "Assez Chère";
            rdbPrixBas.BackColor = Color.White;

            rdbPrixBas.CheckedChanged += new System.EventHandler(PrixChere);
            rdbPrixMoyen.CheckedChanged += new System.EventHandler(PrixMoyen);
            rdbPrixHaut.CheckedChanged += new System.EventHandler(PrixBas);

            pnlPrix.Controls.Add(rdbPrixHaut);
            pnlPrix.Controls.Add(rdbPrixMoyen);
            pnlPrix.Controls.Add(rdbPrixBas);
        }
        private void TypeDeRecette()
        {
            int x = 0;
            int y = 80;
            int nbFiltre = 0;

            foreach (DataRow row in ds.Tables["Catégories"].Rows)
            {
                if (nbFiltre % 1 == 0)
                {
                    x = 50;
                    y += 40;

                }
                CheckBox ckb = new CheckBox();

                ckb.Size = new Size(300, 40);
                ckb.Location = new Point(x, y);
                ckb.Text = row[1].ToString();
                ckb.BackColor = Color.White;
                pnlTypeDePlat.Controls.Add(ckb);
                if (RecapTypeDeRecette.Contains(ckb.Text) == true)
                {
                    ckb.Checked = true;
                }
                x += 150;
                nbFiltre++;
                ckb.CheckedChanged += new System.EventHandler(TypeDePlat);
            }
        }
        private void FiltreTemps()
        {
            TextBox txtTemp = new TextBox();
            txtTemp.BorderStyle = BorderStyle.None;
            txtTemp.BackColor = Color.FromArgb(217, 217, 217);
            txtTemp.Location = new Point(50, 260);
            txtTemp.Size = new Size(250, 50);

            txtTemp.TextChanged += new System.EventHandler(TempsPlat);
            

            pnlTemps.Controls.Add(txtTemp);
        }
        private void TypeDePlat(object sender, EventArgs e)
        {
            RecapTypeDeRecette.Clear();


            foreach (Control ckbTypedeplat in pnlTypeDePlat.Controls)
            {
               
                CheckBox ckb = (CheckBox)ckbTypedeplat;
                


                if (ckbTypedeplat is CheckBox)
                {


                    if (ckb.Checked == true)
                    {
                        if (RecapTypeDeRecette.Contains(ckbTypedeplat.Text) == false)
                        {
    
                            RecapTypeDeRecette.Add(ckbTypedeplat.Text);
                        



                        }

                    }
                    else if (ckb.Checked == false)
                    {
                        if (RecapTypeDeRecette.Contains(ckbTypedeplat.Text) == true)
                        {
                            RecapTypeDeRecette.Remove(ckbTypedeplat.Text);
                            ckb.Checked = false;
                            

                        }
                    }


                }
                

            }
            

           
        }

        private void TempsPlat(object sender, EventArgs e)
        {
            TextBox txtTemp = (TextBox)sender;
            if(txtTemp.Text != "")
            {
                temps = int.Parse(txtTemp.Text);
            }
            
        }
        private void grpRecap_Enter(object sender, EventArgs e)
        {

        }
        private void PrixChere(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked == true)
            {
                budget = 3;
            }
            else
            {
                budget = 0;
            }
        }

        private void PrixMoyen(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked == true)
            {
                budget = 2;
            }
            else
            {
                budget = 0;
            }
        }

        private void PrixBas(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if(rb.Checked == true)
            {
                budget = 1;
            }
            else
            {
                budget = 0;
            }
        }
        private void PageRecette(object sender, EventArgs e)
        {
           
            freePage();
            TransformIngrediantEnInt();
            TransformeFiltreEnInt();
            creeRequete(RecapTypeDeRecetteEnInt, budget,temps,RecapIngredientsEnInt);
            
            pnlRecette.Controls.Clear();

            Button btnRetour2 = new Button();
            btnRetour2.Click += new System.EventHandler(pageFiltre);
            btnRetour2.BackgroundImage = Image.FromFile("ImageBtnRetour.png");
            btnRetour2.BackgroundImageLayout = ImageLayout.Stretch;
            btnRetour2.FlatAppearance.BorderSize = 0;
            btnRetour2.FlatStyle = FlatStyle.Flat;
            btnRetour2.Size = new Size(100, 80);
            btnRetour2.Location = new Point(20, 850);

            this.Controls.Add(btnRetour2);

            pnlRecette.Location = new Point(0 * COEFFICIENT_TAILLE, 0 * COEFFICIENT_TAILLE);
            pnlRecette.Size = new Size(1920 * COEFFICIENT_TAILLE, 1080 * COEFFICIENT_TAILLE);
            pnlRecette.Name = "Text";
            pnlRecette.BackColor = Color.White;
            pnlRecette.BackgroundImage = Image.FromFile("BackgroundEtape3.png");
            pnlRecette.BackgroundImageLayout = ImageLayout.Zoom;

            Panel pnlAfficheRecette = new Panel();
            pnlAfficheRecette.Controls.Clear();
            pnlAfficheRecette.Location = new Point(200, 300);
            pnlAfficheRecette.Size = new Size(1680, 720);
            pnlAfficheRecette.BackColor = Color.FromArgb(239, 239, 239);
            pnlAfficheRecette.BorderStyle = BorderStyle.FixedSingle;
            pnlAfficheRecette.AutoScroll = true;
            

            this.Controls.Add(pnlRecette);
            pnlRecette.Controls.Add(pnlAfficheRecette);

            
            OleDbCommand OdCommand = new OleDbCommand(requete, cx);
            OleDbDataReader OdDataReader = OdCommand.ExecuteReader();
            int X = 5;
            int Y = 30;
            int nbRecetteTrouvee = 0;
            pnlAfficheRecette.Controls.Clear();
            while (OdDataReader.Read())
            {
                
                string nomRecette = OdDataReader[1].ToString();

                int prixEnInt = Convert.ToInt32(OdDataReader[5]);
                int duree = Convert.ToInt32(OdDataReader[3]);
                string Image = OdDataReader[4].ToString();
               
                int CodeRecette = Convert.ToInt32(OdDataReader[0]);
                string prix;
                if (prixEnInt == 1)
                {
                    prix = "Bon Marché";
                }
                else if (prixEnInt == 2)
                {
                    prix = "Coût Moyen";
                }
                else
                {
                    prix = "Assez Chère";
                }

                SAEFrigoBibliothèqueUtilisateur.UserControlRecette ucrecette = new SAEFrigoBibliothèqueUtilisateur.UserControlRecette(nomRecette, prix, duree, Image, CodeRecette);
                ucrecette.Location = new Point(X, Y);
                ucrecette.Size = new Size(800, 150);
                pnlAfficheRecette.Controls.Add(ucrecette);

                



                Y += 170;
                nbRecetteTrouvee++;


            }

            if (nbRecetteTrouvee <1)
            {
                pnlAfficheRecette.BackgroundImage = Image.FromFile("ImageFrigoVide.png");
                pnlAfficheRecette.BackgroundImageLayout = ImageLayout.Stretch;

            }
            else
            {
                pnlAfficheRecette.BackColor = Color.FromArgb(239, 239, 239);
            }
            OdDataReader.Close();
            


        }



        private void btnSuivantUnToDeux_Click(object sender, EventArgs e)
        {
            pnlChoixIngredient.Controls.Clear();
            
        }
        
        private void pnlChoixIngredient_Paint(object sender, PaintEventArgs e)
        {

        }
        private void TransformeFiltreEnInt()
        {
            RecapTypeDeRecetteEnInt.Clear();

            for (int i = 0; i < RecapTypeDeRecette.Count; i++)
            {
                string filtre1 = "libCategorie ='" + RecapTypeDeRecette[i] + "'";
                DataRow[] res1 = ds.Tables["Catégories"].Select(filtre1);
                DataRow ligne1 = res1[0];
                RecapTypeDeRecetteEnInt.Add(Convert.ToInt32(ligne1["codeCategorie"]));
                
            }
        }

        public void TransformIngrediantEnInt()
        {
            RecapIngredientsEnInt.Clear();

            if(listrecap.Count !=0)
            {
                for (int i = 0; i < listrecap.Count; i++)
            {
                string filtre = "libIngredient ='" + listrecap[i]+"'";
                DataRow[] res = ds.Tables["Ingrédients"].Select(filtre);
                DataRow ligne = res[0];
                RecapIngredientsEnInt.Add(Convert.ToInt32(ligne["codeIngredient"]));
                    
            }
            }
            

           


        }
        public string creeRequete(List<int> typeRecette_, int budget_, int duree_, List<int> listIng)
        {
            //Création d'un booléen pour savoir si on doit mettre un and ou pas dans la construction de la requete
            bool AND = false;

            requete = "";
            requete = @"SELECT * FROM Recettes";
            

            //Si la catégorie a été choisie, on ajoute à la construction de la requete
            if (typeRecette_.Count >0)
            {
                if (typeRecette_.Count >= 1)
                {
                    if (AND)
                    {
                        requete += " AND codeRecette IN (SELECT codeRecette FROM CatégoriesRecette WHERE codeCategorie =" + typeRecette_[0]+")";
                    }
                    else
                    {
                        requete += " WHERE codeRecette IN (SELECT codeRecette FROM CatégoriesRecette WHERE codeCategorie =" + typeRecette_[0]+")";
                    }
                    for (int i = 1; i < typeRecette_.Count; i++)
                    {
                        requete += " OR codeRecette =" + typeRecette_[i];
                    }
                }
                   

                AND = true;
            }

            //Si le budget a été choisi, on ajoute a la construction de la requete
            if (budget_ != -1)
            {
                if (AND)
                {
                    requete += " AND categPrix <=" + budget_;
                }
                else
                {
                    requete += " WHERE categPrix <=" + budget_;
                }
                AND = true;
            }
            if (duree_ != -1)
            {
                if (AND)
                {
                    requete += " AND tempsCuisson <=" + duree_;
                }
                else
                {
                    requete += " WHERE tempsCuisson <=" + duree_;
                }

            }

            //On ajoute ensuite les ingrédients à la requete si la taille de la liste est supérieure à 0
            if (listIng.Count > 0)
            {
                if (listIng.Count >= 1)
                {
                    if (AND)
                    {
                        requete += " AND codeRecette IN (SELECT codeRecette FROM IngrédientsRecette WHERE codeIngredient =" + listIng[0];
                    }
                    else
                    {
                        requete += " WHERE codeRecette IN (SELECT codeRecette FROM IngrédientsRecette WHERE codeIngredient =" + listIng[0];
                    }
                    for (int i = 1; i < listIng.Count; i++)
                    {
                        requete += " OR codeIngredient =" + listIng[i];
                    }
                    requete += ")";
                }
            }

            
            return requete;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pChargement.Width += 6;

            if (pChargement.Width > 800)
            {
                timer1.Stop();
                pChargement.Visible = false;
                pChargement2.Visible = false;
                pnlAccueil.Visible = false;
                generationAccueilIngredients(sender,e);


            }
        }


        
    }
}
