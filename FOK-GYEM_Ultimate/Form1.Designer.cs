
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
            this.animBtn = new System.Windows.Forms.Button();
            this.frameBtn = new System.Windows.Forms.Button();
            this.transBtn = new System.Windows.Forms.Button();
            this.transitionCombo = new System.Windows.Forms.ComboBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.delayNumeric = new System.Windows.Forms.NumericUpDown();
            this.animExpBtn = new System.Windows.Forms.Button();
            this.framesLabel = new System.Windows.Forms.Label();
            this.frameSelLabel = new System.Windows.Forms.Label();
            this.frameCombo = new System.Windows.Forms.ComboBox();
            this.loopCheck = new System.Windows.Forms.CheckBox();
            this.loopNumeric = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.AutoScroll = true;
            this.containerPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.containerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.containerPanel.Location = new System.Drawing.Point(14, 36);
            this.containerPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(1357, 309);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1385, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.binToolStripMenuItem1,
            this.bmpToolStripMenuItem1});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // binToolStripMenuItem1
            // 
            this.binToolStripMenuItem1.Name = "binToolStripMenuItem1";
            this.binToolStripMenuItem1.Size = new System.Drawing.Size(123, 26);
            this.binToolStripMenuItem1.Text = "bin";
            this.binToolStripMenuItem1.Click += new System.EventHandler(this.LoadFromBin);
            // 
            // bmpToolStripMenuItem1
            // 
            this.bmpToolStripMenuItem1.Name = "bmpToolStripMenuItem1";
            this.bmpToolStripMenuItem1.Size = new System.Drawing.Size(123, 26);
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
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.saveToolStripMenuItem.Text = "Export";
            // 
            // binToolStripMenuItem
            // 
            this.binToolStripMenuItem.Name = "binToolStripMenuItem";
            this.binToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.binToolStripMenuItem.Text = "bin";
            this.binToolStripMenuItem.Click += new System.EventHandler(this.ExportBin);
            // 
            // bmpToolStripMenuItem
            // 
            this.bmpToolStripMenuItem.Name = "bmpToolStripMenuItem";
            this.bmpToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.bmpToolStripMenuItem.Text = "bmp";
            this.bmpToolStripMenuItem.Click += new System.EventHandler(this.ExportBmp);
            // 
            // maincppToolStripMenuItem
            // 
            this.maincppToolStripMenuItem.Name = "maincppToolStripMenuItem";
            this.maincppToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.maincppToolStripMenuItem.Text = "main.cpp";
            this.maincppToolStripMenuItem.Click += new System.EventHandler(this.ExportMainCpp);
            // 
            // panelToolStripMenuItem
            // 
            this.panelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSizeToolStripMenuItem,
            this.setNewBreakpointToolStripMenuItem});
            this.panelToolStripMenuItem.Name = "panelToolStripMenuItem";
            this.panelToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.panelToolStripMenuItem.Text = "Panel";
            // 
            // newSizeToolStripMenuItem
            // 
            this.newSizeToolStripMenuItem.Name = "newSizeToolStripMenuItem";
            this.newSizeToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.newSizeToolStripMenuItem.Text = "New size...";
            this.newSizeToolStripMenuItem.Click += new System.EventHandler(this.newSizeToolStripMenuItem_Click);
            // 
            // setNewBreakpointToolStripMenuItem
            // 
            this.setNewBreakpointToolStripMenuItem.Name = "setNewBreakpointToolStripMenuItem";
            this.setNewBreakpointToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
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
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearEditStrip
            // 
            this.clearEditStrip.Name = "clearEditStrip";
            this.clearEditStrip.Size = new System.Drawing.Size(189, 26);
            this.clearEditStrip.Text = "Clear";
            this.clearEditStrip.Click += new System.EventHandler(this.ClearPanel);
            // 
            // invertEditStrip
            // 
            this.invertEditStrip.Name = "invertEditStrip";
            this.invertEditStrip.Size = new System.Drawing.Size(189, 26);
            this.invertEditStrip.Text = "Invert";
            this.invertEditStrip.Click += new System.EventHandler(this.InvertPanel);
            // 
            // flipEditStrip
            // 
            this.flipEditStrip.Name = "flipEditStrip";
            this.flipEditStrip.Size = new System.Drawing.Size(189, 26);
            this.flipEditStrip.Text = "Flip vertically";
            this.flipEditStrip.Click += new System.EventHandler(this.FlipVertically);
            // 
            // textEditStrip
            // 
            this.textEditStrip.Name = "textEditStrip";
            this.textEditStrip.Size = new System.Drawing.Size(189, 26);
            this.textEditStrip.Text = "Insert text...";
            this.textEditStrip.Click += new System.EventHandler(this.TextGen);
            // 
            // symbolEditStrip
            // 
            this.symbolEditStrip.Name = "symbolEditStrip";
            this.symbolEditStrip.Size = new System.Drawing.Size(189, 26);
            this.symbolEditStrip.Text = "Insert symbol...";
            this.symbolEditStrip.Click += new System.EventHandler(this.symbolEditStrip_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setColorToolStripMenuItem,
            this.setDefaultsToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // setColorToolStripMenuItem
            // 
            this.setColorToolStripMenuItem.Name = "setColorToolStripMenuItem";
            this.setColorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.setColorToolStripMenuItem.Text = "Set color";
            this.setColorToolStripMenuItem.Click += new System.EventHandler(this.setColorToolStripMenuItem_Click);
            // 
            // setDefaultsToolStripMenuItem
            // 
            this.setDefaultsToolStripMenuItem.Name = "setDefaultsToolStripMenuItem";
            this.setDefaultsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.setDefaultsToolStripMenuItem.Text = "Set defaults";
            this.setDefaultsToolStripMenuItem.Click += new System.EventHandler(this.setDefaultsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wikiAboutStrip,
            this.githubAboutStrip,
            this.creditsAboutStrip});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // wikiAboutStrip
            // 
            this.wikiAboutStrip.Name = "wikiAboutStrip";
            this.wikiAboutStrip.Size = new System.Drawing.Size(167, 26);
            this.wikiAboutStrip.Text = "Help (Wiki)";
            this.wikiAboutStrip.Click += new System.EventHandler(this.wikiAboutStrip_Click);
            // 
            // githubAboutStrip
            // 
            this.githubAboutStrip.Name = "githubAboutStrip";
            this.githubAboutStrip.Size = new System.Drawing.Size(167, 26);
            this.githubAboutStrip.Text = "GitHub";
            this.githubAboutStrip.Click += new System.EventHandler(this.githubAboutStrip_Click);
            // 
            // creditsAboutStrip
            // 
            this.creditsAboutStrip.Name = "creditsAboutStrip";
            this.creditsAboutStrip.Size = new System.Drawing.Size(167, 26);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 485);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1385, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(101, 20);
            this.toolStripStatusLabel1.Text = "Current panel:";
            // 
            // panelDataAStrip
            // 
            this.panelDataAStrip.Name = "panelDataAStrip";
            this.panelDataAStrip.Size = new System.Drawing.Size(63, 20);
            this.panelDataAStrip.Text = "[PAN-A]";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(19, 20);
            this.toolStripStatusLabel3.Text = "+";
            // 
            // panelDataBStrip
            // 
            this.panelDataBStrip.Name = "panelDataBStrip";
            this.panelDataBStrip.Size = new System.Drawing.Size(62, 20);
            this.panelDataBStrip.Text = "[PAN-B]";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Enabled = false;
            this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(1123, 20);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Version: Dev10 - 22/03/23";
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
            // animBtn
            // 
            this.animBtn.Location = new System.Drawing.Point(14, 352);
            this.animBtn.Name = "animBtn";
            this.animBtn.Size = new System.Drawing.Size(155, 35);
            this.animBtn.TabIndex = 3;
            this.animBtn.Text = "Enable animation";
            this.animBtn.UseVisualStyleBackColor = true;
            this.animBtn.Click += new System.EventHandler(this.animBtn_Click);
            // 
            // frameBtn
            // 
            this.frameBtn.Enabled = false;
            this.frameBtn.Location = new System.Drawing.Point(14, 393);
            this.frameBtn.Name = "frameBtn";
            this.frameBtn.Size = new System.Drawing.Size(155, 35);
            this.frameBtn.TabIndex = 4;
            this.frameBtn.Text = "Add frame";
            this.frameBtn.UseVisualStyleBackColor = true;
            this.frameBtn.Click += new System.EventHandler(this.frameBtn_Click);
            // 
            // transBtn
            // 
            this.transBtn.Enabled = false;
            this.transBtn.Location = new System.Drawing.Point(14, 435);
            this.transBtn.Name = "transBtn";
            this.transBtn.Size = new System.Drawing.Size(155, 35);
            this.transBtn.TabIndex = 5;
            this.transBtn.Text = "Add transition";
            this.transBtn.UseVisualStyleBackColor = true;
            this.transBtn.Click += new System.EventHandler(this.transBtn_Click);
            // 
            // transitionCombo
            // 
            this.transitionCombo.Enabled = false;
            this.transitionCombo.FormattingEnabled = true;
            this.transitionCombo.Items.AddRange(new object[] {
            "1 Full 1",
            "2 Full 0",
            "3 Full 1 + Full 0",
            "4 Alternating 101",
            "5 Alternating 010",
            "6 Alternating 101 + 010 "});
            this.transitionCombo.Location = new System.Drawing.Point(175, 437);
            this.transitionCombo.Name = "transitionCombo";
            this.transitionCombo.Size = new System.Drawing.Size(203, 28);
            this.transitionCombo.TabIndex = 6;
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Enabled = false;
            this.delayLabel.Location = new System.Drawing.Point(175, 400);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(83, 20);
            this.delayLabel.TabIndex = 7;
            this.delayLabel.Text = "Delay (ms):";
            // 
            // delayNumeric
            // 
            this.delayNumeric.Enabled = false;
            this.delayNumeric.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.delayNumeric.Location = new System.Drawing.Point(264, 397);
            this.delayNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.delayNumeric.Name = "delayNumeric";
            this.delayNumeric.Size = new System.Drawing.Size(114, 27);
            this.delayNumeric.TabIndex = 8;
            this.delayNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // animExpBtn
            // 
            this.animExpBtn.Enabled = false;
            this.animExpBtn.Location = new System.Drawing.Point(175, 352);
            this.animExpBtn.Name = "animExpBtn";
            this.animExpBtn.Size = new System.Drawing.Size(203, 35);
            this.animExpBtn.TabIndex = 9;
            this.animExpBtn.Text = "Export animation";
            this.animExpBtn.UseVisualStyleBackColor = true;
            this.animExpBtn.Click += new System.EventHandler(this.animExpBtn_Click);
            // 
            // framesLabel
            // 
            this.framesLabel.AutoSize = true;
            this.framesLabel.Enabled = false;
            this.framesLabel.Location = new System.Drawing.Point(459, 359);
            this.framesLabel.Name = "framesLabel";
            this.framesLabel.Size = new System.Drawing.Size(145, 20);
            this.framesLabel.TabIndex = 10;
            this.framesLabel.Text = "Number of frames: 0";
            // 
            // frameSelLabel
            // 
            this.frameSelLabel.AutoSize = true;
            this.frameSelLabel.Enabled = false;
            this.frameSelLabel.Location = new System.Drawing.Point(459, 400);
            this.frameSelLabel.Name = "frameSelLabel";
            this.frameSelLabel.Size = new System.Drawing.Size(95, 20);
            this.frameSelLabel.TabIndex = 11;
            this.frameSelLabel.Text = "Select frame:";
            // 
            // frameCombo
            // 
            this.frameCombo.Enabled = false;
            this.frameCombo.FormattingEnabled = true;
            this.frameCombo.Location = new System.Drawing.Point(561, 397);
            this.frameCombo.Name = "frameCombo";
            this.frameCombo.Size = new System.Drawing.Size(151, 28);
            this.frameCombo.TabIndex = 12;
            this.frameCombo.SelectedValueChanged += new System.EventHandler(this.frameCombo_SelectedValueChanged);
            // 
            // loopCheck
            // 
            this.loopCheck.AutoSize = true;
            this.loopCheck.Enabled = false;
            this.loopCheck.Location = new System.Drawing.Point(459, 440);
            this.loopCheck.Name = "loopCheck";
            this.loopCheck.Size = new System.Drawing.Size(177, 24);
            this.loopCheck.TabIndex = 13;
            this.loopCheck.Text = "Loop with delay (ms): ";
            this.loopCheck.UseVisualStyleBackColor = true;
            this.loopCheck.Click += new System.EventHandler(this.loopCheck_Click);
            // 
            // loopNumeric
            // 
            this.loopNumeric.Enabled = false;
            this.loopNumeric.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.loopNumeric.Location = new System.Drawing.Point(643, 440);
            this.loopNumeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.loopNumeric.Name = "loopNumeric";
            this.loopNumeric.Size = new System.Drawing.Size(69, 27);
            this.loopNumeric.TabIndex = 14;
            this.loopNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1385, 511);
            this.Controls.Add(this.loopNumeric);
            this.Controls.Add(this.loopCheck);
            this.Controls.Add(this.frameCombo);
            this.Controls.Add(this.frameSelLabel);
            this.Controls.Add(this.framesLabel);
            this.Controls.Add(this.animExpBtn);
            this.Controls.Add(this.delayNumeric);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.transitionCombo);
            this.Controls.Add(this.transBtn);
            this.Controls.Add(this.frameBtn);
            this.Controls.Add(this.animBtn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FOK-GYEM Ultimate control panel by zsotroav";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loopNumeric)).EndInit();
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
        private System.Windows.Forms.Button animBtn;
        private System.Windows.Forms.Button frameBtn;
        private System.Windows.Forms.Button transBtn;
        private System.Windows.Forms.ComboBox transitionCombo;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.NumericUpDown delayNumeric;
        private System.Windows.Forms.Button animExpBtn;
        private System.Windows.Forms.Label framesLabel;
        private System.Windows.Forms.Label frameSelLabel;
        private System.Windows.Forms.ComboBox frameCombo;
        private System.Windows.Forms.CheckBox loopCheck;
        private System.Windows.Forms.NumericUpDown loopNumeric;
    }
}

