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

//--------------------------------------------------------------------------------------
// Namespace of the project.
//--------------------------------------------------------------------------------------
namespace Level_Editor
{
    //--------------------------------------------------------------------------------------
    // The Class for the WinForm
    //--------------------------------------------------------------------------------------
    public partial class LevelEditorForm1 : Form
	{
        //--------------------------------------------------------------------------------------
        // Creating a list of UndoRedo that will keep track of the user's actions to Undo
        //--------------------------------------------------------------------------------------
        List<UndoRedo> undoLog = new List<UndoRedo>();

        //--------------------------------------------------------------------------------------
        // Creating a list of UndoRedo that will keep track of the user's undo's to redo.
        //--------------------------------------------------------------------------------------
        List<UndoRedo> redoLog = new List<UndoRedo>();

        //--------------------------------------------------------------------------------------
        // Creating a list of strings to stores the file path of imported images.
        //--------------------------------------------------------------------------------------
        List<string> imageLog = new List<string>();

        //--------------------------------------------------------------------------------------
        // This function stopped Refresh flickering the panel.
        //--------------------------------------------------------------------------------------
        protected override CreateParams CreateParams
		{
			get
			{
				CreateParams handleParam = base.CreateParams;
				handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
				return handleParam;
			}
		}

        //--------------------------------------------------------------------------------------
        // A function that creates everything needed to calculate the cursor's position.
        //--------------------------------------------------------------------------------------
        private void MoveCursor()
		{
			// Creates a new Cursor handle
			Cursor = new Cursor(Cursor.Current.Handle);
            // Allocates the position of the cursor to be the mouse's position
			Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
            // This clipa the cursors location to be relative to the application
			Cursor.Clip = new Rectangle(Location, Size);
		}

        //--------------------------------------------------------------------------------------
        // Creating the Grid. The grid is just a 2 dimensional array.
        //--------------------------------------------------------------------------------------
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

        //--------------------------------------------------------------------------------------
        // Creating the dimensions of the Map Length and Height.
        //--------------------------------------------------------------------------------------
        //960
        int mapLength = 960;
		//640
		int mapHeight = 640;

        //--------------------------------------------------------------------------------------
        // PaintMe Function draws the grid.
        //--------------------------------------------------------------------------------------
        public void paintMe(object sender, PaintEventArgs e)
		{

            //--------------------------------------------------------------------------------------
            // Creating a new graphics instance
            //--------------------------------------------------------------------------------------
            System.Drawing.Graphics g = (sender as Panel).CreateGraphics();

            //--------------------------------------------------------------------------------------
            // Creating a new pen instance
            //--------------------------------------------------------------------------------------
            System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Black, 2F);

            //--------------------------------------------------------------------------------------
            // Renders the images into each 64x64 square via a nested for loop
            //--------------------------------------------------------------------------------------
            for (int i = 0; i < gridArray.GetLength(0); i++)
			{
				for (int j = 0; j < gridArray.GetLength(1); j++)
                {
					g.DrawImage(Palette.palette[gridArray[i, j]], (64 * i), (64 * j), 64, 64);
				}
			}

            //--------------------------------------------------------------------------------------
            //Draws the vertical of the grid
            //--------------------------------------------------------------------------------------
            for (int i = 0; i < gridArray.GetLength(0); ++i)
			{ 
					g.DrawLine(pen1, (64 * i), 0, (64 * i), mapHeight);
			}

            //--------------------------------------------------------------------------------------
            //Draws the horizontal of the grid
            //--------------------------------------------------------------------------------------
            for (int i = 0; i < gridArray.GetLength(0); ++i)
			{
				g.DrawLine(pen1, 0, (64 * i), mapLength, (64 * i));
			}
			
		}

        //--------------------------------------------------------------------------------------
        // Creating the palette based off the initial "Bloons TD Texture Pack" that is the default
        //--------------------------------------------------------------------------------------
        public void CreatePalette()
		{
			CreateDictionary(Properties.Resources.tex_none_grey);
			CreateDictionary(Properties.Resources.tex_Bloons_terrain_grass);
			CreateDictionary(Properties.Resources.tex_Bloons_terrain_long_grass);
		}

        //--------------------------------------------------------------------------------------
        // Creating a list of TileButtons for the imported textures to create a tilebutton.
        //--------------------------------------------------------------------------------------
        List<TileButton> tileList = new List<TileButton>();

        //--------------------------------------------------------------------------------------
        // Creates a new addition to the dictionary.
        //
        // Param:
        //		bitmap: This bitmap is the image paired in the dictionary. 
        //--------------------------------------------------------------------------------------
        public void CreateDictionary(Bitmap bitmap)
		{
            //--------------------------------------------------------------------------------------
            // An int that keeps count of the palette count.
            //--------------------------------------------------------------------------------------
            int newDictionary = Palette.palette.Count;
            //--------------------------------------------------------------------------------------
            // This adds the new texture to the palette.
            //--------------------------------------------------------------------------------------
            Palette.palette.Add(newDictionary, bitmap);
            //--------------------------------------------------------------------------------------
            // 
            //--------------------------------------------------------------------------------------
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
                string[] palettePath = lines[0].Split(',');

                
                for (int i = 0; i < palettePath.Length; i++)
                {

                    if (palettePath[i] == "")
                        continue;
                    
                    //From here I need to get the values back into the palette
                    //Unless I can export the palette too. 
                    Bitmap image = (Bitmap)Image.FromFile(palettePath[i]);
                    imageLog.Add(palettePath[i]);
                    CreateDictionary(image);

                }

				int lineNumber = 1;
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

            Refresh();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog save = new SaveFileDialog();
			save.Filter = "text files |*.txt";
			if(save.ShowDialog() == DialogResult.OK)
			{
				string text_line = "";

                //Write line 0 
                //Write it as location comma location comma
                //Read it in as split strings. From there it'd load in each one.
                // Look at the load for loop with the lines[linenumber] and the line number is 0. This means it will only go through the written line.

                //text_line = 



                for (int i = 0; i < imageLog.Count; i++)
                {

                    text_line += imageLog[i].ToString();
                    text_line += ",";

                    //string[] parts = text_line.Split(',');
                }

                for (int i = 0; i < gridArray.GetLength(1); i++)
				{
					for (int j = 0; j < gridArray.GetLength(0); j++)
					{
                        text_line += "\n";
						text_line += gridArray[j, i].ToString();
						
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

        private void SaveToTxt()
        {
            //Gets the application's path in a string
            //Path.GetDirectoryName(Application.ExecutablePath).Replace(@"bin\debug\", string.Empty);
            
            string text_line = "";

            for (int i = 0; i < gridArray.GetLength(1); i++)
            {
                for (int j = 0; j < gridArray.GetLength(0); j++)
                {
                    text_line += gridArray[j, i].ToString();
                    text_line += "\n";
                }
            }

            //Trying to gain access to denied acces files in the project directory.

            File.SetAttributes(Path.GetDirectoryName(Application.ExecutablePath), FileAttributes.Normal);
            File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath), text_line);

            //Make sure that the temp files get cleaned up after the application is closed.
        }

		public void GridPanel_Click(object sender, EventArgs e)
		{
            // SaveToTxt();
            redoLog.Clear();
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

            UndoRedo undoRedo = new UndoRedo();

            undoRedo.tempX = tileX;
            undoRedo.tempY = tileY;
            undoRedo.PreviousTile = gridArray[tileX, tileY];
            undoRedo.NextTile = Palette.selected;

            undoLog.Add(undoRedo);
            
    

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

                imageLog.Add(open.FileName);
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

            imageLog.Add(strFiles);

            Bitmap image = (Bitmap)Image.FromFile(strFiles);

            CreateDictionary(image);
            //foreach (string file in files)
            //MessageBox.Show(file);
            Invalidate();
            Refresh();
                  
        }

        public void Undo()
        {
            //Export the old one to tempRedo.txt


            //load in the tempUndo.txt

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            { 

            int index = undoLog.Count - 1;

                if (index < 0)
                    return false;
                gridArray[undoLog[index].tempX, undoLog[index].tempY] = undoLog[index].PreviousTile;

                //Remove one from list

                redoLog.Add(undoLog[index]);
                undoLog.RemoveAt(index);


                Refresh();
                return true;
            }

            if (keyData == (Keys.Control | Keys.Y))
            {
                int index = redoLog.Count - 1;

                if (index < 0)
                    return false;

                gridArray[redoLog[index].tempX, redoLog[index].tempY] = redoLog[index].NextTile;


                undoLog.Add(redoLog[index]);
                redoLog.RemoveAt(index);

                Refresh();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public class UndoRedo
    {
        //I could create a new dictionary that will hold the point and the image that was selected at the time. 
        //This would mean that I can just call from the dictionary and it will place it in the normal dictionary.

        //There is a way that I might be able to store it in the same dictionary. The issue with this would be if it creates another one in the list, it might stuff up the
        //save file because it might have the undo numbers instead of the normal ones which is bad.
        
        //There is probably also a way to just take the last one that got placed from the list. This could just be stored in an int.

        //Create a log that contains all of the points and images that have been used. 


        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //Create a temp.txt that holds the last drawn array and when undo is pressed, revert it back to that. When undo is pressed, it also changes the temp to the array, pre-undo.
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------



            //Make a list of lists


        //These values are to temporarily hold the point incase the user decides to undo. It will hold the most recent point click
        public int tempX = 0; //tempX is the pointX created by GridPanel_Click function
        public int tempY = 0; //tempY is the pointY created by GridPanel_Click function
        public int PreviousTile = 0;
        public int NextTile = 0;


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