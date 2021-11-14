using System;
using System.Collections;
using System.Drawing;
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
            panelDataStrip.Text = n.ToString();

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

        #region Panel menu strip

        public void ResetPanel(object sender, EventArgs e)
        {
            foreach (Control c in containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = Color.DarkGray;
            }
        }
        
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
            }

            for (int i = 0; i < primary.Length; i++)
            {
                var t = 0;
                for (int j = 0; j < 8; j++)
                {
                    t *= 2;
                    t += primary[i] % 2;
                    primary[i] >>= 1;
                }

                primary[i] = Convert.ToByte(t);
            }

            var bits = new BitArray(primary);

            if (bits.Length/(7*24) != ModCnt) GenModules(bits.Length/(7*24),0);

            for (var i = 0; i < bits.Length; i++)
            {
                c.Find(i.ToString(), false)[0].BackColor = bits[i] ? Color.Black : Color.DarkGray;
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

            External.SaveBin(saveDialog.FileName, External.ToByteArray(output));
        }
        #endregion
    }
}
