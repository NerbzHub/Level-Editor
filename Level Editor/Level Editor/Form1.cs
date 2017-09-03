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
            // Creates a new tilebutton and adds the new tile to the list.
            //--------------------------------------------------------------------------------------
            TileButton tile = new TileButton();
			tileList.Add(tile);//add to list


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

        //--------------------------------------------------------------------------------------
        // This is the function that is what happens at startup of the application.
        //--------------------------------------------------------------------------------------
        public LevelEditorForm1()
        {
            //--------------------------------------------------------------------------------------
            // Initializes the form.
            //--------------------------------------------------------------------------------------
            InitializeComponent();
            //--------------------------------------------------------------------------------------
            // Creates the Palette
            //--------------------------------------------------------------------------------------
            CreatePalette();
		}

        //--------------------------------------------------------------------------------------
        // This function executes when the form is loaded.
        //--------------------------------------------------------------------------------------
        private void LevelEditorForm1_Load(object sender, EventArgs e)
        {
			Bitmap map = new Bitmap(mapHeight, mapLength);
		}

        private void fileToolStripMenuItem_Click(object sender, EventArgs e){}

        //--------------------------------------------------------------------------------------
        // This function executes when the Load button of the drop menu.
        //--------------------------------------------------------------------------------------
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //--------------------------------------------------------------------------------------
            // Creates a new instance of the file browser.
            //--------------------------------------------------------------------------------------
            OpenFileDialog open = new OpenFileDialog();

            //--------------------------------------------------------------------------------------
            // Sets the file browser to default open to the C drive.
            //--------------------------------------------------------------------------------------
            open.InitialDirectory = @"C:";
            //--------------------------------------------------------------------------------------
            // Sets the files that the user can open.
            //--------------------------------------------------------------------------------------
            open.Filter = "Text files (*.txt)|*.txt|Image files (*.png *.bmp *.jpg)|*.jpg; *.bmp; *.png";

            //--------------------------------------------------------------------------------------
            // If the user has pressed OK on the file browser then do this.
            //--------------------------------------------------------------------------------------
            if (open.ShowDialog() == DialogResult.OK)
            {
                //--------------------------------------------------------------------------------------
                // Takes the selected file's name and puts it into a string.
                //--------------------------------------------------------------------------------------
                string text = System.IO.File.ReadAllText(open.FileName);

                //--------------------------------------------------------------------------------------
                // A variable to store the text from the file.
                //--------------------------------------------------------------------------------------
                var lines = File.ReadAllLines(open.FileName);

                //--------------------------------------------------------------------------------------
                // A string array to hold each string that has been seperated by commas.
                //--------------------------------------------------------------------------------------
                string[] palettePath = lines[0].Split(',');

                //--------------------------------------------------------------------------------------
                // For loop to iterate through each filename from the saved path and place them into the palette array.
                //--------------------------------------------------------------------------------------
                for (int i = 0; i < palettePath.Length; i++)
                {
                    //--------------------------------------------------------------------------------------
                    // If the palette path string is empty, continue
                    //--------------------------------------------------------------------------------------
                    if (palettePath[i] == "")
                        continue;

                    //--------------------------------------------------------------------------------------
                    // This takes the filename and finds the actual file.
                    //--------------------------------------------------------------------------------------
                    Bitmap image = (Bitmap)Image.FromFile(palettePath[i]);
                    //--------------------------------------------------------------------------------------
                    // Adds the image found via the filename to the palette array.
                    //--------------------------------------------------------------------------------------
                    imageLog.Add(palettePath[i]);
                    //--------------------------------------------------------------------------------------
                    // This adds the image to a new dictionary input.
                    //--------------------------------------------------------------------------------------
                    CreateDictionary(image);

                }

                //--------------------------------------------------------------------------------------
                // Allocating the line number to 1 allows the reading of the file to skip the first line
                // which contains the image directories.
                //--------------------------------------------------------------------------------------
                int lineNumber = 1;

                //--------------------------------------------------------------------------------------
                // A for loops that goes through the save file and allocates the images of the grid 
                // accordingly
                //--------------------------------------------------------------------------------------
                for (int i = 0; i < gridArray.GetLength(1); i++)
				{
                    //--------------------------------------------------------------------------------------
                    // Nested for loop
                    //--------------------------------------------------------------------------------------
                    for (int j = 0; j < gridArray.GetLength(0); j++)
					{
                        //--------------------------------------------------------------------------------------
                        // Converts the numbers of the save file to an int32 so that it is readable in the array
                        //--------------------------------------------------------------------------------------
                        gridArray[j, i] = Convert.ToInt32(lines[lineNumber]);
                        //--------------------------------------------------------------------------------------
                        // goes to next line to read the next int.
                        //--------------------------------------------------------------------------------------
                        ++lineNumber;
					}
				}

                


            }
            //--------------------------------------------------------------------------------------
            // Once it has finished loading, refresh the panel so that it displays the most recent 
            // grid.
            //--------------------------------------------------------------------------------------
            Refresh();
		}

        //--------------------------------------------------------------------------------------
        // This code executes when the Save button is clicked from the drop menu.
        //--------------------------------------------------------------------------------------
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
            //--------------------------------------------------------------------------------------
            // Creates a new instance of the file browser.
            //--------------------------------------------------------------------------------------
            SaveFileDialog save = new SaveFileDialog();

            //--------------------------------------------------------------------------------------
            // Limits the user to only be able to save to a txt file.
            //--------------------------------------------------------------------------------------
            save.Filter = "text files |*.txt";

            //--------------------------------------------------------------------------------------
            // If the user has pressed OK on the file browser, execute this code.
            //--------------------------------------------------------------------------------------
            if (save.ShowDialog() == DialogResult.OK)
			{
                //--------------------------------------------------------------------------------------
                // Creates a new string set to nothing.
                //--------------------------------------------------------------------------------------
                string text_line = "";

                //--------------------------------------------------------------------------------------
                // Saves the image log as a string with a comma between each value in the array.
                //--------------------------------------------------------------------------------------
                for (int i = 0; i < imageLog.Count; i++)
                {
                    //--------------------------------------------------------------------------------------
                    // Changing the array to a string.
                    //--------------------------------------------------------------------------------------
                    text_line += imageLog[i].ToString();

                    //--------------------------------------------------------------------------------------
                    // Place a comma between each value of the array.
                    //--------------------------------------------------------------------------------------
                    text_line += ",";
                }

                //--------------------------------------------------------------------------------------
                // Saves the grid array on a single line every value.
                //--------------------------------------------------------------------------------------
                for (int i = 0; i < gridArray.GetLength(1); i++)
				{
                    //--------------------------------------------------------------------------------------
                    // Nested for loop.
                    //--------------------------------------------------------------------------------------
                    for (int j = 0; j < gridArray.GetLength(0); j++)
					{
                        //--------------------------------------------------------------------------------------
                        // Creates a new line.
                        //--------------------------------------------------------------------------------------
                        text_line += "\n";

                        //--------------------------------------------------------------------------------------
                        // Turns the ints in the array to strings so that they can be saves in a .txt.
                        //--------------------------------------------------------------------------------------
                        text_line += gridArray[j, i].ToString();
					}
				}
                //--------------------------------------------------------------------------------------
                // This saves the data to a text file.
                //--------------------------------------------------------------------------------------
                File.WriteAllText(save.FileName, text_line);
			}
            //--------------------------------------------------------------------------------------
            // A message box to confirm that the file has successfully saved.
            //--------------------------------------------------------------------------------------
            MessageBox.Show("File Saved Successfully");
		}

        //--------------------------------------------------------------------------------------
        // This function executes when tileButton1 is clicked.
        //--------------------------------------------------------------------------------------
        private void tileButton1_Click(object sender, EventArgs e)
		{
            //--------------------------------------------------------------------------------------
            // Checks whether the tilebutton has been selected.
            //--------------------------------------------------------------------------------------
            ((TileButton)sender).Select();

            //--------------------------------------------------------------------------------------
            // Once it has been selected, add the selected.
            //--------------------------------------------------------------------------------------
            Palette.selected = ((TileButton)sender).myType;

            //--------------------------------------------------------------------------------------
            // This function helps refresh work a bit smoother.
            //--------------------------------------------------------------------------------------
            Invalidate();

            //--------------------------------------------------------------------------------------
            // Refresh update/Refreshes the panel to be the most recent version of the grid array
            // so that if any changes occur, it will display them straight away.
            //--------------------------------------------------------------------------------------
            Refresh();
		}

        //--------------------------------------------------------------------------------------
        // Save to txt is the function that saves the grid array to text.
        //--------------------------------------------------------------------------------------
        private void SaveToTxt()
        {
            //--------------------------------------------------------------------------------------
            // Creates a new string that has nothing in it.
            //--------------------------------------------------------------------------------------
            string text_line = "";

            //--------------------------------------------------------------------------------------
            // A nested for loop that changes all of the grid array's int values to a string.
            //--------------------------------------------------------------------------------------
            for (int i = 0; i < gridArray.GetLength(1); i++)
            {
                //--------------------------------------------------------------------------------------
                // Nested for loop.
                //--------------------------------------------------------------------------------------
                for (int j = 0; j < gridArray.GetLength(0); j++)
                {
                    //--------------------------------------------------------------------------------------
                    // Changes the int to a string.
                    //--------------------------------------------------------------------------------------
                    text_line += gridArray[j, i].ToString();
                    //--------------------------------------------------------------------------------------
                    // Changes to a new line after every value in the array for easier loadability.
                    //--------------------------------------------------------------------------------------
                    text_line += "\n";
                }
            }
            //--------------------------------------------------------------------------------------
            // These take the grid array as a string and save it to a .txt in the file dir.
            //--------------------------------------------------------------------------------------
            File.SetAttributes(Path.GetDirectoryName(Application.ExecutablePath), FileAttributes.Normal);
            File.WriteAllText(Path.GetDirectoryName(Application.ExecutablePath), text_line);
        }

        //--------------------------------------------------------------------------------------
        // This function executes when the panel is clicked.S
        //--------------------------------------------------------------------------------------
        public void GridPanel_Click(object sender, EventArgs e)
		{
            //--------------------------------------------------------------------------------------
            // This clears the redo log once a new action is done.
            //--------------------------------------------------------------------------------------
            redoLog.Clear();

            //--------------------------------------------------------------------------------------
            // Creates a new point that represents the mouse's position when the panel is clicked.
            //--------------------------------------------------------------------------------------
            Point point = GridPanel.PointToClient(Cursor.Position);

            //--------------------------------------------------------------------------------------
            // Creating a new int to store the point's X value.
            //--------------------------------------------------------------------------------------
            int tileX = point.X;

            //--------------------------------------------------------------------------------------
            // Creating a new int to store the point's Y value.
            //--------------------------------------------------------------------------------------
            int tileY = point.Y;

            //--------------------------------------------------------------------------------------
            // This equation calculates which tile is being pressed by dividing the mouse's
            // position by the tile size which is set to 64.
            //--------------------------------------------------------------------------------------
            tileX = tileX / 64;
			tileY = tileY / 64;

            //--------------------------------------------------------------------------------------
            // Creates a new UndoRedo class.
            //--------------------------------------------------------------------------------------
            UndoRedo undoRedo = new UndoRedo();

            //--------------------------------------------------------------------------------------
            // Stores all of the necessary values into the undo redo so that it can remember when
            // needed.
            //--------------------------------------------------------------------------------------
            undoRedo.tempX = tileX;
            undoRedo.tempY = tileY;
            undoRedo.PreviousTile = gridArray[tileX, tileY];
            undoRedo.NextTile = Palette.selected;

            //--------------------------------------------------------------------------------------
            // Adds the undoRedo with all of the values to the undoLog.
            //--------------------------------------------------------------------------------------
            undoLog.Add(undoRedo);

            //--------------------------------------------------------------------------------------
            // Places the selected image from the palette into the tile being clicked on.
            //--------------------------------------------------------------------------------------
            gridArray[tileX, tileY] = Palette.selected;

            //--------------------------------------------------------------------------------------
            // This function helps Refresh run smoothly.
            //--------------------------------------------------------------------------------------
            GridPanel.Invalidate();

            //--------------------------------------------------------------------------------------
            // This refreshes the panel so that it shows any changes to the grid.
            //--------------------------------------------------------------------------------------
            GridPanel.Refresh();
		}

        //--------------------------------------------------------------------------------------
        // This function executes when the import button is clicked.
        //--------------------------------------------------------------------------------------
        private void buttonImport_Click(object sender, EventArgs e)
		{
            //--------------------------------------------------------------------------------------
            // Creates a new instance of the OpenFileDialog
            //--------------------------------------------------------------------------------------
            OpenFileDialog open = new OpenFileDialog();

            //--------------------------------------------------------------------------------------
            // Sets the file browser to open at the base C drive directory by default.
            //--------------------------------------------------------------------------------------
            open.InitialDirectory = @"C:";

            //--------------------------------------------------------------------------------------
            // This limits the user's import files to only ones of my choice.
            //--------------------------------------------------------------------------------------
            open.Filter = "Image files (*.png *.bmp *.jpg)|*.jpg; *.bmp; *.png";

            //--------------------------------------------------------------------------------------
            // If the OK button of the file browser is clicked then execute this code.
            //--------------------------------------------------------------------------------------
            if (open.ShowDialog() == DialogResult.OK)
			{
                //--------------------------------------------------------------------------------------
                // Creates a new bitmap from the file that is chosen inside the file browser.
                //--------------------------------------------------------------------------------------
                Bitmap image = (Bitmap)Image.FromFile(open.FileName);

                //--------------------------------------------------------------------------------------
                // Add the new imported image's filename to the imageLog.
                //--------------------------------------------------------------------------------------
                imageLog.Add(open.FileName);

                //--------------------------------------------------------------------------------------
                // Adds the new imported image to the dictionary.
                //--------------------------------------------------------------------------------------
                CreateDictionary(image);
			}
		}

        //--------------------------------------------------------------------------------------
        // This function allows Drag and Drop to occur.
        //--------------------------------------------------------------------------------------
        private void GridPanel_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //--------------------------------------------------------------------------------------
        // This function gets executed when someone drags an image into the panel.
        //--------------------------------------------------------------------------------------
        private void GridPanel_DragDrop(object sender, DragEventArgs e)
        {
            //--------------------------------------------------------------------------------------
            // This takes in the filename as a string array.
            //--------------------------------------------------------------------------------------
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            //--------------------------------------------------------------------------------------
            // Creating a new string that takes the array of filenames and turns them into a string.
            //--------------------------------------------------------------------------------------
            string strFiles = String.Join(" ", files);


            //--------------------------------------------------------------------------------------
            // Adds the image paths to the image log.
            //--------------------------------------------------------------------------------------
            imageLog.Add(strFiles);

            //--------------------------------------------------------------------------------------
            // Creates a new bitmap from the filename string
            //--------------------------------------------------------------------------------------
            Bitmap image = (Bitmap)Image.FromFile(strFiles);

            //--------------------------------------------------------------------------------------
            // Adds the created bitmap to the dictionary.
            //--------------------------------------------------------------------------------------
            CreateDictionary(image);

            //--------------------------------------------------------------------------------------
            // This function helps refresh run smoother.
            //--------------------------------------------------------------------------------------
            Invalidate();

            //--------------------------------------------------------------------------------------
            // Refresh updates the grid to the most recent version.
            //--------------------------------------------------------------------------------------
            Refresh();  
        }

        //--------------------------------------------------------------------------------------
        // This function allows for keyboard shortcuts to be used.
        //--------------------------------------------------------------------------------------
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //--------------------------------------------------------------------------------------
            // Creates a shorcut for ctrl + z for undo.
            //--------------------------------------------------------------------------------------
            if (keyData == (Keys.Control | Keys.Z))
            {
                //--------------------------------------------------------------------------------------
                // A new int for the index of the undoLog. This goes back 1 action in the undoLog.
                //--------------------------------------------------------------------------------------
                int index = undoLog.Count - 1;

                //--------------------------------------------------------------------------------------
                // Checks for if there is no more actions to undo then return false.
                //--------------------------------------------------------------------------------------
                if (index < 0)
                    return false;

                //--------------------------------------------------------------------------------------
                // Changes the grid array to the last action / Undo.
                //--------------------------------------------------------------------------------------
                gridArray[undoLog[index].tempX, undoLog[index].tempY] = undoLog[index].PreviousTile;

                //--------------------------------------------------------------------------------------
                // Adds the undone action to the redo log so that it can be redone, once undone.
                //--------------------------------------------------------------------------------------
                redoLog.Add(undoLog[index]);

                //--------------------------------------------------------------------------------------
                // Remove the action that has been undone from the undo log so that it can iterate
                // further through the undo log.
                //--------------------------------------------------------------------------------------
                undoLog.RemoveAt(index);

                //--------------------------------------------------------------------------------------
                // Refresh refreshes the grid array.
                //--------------------------------------------------------------------------------------
                Refresh();

                //--------------------------------------------------------------------------------------
                // Returns the bool as true.
                //--------------------------------------------------------------------------------------
                return true;
            }

            //--------------------------------------------------------------------------------------
            // Creates the shortcut for ctrl + y for redo.
            //--------------------------------------------------------------------------------------
            if (keyData == (Keys.Control | Keys.Y))
            {
                //--------------------------------------------------------------------------------------
                // Creates an int for the index of the redoLog. This goes back 1 action in the redoLog.
                //--------------------------------------------------------------------------------------
                int index = redoLog.Count - 1;

                //--------------------------------------------------------------------------------------
                // A check to see if the redoLog can go back any further or not. If not, return false.
                //--------------------------------------------------------------------------------------
                if (index < 0)
                    return false;

                //--------------------------------------------------------------------------------------
                // Allocates the grid array values of the redoLog into the grid array.
                //--------------------------------------------------------------------------------------
                gridArray[redoLog[index].tempX, redoLog[index].tempY] = redoLog[index].NextTile;

                //--------------------------------------------------------------------------------------
                // Add the last redoLog index to the undoLog so that you are able to undo the redo.
                //--------------------------------------------------------------------------------------
                undoLog.Add(redoLog[index]);

                //--------------------------------------------------------------------------------------
                // Remove the indexed redoLog action as it has been used.
                //--------------------------------------------------------------------------------------
                redoLog.RemoveAt(index);

                //--------------------------------------------------------------------------------------
                // Refreshes the grid array so that it shows the most recent grid.
                //--------------------------------------------------------------------------------------
                Refresh();

                //--------------------------------------------------------------------------------------
                // Return the bool as true.
                //--------------------------------------------------------------------------------------
                return true;
            }

            //--------------------------------------------------------------------------------------
            // This is needed for the key shortcuts.
            //--------------------------------------------------------------------------------------
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    //--------------------------------------------------------------------------------------
    // A class to store all of the most recent actions in to undo and redo.
    //--------------------------------------------------------------------------------------
    public class UndoRedo
    {
        //--------------------------------------------------------------------------------------
        // Creating public ints to store the values for undoing and redoing actions. 
        //--------------------------------------------------------------------------------------
        public int tempX = 0; //tempX is the pointX created by GridPanel_Click function
        public int tempY = 0; //tempY is the pointY created by GridPanel_Click function
        public int PreviousTile = 0; // PreviousTile is the previous tile that was clicked.
        public int NextTile = 0; // Next tile is the next tile.
    }
}