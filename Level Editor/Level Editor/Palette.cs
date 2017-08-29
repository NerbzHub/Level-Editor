using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level_Editor
{
	enum TileType
	{
		ENUM_NONE,
		ENUM_GRASS,
		ENUM_LONG_GRASS
	}

	enum TileTypeSwitcher
	{
		
	}
	class Palette
	{
		//static public void CreatePalette()
		//{
		//	CreateDictionary(Properties.Resources.tex_none_grey);
		//	CreateDictionary(Properties.Resources.tex_Bloons_terrain_grass);
		//	CreateDictionary(Properties.Resources.tex_Bloons_terrain_long_grass);
		//}
			//Bitmap img = new Bitmap(Properties.Resources.tex_none_grey);
			//palette.Add(0, Properties.Resources.tex_none_grey);

			//img = new Bitmap(Properties.Resources.tex_Bloons_terrain_grass);
			//palette.Add(1, Properties.Resources.tex_Bloons_terrain_grass);

			//img = new Bitmap(Properties.Resources.tex_Bloons_terrain_long_grass);
			//palette.Add(2, Properties.Resources.tex_Bloons_terrain_long_grass);

			//palette.Add(TileType.selectedTexture, Properties.Resources.tex_Bloons_terrain_long_grass);
		

		static public Dictionary<int, Bitmap> palette = new Dictionary<int, Bitmap>();

		static public int selected;

		//List<TileButton> tileList;

		//static public void CreateDictionary(Bitmap bitmap)
		//{
		//	//Figure out how to add a new enum to tiletype. The problem at the moment is the new tiletype is just set to enum none. I need to create a new enum & add it in the palette
		//	int newDictionary = palette.Count;
		//	palette.Add(newDictionary, bitmap);

		//	TileButton tile = new TileButton();
		//	//add to list
		//	//tile.Location = new location(x, y);
		//	//tile.Parent = tabPanel;
		//	tile.myType = newDictionary;
		//}
	}
}
