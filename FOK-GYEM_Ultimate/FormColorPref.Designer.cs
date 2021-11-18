
namespace FOK_GYEM_Ultimate
{
    partial class FormColorPref
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textActive = new System.Windows.Forms.TextBox();
            this.textInactive = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnActive = new System.Windows.Forms.Button();
            this.btnInactive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active color:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Inactive color:";
            // 
            // textActive
            // 
            this.textActive.Location = new System.Drawing.Point(120, 10);
            this.textActive.Name = "textActive";
            this.textActive.Size = new System.Drawing.Size(142, 27);
            this.textActive.TabIndex = 1;
            // 
            // textInactive
            // 
            this.textInactive.Location = new System.Drawing.Point(120, 43);
            this.textInactive.Name = "textInactive";
            this.textInactive.Size = new System.Drawing.Size(142, 27);
            this.textInactive.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(281, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(268, 10);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(26, 27);
            this.btnActive.TabIndex = 2;
            this.btnActive.Text = "...";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // btnInactive
            // 
            this.btnInactive.Location = new System.Drawing.Point(268, 43);
            this.btnInactive.Name = "btnInactive";
            this.btnInactive.Size = new System.Drawing.Size(26, 27);
            this.btnInactive.TabIndex = 4;
            this.btnInactive.Text = "...";
            this.btnInactive.UseVisualStyleBackColor = true;
            this.btnInactive.Click += new System.EventHandler(this.btnInactive_Click);
            // 
            // FormColorPref
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 112);
            this.Controls.Add(this.btnInactive);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textInactive);
            this.Controls.Add(this.textActive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormColorPref";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set colors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textActive;
        private System.Windows.Forms.TextBox textInactive;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button btnInactive;
    }
}