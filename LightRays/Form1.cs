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
        // Drag code
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

        // Drag code end

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

            //var newItem = new Panel() { Location = new Point(2, 6), Width = 78, Height = 30, BackColor = Color.FromArgb(0, 38, 66) };

            //var newItemLabel = new Label() { Text = "COM3", Location = new Point(2, 4), Font = new Font("Segoe UI", 12, FontStyle.Regular), ForeColor = Color.WhiteSmoke };
            //newItemLabel.MouseEnter += panelPort_MouseEnter;
            //newItemLabel.MouseLeave += panelPort_MouseLeave;

            //newItem.Controls.Add(newItemLabel);
            //newItem.MouseEnter += panelPort_MouseEnter;
            //newItem.MouseLeave += panelPort_MouseLeave;

            //panelPort.Controls.Add(newItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();

            panelPort.Height = ports.Count() * 30 + 12;

            for (int i = 0; i < ports.Count(); i++)
            {
                var newItem = new Panel() { Location = new Point(2, 6 + (i * 30)), Width = 78, Height = 30, BackColor = Color.FromArgb(0, 38, 66) };

                var newItemLabel = new Label() { Text = ports[i], Location = new Point(2, 4), Font = new Font("Segoe UI", 12, FontStyle.Regular), ForeColor = Color.WhiteSmoke };
                newItemLabel.MouseEnter += panelPort_MouseEnter;
                newItemLabel.MouseLeave += panelPort_MouseLeave;
                newItemLabel.Click += selectPort_Click;

                newItem.Controls.Add(newItemLabel);
                newItem.MouseEnter += panelPort_MouseEnter;
                newItem.MouseLeave += panelPort_MouseLeave;
                newItem.Click += selectPort_Click;

                panelPort.Controls.Add(newItem);
            }
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
           //  Port = (string)comboBoxPorts.SelectedItem;

            if(!string.IsNullOrEmpty(Port))
            {
                _serialHelper = new SerialHelper(Port);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            r = trackBar1.Value;
            panelColormix.BackColor = Color.FromArgb(r, g, b);

            if ((string)comboBoxEffect.SelectedItem == "Single color")
            {
                Effect = string.Format("{0},{1},{2}", r, g, b);
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            g = trackBar3.Value;
            panelColormix.BackColor = Color.FromArgb(r, g, b);

            if ((string)comboBoxEffect.SelectedItem == "Single color")
            {
                Effect = string.Format("{0},{1},{2}", r, g, b);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = trackBar2.Value;
            panelColormix.BackColor = Color.FromArgb(r, g, b);

            if ((string)comboBoxEffect.SelectedItem == "Single color")
            {
                Effect = string.Format("{0},{1},{2}", r, g, b);
            }
        }

        private void comboBoxEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (string)comboBoxEffect.SelectedItem;
            switch (item)
            {
                case "Rainbow":
                    Effect = "a";
                    break;
                case "Single color":
                    Effect = string.Format("{0},{1},{2}", r, g, b);
                    break;
            }
        }

        private void comboBoxZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (string)comboBoxZone.SelectedItem;
            switch (item)
            {
                case "Sync":
                    Zone = "0";
                    break;
                case "1":
                    Zone = "1";
                    break;
                case "2":
                    Zone = "2";
                    break;
                case "3":
                    Zone = "3";
                    break;
            }
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
        
        // Top bar icons

        // Close
        private void icon_exit_MouseLeave(object sender, EventArgs e)
        {
            icon_exit.Image = Properties.Resources.close_icon;
        }

        private void icon_exit_MouseEnter(object sender, EventArgs e)
        {
            icon_exit.Image = Properties.Resources.close_icon_selected;
        }

        private void icon_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        // Hide
        private void icon_hide_MouseLeave(object sender, EventArgs e)
        {
            var picBox = (PictureBox)sender;
            icon_hide.Image = Properties.Resources.hide_icon;
        }

        private void icon_hide_MouseEnter(object sender, EventArgs e)
        {
            icon_hide.Image = Properties.Resources.hide_icon_selected;
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelPort_MouseLeave(object sender, EventArgs e)
        {
            if(sender.GetType() == typeof(Panel))
            {
                var panel = (Panel)sender;
                panel.Controls[0].BackColor = Color.FromArgb(0, 38, 66);
                panel.BackColor = Color.FromArgb(0, 38, 66);

            }
            else if(sender.GetType() == typeof(Label))
            {
                var label = (Label)sender;
                var container = ((Panel)label.Parent);
                container.BackColor = Color.FromArgb(0, 38, 66);
                label.BackColor = Color.FromArgb(0, 38, 66);
            }
        }

        private void panelPort_MouseEnter(object sender, EventArgs e)
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

        private void buttonPort_MouseEnter(object sender, EventArgs e)
        {
            buttonPort.Image = Properties.Resources.background_dropdown_selected;
        }

        private void buttonPort_MouseLeave(object sender, EventArgs e)
        {
            buttonPort.Image = Properties.Resources.background_dropdown_port;
        }

        private void buttonPort_Click(object sender, EventArgs e)
        {
            panelPort.Visible = true;
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

            panelPort.Visible = false;
        }
    }
}
