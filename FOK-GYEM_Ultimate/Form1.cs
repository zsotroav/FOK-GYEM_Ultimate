using PluginBase;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
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

        public int ModH = Config.ModuleH;
        public int ModV = Config.ModuleV;
        internal ConfigLoader ConfLoader = new();
        
        public FormMain(string[] args)
        {
            ConfLoader.Init("FOK-GYEM_ultimate");
            InitializeComponent();

            LoadConfig();
            if (args.Length == 1 && args[0].Length > 4)
            {
                if (args[0][^4..] == ".png" || args[0][^4..] == ".bmp") LoadFromBmpFile(args[0], true);
                if (args[0][^4..] == ".bin") LoadFromBinFile(args[0], true);
            } else GenModules(ModCnt,ModCut);

            try { PluginsInit(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Encountered exception while loading plugin", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            SDK.UpdatePixelEvent += SetPixel;
            SDK.CommunicateEvent += PluginCommunicate;
            SDK.GetScreenStateEvent += GetBitArray;
        }

        private void LoadConfig()
        {
            ModCnt = ConfLoader.GetInt("ModCnt", 7);
            ModCut = ConfLoader.GetInt("ModCut", 3);
            ActiveColor = ColorTranslator.FromHtml(ConfLoader.Get("ActiveColor", "Black"));
            InactiveColor = ColorTranslator.FromHtml(ConfLoader.Get("InactiveColor", "DarkGray"));
        }

        #region Plugins

        private void PluginsInit()
        {
            var loadLocations = ResourceLoader.GetResourceListPattern("plugins", "*.dll", strip: false);
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
                var pluginItem = new ToolStripMenuItem
                {
                    Text = $@"{task.Name}"
                };
                pluginItem.Click += (_, _) => 
                    MessageBox.Show($"{task.Description}\n\n{task.Link}", $@"{task.Name} by {task.Author} - FOK-GYEM_Ultimate",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (var action in task.Actions)
                {
                    var menu = action.Menu switch
                    {
                        Menu.About => aboutToolStripMenuItem,
                        Menu.Load => loadToolStripMenuItem,
                        Menu.Export => saveToolStripMenuItem,
                        Menu.Panel => panelToolStripMenuItem,
                        Menu.Edit => editToolStripMenuItem,
                        Menu.Preferences => preferencesToolStripMenuItem,
                        _ => pluginItem
                    };
                    
                    var item = new ToolStripMenuItem
                    {
                        Name = action.ActionName,
                        Text = action.ActionName
                    };
                    item.Click += (_, _) =>
                    {
                        Thread runThread = new(() => { task.Run(GenContext(), action.ActionID); });
                        runThread.Start();
                    };

                    if (action.SubActions != null)
                    {
                        foreach (var subAction in action.SubActions)
                        {
                            var subMenuItem = new ToolStripMenuItem
                            {
                                Name = subAction.ActionName,
                                Text = subAction.ActionName
                            };
                            subMenuItem.Click += (_, _) =>
                                task.Run(GenContext(),
                                    subAction.ActionID);
                            item.DropDownItems.Add(subMenuItem);
                        }
                    }

                    menu.DropDownItems.Add(item);
                }

                pluginsToolStripMenuItem.DropDownItems.Add(pluginItem);
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
            //int count = 0;

            foreach (Type type in assembly.GetTypes())
            {
                if (!typeof(IPlugin).IsAssignableFrom(type)) continue;
                if (Activator.CreateInstance(type) is not IPlugin result) continue;

                //count++;
                yield return result;
            }
        }

        private static void PluginCommunicate(string title, string text, string icon = "info")
        {
            var ico = icon switch
            {
                "info" => MessageBoxIcon.Information,
                "error" => MessageBoxIcon.Error,
                "warning" => MessageBoxIcon.Warning,
                "question" => MessageBoxIcon.Question,
                _ => MessageBoxIcon.None
            };
            MessageBox.Show(text, title, MessageBoxButtons.OK, ico);
        }

        #endregion

        #region Module and panel manipulations

        public void GenModules(int n, int cut)
        {
            int h = ModH;
            int v = ModV;
            ModCnt = n;
            Config.ModuleCount = n;
            ModCut = cut;
            Config.ModuleCut = cut;
            panelDataAStrip.Text = cut.ToString();
            panelDataBStrip.Text = (n-cut).ToString();

            containerPanel.Controls.Clear();
            for (int i = 0; i < n * h; i++)
            {
                for (int j = 1; j <= v; j++)
                {
                    var p = new Panel
                    {
                        Name = (i + (j - 1) * h * n).ToString(),
                        Size = new Size(10, 10)
                    };
                    int x = i * 12 + (i / h * 5) - (i / h < cut ? 0 : cut * h * 12 + cut * 5);
                    int y = j * 12 + (i / h < cut ? 0 : 8*12);
                    p.Location = new Point(x, y);
                    p.BackColor = InactiveColor;
                    p.Click += PanelClick;
                    containerPanel.Controls.Add(p);
                }
            }
        }

        public void SetCut(int cut)
        {
            int h = ModH;
            int v = ModV;
            ModCut = cut;
            Config.ModuleCut = cut;
            panelDataAStrip.Text = cut.ToString();
            panelDataBStrip.Text = (ModCnt - cut).ToString();

            var controls = containerPanel.Controls;
            for (int i = 0; i < ModCnt * h; i++)
            {
                for (int j = 1; j <= v; j++)
                {
                    var p = controls.Find((i + (j - 1) * h * ModCnt).ToString(),false)[0];
                    int x = i * 12 + (i / h * 5) - (i / h < cut ? 0 : cut * h * 12 + cut * 5);
                    int y = j * 12 + (i / h < cut ? 0 : 8 * 12);
                    p.Location = new Point(x, y);
                }
            }
        }

        private void PanelClick(object sender, EventArgs e)
        {
            if (sender is not Panel p) return;
            p.BackColor = (p.BackColor == InactiveColor) ? ActiveColor : InactiveColor;
            SDK.PixelUpdated(new PixelData(new Loc(int.Parse(p.Name)), p.BackColor == ActiveColor));
        }

        public bool SetPixel(PixelData data)
        {
            var controls = containerPanel.Controls;
            var p = controls.Find(data.Loc.Serial.ToString(), false)[0];
            p.BackColor = data.State ? ActiveColor : InactiveColor;

            SDK.PixelUpdated(data); // Called to let the other plugins know that data has changed
            return p.BackColor == ActiveColor;
        }
        #endregion

        #region Utils
        
        public BitArray GetBitArray()
        {
            BitArray output = new(ModH * ModV * ModCnt);
            var c = containerPanel.Controls;
            for (int i = 0; i < ModH * ModV * ModCnt; i++)
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
            LoadFromBinFile(openFileDialog1.FileName);
        }

        private void LoadFromBinFile(string loc, bool force = false)
        {

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

            if (bits.Length / (ModV * ModH) != ModCnt || force) 
                GenModules(bits.Length / (ModV * ModH), (bits.Length / (ModV * ModH))/2);

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
            LoadFromBmpFile(openFileDialog1.FileName);
        }

        private void LoadFromBmpFile(string loc, bool force = false)
        {
            if (string.IsNullOrEmpty(loc) || !External.FileExists(loc)) return;

            var bmp = new Bitmap(Image.FromFile(loc));

            if (bmp.Width % ModH != 0 || bmp.Height != ModV)
            {
                MessageBox.Show(@"Bitmap dimensions are incorrect", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (bmp.Width / ModH != ModCnt || force) 
                GenModules(bmp.Width / ModH, (bmp.Width / ModH)/2);

            var c = containerPanel.Controls;
            for (int x = 0; x < ModH * ModCnt; x++)
            {
                for (int y = 0; y < ModV; y++)
                {
                    var col = bmp.GetPixel(x, y);
                    var gs = (Int32)(col.R * 0.3 + col.G * 0.59 + col.B * 0.11);
                    c.Find((x + y * ModH * ModCnt).ToString(), false)[0].BackColor =
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

            Bitmap bmp = new(ModH * ModCnt, ModV);
            var c = containerPanel.Controls;
            for (int x = 0; x < ModH * ModCnt; x++)
            {
                for (int y = 0; y < ModV; y++)
                {
                    bmp.SetPixel(x, y,
                        c.Find((x + y * ModH * ModCnt).ToString(), false)[0].BackColor == InactiveColor
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

            _generator ??= new ArduinoGenerator();

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

        private void setNewBreakpointToolStripMenuItem_Click(object sender, EventArgs e) => new FormReCut(this, ModCnt).Show();

        private void newSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formNewSize = new FormNewSize(this);
            formNewSize.ShowDialog();
            SDK.ScreenSizeChanged(ModCnt, ModCut, ModH, ModV);
        }

        #endregion

        #region Edit menu strip

        public void ClearPanel(object sender, EventArgs e)
        {
            foreach (Control c in containerPanel.Controls)
            {
                if (c is Panel) c.BackColor = InactiveColor;
            }
            SDK.ScreenUpdated(new BitArray(Config.ModuleCount*ModH*ModV, false));
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
            var copy = new BitArray(ModCnt * ModH * ModV);
            var c = containerPanel.Controls;
            for (int i = 0; i < ModH * ModV * ModCnt; i++)
                copy[i] = c.Find(i.ToString(), false)[0].BackColor == Color.Black;

            for (int i = 0; i < ModCnt * ModH; i++)
            {
                for (int j = 0; j < ModV; j++)
                {
                    c.Find((i + j * ModH * ModCnt).ToString(), false)[0].BackColor =
                        copy[i + (6 - j) * ModH * ModCnt] ? ActiveColor : InactiveColor;
                }
            }
            SDK.ScreenUpdated(GetBitArray());
        }

        public void TextGen(object sender, EventArgs e) => new FormText(this).Show();

        private void symbolEditStrip_Click(object sender, EventArgs e) => new FormSymbol(this).Show();

        #endregion

        #region About menu strip

        private void wikiAboutStrip_Click(object sender, EventArgs e) => 
            Process.Start(new ProcessStartInfo("https://github.com/zsotroav/FOK-GYEM_Ultimate/wiki") { UseShellExecute = true });

        private void githubAboutStrip_Click(object sender, EventArgs e) =>
            Process.Start(new ProcessStartInfo("https://github.com/zsotroav/FOK-GYEM_Ultimate") { UseShellExecute = true });

        private void creditsAboutStrip_Click(object sender, EventArgs e) => new FormCredits().Show();
        
        #endregion

        #region Preferences menu strip

        private void setColorToolStripMenuItem_Click(object sender, EventArgs e) => new FormColorPref(this).Show();

        private void setDefaultsToolStripMenuItem_Click(object sender, EventArgs e) => new FormSetDefaults(this).Show();

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
            try
            {
                if (_currentFrame.I - 1 >= 0 && _currentFrame.I - 1 < Animation.FrameCount)
                    Animation.AnimationFrames.Reverse(_currentFrame.I - 1, 2);
                UpdateFrameCombo();
            } catch { PluginCommunicate("Animation error", "Invalid frame operation", "error"); }
        }

        private void animDownBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentFrame.I >= 0 && _currentFrame.I < Animation.FrameCount)
                    Animation.AnimationFrames.Reverse(_currentFrame.I, 2);
                UpdateFrameCombo();
            } catch { PluginCommunicate("Animation error", "Invalid frame operation", "error"); }
        }

        private void animDelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Animation.AnimationFrames.RemoveAt(_currentFrame.I);
                UpdateFrameCombo();
            } catch { PluginCommunicate("Animation error", "Invalid frame operation", "error"); }
        }

        private void animSaveBtn_Click(object sender, EventArgs e) =>
            Animation.AnimationFrames[_currentFrame.I].Frame = GetBitArray();


        private void animRelBtn_Click(object sender, EventArgs e) =>
            frameCombo_SelectedValueChanged(sender, e);

        private void UpdateFrameCombo()
        {
            frameCombo.Items.Clear();
            foreach (var name in Animation.GetAllNames())
            {
                frameCombo.Items.Add(name);
            }
        }

        private void transBtn_Click(object sender, EventArgs e)
        {
            Animation.AddTransition(transitionCombo.Text, ModCnt);
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
