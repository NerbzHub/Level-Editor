using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Level_Editor
{
    public partial class LevelEditorForm1 : Form
    {
        //List<PictureBox> tileTexture = new List<PictureBox>();

        public LevelEditorForm1()
        {
            InitializeComponent();
        }

        private void LevelEditorForm1_Load(object sender, EventArgs e)
        {
            PictureBox texGrass = new PictureBox();
            texGrass.Size = new Size(65, 65);
            texGrass.BackgroundImage = Properties.Resources.tex_Bloons_terrain_grass;
            PictureBox texLongGrass = new PictureBox();
            texLongGrass.Size = new Size(65, 65);
            texLongGrass.BackgroundImage = Properties.Resources.tex_Bloons_terrain_long_grass;

            //texGrass.Location = new Point(50, 50);
            
            Controls.Add(texGrass);

            Enum ENUM_GRASS, ENUM_LONG_GRASS;

            Dictionary<int, PictureBox> tileTexture = new Dictionary<int, PictureBox>();

            tileTexture.Add(0, texGrass);
            tileTexture.Add(1, texLongGrass);


            int[,] gridArray = new int[5, 5]
            {
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0},
            };

            //tileTexture.Add(texture);
        }
    }
}

//https://www.youtube.com/watch?v=lk0GsyxCj-U&index=1&list=PL0A865073DA96A7DA - this is the tutorial in xna
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