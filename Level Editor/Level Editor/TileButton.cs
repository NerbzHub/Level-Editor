using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//--------------------------------------------------------------------------------------
// Namespace of the project.
//--------------------------------------------------------------------------------------
namespace Level_Editor
{
    //--------------------------------------------------------------------------------------
    // A new tilebutton class that derives from the picturebox class.
    // The tilebutton is created so that I have a custom picturebox that has more functions 
    // than a regular picturebox.
    //--------------------------------------------------------------------------------------
    class TileButton : System.Windows.Forms.PictureBox
	{
        //--------------------------------------------------------------------------------------
        // A public int to hold a value.
        //--------------------------------------------------------------------------------------
        public int Value;

        //--------------------------------------------------------------------------------------
        // The description of the tileButton.
        //--------------------------------------------------------------------------------------
        [Description("Test text displayed in the textbox"), Category("Data")]

        //--------------------------------------------------------------------------------------
        // Creating a new int that holds myType.
        //--------------------------------------------------------------------------------------
        public int myType
		{
			get
			{
				return Value;
			}
			set
			{
				if(!DesignMode)
					Image = Palette.palette[value];
				Value = value;
			}
		}
	}
}
