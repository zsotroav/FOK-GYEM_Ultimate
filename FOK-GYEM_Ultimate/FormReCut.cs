using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FOK_GYEM_Ultimate
{
    public partial class FormReCut : Form
    {
        private FormMain _formMain;
        public FormReCut(Form main, int max)
        {
            _formMain = main as FormMain;
            InitializeComponent();
            numericUpDown1.Maximum = max;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            _formMain.SetCut((int)numericUpDown1.Value);
            this.Close();
        }
    }
}
