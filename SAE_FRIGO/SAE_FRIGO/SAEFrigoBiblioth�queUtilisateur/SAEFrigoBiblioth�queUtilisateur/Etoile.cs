using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAEFrigoBibliothèqueUtilisateur
{
    public partial class Etoile : UserControl
    {
        public Etoile()
        {
            InitializeComponent();
        }

        private void Etoile_Load(object sender, EventArgs e)
        {
            Button btnEtoile1 = new Button();
            btnEtoile1.Size = new Size(100, 100);

            Button btnEtoile2 = new Button();
            btnEtoile2.Size = new Size(100, 100);

            Button btnEtoile3 = new Button();
            btnEtoile3.Size = new Size(100, 100);

            Button btnEtoile4 = new Button();
            btnEtoile4.Size = new Size(100, 100);

            Button btnEtoile5 = new Button();
            btnEtoile5.Size = new Size(100, 100);
        }
    }
}
