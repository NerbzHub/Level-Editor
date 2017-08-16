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
        List<PictureBox> tileTexture = new List<PictureBox>();

        public LevelEditorForm1()
        {
            InitializeComponent();
        }

        private void LevelEditorForm1_Load(object sender, EventArgs e)
        {
            PictureBox texture = new PictureBox();
            texture.Location = new Point(50, 50);
            texture.Size = new Size(65, 65);
            texture.BackgroundImage = Properties.Resources.tex_Bloons_terrain_grass;
            Controls.Add(texture);
            for (int i = 0; i < 0; ++i)
            {
                tileTexture.Add(texture);
                texture.Location{Location};
            }
            tileTexture.Add(texture);
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
// Utilize bitmap blitting to allocate where inside a picture box the textures will be placed.
// The diagram matt drew shows how this will be implemented.