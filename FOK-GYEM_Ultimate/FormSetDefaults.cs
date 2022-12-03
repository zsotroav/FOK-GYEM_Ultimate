using System;
using System.Drawing;
using System.Windows.Forms;

namespace FOK_GYEM_Ultimate
{
    public partial class FormSetDefaults : Form
    {
        private Color _oldActive;
        private Color _oldInactive;
        private int _oldCnt;
        private int _oldCut;
        private FormMain _formMain;

        public FormSetDefaults(Form main)
        {
            InitializeComponent();
            _formMain = main as FormMain;
            _oldActive = _formMain.ActiveColor;
            textActive.Text = ColorTranslator.ToHtml(_oldActive);
            _oldInactive = _formMain.InactiveColor;
            textInactive.Text = ColorTranslator.ToHtml(_oldInactive);
            _oldCnt = _formMain.ModCnt;
            numericCnt.Value = _oldCnt;
            _oldCut = _formMain.ModCut;
            numericCut.Value = _oldCut;
        }

        private void btnActive_Click(object sender, EventArgs e)
        {

            var dr = colorDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textInactive.Text = ColorTranslator.ToHtml(colorDialog1.Color);
            }
        }

        private void btnInactive_Click(object sender, EventArgs e)
        {
            var dr = colorDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textInactive.Text = ColorTranslator.ToHtml(colorDialog1.Color);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _formMain.ActiveColor = ColorTranslator.FromHtml(textActive.Text);
            _formMain.InactiveColor = ColorTranslator.FromHtml(textInactive.Text);

            _formMain.ConfLoader.Set("ModCnt", numericCnt.Value.ToString(), false);
            _formMain.ConfLoader.Set("ModCut", numericCut.Value.ToString(), false);
            _formMain.ConfLoader.Set("ActiveColor", textActive.Text, false);
            _formMain.ConfLoader.Set("InactiveColor", textInactive.Text);
            
            foreach (Control c in _formMain.containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = c.BackColor == _oldActive ? _formMain.ActiveColor : _formMain.InactiveColor;
            }
            Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            textActive.Text = ColorTranslator.ToHtml(Color.Black);
            textInactive.Text = ColorTranslator.ToHtml(Color.DarkGray);
            numericCnt.Value = 7;
            numericCut.Value = 3;
        }
    }
}
