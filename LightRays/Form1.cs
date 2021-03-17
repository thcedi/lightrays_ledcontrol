using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dropdownPort.Image = Properties.Resources.background_dropdown_port;
        }

        private void dropdownEffekt_MouseEnter(object sender, EventArgs e)
        {
            dropdownEffekt.Image = Properties.Resources.background_dropdown_effekt_selected;
        }

        private void dropdownEffekt_MouseLeave(object sender, EventArgs e)
        {
            dropdownEffekt.Image = Properties.Resources.background_dropdown_effekt;
        }

        private void dropdownZone_MouseEnter(object sender, EventArgs e)
        {
            dropdownZone.Image = Properties.Resources.background_dropdown_zone_selected;
        }

        private void dropdownZone_MouseLeave(object sender, EventArgs e)
        {
            dropdownZone.Image = Properties.Resources.background_dropdown_zonet;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get ports
            var ports = SerialPort.GetPortNames();
            panelPort.Height = ports.Count() * 30 + 12;
            for (int i = 0; i < ports.Count(); i++)
            {
                var newItem = new Panel() { Location = new Point(2, 6 + (i * 30)), Width = 78, Height = 30, BackColor = Color.FromArgb(0, 38, 66) };

                var newItemLabel = new Label() { Text = ports[i], Location = new Point(2, 4), Font = new Font("Segoe UI", 12, FontStyle.Regular), ForeColor = Color.WhiteSmoke };
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
            var effects = new List<string>() { "Single color", "Rainbow", "Fade", "Huewheel", "Comet" };
            panelEffekt.Height = effects.Count() * 30 + 12;
            for (int i = 0; i < effects.Count(); i++)
            {
                var newItem = new Panel() { Location = new Point(2, 6 + (i * 30)), Width = 156, Height = 30, BackColor = Color.FromArgb(0, 38, 66) };

                var newItemLabel = new Label() { Text = effects[i], Location = new Point(2, 4), Font = new Font("Segoe UI", 12, FontStyle.Regular), ForeColor = Color.WhiteSmoke };
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

                var newItemLabel = new Label() { Text = zones[i], Location = new Point(2, 4), Font = new Font("Segoe UI", 12, FontStyle.Regular), ForeColor = Color.WhiteSmoke };
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
        public int r = 0;
        public int g = 0;
        public int b = 0;
        public SerialHelper _serialHelper;

        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //r = trackBar1.Value;
            //panelColormix.BackColor = Color.FromArgb(r, g, b);

            //if ((string)comboBoxEffect.SelectedItem == "Single color")
            //{
            //    Effect = string.Format("{0},{1},{2}", r, g, b);
            //}
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //g = trackBar3.Value;
            //panelColormix.BackColor = Color.FromArgb(r, g, b);

            //if ((string)comboBoxEffect.SelectedItem == "Single color")
            //{
            //    Effect = string.Format("{0},{1},{2}", r, g, b);
            //}
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //b = trackBar2.Value;
            //panelColormix.BackColor = Color.FromArgb(r, g, b);

            //if ((string)comboBoxEffect.SelectedItem == "Single color")
            //{
            //    Effect = string.Format("{0},{1},{2}", r, g, b);
            //}
        }

        private void comboBoxEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // var item = (string)comboBoxEffect.SelectedItem;
            //switch (item)
            //{
            //    case "Rainbow":
            //        Effect = "a";
            //        break;
            //    case "Single color":
            //        Effect = string.Format("{0},{1},{2}", r, g, b);
            //        break;
            //}
        }

        private async void buttonApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Zone) || string.IsNullOrEmpty(Effect) || string.IsNullOrEmpty(Port)) return;

            if(Zone == "Sync" && Effect.Contains(','))
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
            }
        }

        private void selectEffekt_Click(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(Panel))
            {
                var panel = (Panel)sender;
                Effect = panel.Controls[0].Text;
            }
            else if (sender.GetType() == typeof(Label))
            {
                var label = (Label)sender;
                Effect = label.Text;
            }

            labelEffekt.Text = Effect;
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
    }
}
