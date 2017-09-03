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
            this.GridPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabTexture = new System.Windows.Forms.TabControl();
            this.tabTerrain = new System.Windows.Forms.TabPage();
            this.buttonImport = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabTexture.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridPanel
            // 
            this.GridPanel.AllowDrop = true;
            this.GridPanel.BackColor = System.Drawing.SystemColors.Window;
            this.GridPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GridPanel.Location = new System.Drawing.Point(12, 30);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(960, 640);
            this.GridPanel.TabIndex = 0;
            this.GridPanel.Click += new System.EventHandler(this.GridPanel_Click);
            this.GridPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.GridPanel_DragDrop);
            this.GridPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.GridPanel_DragEnter);
            this.GridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.paintMe);
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
            this.tabTexture.Location = new System.Drawing.Point(1018, 27);
            this.tabTexture.Name = "tabTexture";
            this.tabTexture.SelectedIndex = 0;
            this.tabTexture.Size = new System.Drawing.Size(206, 579);
            this.tabTexture.TabIndex = 2;
            // 
            // tabTerrain
            // 
            this.tabTerrain.Location = new System.Drawing.Point(4, 22);
            this.tabTerrain.Name = "tabTerrain";
            this.tabTerrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerrain.Size = new System.Drawing.Size(198, 553);
            this.tabTerrain.TabIndex = 0;
            this.tabTerrain.Text = "Tiles";
            this.tabTerrain.UseVisualStyleBackColor = true;
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(1022, 608);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(202, 58);
            this.buttonImport.TabIndex = 3;
            this.buttonImport.Text = "Import Texture";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // LevelEditorForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.tabTexture);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LevelEditorForm1";
            this.Text = "Nathan\'s Level Editor";
            this.Load += new System.EventHandler(this.LevelEditorForm1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabTexture.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.TabControl tabTexture;
		private System.Windows.Forms.TabPage tabTerrain;
		private System.Windows.Forms.Button buttonImport;
	}
}

