using System;
using System.Drawing;
using System.Windows.Forms;

namespace FOK_GYEM_Ultimate
{
    public partial class FormColorPref : Form
    {
        private Color oldActive;
        private Color oldInactive;
        private FormMain formMain;
        public FormColorPref(Form main)
        {
            InitializeComponent();
            formMain = main as FormMain;

            oldActive = formMain.ActiveColor;
            oldInactive = formMain.InactiveColor;
            textActive.Text = ColorTranslator.ToHtml(oldActive);
            textInactive.Text = ColorTranslator.ToHtml(oldInactive);
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
            formMain.ActiveColor = ColorTranslator.FromHtml(textActive.Text);
            formMain.InactiveColor = ColorTranslator.FromHtml(textInactive.Text);

            foreach (Control c in formMain.containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = c.BackColor == oldActive ? formMain.ActiveColor : formMain.InactiveColor;
            }
            Close();
        }
    }
}
