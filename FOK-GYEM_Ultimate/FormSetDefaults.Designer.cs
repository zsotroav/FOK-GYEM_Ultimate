
namespace FOK_GYEM_Ultimate
{
    partial class FormSetDefaults
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textActive = new System.Windows.Forms.TextBox();
            this.textInactive = new System.Windows.Forms.TextBox();
            this.btnActive = new System.Windows.Forms.Button();
            this.btnInactive = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.numericCnt = new System.Windows.Forms.NumericUpDown();
            this.numericCut = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCut)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Panel Module count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Panel Module breakpoint:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pixel active color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pixel inactive color:";
            // 
            // textActive
            // 
            this.textActive.Location = new System.Drawing.Point(128, 67);
            this.textActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textActive.Name = "textActive";
            this.textActive.Size = new System.Drawing.Size(86, 23);
            this.textActive.TabIndex = 3;
            // 
            // textInactive
            // 
            this.textInactive.Location = new System.Drawing.Point(128, 95);
            this.textInactive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textInactive.Name = "textInactive";
            this.textInactive.Size = new System.Drawing.Size(86, 23);
            this.textInactive.TabIndex = 5;
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(220, 66);
            this.btnActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(24, 23);
            this.btnActive.TabIndex = 4;
            this.btnActive.Text = "...";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnInactive
            // 
            this.btnInactive.Location = new System.Drawing.Point(220, 95);
            this.btnInactive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInactive.Name = "btnInactive";
            this.btnInactive.Size = new System.Drawing.Size(24, 23);
            this.btnInactive.TabIndex = 6;
            this.btnInactive.Text = "...";
            this.btnInactive.UseVisualStyleBackColor = true;
            this.btnInactive.Click += new System.EventHandler(this.btnInactive_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(127, 122);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 25);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save new values";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(12, 122);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(109, 25);
            this.btnRestore.TabIndex = 8;
            this.btnRestore.Text = "Reset";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // numericCnt
            // 
            this.numericCnt.Location = new System.Drawing.Point(161, 10);
            this.numericCnt.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCnt.Name = "numericCnt";
            this.numericCnt.Size = new System.Drawing.Size(83, 23);
            this.numericCnt.TabIndex = 1;
            this.numericCnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericCut
            // 
            this.numericCut.Location = new System.Drawing.Point(161, 39);
            this.numericCut.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numericCut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericCut.Name = "numericCut";
            this.numericCut.Size = new System.Drawing.Size(83, 23);
            this.numericCut.TabIndex = 2;
            this.numericCut.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormSetDefaults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 157);
            this.Controls.Add(this.numericCut);
            this.Controls.Add(this.numericCnt);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnInactive);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.textInactive);
            this.Controls.Add(this.textActive);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetDefaults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Default values";
            ((System.ComponentModel.ISupportInitialize)(this.numericCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textActive;
        private System.Windows.Forms.TextBox textInactive;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button btnInactive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown numericCnt;
        private System.Windows.Forms.NumericUpDown numericCut;
    }
}