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

namespace Level_Editor
{
	class TileButton : System.Windows.Forms.PictureBox
	{
		public TileType Value;

		[Description("Test text displayed in the textbox"), Category("Data")]
		public TileType myType
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

		private void OnClick(object sender, MouseEventArgs e)
		{
			
		}


		//Assign the img in the img[] array to the enum so that it displays the image.

	}
}
