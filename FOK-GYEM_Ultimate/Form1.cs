using PluginBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using zsotroav;

namespace FOK_GYEM_Ultimate
{
    public partial class FormMain : Form
    {
        public Color InactiveColor;
        public Color ActiveColor;

        public int ModCnt = Config.ModuleCount;
        public int ModCut = Config.ModuleCut;
        internal ConfigLoader ConfLoader = new();
        
        public FormMain()
        {
            ConfLoader.Init("FOK-GYEM_ultimate");
            InitializeComponent();

            LoadConfig();
            GenModules(ModCnt,ModCut);

            try { PluginsInit(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Encountered exception while loading plugin", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            SDK.UpdatePixelEvent += SetPixel;
            SDK.CommunicateEvent += PluginCommunicate;
        }

        private void LoadConfig()
        {
            // Try-Catch is needed in case there is no config for a variable yet

            try
            {
                ModCnt = ConfLoader.GetInt("ModCnt");
                Config.ModuleCount = ModCnt;
            }
            catch
            {
                ModCnt = 7;
                ConfLoader.Set("ModCnt", "7");
            }

            try
            {
                ModCut = ConfLoader.GetInt("ModCut");
                Config.ModuleCut = ModCut;
            }
            catch
            {
                ModCut = 3;
                ConfLoader.Set("ModCut", "3");
            }
            
            try
            {
                ActiveColor = ColorTranslator.FromHtml(ConfLoader.Get("ActiveColor"));
            }
            catch
            {
                ActiveColor = Color.Black;
                ConfLoader.Set("ActiveColor", "Black");
            }

            try
            {
                InactiveColor = ColorTranslator.FromHtml(ConfLoader.Get("InactiveColor"));
            }
            catch
            {
                InactiveColor = Color.DarkGray;
                ConfLoader.Set("InactiveColor", "DarkGray");
            }
        }

        #region Plugins

        private void PluginsInit()
        {
            var loadLocations = ConfLoader.GetPlugins();
            if (loadLocations.Length <= 0) return;
            IEnumerable<IPlugin> tasks = loadLocations.SelectMany(pluginPath =>
            {
                Assembly pluginAssembly = LoadPlugin(pluginPath);
                return CreateCommands(pluginAssembly);
            }).ToList();
            pluginsToolStripMenuItem.Enabled = true;
            foreach (IPlugin task in tasks)
            {
                task.Init(GenContext());
                pluginsToolStripMenuItem.DropDownItems.Add($"{task.Name} by {task.Author}");
                pluginsToolStripMenuItem.DropDownItems[^1].Click += (_, _) => 
                    MessageBox.Show($"{task.Description}\n\n{task.Link}", $@"{task.Name} by {task.Author} - FOK-GYEM_Ultimate",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (var action in task.Actions)
                {
                    var menu = pluginsToolStripMenuItem;
                    switch (action.Menu)
                    {
                        case Menu.About:
                            menu = aboutToolStripMenuItem;
                            break;
                        case Menu.Load:
                            menu = loadToolStripMenuItem;
                            break;
                        case Menu.Export:
                            menu = saveToolStripMenuItem;
                            break;
                        case Menu.Panel:
                            menu = panelToolStripMenuItem;
                            break;
                        case Menu.Edit:
                            menu = editToolStripMenuItem;
                            break;
                        case Menu.Preferences:
                            menu = preferencesToolStripMenuItem;
                            break;
                    }

                    var item = new ToolStripMenuItem();
                    item.Name = action.ActionName;
                    item.Text = action.ActionName;
                    item.Click += (_, _) =>
                        task.Run(GenContext(),
                            action.ActionID);

                    if (action.SubActions != null)
                    {
                        foreach (var subAction in action.SubActions)
                        {
                            var subMenuItem = new ToolStripMenuItem();
                            subMenuItem.Name = subAction.ActionName;
                            subMenuItem.Text = subAction.ActionName;
                            subMenuItem.Click += (_, _) =>
                                task.Run(GenContext(),
                                    subAction.ActionID);
                            item.DropDownItems.Add(subMenuItem);
                        }
                    }

                    menu.DropDownItems.Add(item);
                }
            }
        }

        public IContext GenContext() => new PluginLoadContext.Context(GetBitArray());
        
        static Assembly LoadPlugin(string relativePath)
        {
            var pluginLocation = relativePath;
            var loadContext = new PluginLoadContext(pluginLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }

        private static IEnumerable<IPlugin> CreateCommands(Assembly assembly)
        {
            int count = 0;

            foreach (Type type in assembly.GetTypes())
            {
                if (!typeof(IPlugin).IsAssignableFrom(type)) continue;
                if (Activator.CreateInstance(type) is not IPlugin result) continue;

                count++;
                yield return result;
            }
        }

        private void PluginCommunicate(string title, string text, string icon = "info")
        {
            var ico = icon switch
            {
                "info" => MessageBoxIcon.Information,
                "error" => MessageBoxIcon.Error,
                "warning" => MessageBoxIcon.Warning,
                "question" => MessageBoxIcon.Question
            };
            MessageBox.Show(text, title, MessageBoxButtons.OK, ico);
        }

        #endregion

        #region Module and panel manipulations

        public void GenModules(int n, int cut)
        {
            ModCnt = n;
            Config.ModuleCount = n;
            ModCut = cut;
            Config.ModuleCut = cut;
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
            Config.ModuleCut = cut;
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
            SDK.PixelUpdated(new pixelData(new loc(int.Parse(p.Name)), p.BackColor == ActiveColor));
        }

        public bool SetPixel(pixelData data)
        {
            var controls = containerPanel.Controls;
            var p = controls.Find(data.loc.serial.ToString(), false)[0];
            p.BackColor = data.state ? ActiveColor : InactiveColor;

            SDK.PixelUpdated(data); // Called to let the other plugins know that data has changed
            return p.BackColor == ActiveColor;
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
            FlipVertically(null, null);
            BitArray output = GetBitArray();
            FlipVertically(null, null);

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

            SDK.ScreenUpdated(bits);
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

            SDK.ScreenUpdated(GetBitArray());
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
            SDK.ScreenUpdated(new BitArray(Config.ModuleCount*Config.ModuleH*Config.ModuleV, false));
        }
        
        public void InvertPanel(object sender, EventArgs e)
        {
            foreach (Control c in containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = c.BackColor == InactiveColor ? ActiveColor : InactiveColor;
            }
            SDK.ScreenUpdated(GetBitArray());
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
            SDK.ScreenUpdated(GetBitArray());
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

        private void creditsAboutStrip_Click(object sender, EventArgs e)
        {
            FormCredits formCredits = new();
            formCredits.Show();
        }
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
        
        private AnimationFrame _currentFrame;
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
                framesLabel.Enabled = frameSelLabel.Enabled = frameCombo.Enabled = loopCheck.Enabled = 
                animUpBtn.Enabled = animDownBtn.Enabled = animDelBtn.Enabled = animSaveBtn.Enabled =
                animRelBtn.Enabled = en;

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

            _currentFrame = Animation.GetFrameByName(frameCombo.Text);
            var bits = _currentFrame.Frame;
            var c = containerPanel.Controls;
            for (var i = 0; i < bits.Length; i++)
            {
                c.Find(i.ToString(), false)[0].BackColor = bits[i] ? ActiveColor : InactiveColor;
            }

            SDK.ScreenUpdated(_currentFrame.Frame);
        }

        private void animUpBtn_Click(object sender, EventArgs e)
        {
            if (_currentFrame.i - 1 >= 0 && _currentFrame.i - 1 < Animation.FrameCount)
                Animation.AnimationFrames.Reverse(_currentFrame.i - 1, 2);
            updateFrameCombo();
        }

        private void animDownBtn_Click(object sender, EventArgs e)
        {
            if (_currentFrame.i >= 0 && _currentFrame.i < Animation.FrameCount)
                Animation.AnimationFrames.Reverse(_currentFrame.i, 2);
            updateFrameCombo();
        }

        private void animDelBtn_Click(object sender, EventArgs e)
        {
            Animation.AnimationFrames.RemoveAt(_currentFrame.i);
            updateFrameCombo();
        }
        
        private void animSaveBtn_Click(object sender, EventArgs e) =>
            Animation.AnimationFrames[_currentFrame.i].Frame = GetBitArray();


        private void animRelBtn_Click(object sender, EventArgs e) =>
            frameCombo_SelectedValueChanged(sender, e);

        private void updateFrameCombo()
        {
            frameCombo.Items.Clear();
            foreach (var name in Animation.GetAllNames())
            {
                frameCombo.Items.Add(name);
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
                    Animation.NewFrame(tmp2, $"Pat{Animation.FrameCount} ({type})", 0);
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
                    Animation.NewFrame(tmp3, $"Pat{Animation.FrameCount} ({type})", 0);
                    for (int i = 0; i < tmp.Length; i++)
                    {
                        if (i % 2 == 0) tmp[i] = false;
                        else tmp[i] = true;
                    }
                    break;
            }
            
            Animation.NewFrame(tmp, $"pat{Animation.FrameCount} ({type})", 0);
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
