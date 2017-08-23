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
		static public void CreatePalette()
		{
			//Bitmap img = new Bitmap(Properties.Resources.tex_none_grey);
			palette.Add(TileType.ENUM_NONE, Properties.Resources.tex_none_grey);

			//img = new Bitmap(Properties.Resources.tex_Bloons_terrain_grass);
			palette.Add(TileType.ENUM_GRASS, Properties.Resources.tex_Bloons_terrain_grass);

			//img = new Bitmap(Properties.Resources.tex_Bloons_terrain_long_grass);
			palette.Add(TileType.ENUM_LONG_GRASS, Properties.Resources.tex_Bloons_terrain_long_grass);

			//palette.Add(TileType.selectedTexture, Properties.Resources.tex_Bloons_terrain_long_grass);

			
		}

		static public Dictionary<TileType, Bitmap> palette = new Dictionary<TileType, Bitmap>();

		static public TileType selected;
	}
}
