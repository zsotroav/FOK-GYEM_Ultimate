
namespace FOK_GYEM_Ultimate
{
    partial class FormSymbol
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
            this.endModNumeric = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.endPxNumeric = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.symbolCombo = new System.Windows.Forms.ComboBox();
            this.OffModNumeric = new System.Windows.Forms.NumericUpDown();
            this.OffPxNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.centerCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.endModNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPxNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffModNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffPxNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // endModNumeric
            // 
            this.endModNumeric.Location = new System.Drawing.Point(112, 128);
            this.endModNumeric.Name = "endModNumeric";
            this.endModNumeric.Size = new System.Drawing.Size(130, 23);
            this.endModNumeric.TabIndex = 5;
            this.endModNumeric.ValueChanged += new System.EventHandler(this.endModNumeric_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "End (module):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "End (px):";
            // 
            // endPxNumeric
            // 
            this.endPxNumeric.Location = new System.Drawing.Point(112, 99);
            this.endPxNumeric.Name = "endPxNumeric";
            this.endPxNumeric.Size = new System.Drawing.Size(130, 23);
            this.endPxNumeric.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Center symbol:";
            // 
            // symbolCombo
            // 
            this.symbolCombo.FormattingEnabled = true;
            this.symbolCombo.Location = new System.Drawing.Point(112, 12);
            this.symbolCombo.Name = "symbolCombo";
            this.symbolCombo.Size = new System.Drawing.Size(130, 23);
            this.symbolCombo.TabIndex = 1;
            // 
            // OffModNumeric
            // 
            this.OffModNumeric.Location = new System.Drawing.Point(112, 70);
            this.OffModNumeric.Name = "OffModNumeric";
            this.OffModNumeric.Size = new System.Drawing.Size(130, 23);
            this.OffModNumeric.TabIndex = 3;
            this.OffModNumeric.ValueChanged += new System.EventHandler(this.OffModNumeric_ValueChanged);
            // 
            // OffPxNumeric
            // 
            this.OffPxNumeric.Location = new System.Drawing.Point(112, 41);
            this.OffPxNumeric.Name = "OffPxNumeric";
            this.OffPxNumeric.Size = new System.Drawing.Size(130, 23);
            this.OffPxNumeric.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Offset (module):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Offset (px):";
            // 
            // centerCheckBox
            // 
            this.centerCheckBox.AutoSize = true;
            this.centerCheckBox.Location = new System.Drawing.Point(111, 157);
            this.centerCheckBox.Name = "centerCheckBox";
            this.centerCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.centerCheckBox.Size = new System.Drawing.Size(15, 14);
            this.centerCheckBox.TabIndex = 6;
            this.centerCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Symbol:";
            // 
            // FormSymbol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 209);
            this.Controls.Add(this.endModNumeric);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.endPxNumeric);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.symbolCombo);
            this.Controls.Add(this.OffModNumeric);
            this.Controls.Add(this.OffPxNumeric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.centerCheckBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSymbol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert symbol";
            ((System.ComponentModel.ISupportInitialize)(this.endModNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPxNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffModNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffPxNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown endModNumeric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown endPxNumeric;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox symbolCombo;
        private System.Windows.Forms.NumericUpDown OffModNumeric;
        private System.Windows.Forms.NumericUpDown OffPxNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox centerCheckBox;
        private System.Windows.Forms.Label label1;
    }
}