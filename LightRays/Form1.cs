using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace LightRays
{
    public partial class Form1 : Form
    {
        #region TOPBAR_CODE

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void icon_exit_Click(object sender, EventArgs e)
        {
            Hide();
            notifyIcon.Visible = false;
            Environment.Exit(1);
        }

        private void icon_hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void labelGithub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/thcedi/lightrays_ledcontrol");
        }

        private void icon_back_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            var cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
            System.Diagnostics.Process.Start(cplPath, "/name Microsoft.Personalization");
        }

        #endregion

        #region HOVER_CODE

        private void icon_exit_MouseLeave(object sender, EventArgs e)
        {
            icon_exit.Image = Properties.Resources.close_icon;
        }

        private void icon_exit_MouseEnter(object sender, EventArgs e)
        {
            icon_exit.Image = Properties.Resources.close_icon_selected;
        }

        private void icon_hide_MouseLeave(object sender, EventArgs e)
        {
            var picBox = (PictureBox)sender;
            icon_hide.Image = Properties.Resources.hide_icon;
        }

        private void icon_hide_MouseEnter(object sender, EventArgs e)
        {
            icon_hide.Image = Properties.Resources.hide_icon_selected;
        }

        private void buttonPort_MouseEnter(object sender, EventArgs e)
        {
            dropdownPort.Image = Properties.Resources.background_dropdown_selected;
        }

        private void buttonPort_MouseLeave(object sender, EventArgs e)
        {
            dropdownPort.Image = Properties.Resources.background_dropdown;
        }

        private void dropdownEffekt_MouseEnter(object sender, EventArgs e)
        {
            dropdownEffekt.Image = Properties.Resources.background_dropdown_selected;
        }

        private void dropdownEffekt_MouseLeave(object sender, EventArgs e)
        {
            dropdownEffekt.Image = Properties.Resources.background_dropdown;
        }

        private void dropdownZone_MouseEnter(object sender, EventArgs e)
        {
            dropdownZone.Image = Properties.Resources.background_dropdown_selected;
        }

        private void dropdownZone_MouseLeave(object sender, EventArgs e)
        {
            dropdownZone.Image = Properties.Resources.background_dropdown;
        }

        private void btnApply_MouseEnter(object sender, EventArgs e)
        {
            btnApply.BackgroundImage = Properties.Resources.background_button_apply_selected;
        }

        private void btnApply_MouseLeave(object sender, EventArgs e)
        {
            btnApply.BackgroundImage = null;
        }

        private void labelGithub_MouseEnter(object sender, EventArgs e)
        {
            labelGithub.ForeColor = Color.DimGray;
        }

        private void labelGithub_MouseLeave(object sender, EventArgs e)
        {
            labelGithub.ForeColor = Color.FromArgb(0, 120, 215);
        }

        private void icon_back_MouseEnter(object sender, EventArgs e)
        {
            icon_back.Image = Properties.Resources.icon_back_selected;
        }

        private void icon_back_MouseLeave(object sender, EventArgs e)
        {
            icon_back.Image = Properties.Resources.icon_back;
        }

        private void panelStartseite_MouseEnter(object sender, EventArgs e)
        {
            panelStartseite.BackgroundImage = Properties.Resources.button_startseite_selected;
        }

        private void panelStartseite_MouseLeave(object sender, EventArgs e)
        {
            panelStartseite.BackgroundImage = Properties.Resources.button_startseite;
        }

        private void dropdownEffekt_Click(object sender, EventArgs e)
        {
            panelEffekt.Visible = true;
            panelZone.Visible = false;
            panelPort.Visible = false;
        }

        private void buttonPort_Click(object sender, EventArgs e)
        {
            panelPort.Visible = true;
            panelZone.Visible = false;
            panelEffekt.Visible = false;
        }

        private void dropdownZone_Click(object sender, EventArgs e)
        {
            panelZone.Visible = true;
            panelEffekt.Visible = false;
            panelPort.Visible = false;
        }

        private void dropdownItem_MouseLeave(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Panel))
            {
                var panel = (Panel)sender;
                panel.Controls[0].BackColor = Color.FromArgb(0, 38, 66);
                panel.BackColor = Color.FromArgb(0, 38, 66);

            }
            else if (sender.GetType() == typeof(Label))
            {
                var label = (Label)sender;
                var container = ((Panel)label.Parent);
                container.BackColor = Color.FromArgb(0, 38, 66);
                label.BackColor = Color.FromArgb(0, 38, 66);
            }
        }

        private void dropdownItem_MouseEnter(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Panel))
            {
                var panel = (Panel)sender;
                panel.Controls[0].BackColor = Color.FromArgb(0, 66, 117);
                panel.BackColor = Color.FromArgb(0, 66, 117);
            }
            else if (sender.GetType() == typeof(Label))
            {
                var label = (Label)sender;
                var container = ((Panel)label.Parent);
                container.BackColor = Color.FromArgb(0, 66, 117);
                label.BackColor = Color.FromArgb(0, 66, 117);
            }
        }

        #endregion

        #region PORT_AND_EFFECTS

        private string _settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "settings.xml");

        private async void Form1_Load(object sender, EventArgs e)
        {
            // Get last settings
            if(!File.Exists(_settingsPath))
            {
                var white = "255,255,255";

                new XDocument(
                        new XElement("settings",
                            new XElement("lasteffect", "0;a;"),
                            new XElement("comport", "COM3"),
                            new XElement("color1", white),
                            new XElement("color2", white),
                            new XElement("color3", white),
                            new XElement("color4", white),
                            new XElement("color5", white),
                            new XElement("color6", white),
                            new XElement("color7", white)
                            )
                        )
                    .Save(_settingsPath);
            }
            else
            {
                var doc = XElement.Load(_settingsPath);
                var lastEffectXml = doc.Elements("lasteffect").Single().Value.ToString();
                var lastEffect = lastEffectXml.Split(';');
                labelComPort.Text = Port = doc.Elements("comport").Single().Value.ToString();
                Zone = lastEffect[0];
                switch (Zone)
                {
                    case "0":
                        labelZone.Text = "Sync";
                        break;
                    case "1":
                        labelZone.Text = "Zone 1";
                        break;
                    case "2":
                        labelZone.Text = "Zone 2";
                        break;
                    case "3":
                        labelZone.Text = "Zone 3";
                        break;
                }

                Effect = lastEffect[1];
                switch (Effect)
                {
                    case "a":
                        labelEffekt.Text = "Rainbow";
                        break;
                    case "b":
                        labelEffekt.Text = "Fade";
                        break;
                    case "c":
                        labelEffekt.Text = "Fire";
                        break;
                    case "d":
                        labelEffekt.Text = "Comet";
                        break;
                    case "e":
                        labelEffekt.Text = "Huewheel";
                        break;
                    default:
                        if (Zone.Contains(","))
                        {
                            panelSingleColor.Visible = labelSelectColor.Visible = true;
                            labelEffekt.Text = "Single color";
                        }
                        break;
                }

                color1.BackColor = Color.FromArgb(Convert.ToInt32(doc.Elements("color1").Single().Value.ToString().Split(',')[0]), Convert.ToInt32(doc.Elements("color1").Single().Value.ToString().Split(',')[1]), Convert.ToInt32(doc.Elements("color1").Single().Value.ToString().Split(',')[2]));
                color2.BackColor = Color.FromArgb(Convert.ToInt32(doc.Elements("color2").Single().Value.ToString().Split(',')[0]), Convert.ToInt32(doc.Elements("color2").Single().Value.ToString().Split(',')[1]), Convert.ToInt32(doc.Elements("color2").Single().Value.ToString().Split(',')[2]));
                color3.BackColor = Color.FromArgb(Convert.ToInt32(doc.Elements("color3").Single().Value.ToString().Split(',')[0]), Convert.ToInt32(doc.Elements("color3").Single().Value.ToString().Split(',')[1]), Convert.ToInt32(doc.Elements("color3").Single().Value.ToString().Split(',')[2]));
                color4.BackColor = Color.FromArgb(Convert.ToInt32(doc.Elements("color4").Single().Value.ToString().Split(',')[0]), Convert.ToInt32(doc.Elements("color4").Single().Value.ToString().Split(',')[1]), Convert.ToInt32(doc.Elements("color4").Single().Value.ToString().Split(',')[2]));
                color5.BackColor = Color.FromArgb(Convert.ToInt32(doc.Elements("color5").Single().Value.ToString().Split(',')[0]), Convert.ToInt32(doc.Elements("color5").Single().Value.ToString().Split(',')[1]), Convert.ToInt32(doc.Elements("color5").Single().Value.ToString().Split(',')[2]));
                color6.BackColor = Color.FromArgb(Convert.ToInt32(doc.Elements("color6").Single().Value.ToString().Split(',')[0]), Convert.ToInt32(doc.Elements("color6").Single().Value.ToString().Split(',')[1]), Convert.ToInt32(doc.Elements("color6").Single().Value.ToString().Split(',')[2]));
                color7.BackColor = Color.FromArgb(Convert.ToInt32(doc.Elements("color7").Single().Value.ToString().Split(',')[0]), Convert.ToInt32(doc.Elements("color7").Single().Value.ToString().Split(',')[1]), Convert.ToInt32(doc.Elements("color7").Single().Value.ToString().Split(',')[2]));

                _serialHelper = new SerialHelper(Port);

                await Apply();
            }

            // Get ports
            var ports = SerialPort.GetPortNames();
            panelPort.Height = ports.Count() * 30 + 12;
            for (int i = 0; i < ports.Count(); i++)
            {
                var newItem = new Panel() { Location = new Point(2, 6 + (i * 30)), Width = 156, Height = 30, BackColor = Color.FromArgb(0, 38, 66) };

                var newItemLabel = new Label() { Text = ports[i], Location = new Point(2, 5), Font = new Font("Segoe UI", 10, FontStyle.Regular), ForeColor = Color.WhiteSmoke };
                newItemLabel.MouseEnter += dropdownItem_MouseEnter;
                newItemLabel.MouseLeave += dropdownItem_MouseLeave;
                newItemLabel.Click += selectPort_Click;

                newItem.Controls.Add(newItemLabel);
                newItem.MouseEnter += dropdownItem_MouseEnter;
                newItem.MouseLeave += dropdownItem_MouseLeave;
                newItem.Click += selectPort_Click;

                panelPort.Controls.Add(newItem);
            }

            // Get effects
            var effects = new List<string>() { "Single color", "Rainbow", "Fade", "Fire", "Comet", "Huewheel" };
            panelEffekt.Height = effects.Count() * 30 + 12;
            for (int i = 0; i < effects.Count(); i++)
            {
                var newItem = new Panel() { Location = new Point(2, 6 + (i * 30)), Width = 156, Height = 30, BackColor = Color.FromArgb(0, 38, 66) };

                var newItemLabel = new Label() { Text = effects[i], Location = new Point(2, 5), Font = new Font("Segoe UI", 10, FontStyle.Regular), ForeColor = Color.WhiteSmoke };
                newItemLabel.MouseEnter += dropdownItem_MouseEnter;
                newItemLabel.MouseLeave += dropdownItem_MouseLeave;
                newItemLabel.Click += selectEffekt_Click;

                newItem.Controls.Add(newItemLabel);
                newItem.MouseEnter += dropdownItem_MouseEnter;
                newItem.MouseLeave += dropdownItem_MouseLeave;
                newItem.Click += selectEffekt_Click;

                panelEffekt.Controls.Add(newItem);
            }

            // Get zones
            var zones = new List<string>() { "Sync", "Zone 1", "Zone 2", "Zone 3" };
            panelZone.Height = zones.Count() * 30 + 12;
            for (int i = 0; i < zones.Count(); i++)
            {
                var newItem = new Panel() { Location = new Point(2, 6 + (i * 30)), Width = 156, Height = 30, BackColor = Color.FromArgb(0, 38, 66) };

                var newItemLabel = new Label() { Text = zones[i], Location = new Point(2, 5), Font = new Font("Segoe UI", 10, FontStyle.Regular), ForeColor = Color.WhiteSmoke };
                newItemLabel.MouseEnter += dropdownItem_MouseEnter;
                newItemLabel.MouseLeave += dropdownItem_MouseLeave;
                newItemLabel.Click += selectZone_Click;

                newItem.Controls.Add(newItemLabel);
                newItem.MouseEnter += dropdownItem_MouseEnter;
                newItem.MouseLeave += dropdownItem_MouseLeave;
                newItem.Click += selectZone_Click;

                panelZone.Controls.Add(newItem);
            }

        }

        #endregion

        public string Port = "";
        public string Effect = "";
        public string Zone = "";
        public SerialHelper _serialHelper;

        public Form1()
        {
            InitializeComponent();
        }

        private void selectPort_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Panel))
            {
                var panel = (Panel)sender;
                Port = panel.Controls[0].Text;
            }
            else if (sender.GetType() == typeof(Label))
            {
                var label = (Label)sender;
                Port = label.Text;
            }

            labelComPort.Text = Port;
            panelPort.Visible = false;

            if (!string.IsNullOrEmpty(Port))
            {
                _serialHelper = new SerialHelper(Port);

                var doc = XElement.Load(_settingsPath);
                var portElement = doc.Elements("comport").Single();
                portElement.Value = Port;
                doc.Save(_settingsPath);
            }
        }

        private void selectEffekt_Click(object sender, EventArgs e)
        {
            string selectedEffect = "";

            if (sender.GetType() == typeof(Panel))
            {
                var panel = (Panel)sender;
                selectedEffect = panel.Controls[0].Text;
            }
            else if (sender.GetType() == typeof(Label))
            {
                var label = (Label)sender;
                selectedEffect = label.Text;
            }

            panelSingleColor.Visible = labelSelectColor.Visible = false;

            switch (selectedEffect)
            {
                case "Rainbow":
                    Effect = "a";
                    break;
                case "Fade":
                    Effect = "b";
                    break;
                case "Fire":
                    Effect = "c";
                    break;
                case "Comet":
                    Effect = "d";
                    break;
                case "Huewheel":
                    Effect = "e";
                    break;
                case "Single color":
                    panelSingleColor.Visible = labelSelectColor.Visible = true;
                    break;
            }

            labelEffekt.Text = selectedEffect;
            panelEffekt.Visible = false;
        }

        private void selectZone_Click(object sender, EventArgs e)
        {
            string selectedZone = "";

            if (sender.GetType() == typeof(Panel))
            {
                var panel = (Panel)sender;
                selectedZone = panel.Controls[0].Text;
            }
            else if (sender.GetType() == typeof(Label))
            {
                var label = (Label)sender;
                selectedZone = label.Text;
            }

            switch (selectedZone)
            {
                case "Sync":
                    Zone = "0";
                    break;
                case "Zone 1":
                    Zone = "1";
                    break;
                case "Zone 2":
                    Zone = "2";
                    break;
                case "Zone 3":
                    Zone = "3";
                    break;
            }

            labelZone.Text = selectedZone;
            panelZone.Visible = false;
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            await Apply();

            var currentEffect = string.Format("{0};{1};", Zone, Effect);
            var doc = XElement.Load(_settingsPath);
            var lastEffect = doc.Elements("lasteffect").Single();
            lastEffect.Value = currentEffect;
            doc.Save(_settingsPath);
        }

        private async Task Apply()
        {
            if (string.IsNullOrEmpty(Zone) || string.IsNullOrEmpty(Effect) || string.IsNullOrEmpty(Port)) return;

            if (Zone == "Sync" && Effect.Contains(','))
            {
                await Task.Run(async () =>
                {
                    await Task.Delay(10);
                    _serialHelper.Write(string.Format("1;{0};", Effect));
                    await Task.Delay(10);
                    _serialHelper.Write(string.Format("2;{0};", Effect));
                    await Task.Delay(10);
                    _serialHelper.Write(string.Format("3;{0};", Effect));
                });

            }
            else
            {
                _serialHelper.Write(string.Format("{0};{1};", Zone, Effect));
            }
        }

        private void color_Click(object sender, EventArgs e)
        {
            selectColor((Panel)sender, ((Panel)sender).BackColor);
        }

        private void color1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                var panel = (Panel)sender;
                var color = colorDialog1.Color;
                selectColor(panel, color);

                var doc = XElement.Load(_settingsPath);
                var lastEffectXml = doc.Elements(panel.Name).Single();
                lastEffectXml.Value = string.Format("{0},{1},{2}", color.R, color.G, color.B);
                doc.Save(_settingsPath);
            }
        }

        private void selectColor(Panel panel, Color color)
        {
            var panels = new List<Panel>() { color1, color2, color3, color4, color5, color6, color7 };

            foreach(Panel p in panels)
            {
                if(p != panel)
                {
                    p.BorderStyle = BorderStyle.None;
                }
            }

            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = color;
            Effect = string.Format("{0},{1},{2}", color.R, color.G, color.B);
        }
    }
}
