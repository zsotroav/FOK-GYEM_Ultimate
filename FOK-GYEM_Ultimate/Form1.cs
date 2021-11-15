using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using zsotroav;

namespace FOK_GYEM_Ultimate
{
    public partial class FormMain : Form
    {
        public int ModCnt = 7;
        public int ModCut = 3;
        public FormMain()
        {
            InitializeComponent();

            GenModules(ModCnt,ModCut);
        }

        #region Module and panel manipulations

        public void GenModules(int n, int cut)
        {
            ModCnt = n;
            ModCut = cut;
            panelDataAStrip.Text = cut.ToString();
            panelDataBStrip.Text = (n-cut).ToString();

            containerPanel.Controls.Clear();
            for (int i = 0; i < n*24; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    var p = new Panel();
                    p.Name = (i + (j - 1) * 24 * n).ToString();
                    p.Size = new Size(10, 10);
                    int x = i * 12 + (i / 24 * 5) - (i / 24 < cut ? 0 : cut * 24 * 12 + cut * 5);
                    int y = j * 12 + (i / 24 < cut ? 0 : 8*12);
                    p.Location = new Point(x, y);
                    p.BackColor = Color.DarkGray;
                    p.Click += PanelClick;
                    containerPanel.Controls.Add(p);
                }
            }
        }

        public void SetCut(int cut)
        {
            ModCut = cut;
            panelDataAStrip.Text = cut.ToString();
            panelDataBStrip.Text = (ModCnt - cut).ToString();

            var controls = containerPanel.Controls;
            for (int i = 0; i < ModCnt * 24; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    var p = controls.Find((i + (j - 1) * 24 * ModCnt).ToString(),false)[0];
                    int x = i * 12 + (i / 24 * 5) - (i / 24 < cut ? 0 : cut * 24 * 12 + cut * 5);
                    int y = j * 12 + (i / 24 < cut ? 0 : 8 * 12);
                    p.Location = new Point(x, y);
                }
            }
        }

        private void PanelClick(object sender, EventArgs e)
        {
            var p = sender as Panel;
            p.BackColor = (p.BackColor == Color.DarkGray) ? Color.Black : Color.DarkGray;
        }
        #endregion
        
        #region Load/Import
        
        private void LoadFromBin(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"Binary files|*.bin";
            openFileDialog1.ShowDialog();

            var loc = openFileDialog1.FileName;
            if (string.IsNullOrEmpty(loc) || !External.FileExists(loc)) return;

            var c = containerPanel.Controls;
            var primary = External.LoadBin(loc);

            if (primary.Length > 336 || primary.Length % 21 != 0)
            {
                MessageBox.Show(@"This bin file is either too large or in an not processable format.", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            primary = Utils.ReverseBytes(primary);

            var bits = new BitArray(primary);

            if (bits.Length/(7*24) != ModCnt) GenModules(bits.Length/(7*24),0);

            for (var i = 0; i < bits.Length; i++)
            {
                c.Find(i.ToString(), false)[0].BackColor = bits[i] ? Color.Black : Color.DarkGray;
            }
        }

        private void LoadFromBmp(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"Bitmap files|*.bmp|Portable Network Graphics|*.png";
            openFileDialog1.ShowDialog();
            var loc = openFileDialog1.FileName;
            if (string.IsNullOrEmpty(loc) || !External.FileExists(loc)) return;

            var bmp = new Bitmap(Image.FromFile(loc));

            if (bmp.Width % 24 != 0 || bmp.Height != 7)
            {
                MessageBox.Show(@"Bitmap dimensions are incorrect", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bmp.Width / 24 != ModCnt) GenModules(bmp.Width / 24, bmp.Width / 24);
            
            var c = containerPanel.Controls;
            for (int x = 0; x < 24 * ModCnt; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    var col = bmp.GetPixel(x, y);
                    var gs = (Int32)(col.R * 0.3 + col.G * 0.59 + col.B * 0.11);
                    c.Find((x + y * 24 * ModCnt).ToString(), false)[0].BackColor =
                        Color.FromArgb(gs, gs, gs) == Color.FromArgb(0, 0, 0) ? Color.DarkGray : Color.Black;
                }
            }
        }
        #endregion

        #region Save/Export

        private void ExportBin(object sender, EventArgs e)
        {
            saveDialog.Filter = @"Binary file|*.bin";
            saveDialog.DefaultExt = ".bin";
            var dr = saveDialog.ShowDialog();

            if (dr != DialogResult.OK) return;

            BitArray output = new(24 * 7 * ModCnt);
            var c = containerPanel.Controls;
            for (int i = 0; i < 24*7*ModCnt; i++)
            {
                output[i] = c.Find(i.ToString(), false)[0].BackColor == Color.Black;
            }

            External.SaveBin(saveDialog.FileName, Utils.ToByteArrayFlip(output));
            MessageBox.Show(@"File saved successfully.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportBmp(object sender, EventArgs e)
        {
            saveDialog.Filter = @"Bitmap file|*.bmp";
            saveDialog.DefaultExt = ".bmp";
            var dr = saveDialog.ShowDialog();
            if (dr != DialogResult.OK) return;

            Bitmap bmp = new(24*ModCnt, 7);
            var c = containerPanel.Controls;
            for (int x = 0; x < 24*ModCnt; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    bmp.SetPixel(x, y,
                        c.Find((x + y * 24 * ModCnt).ToString(), false)[0].BackColor == Color.DarkGray
                            ? Color.Black
                            : Color.White);
                }
            }

            bmp.Save(saveDialog.FileName);
            MessageBox.Show(@"File saved successfully.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Panel menu strip

        private void setNewBreakpointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReCut = new FormReCut(this, ModCnt);
            formReCut.Show();
        }

        private void newSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNewSize = new FormNewSize(this);
            formNewSize.Show();
        }

        #endregion

        #region Edit menu strip

        public void ClearPanel(object sender, EventArgs e)
        {
            foreach (Control c in containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = Color.DarkGray;
            }
        }
        
        public void InvertPanel(object sender, EventArgs e)
        {
            foreach (Control c in containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = c.BackColor == Color.DarkGray? Color.Black : Color.DarkGray;
            }
        }

        public void TextGen(object sender, EventArgs e)
        {
            if (Directory.Exists(@"resources/fonts/"))
            {

                var formText = new FormText(this);
                formText.Show();
            }
            else
            {
                MessageBox.Show(@"Couldn't find the resources/fonts directory.", @"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region About menu strip

        private void wikiAboutStrip_Click(object sender, EventArgs e) => 
            Process.Start(new ProcessStartInfo("https://github.com/zsotroav/FOK-GYEM_Ultimate/wiki") { UseShellExecute = true });

        private void githubAboutStrip_Click(object sender, EventArgs e) =>
            Process.Start(new ProcessStartInfo("https://github.com/zsotroav/FOK-GYEM_Ultimate") { UseShellExecute = true });

        #endregion

    }
}
