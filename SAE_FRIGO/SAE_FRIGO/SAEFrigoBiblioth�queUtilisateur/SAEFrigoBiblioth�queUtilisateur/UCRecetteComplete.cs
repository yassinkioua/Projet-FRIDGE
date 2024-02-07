using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAEFrigoBibliothèqueUtilisateur
{
    public partial class UCRecetteComplete : UserControl
    {
        OleDbConnection cx;
        
        public UCRecetteComplete(int CodeRecette)
        {
            InitializeComponent();
            this.Font = new Font("Aileron heavy", 17);

            string chaine = @"Provider=Microsoft.jet.OLEDB.4.0; Data Source=" + System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\baseFrigo.mdb";
            cx = new OleDbConnection(chaine);
            
           
        }

        

        

        private void UCRecetteComplete_Load(object sender, EventArgs e)
        {
            

            this.Size = new Size(1920 , 1080);
            
            try
            {
                cx.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
