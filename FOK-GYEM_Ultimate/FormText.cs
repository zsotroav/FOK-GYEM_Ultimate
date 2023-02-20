using PluginBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using zsotroav;

namespace FOK_GYEM_Ultimate
{
    public partial class FormText : Form
    {
        private FormMain _formMain;
        public FormText(Form main)
        {
            _formMain = main as FormMain;
            InitializeComponent();

            string[] fonts = Directory.GetFiles(@"resources/fonts/", "*.bmp");
            var n = 0;
            foreach (var font in fonts)
            {
                if (!External.FileExists($@"resources/fonts/{External.NameNoExtFromPath(font)}_structure.txt")) continue;
                fontCombo.Items.Add(External.NameNoExtFromPath(font));
                n++;
            }
            if (n == 0)
            {
                MessageBox.Show(@"Couldn't find a single font!", @"Text insert error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            fontCombo.SelectedIndex = 0;
            OffModNumeric.Maximum = _formMain.ModCnt;
            OffPxNumeric.Maximum = _formMain.ModCnt * 24;
            endModNumeric.Maximum = _formMain.ModCnt;
            endPxNumeric.Maximum = _formMain.ModCnt * 24;
            endModNumeric.Value = _formMain.ModCnt;
            endPxNumeric.Value = _formMain.ModCnt * 24;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (!string.IsNullOrEmpty(fontCombo.Text) && External.FileExists($@"resources/fonts/{fontCombo.Text}.bmp"))
                TextGenFun(fontCombo.Text, textBox.Text, (int) OffPxNumeric.Value, centerCheckBox.Checked);
            else MessageBox.Show(@"Font not found", @"Text insert error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }


        public void TextGenFun(string font, string text, int offset, bool center)
        {
            var fontBmp = (Bitmap)Image.FromFile($@"resources/fonts/{font}.bmp");
            var sr = new StreamReader($@"resources/fonts/{font}_structure.txt", Encoding.UTF8);

            Dictionary<char, int[]> chars = new();
            var n = 0;
            var prev = 0;
            for (int i = 0; i < fontBmp.Width; i++)
            {
                if (fontBmp.GetPixel(i, 0) != Color.FromArgb(0, 0, 0)) continue;
                n++;
                chars.Add((char)sr.Read(), new[] { prev, i });
                prev = i;
            }

            var ch = text.ToCharArray();

            n = 0;
            foreach (var c in ch)
            {
                if (!chars.ContainsKey(c))
                {
                    MessageBox.Show($@"Character '{c}' is not supported in the selected font. Aborting...", 
                        @"Text insert error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                n += chars[c][1] - chars[c][0] - 1;
                if (n <= (int)endPxNumeric.Value - offset) continue;
                MessageBox.Show(@"This much text would overflow. Please try again with a shorter text.", 
                    @"Text insert error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (center) offset += ((int)endPxNumeric.Value - offset - n) / 2;


            var pan = _formMain.containerPanel.Controls;
            n = offset;
            foreach (var c in ch)
            {

                for (int i = 0; i < chars[c][1] - chars[c][0]; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        pan.Find((n + i + (j * _formMain.ModCnt*24)).ToString(), false)[0].BackColor =
                            fontBmp.GetPixel(chars[c][0] + 1 + i, j + 2) != Color.FromArgb(0, 0, 0)
                                ? _formMain.ActiveColor
                                : _formMain.InactiveColor;
                    }
                }

                n += chars[c][1] - chars[c][0] - 1;
            }
            SDK.ScreenUpdated(_formMain.GetBitArray());
        }

        private void OffModNumeric_ValueChanged(object sender, EventArgs e)
        {
            OffPxNumeric.Value = OffModNumeric.Value * 24;
        }

        private void endModNumeric_ValueChanged(object sender, EventArgs e)
        {
            endPxNumeric.Value = endModNumeric.Value * 24;
        }
    }
}
