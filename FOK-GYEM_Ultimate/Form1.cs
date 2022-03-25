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
        public Color InactiveColor;
        public Color ActiveColor;

        public int ModCnt;
        public int ModCut;
        internal Config Conf = new();
        public FormMain()
        {
            Conf.Init("FOK-GYEM_ultimate");
            InitializeComponent();

            LoadConfig();
            GenModules(ModCnt,ModCut);
        }

        private void LoadConfig()
        {
            // Try-Catch is needed in case there is no config for a variable yet

            try
            {
                ModCnt = Conf.GetInt("ModCnt");
            }
            catch
            {
                ModCnt = 7;
                Conf.Set("ModCnt", "7");
            }

            try
            {
                ModCut = Conf.GetInt("ModCut");
            }
            catch
            {
                ModCut = 3;
                Conf.Set("ModCut", "3");
            }
            
            try
            {
                ActiveColor = ColorTranslator.FromHtml(Conf.Get("ActiveColor"));
            }
            catch
            {
                ActiveColor = Color.Black;
                Conf.Set("ActiveColor", "Black");
            }

            try
            {
                InactiveColor = ColorTranslator.FromHtml(Conf.Get("InactiveColor"));
            }
            catch
            {
                InactiveColor = Color.DarkGray;
                Conf.Set("InactiveColor", "DarkGray");
            }
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
                    p.BackColor = InactiveColor;
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
            p.BackColor = (p.BackColor == InactiveColor) ? ActiveColor : InactiveColor;
        }
        #endregion

        #region Utils

        public BitArray GetBitArray()
        {
            BitArray output = new(24 * 7 * ModCnt);
            var c = containerPanel.Controls;
            for (int i = 0; i < 24 * 7 * ModCnt; i++)
            {
                output[i] = c.Find(i.ToString(), false)[0].BackColor == ActiveColor;
            }

            return output;
        }

        public BitArray GetUpsideDownArray()
        {
            BitArray output = new(24 * 7 * ModCnt);
            var c = containerPanel.Controls;

            for (int y = 0; y < 7; y++)
            {
                for (int x = 1; x <= 24 * ModCut; x++)
                {
                    output[y * ModCnt * 24 + x - 1] =
                        c.Find((24 * ModCnt * y + ModCut * 24 - x).ToString(), false)[0].BackColor == ActiveColor;
                }

                for (int x = 1; x < 24 * (ModCnt - ModCut); x++)
                {
                    output[ModCnt * 24 * (y + 1) - x] =
                        c.Find((ModCnt * 24 * (y) + x + ModCut * 24).ToString(), false)[0].BackColor == ActiveColor;
                }
            }

            return output;
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
                c.Find(i.ToString(), false)[0].BackColor = bits[i] ? ActiveColor : InactiveColor;
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
                        Color.FromArgb(gs, gs, gs) == Color.FromArgb(0, 0, 0) ? InactiveColor : ActiveColor;
                }
            }
        }
        #endregion

        #region Save/Export

        private void ExportBin(object sender, EventArgs e)
        {
            saveDialog.Filter = @"Binary file|*.bin";
            saveDialog.DefaultExt = ".bin";
            saveDialog.FileName = "output.bin";
            var dr = saveDialog.ShowDialog();

            if (dr != DialogResult.OK) return;

            var output = GetBitArray();

            External.SaveBin(saveDialog.FileName, Utils.ToByteArray(output, true));
            MessageBox.Show(@"File saved successfully.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportBmp(object sender, EventArgs e)
        {
            saveDialog.Filter = @"Bitmap file|*.bmp";
            saveDialog.DefaultExt = ".bmp";
            saveDialog.FileName = "output.bmp";
            var dr = saveDialog.ShowDialog();
            if (dr != DialogResult.OK) return;

            Bitmap bmp = new(24*ModCnt, 7);
            var c = containerPanel.Controls;
            for (int x = 0; x < 24*ModCnt; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    bmp.SetPixel(x, y,
                        c.Find((x + y * 24 * ModCnt).ToString(), false)[0].BackColor == InactiveColor
                            ? Color.Black
                            : Color.White);
                }
            }

            bmp.Save(saveDialog.FileName);
            MessageBox.Show(@"File saved successfully.", @"Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ArduinoGenerator _generator;
        private void ExportMainCpp(object sender, EventArgs e)
        {
            saveDialog.Filter = @"szig-fok-gyem compatible main.cpp|main.cpp|C++ source code|*.cpp";
            saveDialog.DefaultExt = ".cpp";
            saveDialog.FileName = "main.cpp";
            var dr = saveDialog.ShowDialog();
            if (dr != DialogResult.OK) return;

            if (_generator is not ArduinoGenerator)
            {
                _generator = new ArduinoGenerator();
            }

            if (!_generator.Init())
            {
                MessageBox.Show(@"An error occurred. Please try again later.", @"main.cpp export error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FormArduinoConfig configForm = new(this, _generator, saveDialog.FileName);
            configForm.Show();
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
                if (c is Panel) c.BackColor = InactiveColor;
            }
        }
        
        public void InvertPanel(object sender, EventArgs e)
        {
            foreach (Control c in containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = c.BackColor == InactiveColor ? ActiveColor : InactiveColor;
            }
        }

        public void FlipVertically(object sender, EventArgs e)
        {
            var copy = new BitArray(ModCnt * 24 * 7);
            var c = containerPanel.Controls;
            for (int i = 0; i < 24 * 7 * ModCnt; i++)
                copy[i] = c.Find(i.ToString(), false)[0].BackColor == Color.Black;

            for (int i = 0; i < ModCnt * 24; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    c.Find((i + j * 24 * ModCnt).ToString(), false)[0].BackColor =
                        copy[i + (6 - j) * 24 * ModCnt] ? ActiveColor : InactiveColor;
                }
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

        private void symbolEditStrip_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"resources/symbols/"))
            {

                var formSymbol= new FormSymbol(this);
                formSymbol.Show();
            }
            else
            {
                MessageBox.Show(@"Couldn't find the resources/symbols directory.", @"Error",
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

        #region Preferences menu strip

        private void setColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formColorPref = new FormColorPref(this);
            formColorPref.Show();
        }

        private void setDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formSetDefaults = new FormSetDefaults(this);
            formSetDefaults.Show();
        }

        #endregion

        #region Animation

        public Animation Animation;
        private void animBtn_Click(object sender, EventArgs e)
        {
            var en = false;
            if (Animation is null)
            {
                Animation = new Animation();
                newSizeToolStripMenuItem.Enabled = false;
                en = true;
                animBtn.Text = @"Disable Animation";
                Animation.NewFrameName += AddName;
            }
            else
            {
                Animation = null;
                newSizeToolStripMenuItem.Enabled = true;
                animBtn.Text = @"Enable Animation";
            }
            frameBtn.Enabled = transBtn.Enabled = animExpBtn.Enabled =
                delayLabel.Enabled = delayNumeric.Enabled = transitionCombo.Enabled = 
                framesLabel.Enabled = frameSelLabel.Enabled = frameCombo.Enabled = loopCheck.Enabled = en;

            framesLabel.Text = @"Number of frames: 0";
            frameCombo.Items.Clear();
            frameCombo.Text = "";
            transitionCombo.SelectedIndex = 0;
            delayNumeric.Value = 1000;
        }
        
        private void AddName(string name) => frameCombo.Items.Add(name);

        private void loopCheck_Click(object sender, EventArgs e) => loopNumeric.Enabled = loopCheck.Checked;

        private void frameBtn_Click(object sender, EventArgs e)
        {
            Animation.NewFrame(GetBitArray(), $"Frame {Animation.FrameCount}", (int)delayNumeric.Value);
            framesLabel.Text = @"Number of frames: " + Animation.FrameCount;
        }

        private void frameCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!frameCombo.Items.Contains(frameCombo.Text)) return;

            var bits = Animation.Frames[Animation.FrameDictionary[frameCombo.Text]];
            var c = containerPanel.Controls;
            for (var i = 0; i < bits.Length; i++)
            {
                c.Find(i.ToString(), false)[0].BackColor = bits[i] ? ActiveColor : InactiveColor;
            }
        }

        private void transBtn_Click(object sender, EventArgs e)
        {
            var type = transitionCombo.Text;
            var tn = int.Parse(type[..1]);

            var tmp = new BitArray(7*24*ModCnt);

            switch (tn)
            {
                case 1:
                    // 11111111
                    for (int i = 0; i < tmp.Length; i++) tmp[i] = true;
                    break;
                case 2:
                    // 00000000
                    for (int i = 0; i < tmp.Length; i++) tmp[i] = false;
                    break;
                case 3:
                    // 11111111 00000000
                    var tmp2 = new BitArray(7 * 24 * ModCnt);
                    for (int i = 0; i < tmp2.Length; i++) tmp2[i] = true;
                    Animation.NewFrame(tmp2, $"Transition {Animation.FrameCount} ({type})", 0);
                    for (int i = 0; i < tmp.Length; i++) tmp[i] = false;
                    break;
                case 4:
                    // 10101010
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (i % 2 == 0) tmp[i] = true;
                        else tmp[i] = false;
                    }
                    break;
                case 5:
                    // 01010101
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (i % 2 == 0) tmp[i] = false;
                        else tmp[i] = true;
                    }
                    break;
                case 6:
                    // 10101010 01010101
                    var tmp3 = new BitArray(7 * 24 * ModCnt);
                    for (int i = 0; i < tmp3.Length; i++)
                    {
                        if (i % 2 == 0) tmp3[i] = true;
                        else tmp3[i] = false;
                    }
                    Animation.NewFrame(tmp3, $"Transition {Animation.FrameCount} ({type})", 0);
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (i % 2 == 0) tmp[i] = false;
                        else tmp[i] = true;
                    }
                    break;
            }
            
            Animation.NewFrame(tmp, $"Transition {Animation.FrameCount} ({type})", 0);
            framesLabel.Text = @"Number of frames: " + Animation.FrameCount;
        }

        private void animExpBtn_Click(object sender, EventArgs e)
        {
            saveDialog.Filter = @"szig-fok-gyem compatible main.cpp|main.cpp|C++ source code|*.cpp";
            saveDialog.DefaultExt = ".cpp";
            saveDialog.FileName = "main.cpp";
            var dr = saveDialog.ShowDialog();
            if (dr != DialogResult.OK) return;

            Animation.Export(saveDialog.FileName, loopCheck.Checked, (int)loopNumeric.Value);
        }

        #endregion

    }
}
