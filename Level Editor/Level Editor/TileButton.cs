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
		[Description("Test text displayed in the textbox"), Category("Data")]
		public TileType myType { get; set; }


	}
}
