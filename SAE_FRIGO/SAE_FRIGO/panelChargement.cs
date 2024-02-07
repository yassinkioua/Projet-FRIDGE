using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAE_FRIGO
{
    public class PanelChargement : Panel
    {
        public PanelChargement()
        {
            // Load the background image from a file path
            this.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\radioButtonLightBlue.png");


            // Set the size mode to stretch to fill the button's bounds
            this.BackgroundImageLayout = ImageLayout.Zoom;
            

        }
    }
}
