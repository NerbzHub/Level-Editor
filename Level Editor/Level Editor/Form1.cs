using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Level_Editor
{
	
	public partial class LevelEditorForm1 : Form
	{
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams handleParam = base.CreateParams;
				handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
				return handleParam;
			}
		}

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




		//TileType[,] gridArray = new TileType[15, 10]
		//{
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE},
		//	{TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE, TileType.ENUM_NONE} ,
		//};

		int[,] gridArray = new int[15, 10]
	{
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0}
	};



		// Make it so that the [0, 0] draws (0,0, 64,64) then [1,0] draws at (65,

		//https://stackoverflow.com/questions/3884860/drawing-image-to-bigger-bitmap
		//960
		int mapLength = 960;
		//640
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

		//public void createGrid()
		//{
		//	for (int i = 0; i < gridArray.GetLength(0); i++)
		//	{
		//		for (int j = 0; j < gridArray.GetLength(0); j++)
		//		{
		//			Graphics g = CreateGraphics();

		//			g.DrawImage(Properties.Resources.tex_Bloons_terrain_long_grass, 0, 0, 64, 64);
		//		}
		//	}
		//}
		public void CreatePalette()
		{
			CreateDictionary(Properties.Resources.tex_none_grey);
			CreateDictionary(Properties.Resources.tex_Bloons_terrain_grass);
			CreateDictionary(Properties.Resources.tex_Bloons_terrain_long_grass);
		}

		List<TileButton> tileList = new List<TileButton>();

		public void CreateDictionary(Bitmap bitmap)
		{
			//Figure out how to add a new enum to tiletype. The problem at the moment is the new tiletype is just set to enum none. I need to create a new enum & add it in the palette

			int newDictionary = Palette.palette.Count;
			Palette.palette.Add(newDictionary, bitmap);

			TileButton tile = new TileButton();
			tileList.Add(tile);//add to list

			// What do I use for location?

			tile.Parent = tabTerrain;
			tile.BackColor = Color.Black;
			tile.myType = newDictionary;

			int x = ((tileList.Count - 1) % 3) * 66;

			int y = ((tileList.Count - 1) / 3) * 66;

			tile.Location = new Point(x, y);
			tile.Width = 64;
			tile.Height = 64;
			tile.BringToFront();
			tile.Click += tileButton1_Click;
			tile.SizeMode = PictureBoxSizeMode.StretchImage;
			//tile.Show();
		}

		public LevelEditorForm1()
        {
			
			InitializeComponent();
			CreatePalette();



			//typeof(Panel).InvokeMember("DoubleBuffered",
			//	BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
			//	null, GridPanel, new object[] { true });
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
				//This takes it in as a 1D string list. How do I change it to a 2D TileType list.
				//List<string> allLinesText = File.ReadAllLines(text).ToList();


				var lines = File.ReadAllLines(open.FileName);

				//for (int i = 0; i < lines.Length; i++)
				//{
				//	var fields = lines[i];
				//}
				int lineNumber = 0;
				for (int i = 0; i < gridArray.GetLength(1); i++)
				{
					for (int j = 0; j < gridArray.GetLength(0); j++)
					{
						//gridArray[j, i] = (TileType)Enum.Parse(typeof(TileType), lines[lineNumber]);
						gridArray[j, i] = Convert.ToInt32(lines[lineNumber]);
						++lineNumber;
					}
				}


			}
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "text files |*.txt";
			if(save.ShowDialog() == DialogResult.OK)
			{
				string text_line = "";

				for (int i = 0; i < gridArray.GetLength(1); i++)
				{
					for (int j = 0; j < gridArray.GetLength(0); j++)
					{
						text_line += gridArray[j, i].ToString();
						text_line += "\n";
					}
				}

				File.WriteAllText(save.FileName, text_line);
			}
			//this is a potentially good tutorial, this function is unfinished though, ask richard.
			// http://www.homeandlearn.co.uk/csharp/csharp_s11p3.html
			//string file_name = "C:\\Users\\s171735\\Downloads\\test1.txt";
			//string text_line = "";
			//System.IO.StreamWriter objWriter;
			
			//objWriter = new System.IO.StreamWriter(file_name, true);

			
			//objWriter.Write(textBox1.Text);
			
			//objWriter.Close();

			MessageBox.Show("File is written");


			
		}

		private void tileButton1_MouseDown(object sender,
		System.Windows.Forms.MouseEventArgs e)
		{
			//tileButton1.DoDragDrop(tileButton1.Value, DragDropEffects.Copy |
			//   DragDropEffects.Move);
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
			//gridArray[0, 0] = TileType.ENUM_GRASS;
			//TileType.selectedTexture = Proper;
			((TileButton)sender).Select();
			Palette.selected = ((TileButton)sender).myType;
			Invalidate();
			Refresh();
		}

		private void GridPanel_Click(object sender, EventArgs e)
		{
			//TileType selectedTexture;
			Point point = GridPanel.PointToClient(Cursor.Position);
			//string mouseString;
			//mouseString = Cursor.Position.X;
			//float fTileX = float.Parse(mouseString);
			int tileX = point.X;

			//mouseString = Cursor.Position.Y.ToString();
			//float fTileY = float.Parse(mouseString);
			int tileY = point.Y;

			tileX = tileX / 64;
			tileY = tileY / 64;

			gridArray[tileX, tileY] = Palette.selected;
			GridPanel.Invalidate();
			GridPanel.Refresh();
		}

		private void tileButton2_Click(object sender, EventArgs e)
		{
			//this.FormBorderStyle
			Palette.selected = 1;
			Invalidate();
			Refresh();
		}

		private void tileButton3_Click(object sender, EventArgs e)
		{
			Palette.selected = 2;
			Invalidate();
			Refresh();
		}

		private void buttonImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();

			open.InitialDirectory = @"C:";
			open.Filter = "Image files (*.png *.bmp *.jpg)|*.jpg; *.bmp; *.png";


			//Graphics g = CreateGraphics();

			//g.DrawImage(Properties.Resources.tex_Bloons_terrain_long_grass, 0, 0, 64, 64);

			if (open.ShowDialog() == DialogResult.OK)
			{
				Bitmap image = (Bitmap)Image.FromFile(open.FileName);
				//DemoPictureBox.Image = (Bitmap)Image.FromFile(open.FileName);

				CreateDictionary(image);
				// I need to add the image to an empty picturebox.
				// Then I need to add a new enum,
				// Then add a new dictionary add to add the new image to the new enum.

				
				//string text = System.IO.File.ReadAllText(open.FileName);

			}
		}

        private void GridPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void GridPanel_DragDrop(object sender, DragEventArgs e)
        {
            //Save
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            string strFiles = String.Join(" ", files);

            Bitmap image = (Bitmap)Image.FromFile(strFiles);

            CreateDictionary(image);
            //foreach (string file in files)
                  //MessageBox.Show(file);
                  
        }
    }
}

//Make not walkable bool that will show a little red x ontop of tiles.

//marking collision

//Undo and redo 

    //create a struct / class
    // take in the values of the last tile and when they click on a new one it adds the most recent tile value to a list. Undo changes it back then redo changes it back.


//save the file path into a file so that it can find what the picture was.








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