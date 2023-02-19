
namespace FOK_GYEM_Ultimate
{
    partial class FormText
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
            this.centerCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.OffPxNumeric = new System.Windows.Forms.NumericUpDown();
            this.OffModNumeric = new System.Windows.Forms.NumericUpDown();
            this.fontCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.endPxNumeric = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.endModNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.OffPxNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffModNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPxNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endModNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Font:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Text:";
            // 
            // centerCheckBox
            // 
            this.centerCheckBox.AutoSize = true;
            this.centerCheckBox.Location = new System.Drawing.Point(111, 186);
            this.centerCheckBox.Name = "centerCheckBox";
            this.centerCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.centerCheckBox.Size = new System.Drawing.Size(15, 14);
            this.centerCheckBox.TabIndex = 7;
            this.centerCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Offset (px):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Offset (module):";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(112, 41);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(130, 23);
            this.textBox.TabIndex = 2;
            // 
            // OffPxNumeric
            // 
            this.OffPxNumeric.Location = new System.Drawing.Point(112, 70);
            this.OffPxNumeric.Name = "OffPxNumeric";
            this.OffPxNumeric.Size = new System.Drawing.Size(130, 23);
            this.OffPxNumeric.TabIndex = 3;
            // 
            // OffModNumeric
            // 
            this.OffModNumeric.Location = new System.Drawing.Point(112, 99);
            this.OffModNumeric.Name = "OffModNumeric";
            this.OffModNumeric.Size = new System.Drawing.Size(130, 23);
            this.OffModNumeric.TabIndex = 4;
            this.OffModNumeric.ValueChanged += new System.EventHandler(this.OffModNumeric_ValueChanged);
            // 
            // fontCombo
            // 
            this.fontCombo.FormattingEnabled = true;
            this.fontCombo.Location = new System.Drawing.Point(112, 12);
            this.fontCombo.Name = "fontCombo";
            this.fontCombo.Size = new System.Drawing.Size(130, 23);
            this.fontCombo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Center text:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // endPxNumeric
            // 
            this.endPxNumeric.Location = new System.Drawing.Point(112, 128);
            this.endPxNumeric.Name = "endPxNumeric";
            this.endPxNumeric.Size = new System.Drawing.Size(130, 23);
            this.endPxNumeric.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "End (px):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "End (module):";
            // 
            // endModNumeric
            // 
            this.endModNumeric.Location = new System.Drawing.Point(112, 157);
            this.endModNumeric.Name = "endModNumeric";
            this.endModNumeric.Size = new System.Drawing.Size(130, 23);
            this.endModNumeric.TabIndex = 6;
            this.endModNumeric.ValueChanged += new System.EventHandler(this.endModNumeric_ValueChanged);
            // 
            // FormText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 239);
            this.Controls.Add(this.endModNumeric);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.endPxNumeric);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fontCombo);
            this.Controls.Add(this.OffModNumeric);
            this.Controls.Add(this.OffPxNumeric);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.centerCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormText";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert text";
            ((System.ComponentModel.ISupportInitialize)(this.OffPxNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffModNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPxNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endModNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox centerCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.NumericUpDown OffPxNumeric;
        private System.Windows.Forms.NumericUpDown OffModNumeric;
        private System.Windows.Forms.ComboBox fontCombo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown endPxNumeric;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown endModNumeric;
    }
}