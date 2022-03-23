using System;
using System.Drawing;
using System.Windows.Forms;

namespace FOK_GYEM_Ultimate
{
    public partial class FormColorPref : Form
    {
        private Color _oldActive;
        private Color _oldInactive;
        private FormMain _formMain;
        public FormColorPref(Form main)
        {
            InitializeComponent();
            _formMain = main as FormMain;

            _oldActive = _formMain.ActiveColor;
            _oldInactive = _formMain.InactiveColor;
            textActive.Text = ColorTranslator.ToHtml(_oldActive);
            textInactive.Text = ColorTranslator.ToHtml(_oldInactive);
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            var dr = colorDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                textActive.Text = ColorTranslator.ToHtml(colorDialog1.Color);
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

        private void button1_Click(object sender, EventArgs e)
        {
            _formMain.ActiveColor = ColorTranslator.FromHtml(textActive.Text);
            _formMain.InactiveColor = ColorTranslator.FromHtml(textInactive.Text);

            foreach (Control c in _formMain.containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = c.BackColor == _oldActive ? _formMain.ActiveColor : _formMain.InactiveColor;
            }
            Close();
        }
    }
}
