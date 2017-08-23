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
	
	public partial class LevelEditorForm1 : Form
	{
		private void MoveCursor()
		{
			// Set the Current cursor, move the cursor's Position,
			// and set its clipping rectangle to the form. 

			Cursor = new Cursor(Cursor.Current.Handle);
			Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
			Cursor.Clip = new Rectangle(Location, Size);
		}

		//Bitmap[] img = new Bitmap[5];

		//List<PictureBox> tileTexture = new List<PictureBox>();
		

		

		TileType[,] gridArray = new TileType[15, 10]
		{
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
			{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE} ,
		};





		// Make it so that the [0, 0] draws (0,0, 64,64) then [1,0] draws at (65,

		//https://stackoverflow.com/questions/3884860/drawing-image-to-bigger-bitmap
		int mapLength = 960;
		int mapHeight = 640;

		public void MouseLeftClick(object sender, MouseEventArgs e)
		{
			//Cursor.Position.X
		}


		public void paintMe(object sender, PaintEventArgs e)
		{
			System.Drawing.Graphics g = (sender as Panel).CreateGraphics();
			System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Black, 2F);

			// Renders the images into each 64x64 square
			for (int i = 0; i < gridArray.GetLength(0); i++)
			{
				for (int j = 0; j < gridArray.GetLength(1); j++)
				{
					//g.DrawImage(img[(int)gridArray[i,j]], (64 * i), (64 * j), 64, 64);
					g.DrawImage(Palette.palette[gridArray[i, j]], (64 * i), (64 * j), 64, 64);
				}
			}

			//Draws the vertical of the grid
			for (int i = 0; i < gridArray.GetLength(0); ++i)
			{ 
					g.DrawLine(pen1, (64 * i), 0, (64 * i), mapHeight);
			}

			//Draws the horizontal of the grid
			for (int i = 0; i < gridArray.GetLength(0); ++i)
			{
				g.DrawLine(pen1, 0, (64 * i), mapLength, (64 * i));
			}
			
		}

		public void createGrid()
		{
			for (int i = 0; i < gridArray.GetLength(0); i++)
			{
				for (int j = 0; j < gridArray.GetLength(0); j++)
				{
					Graphics g = CreateGraphics();

					g.DrawImage(Properties.Resources.tex_Bloons_terrain_long_grass, 0, 0, 64, 64);
				}
			}
		}

		public LevelEditorForm1()
        {
			
			Palette.CreatePalette();
			InitializeComponent();
			


		}


		private void LevelEditorForm1_Load(object sender, EventArgs e)
        {
			
			Bitmap map = new Bitmap(mapHeight, mapLength);
			//Example of one image
			//PictureBox texGrass = new PictureBox();
			//texGrass.Size = new Size(64, 64);
			//texGrass.BackgroundImage = Properties.Resources.tex_Bloons_terrain_grass;
			//PictureBox texLongGrass = new PictureBox();
			//texLongGrass.Size = new Size(64, 64);
			//texLongGrass.BackgroundImage = Properties.Resources.tex_Bloons_terrain_long_grass;
			//End example

			//texGrass.Location = new Point(50, 50);

			//Controls.Add(texGrass);
			//palette.Add(TileType.ENUM_NONE, Properties.Resources.tex_none_grey);
			//palette.Add(TileType.ENUM_GRASS, Properties.Resources.tex_Bloons_terrain_grass);
			//palette.Add(TileType.ENUM_LONG_GRASS, Properties.Resources.tex_Bloons_terrain_long_grass);
			
			





			//tileTexture.Add(texture);
		}

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

			open.InitialDirectory = @"C:";
			open.Filter = "Text files (*.txt)|*.txt|Image files (*.png *.bmp *.jpg)|*.jpg; *.bmp; *.png";


			//Graphics g = CreateGraphics();

			//g.DrawImage(Properties.Resources.tex_Bloons_terrain_long_grass, 0, 0, 64, 64);

			if (open.ShowDialog() == DialogResult.OK)
            {
				//Bitmap image = (Bitmap)Image.FromFile(open.FileName);
				//DemoPictureBox.Image = (Bitmap)Image.FromFile(open.FileName);

				string text = System.IO.File.ReadAllText(open.FileName);
			}
        }

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			if(save.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(save.FileName, "Hello World");
			}
		}

		private void pictureBoxTexture02_Click(object sender, EventArgs e)
		{
			//(sender as TileButton).myType;
		}

		private void pictureBoxTexture01_Click(object sender, EventArgs e)
		{

		}

		private void pictureBoxTexture03_Click(object sender, EventArgs e)
		{

		}

		private void tileButton1_Click(object sender, EventArgs e)
		{

		}
	}
}

//https://www.youtube.com/watch?v=lk0GsyxCj-U&index=1&list=PL0A864073DA96A7DA - this is the tutorial in xna
//Bitmap Blitting
// Look at picture that matt drew.
// Create an array of enums. The enums then get assigned to textures. 
//[1, 1, 2
// 0, 2, 0
// 1, 1, 2]
// The enums will be allocated to different textures which allows the array to be exported and re-imported to retain the same value.
// This means that the load function will be able to work.
// Utilize bitmap blitting to allocate where inside a picture box the textures will be placed. https://stackoverflow.com/questions/837423/render-a-section-of-an-image-to-a-bitmap-c-sharp-winforms , https://stackoverflow.com/questions/13103682/draw-a-bitmap-image-on-the-screen
// The diagram matt drew shows how this will be implemented.
// The .NET container classes ppt explains the syntax for arrays. It's inside c# basics 
// To allocate a texture to an enum, use a dictionary. The dictionary is in the same powerpoint as arrays.
// In the example it has a name then a number, for me, the name will be the enum value and the number will be the texture.