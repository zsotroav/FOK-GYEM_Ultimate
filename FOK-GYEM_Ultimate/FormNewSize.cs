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
    public partial class FormNewSize : Form
    {
        private FormMain _formMain;
        public FormNewSize(Form main)
        {
            InitializeComponent();
            _formMain = main as FormMain;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Maximum = numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            _formMain.GenModules((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Close();
        }
    }
}
