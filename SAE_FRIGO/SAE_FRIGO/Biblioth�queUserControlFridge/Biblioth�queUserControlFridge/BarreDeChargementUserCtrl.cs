using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliothèqueUserControlFridge
{
    public partial class BarreDeChargementUserCtrl : UserControl
    {
        public BarreDeChargementUserCtrl()
        {
            InitializeComponent();
        }

        private void BarreDeChargementUserCtrl_Load(object sender, EventArgs e)
        {

            pnl1.BackColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

