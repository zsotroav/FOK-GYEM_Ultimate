using PluginBase;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FOK_GYEM_Ultimate
{
    public partial class FormSymbol : Form
    {
        private FormMain _formMain;
        public FormSymbol(Form main)
        {
            _formMain = main as FormMain;
            InitializeComponent();

            var symbols = ResourceLoader.GetResourceListPattern("symbols", "*.bmp");
            var n = 0;
            foreach (var symbol in symbols)
            {
                symbolCombo.Items.Add(symbol);
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
            if (!string.IsNullOrEmpty(symbolCombo.Text) &&
                ResourceLoader.GetResourcePath("symbols", $"{symbolCombo.Text}.bmp") != "")
                SymbolGenFun(symbolCombo.Text, (int)OffPxNumeric.Value, (int)endPxNumeric.Value, centerCheckBox.Checked);
            else MessageBox.Show(@"Symbol not found", @"Symbol insert error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        public void SymbolGenFun(string symbol, int offset, int end, bool center)
        {
            var symbolBmp = (Bitmap)Image.FromFile(ResourceLoader.GetResourcePath("symbols", $"{symbol}.bmp"));

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
