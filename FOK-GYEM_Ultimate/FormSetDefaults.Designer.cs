
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
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Panel Module count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Panel Module breakpoint:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Active color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Inactive color:";
            // 
            // textActive
            // 
            this.textActive.Location = new System.Drawing.Point(139, 78);
            this.textActive.Name = "textActive";
            this.textActive.Size = new System.Drawing.Size(158, 27);
            this.textActive.TabIndex = 3;
            // 
            // textInactive
            // 
            this.textInactive.Location = new System.Drawing.Point(139, 111);
            this.textInactive.Name = "textInactive";
            this.textInactive.Size = new System.Drawing.Size(158, 27);
            this.textInactive.TabIndex = 5;
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(303, 78);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(27, 27);
            this.btnActive.TabIndex = 4;
            this.btnActive.Text = "...";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnInactive
            // 
            this.btnInactive.Location = new System.Drawing.Point(303, 111);
            this.btnInactive.Name = "btnInactive";
            this.btnInactive.Size = new System.Drawing.Size(27, 27);
            this.btnInactive.TabIndex = 6;
            this.btnInactive.Text = "...";
            this.btnInactive.UseVisualStyleBackColor = true;
            this.btnInactive.Click += new System.EventHandler(this.btnInactive_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(139, 145);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(191, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save new values";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(12, 145);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(121, 29);
            this.btnRestore.TabIndex = 8;
            this.btnRestore.Text = "Show original";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // numericCnt
            // 
            this.numericCnt.Location = new System.Drawing.Point(196, 13);
            this.numericCnt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.numericCnt.Size = new System.Drawing.Size(138, 27);
            this.numericCnt.TabIndex = 1;
            this.numericCnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericCut
            // 
            this.numericCut.Location = new System.Drawing.Point(196, 46);
            this.numericCut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
            this.numericCut.Size = new System.Drawing.Size(134, 27);
            this.numericCut.TabIndex = 2;
            this.numericCut.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormSetDefaults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 187);
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