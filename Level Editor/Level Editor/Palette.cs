using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

//--------------------------------------------------------------------------------------
// Namespace of project.
//--------------------------------------------------------------------------------------
namespace Level_Editor
{
    //--------------------------------------------------------------------------------------
    // Palette class is a class that holds the dictionary and selected tile.
    //--------------------------------------------------------------------------------------
    class Palette
	{
        //--------------------------------------------------------------------------------------
        // This creates the dictionary for the palette that pairs the images with the int
        // for the gridArray.
        //--------------------------------------------------------------------------------------
        static public Dictionary<int, Bitmap> palette = new Dictionary<int, Bitmap>();

        //--------------------------------------------------------------------------------------
        // A static public integer that stores the tile that has been selected to be used.
        //--------------------------------------------------------------------------------------
        static public int selected;
	}
}
