namespace Level_Editor
{
    partial class LevelEditorForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.panel1 = new System.Windows.Forms.Panel();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DemoPictureBox = new System.Windows.Forms.PictureBox();
			this.tabTexture = new System.Windows.Forms.TabControl();
			this.tabTerrain = new System.Windows.Forms.TabPage();
			this.tabRoad = new System.Windows.Forms.TabPage();
			this.tabTowers = new System.Windows.Forms.TabPage();
			this.tabScenery = new System.Windows.Forms.TabPage();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DemoPictureBox)).BeginInit();
			this.tabTexture.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.DemoPictureBox);
			this.panel1.Location = new System.Drawing.Point(12, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(791, 494);
			this.panel1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1093, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// DemoPictureBox
			// 
			this.DemoPictureBox.Location = new System.Drawing.Point(494, 163);
			this.DemoPictureBox.Name = "DemoPictureBox";
			this.DemoPictureBox.Size = new System.Drawing.Size(117, 78);
			this.DemoPictureBox.TabIndex = 2;
			this.DemoPictureBox.TabStop = false;
			// 
			// tabTexture
			// 
			this.tabTexture.Controls.Add(this.tabTerrain);
			this.tabTexture.Controls.Add(this.tabRoad);
			this.tabTexture.Controls.Add(this.tabTowers);
			this.tabTexture.Controls.Add(this.tabScenery);
			this.tabTexture.Location = new System.Drawing.Point(809, 27);
			this.tabTexture.Name = "tabTexture";
			this.tabTexture.SelectedIndex = 0;
			this.tabTexture.Size = new System.Drawing.Size(251, 513);
			this.tabTexture.TabIndex = 2;
			// 
			// tabTerrain
			// 
			this.tabTerrain.Location = new System.Drawing.Point(4, 22);
			this.tabTerrain.Name = "tabTerrain";
			this.tabTerrain.Padding = new System.Windows.Forms.Padding(3);
			this.tabTerrain.Size = new System.Drawing.Size(243, 487);
			this.tabTerrain.TabIndex = 0;
			this.tabTerrain.Text = "Terrain";
			this.tabTerrain.UseVisualStyleBackColor = true;
			// 
			// tabRoad
			// 
			this.tabRoad.Location = new System.Drawing.Point(4, 22);
			this.tabRoad.Name = "tabRoad";
			this.tabRoad.Padding = new System.Windows.Forms.Padding(3);
			this.tabRoad.Size = new System.Drawing.Size(243, 487);
			this.tabRoad.TabIndex = 1;
			this.tabRoad.Text = "Road";
			this.tabRoad.UseVisualStyleBackColor = true;
			// 
			// tabTowers
			// 
			this.tabTowers.Location = new System.Drawing.Point(4, 22);
			this.tabTowers.Name = "tabTowers";
			this.tabTowers.Padding = new System.Windows.Forms.Padding(3);
			this.tabTowers.Size = new System.Drawing.Size(243, 487);
			this.tabTowers.TabIndex = 2;
			this.tabTowers.Text = "Towers";
			this.tabTowers.UseVisualStyleBackColor = true;
			// 
			// tabScenery
			// 
			this.tabScenery.Location = new System.Drawing.Point(4, 22);
			this.tabScenery.Name = "tabScenery";
			this.tabScenery.Padding = new System.Windows.Forms.Padding(3);
			this.tabScenery.Size = new System.Drawing.Size(243, 487);
			this.tabScenery.TabIndex = 3;
			this.tabScenery.Text = "Scenery";
			this.tabScenery.UseVisualStyleBackColor = true;
			// 
			// LevelEditorForm1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1093, 633);
			this.Controls.Add(this.tabTexture);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "LevelEditorForm1";
			this.Text = "Nathan\'s Level Editor";
			this.Load += new System.EventHandler(this.LevelEditorForm1_Load);
			this.panel1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DemoPictureBox)).EndInit();
			this.tabTexture.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.PictureBox DemoPictureBox;
		private System.Windows.Forms.TabControl tabTexture;
		private System.Windows.Forms.TabPage tabTerrain;
		private System.Windows.Forms.TabPage tabRoad;
		private System.Windows.Forms.TabPage tabTowers;
		private System.Windows.Forms.TabPage tabScenery;
	}
}

