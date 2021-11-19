
namespace FOK_GYEM_Ultimate
{
    partial class FormArduinoConfig
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
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ClearCombo = new System.Windows.Forms.ComboBox();
            this.loopClearCombo = new System.Windows.Forms.ComboBox();
            this.loopCheck = new System.Windows.Forms.CheckBox();
            this.flipCheck = new System.Windows.Forms.CheckBox();
            this.delayNumeric = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.delayNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clear before:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Delay in loop:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Loop transition:";
            // 
            // ClearCombo
            // 
            this.ClearCombo.FormattingEnabled = true;
            this.ClearCombo.Items.AddRange(new object[] {
            "0 No",
            "1 Full 1",
            "2 Full 0",
            "3 Full 1 and Full 0",
            "4 Alternating 101",
            "5 Alternating 010",
            "6 Alternating 101 and 010 "});
            this.ClearCombo.Location = new System.Drawing.Point(139, 12);
            this.ClearCombo.Name = "ClearCombo";
            this.ClearCombo.Size = new System.Drawing.Size(151, 28);
            this.ClearCombo.TabIndex = 5;
            // 
            // loopClearCombo
            // 
            this.loopClearCombo.FormattingEnabled = true;
            this.loopClearCombo.Items.AddRange(new object[] {
            "0 No",
            "1 Full 1",
            "2 Full 0",
            "3 Full 1 and Full 0",
            "4 Alternating 101",
            "5 Alternating 010",
            "6 Alternating 101 and 010 "});
            this.loopClearCombo.Location = new System.Drawing.Point(139, 79);
            this.loopClearCombo.Name = "loopClearCombo";
            this.loopClearCombo.Size = new System.Drawing.Size(151, 28);
            this.loopClearCombo.TabIndex = 6;
            // 
            // loopCheck
            // 
            this.loopCheck.AutoSize = true;
            this.loopCheck.Checked = true;
            this.loopCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loopCheck.Location = new System.Drawing.Point(139, 143);
            this.loopCheck.Name = "loopCheck";
            this.loopCheck.Size = new System.Drawing.Size(116, 24);
            this.loopCheck.TabIndex = 7;
            this.loopCheck.Text = "Loop display";
            this.loopCheck.UseVisualStyleBackColor = true;
            // 
            // flipCheck
            // 
            this.flipCheck.AutoSize = true;
            this.flipCheck.Location = new System.Drawing.Point(139, 113);
            this.flipCheck.Name = "flipCheck";
            this.flipCheck.Size = new System.Drawing.Size(118, 24);
            this.flipCheck.TabIndex = 8;
            this.flipCheck.Text = "Panel flipped";
            this.flipCheck.UseVisualStyleBackColor = true;
            // 
            // delayNumeric
            // 
            this.delayNumeric.Location = new System.Drawing.Point(139, 46);
            this.delayNumeric.Name = "delayNumeric";
            this.delayNumeric.Size = new System.Drawing.Size(151, 27);
            this.delayNumeric.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(278, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormArduinoConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 214);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.delayNumeric);
            this.Controls.Add(this.flipCheck);
            this.Controls.Add(this.loopCheck);
            this.Controls.Add(this.loopClearCombo);
            this.Controls.Add(this.ClearCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormArduinoConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export main.cpp";
            ((System.ComponentModel.ISupportInitialize)(this.delayNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ClearCombo;
        private System.Windows.Forms.ComboBox loopClearCombo;
        private System.Windows.Forms.CheckBox loopCheck;
        private System.Windows.Forms.CheckBox flipCheck;
        private System.Windows.Forms.NumericUpDown delayNumeric;
        private System.Windows.Forms.Button button1;
    }
}