
namespace FOK_GYEM_Ultimate
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.containerPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bmpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maincppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setNewBreakpointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearEditStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.invertEditStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.flipEditStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.textEditStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolEditStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDefaultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiAboutStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.githubAboutStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsAboutStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelDataAStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelDataBStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.AutoScroll = true;
            this.containerPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.containerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.containerPanel.Location = new System.Drawing.Point(12, 27);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(1188, 233);
            this.containerPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.panelToolStripMenuItem,
            this.editToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1212, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binToolStripMenuItem1,
            this.bmpToolStripMenuItem1});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // binToolStripMenuItem1
            // 
            this.binToolStripMenuItem1.Name = "binToolStripMenuItem1";
            this.binToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.binToolStripMenuItem1.Text = "bin";
            this.binToolStripMenuItem1.Click += new System.EventHandler(this.LoadFromBin);
            // 
            // bmpToolStripMenuItem1
            // 
            this.bmpToolStripMenuItem1.Name = "bmpToolStripMenuItem1";
            this.bmpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.bmpToolStripMenuItem1.Text = "bmp";
            this.bmpToolStripMenuItem1.Click += new System.EventHandler(this.LoadFromBmp);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binToolStripMenuItem,
            this.bmpToolStripMenuItem,
            this.maincppToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.saveToolStripMenuItem.Text = "Export";
            // 
            // binToolStripMenuItem
            // 
            this.binToolStripMenuItem.Name = "binToolStripMenuItem";
            this.binToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.binToolStripMenuItem.Text = "bin";
            this.binToolStripMenuItem.Click += new System.EventHandler(this.ExportBin);
            // 
            // bmpToolStripMenuItem
            // 
            this.bmpToolStripMenuItem.Name = "bmpToolStripMenuItem";
            this.bmpToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.bmpToolStripMenuItem.Text = "bmp";
            this.bmpToolStripMenuItem.Click += new System.EventHandler(this.ExportBmp);
            // 
            // maincppToolStripMenuItem
            // 
            this.maincppToolStripMenuItem.Name = "maincppToolStripMenuItem";
            this.maincppToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.maincppToolStripMenuItem.Text = "main.cpp";
            this.maincppToolStripMenuItem.Click += new System.EventHandler(this.ExportMainCPP);
            // 
            // panelToolStripMenuItem
            // 
            this.panelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSizeToolStripMenuItem,
            this.setNewBreakpointToolStripMenuItem});
            this.panelToolStripMenuItem.Name = "panelToolStripMenuItem";
            this.panelToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.panelToolStripMenuItem.Text = "Panel";
            // 
            // newSizeToolStripMenuItem
            // 
            this.newSizeToolStripMenuItem.Name = "newSizeToolStripMenuItem";
            this.newSizeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.newSizeToolStripMenuItem.Text = "New size...";
            this.newSizeToolStripMenuItem.Click += new System.EventHandler(this.newSizeToolStripMenuItem_Click);
            // 
            // setNewBreakpointToolStripMenuItem
            // 
            this.setNewBreakpointToolStripMenuItem.Name = "setNewBreakpointToolStripMenuItem";
            this.setNewBreakpointToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.setNewBreakpointToolStripMenuItem.Text = "Set new breakpoint...";
            this.setNewBreakpointToolStripMenuItem.Click += new System.EventHandler(this.setNewBreakpointToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearEditStrip,
            this.invertEditStrip,
            this.flipEditStrip,
            this.textEditStrip,
            this.symbolEditStrip});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearEditStrip
            // 
            this.clearEditStrip.Name = "clearEditStrip";
            this.clearEditStrip.Size = new System.Drawing.Size(180, 22);
            this.clearEditStrip.Text = "Clear";
            this.clearEditStrip.Click += new System.EventHandler(this.ClearPanel);
            // 
            // invertEditStrip
            // 
            this.invertEditStrip.Name = "invertEditStrip";
            this.invertEditStrip.Size = new System.Drawing.Size(180, 22);
            this.invertEditStrip.Text = "Invert";
            this.invertEditStrip.Click += new System.EventHandler(this.InvertPanel);
            // 
            // flipEditStrip
            // 
            this.flipEditStrip.Name = "flipEditStrip";
            this.flipEditStrip.Size = new System.Drawing.Size(180, 22);
            this.flipEditStrip.Text = "Flip vertically";
            this.flipEditStrip.Click += new System.EventHandler(this.FlipVertically);
            // 
            // textEditStrip
            // 
            this.textEditStrip.Name = "textEditStrip";
            this.textEditStrip.Size = new System.Drawing.Size(180, 22);
            this.textEditStrip.Text = "Insert text...";
            this.textEditStrip.Click += new System.EventHandler(this.TextGen);
            // 
            // symbolEditStrip
            // 
            this.symbolEditStrip.Name = "symbolEditStrip";
            this.symbolEditStrip.Size = new System.Drawing.Size(180, 22);
            this.symbolEditStrip.Text = "Insert symbol...";
            this.symbolEditStrip.Click += new System.EventHandler(this.symbolEditStrip_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setColorToolStripMenuItem,
            this.setDefaultsToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // setColorToolStripMenuItem
            // 
            this.setColorToolStripMenuItem.Name = "setColorToolStripMenuItem";
            this.setColorToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.setColorToolStripMenuItem.Text = "Set color";
            this.setColorToolStripMenuItem.Click += new System.EventHandler(this.setColorToolStripMenuItem_Click);
            // 
            // setDefaultsToolStripMenuItem
            // 
            this.setDefaultsToolStripMenuItem.Name = "setDefaultsToolStripMenuItem";
            this.setDefaultsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.setDefaultsToolStripMenuItem.Text = "Set defaults";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiAboutStrip,
            this.githubAboutStrip,
            this.creditsAboutStrip});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // wikiAboutStrip
            // 
            this.wikiAboutStrip.Name = "wikiAboutStrip";
            this.wikiAboutStrip.Size = new System.Drawing.Size(133, 22);
            this.wikiAboutStrip.Text = "Help (Wiki)";
            this.wikiAboutStrip.Click += new System.EventHandler(this.wikiAboutStrip_Click);
            // 
            // githubAboutStrip
            // 
            this.githubAboutStrip.Name = "githubAboutStrip";
            this.githubAboutStrip.Size = new System.Drawing.Size(133, 22);
            this.githubAboutStrip.Text = "GitHub";
            this.githubAboutStrip.Click += new System.EventHandler(this.githubAboutStrip_Click);
            // 
            // creditsAboutStrip
            // 
            this.creditsAboutStrip.Name = "creditsAboutStrip";
            this.creditsAboutStrip.Size = new System.Drawing.Size(133, 22);
            this.creditsAboutStrip.Text = "Credits";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.panelDataAStrip,
            this.toolStripStatusLabel3,
            this.panelDataBStrip,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 361);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1212, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel1.Text = "Current panel:";
            // 
            // panelDataAStrip
            // 
            this.panelDataAStrip.Name = "panelDataAStrip";
            this.panelDataAStrip.Size = new System.Drawing.Size(51, 17);
            this.panelDataAStrip.Text = "[PAN-A]";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(15, 17);
            this.toolStripStatusLabel3.Text = "+";
            // 
            // panelDataBStrip
            // 
            this.panelDataBStrip.Name = "panelDataBStrip";
            this.panelDataBStrip.Size = new System.Drawing.Size(50, 17);
            this.panelDataBStrip.Text = "[PAN-B]";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Enabled = false;
            this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(968, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Version: Dev3 - 21/11/19";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openDialog";
            this.openFileDialog1.Title = "Import FOK-GYEM data";
            // 
            // saveDialog
            // 
            this.saveDialog.Title = "Export FOK-GYEM data";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 383);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FOK-GYEM Ultimate control panel by zsotroav";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel panelDataAStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem binToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bmpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem binToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bmpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maincppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setNewBreakpointToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel panelDataBStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertEditStrip;
        private System.Windows.Forms.ToolStripMenuItem textEditStrip;
        private System.Windows.Forms.ToolStripMenuItem symbolEditStrip;
        private System.Windows.Forms.ToolStripMenuItem clearEditStrip;
        public System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.ToolStripMenuItem flipEditStrip;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wikiAboutStrip;
        private System.Windows.Forms.ToolStripMenuItem githubAboutStrip;
        private System.Windows.Forms.ToolStripMenuItem creditsAboutStrip;
        private System.Windows.Forms.ToolStripMenuItem setColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDefaultsToolStripMenuItem;
    }
}

