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
        }
    }
}
