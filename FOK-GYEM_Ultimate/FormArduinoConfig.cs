using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using PluginBase;

namespace FOK_GYEM_Ultimate
{
    public partial class FormArduinoConfig : Form
    {
        private FormMain _formMain;
        private ArduinoGenerator _generator;
        private string _saveLoc;

        public FormArduinoConfig(Form main, ArduinoGenerator generator, string saveLocation)
        {
            InitializeComponent();
            _formMain = main as FormMain;
            _generator = generator;
            _saveLoc = saveLocation;
            ClearCombo.SelectedIndex = 0;
            loopClearCombo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (!_generator.Ready)
            {
                MessageBox.Show(@"An error occurred. Please try again later.", @"main.cpp export error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BitArray output = flipCheck.Checked ? _formMain.GetUpsideDownArray() : _formMain.GetBitArray();

            var re = _generator.GenerateBasic(Utils.ToByteArray(output, true), 
                _saveLoc,
                int.Parse(ClearCombo.Text[..1]), 
                loopCheck.Checked, 
                (int)delayNumeric.Value, 
                flipCheck.Checked,
                int.Parse(loopClearCombo.Text[..1]));
            if (re)
                MessageBox.Show(@"Export success!", @"main.cpp export success", MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            else
                MessageBox.Show(@"An error occurred. Please try again later.", @"main.cpp export error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }
}
