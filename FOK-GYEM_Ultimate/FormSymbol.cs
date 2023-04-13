using PluginBase;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using zsotroav;

namespace FOK_GYEM_Ultimate
{
    public partial class FormSymbol : Form
    {
        private FormMain _formMain;
        public FormSymbol(Form main)
        {
            _formMain = main as FormMain;
            InitializeComponent();

            string[] fonts = Directory.GetFiles(@"resources/symbols/", "*.bmp");
            var n = 0;
            foreach (var font in fonts)
            {
                symbolCombo.Items.Add(External.NameNoExtFromPath(font));
                n++;
            }
            if (n == 0)
            {
                MessageBox.Show(@"Couldn't find a single symbol!",
                    @"Symbol insert error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            symbolCombo.SelectedIndex = 0;
            OffModNumeric.Maximum = _formMain.ModCnt;
            OffPxNumeric.Maximum = _formMain.ModCnt * _formMain.ModH;
            endModNumeric.Maximum = _formMain.ModCnt;
            endPxNumeric.Maximum = _formMain.ModCnt * _formMain.ModH;
            endModNumeric.Value = _formMain.ModCnt;
            endPxNumeric.Value = _formMain.ModCnt * _formMain.ModH;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (!string.IsNullOrEmpty(symbolCombo.Text) && External.FileExists($@"resources/symbols/{symbolCombo.Text}.bmp"))
                SymbolGenFun(symbolCombo.Text, (int)OffPxNumeric.Value, (int)endPxNumeric.Value, centerCheckBox.Checked);
            else MessageBox.Show(@"Symbol not found", @"Symbol insert error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        public void SymbolGenFun(string symbol, int offset, int end, bool center)
        {
            var symbolBmp = (Bitmap)Image.FromFile($@"resources/symbols/{symbol}.bmp");

            if (end - offset < symbolBmp.Width)
            {

                MessageBox.Show(@"The selected symbol doesn't fit in the allowed area.", 
                    @"Symbol insert error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (center) offset += (end - offset - symbolBmp.Width) / 2;

            var pan = _formMain.containerPanel.Controls;
            var n = offset;
            for (int i = 0; i < symbolBmp.Width; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    pan.Find((n + i + (j * _formMain.ModCnt * _formMain.ModH)).ToString(), false)[0].BackColor =
                        symbolBmp.GetPixel(i, j) != Color.FromArgb(0, 0, 0)
                            ? _formMain.ActiveColor
                            : _formMain.InactiveColor;
                }
            }
            SDK.ScreenUpdated(_formMain.GetBitArray());
        }

        private void OffModNumeric_ValueChanged(object sender, EventArgs e)
        {
            OffPxNumeric.Value = OffModNumeric.Value * _formMain.ModH;
        }

        private void endModNumeric_ValueChanged(object sender, EventArgs e)
        {
            endPxNumeric.Value = endModNumeric.Value * _formMain.ModH;
        }
    }
}
