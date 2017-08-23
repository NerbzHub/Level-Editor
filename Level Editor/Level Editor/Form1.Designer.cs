﻿namespace Level_Editor
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
			this.GridPanel = new System.Windows.Forms.Panel();
			this.DemoPictureBox = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabTexture = new System.Windows.Forms.TabControl();
			this.tabTerrain = new System.Windows.Forms.TabPage();
			this.tabRoad = new System.Windows.Forms.TabPage();
			this.tabTowers = new System.Windows.Forms.TabPage();
			this.tabScenery = new System.Windows.Forms.TabPage();
			this.pictureBoxTexture01 = new System.Windows.Forms.PictureBox();
			this.pictureBoxTexture02 = new System.Windows.Forms.PictureBox();
			this.pictureBoxTexture03 = new System.Windows.Forms.PictureBox();
			this.tileButton1 = new Level_Editor.TileButton();
			this.tileButton2 = new Level_Editor.TileButton();
			((System.ComponentModel.ISupportInitialize)(this.DemoPictureBox)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.tabTexture.SuspendLayout();
			this.tabTerrain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture01)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture02)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture03)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tileButton1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tileButton2)).BeginInit();
			this.SuspendLayout();
			// 
			// GridPanel
			// 
			this.GridPanel.BackColor = System.Drawing.SystemColors.Window;
			this.GridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.GridPanel.Location = new System.Drawing.Point(12, 30);
			this.GridPanel.Name = "GridPanel";
			this.GridPanel.Size = new System.Drawing.Size(960, 640);
			this.GridPanel.TabIndex = 0;
			this.GridPanel.Click += new System.EventHandler(this.GridPanel_Click);
			this.GridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.paintMe);
			// 
			// DemoPictureBox
			// 
			this.DemoPictureBox.Location = new System.Drawing.Point(39, 388);
			this.DemoPictureBox.Name = "DemoPictureBox";
			this.DemoPictureBox.Size = new System.Drawing.Size(117, 78);
			this.DemoPictureBox.TabIndex = 2;
			this.DemoPictureBox.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
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
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
			// 
			// tabTexture
			// 
			this.tabTexture.Controls.Add(this.tabTerrain);
			this.tabTexture.Controls.Add(this.tabRoad);
			this.tabTexture.Controls.Add(this.tabTowers);
			this.tabTexture.Controls.Add(this.tabScenery);
			this.tabTexture.Location = new System.Drawing.Point(990, 30);
			this.tabTexture.Name = "tabTexture";
			this.tabTexture.SelectedIndex = 0;
			this.tabTexture.Size = new System.Drawing.Size(251, 513);
			this.tabTexture.TabIndex = 2;
			// 
			// tabTerrain
			// 
			this.tabTerrain.Controls.Add(this.tileButton2);
			this.tabTerrain.Controls.Add(this.tileButton1);
			this.tabTerrain.Controls.Add(this.DemoPictureBox);
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
			// pictureBoxTexture01
			// 
			this.pictureBoxTexture01.Image = global::Level_Editor.Properties.Resources.tex_none_grey;
			this.pictureBoxTexture01.Location = new System.Drawing.Point(1050, 549);
			this.pictureBoxTexture01.Name = "pictureBoxTexture01";
			this.pictureBoxTexture01.Size = new System.Drawing.Size(64, 64);
			this.pictureBoxTexture01.TabIndex = 0;
			this.pictureBoxTexture01.TabStop = false;
			this.pictureBoxTexture01.Click += new System.EventHandler(this.pictureBoxTexture01_Click);
			// 
			// pictureBoxTexture02
			// 
			this.pictureBoxTexture02.Image = global::Level_Editor.Properties.Resources.tex_Bloons_terrain_grass;
			this.pictureBoxTexture02.Location = new System.Drawing.Point(980, 549);
			this.pictureBoxTexture02.Name = "pictureBoxTexture02";
			this.pictureBoxTexture02.Size = new System.Drawing.Size(64, 64);
			this.pictureBoxTexture02.TabIndex = 1;
			this.pictureBoxTexture02.TabStop = false;
			this.pictureBoxTexture02.Click += new System.EventHandler(this.pictureBoxTexture02_Click);
			// 
			// pictureBoxTexture03
			// 
			this.pictureBoxTexture03.Image = global::Level_Editor.Properties.Resources.tex_Bloons_terrain_long_grass;
			this.pictureBoxTexture03.Location = new System.Drawing.Point(1120, 549);
			this.pictureBoxTexture03.Name = "pictureBoxTexture03";
			this.pictureBoxTexture03.Size = new System.Drawing.Size(64, 64);
			this.pictureBoxTexture03.TabIndex = 2;
			this.pictureBoxTexture03.TabStop = false;
			this.pictureBoxTexture03.Click += new System.EventHandler(this.pictureBoxTexture03_Click);
			// 
			// tileButton1
			// 
			this.tileButton1.Location = new System.Drawing.Point(6, 6);
			this.tileButton1.myType = Level_Editor.TileType.ENUM_GRASS;
			this.tileButton1.Name = "tileButton1";
			this.tileButton1.Size = new System.Drawing.Size(64, 64);
			this.tileButton1.TabIndex = 3;
			this.tileButton1.TabStop = false;
			this.tileButton1.Click += new System.EventHandler(this.tileButton1_Click);
			// 
			// tileButton2
			// 
			this.tileButton2.Location = new System.Drawing.Point(76, 6);
			this.tileButton2.myType = Level_Editor.TileType.ENUM_GRASS;
			this.tileButton2.Name = "tileButton2";
			this.tileButton2.Size = new System.Drawing.Size(64, 64);
			this.tileButton2.TabIndex = 4;
			this.tileButton2.TabStop = false;
			// 
			// LevelEditorForm1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 682);
			this.Controls.Add(this.pictureBoxTexture03);
			this.Controls.Add(this.pictureBoxTexture02);
			this.Controls.Add(this.tabTexture);
			this.Controls.Add(this.pictureBoxTexture01);
			this.Controls.Add(this.GridPanel);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "LevelEditorForm1";
			this.Text = "Nathan\'s Level Editor";
			this.Load += new System.EventHandler(this.LevelEditorForm1_Load);
			((System.ComponentModel.ISupportInitialize)(this.DemoPictureBox)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabTexture.ResumeLayout(false);
			this.tabTerrain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture01)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture02)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxTexture03)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tileButton1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tileButton2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GridPanel;
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
		private System.Windows.Forms.PictureBox pictureBoxTexture03;
		private System.Windows.Forms.PictureBox pictureBoxTexture02;
		private System.Windows.Forms.PictureBox pictureBoxTexture01;
		private TileButton tileButton1;
		private TileButton tileButton2;
	}
}

