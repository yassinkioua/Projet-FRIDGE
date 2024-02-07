using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace SAE_FRIGO
{
    public class bouton : RadioButton
    {
        public bouton()
        {
            // Load the background image from a file path
            this.BackgroundImage = Image.FromFile(@System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) +"\\radioButtonLightBlue.png"); 
            

            // Set the size mode to stretch to fill the button's bounds
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Appearance = Appearance.Button;
            this.FlatAppearance.CheckedBackColor = Color.Blue;
            //this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Gray;

        }
    }
}
