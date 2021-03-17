
namespace LightRays
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelZone = new System.Windows.Forms.Panel();
            this.labelZone = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dropdownZone = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelEffekt = new System.Windows.Forms.Panel();
            this.dropdownEffekt = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Panel();
            this.btnApplyLabel = new System.Windows.Forms.Label();
            this.labelEffekt = new System.Windows.Forms.Label();
            this.labelComPort = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPort = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dropdownPort = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelColormix = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.icon_hide = new System.Windows.Forms.PictureBox();
            this.icon_exit = new System.Windows.Forms.PictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEffekt)).BeginInit();
            this.btnApply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownPort)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon_hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_exit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "LightRays v0.1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panelPort);
            this.panel2.Controls.Add(this.panelEffekt);
            this.panel2.Controls.Add(this.panelZone);
            this.panel2.Controls.Add(this.labelZone);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.dropdownZone);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.dropdownEffekt);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnApply);
            this.panel2.Controls.Add(this.labelEffekt);
            this.panel2.Controls.Add(this.labelComPort);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dropdownPort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(320, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 555);
            this.panel2.TabIndex = 5;
            // 
            // panelZone
            // 
            this.panelZone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panelZone.Location = new System.Drawing.Point(22, 289);
            this.panelZone.Name = "panelZone";
            this.panelZone.Size = new System.Drawing.Size(160, 42);
            this.panelZone.TabIndex = 9;
            this.panelZone.Visible = false;
            // 
            // labelZone
            // 
            this.labelZone.AutoSize = true;
            this.labelZone.BackColor = System.Drawing.Color.Transparent;
            this.labelZone.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelZone.ForeColor = System.Drawing.Color.DimGray;
            this.labelZone.Location = new System.Drawing.Point(146, 414);
            this.labelZone.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.labelZone.Name = "labelZone";
            this.labelZone.Size = new System.Drawing.Size(43, 20);
            this.labelZone.TabIndex = 17;
            this.labelZone.Text = "Zone";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label11.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label11.Location = new System.Drawing.Point(19, 414);
            this.label11.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Zone";
            // 
            // dropdownZone
            // 
            this.dropdownZone.Image = global::LightRays.Properties.Resources.background_dropdown_zonet;
            this.dropdownZone.Location = new System.Drawing.Point(22, 289);
            this.dropdownZone.Name = "dropdownZone";
            this.dropdownZone.Size = new System.Drawing.Size(160, 32);
            this.dropdownZone.TabIndex = 14;
            this.dropdownZone.TabStop = false;
            this.dropdownZone.Click += new System.EventHandler(this.dropdownZone_Click);
            this.dropdownZone.MouseEnter += new System.EventHandler(this.dropdownZone_MouseEnter);
            this.dropdownZone.MouseLeave += new System.EventHandler(this.dropdownZone_MouseLeave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label8.Location = new System.Drawing.Point(19, 262);
            this.label8.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Zone";
            // 
            // panelEffekt
            // 
            this.panelEffekt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panelEffekt.Location = new System.Drawing.Point(22, 209);
            this.panelEffekt.Name = "panelEffekt";
            this.panelEffekt.Size = new System.Drawing.Size(160, 42);
            this.panelEffekt.TabIndex = 8;
            this.panelEffekt.Visible = false;
            // 
            // dropdownEffekt
            // 
            this.dropdownEffekt.Image = global::LightRays.Properties.Resources.background_dropdown_effekt;
            this.dropdownEffekt.Location = new System.Drawing.Point(22, 209);
            this.dropdownEffekt.Name = "dropdownEffekt";
            this.dropdownEffekt.Size = new System.Drawing.Size(160, 32);
            this.dropdownEffekt.TabIndex = 1;
            this.dropdownEffekt.TabStop = false;
            this.dropdownEffekt.Click += new System.EventHandler(this.dropdownEffekt_Click);
            this.dropdownEffekt.MouseEnter += new System.EventHandler(this.dropdownEffekt_MouseEnter);
            this.dropdownEffekt.MouseLeave += new System.EventHandler(this.dropdownEffekt_MouseLeave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(19, 182);
            this.label9.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Effekt";
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnApply.Controls.Add(this.btnApplyLabel);
            this.btnApply.Location = new System.Drawing.Point(22, 481);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(150, 31);
            this.btnApply.TabIndex = 8;
            // 
            // btnApplyLabel
            // 
            this.btnApplyLabel.AutoSize = true;
            this.btnApplyLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnApplyLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnApplyLabel.Location = new System.Drawing.Point(37, 5);
            this.btnApplyLabel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.btnApplyLabel.Name = "btnApplyLabel";
            this.btnApplyLabel.Size = new System.Drawing.Size(79, 20);
            this.btnApplyLabel.TabIndex = 13;
            this.btnApplyLabel.Text = "Anwenden";
            // 
            // labelEffekt
            // 
            this.labelEffekt.AutoSize = true;
            this.labelEffekt.BackColor = System.Drawing.Color.Transparent;
            this.labelEffekt.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelEffekt.ForeColor = System.Drawing.Color.DimGray;
            this.labelEffekt.Location = new System.Drawing.Point(145, 386);
            this.labelEffekt.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.labelEffekt.Name = "labelEffekt";
            this.labelEffekt.Size = new System.Drawing.Size(47, 20);
            this.labelEffekt.TabIndex = 12;
            this.labelEffekt.Text = "Effekt";
            // 
            // labelComPort
            // 
            this.labelComPort.AutoSize = true;
            this.labelComPort.BackColor = System.Drawing.Color.Transparent;
            this.labelComPort.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelComPort.ForeColor = System.Drawing.Color.DimGray;
            this.labelComPort.Location = new System.Drawing.Point(145, 357);
            this.labelComPort.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.labelComPort.Name = "labelComPort";
            this.labelComPort.Size = new System.Drawing.Size(72, 20);
            this.labelComPort.TabIndex = 11;
            this.labelComPort.Text = "COM Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label7.Location = new System.Drawing.Point(18, 386);
            this.label7.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Effekt";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Location = new System.Drawing.Point(18, 357);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "COM Port";
            // 
            // panelPort
            // 
            this.panelPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panelPort.Location = new System.Drawing.Point(22, 121);
            this.panelPort.Name = "panelPort";
            this.panelPort.Size = new System.Drawing.Size(82, 42);
            this.panelPort.TabIndex = 7;
            this.panelPort.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Location = new System.Drawing.Point(19, 94);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port auswählen";
            // 
            // dropdownPort
            // 
            this.dropdownPort.Image = global::LightRays.Properties.Resources.background_dropdown_port;
            this.dropdownPort.Location = new System.Drawing.Point(22, 121);
            this.dropdownPort.Name = "dropdownPort";
            this.dropdownPort.Size = new System.Drawing.Size(75, 32);
            this.dropdownPort.TabIndex = 0;
            this.dropdownPort.TabStop = false;
            this.dropdownPort.Click += new System.EventHandler(this.buttonPort_Click);
            this.dropdownPort.MouseEnter += new System.EventHandler(this.buttonPort_MouseEnter);
            this.dropdownPort.MouseLeave += new System.EventHandler(this.buttonPort_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rear Light";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panelColormix);
            this.panel5.Controls.Add(this.trackBar1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.trackBar2);
            this.panel5.Controls.Add(this.trackBar3);
            this.panel5.Location = new System.Drawing.Point(525, 486);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(418, 211);
            this.panel5.TabIndex = 5;
            // 
            // panelColormix
            // 
            this.panelColormix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColormix.Location = new System.Drawing.Point(28, 87);
            this.panelColormix.Name = "panelColormix";
            this.panelColormix.Size = new System.Drawing.Size(76, 68);
            this.panelColormix.TabIndex = 5;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Red;
            this.trackBar1.Location = new System.Drawing.Point(168, 36);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(230, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.BackColor = System.Drawing.Color.Blue;
            this.trackBar2.Location = new System.Drawing.Point(168, 87);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(230, 45);
            this.trackBar2.TabIndex = 7;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.BackColor = System.Drawing.Color.Green;
            this.trackBar3.Location = new System.Drawing.Point(168, 138);
            this.trackBar3.Maximum = 255;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(230, 45);
            this.trackBar3.TabIndex = 8;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Controls.Add(this.icon_hide);
            this.panel4.Controls.Add(this.icon_exit);
            this.panel4.Location = new System.Drawing.Point(320, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(579, 29);
            this.panel4.TabIndex = 9;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // icon_hide
            // 
            this.icon_hide.BackColor = System.Drawing.Color.Transparent;
            this.icon_hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.icon_hide.Dock = System.Windows.Forms.DockStyle.Right;
            this.icon_hide.Image = global::LightRays.Properties.Resources.hide_icon;
            this.icon_hide.Location = new System.Drawing.Point(489, 0);
            this.icon_hide.Margin = new System.Windows.Forms.Padding(0);
            this.icon_hide.Name = "icon_hide";
            this.icon_hide.Size = new System.Drawing.Size(45, 29);
            this.icon_hide.TabIndex = 6;
            this.icon_hide.TabStop = false;
            this.icon_hide.Click += new System.EventHandler(this.icon_hide_Click);
            this.icon_hide.MouseEnter += new System.EventHandler(this.icon_hide_MouseEnter);
            this.icon_hide.MouseLeave += new System.EventHandler(this.icon_hide_MouseLeave);
            // 
            // icon_exit
            // 
            this.icon_exit.BackColor = System.Drawing.Color.Transparent;
            this.icon_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.icon_exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.icon_exit.Image = global::LightRays.Properties.Resources.close_icon;
            this.icon_exit.Location = new System.Drawing.Point(534, 0);
            this.icon_exit.Margin = new System.Windows.Forms.Padding(0);
            this.icon_exit.Name = "icon_exit";
            this.icon_exit.Size = new System.Drawing.Size(45, 29);
            this.icon_exit.TabIndex = 0;
            this.icon_exit.TabStop = false;
            this.icon_exit.Click += new System.EventHandler(this.icon_exit_Click);
            this.icon_exit.MouseEnter += new System.EventHandler(this.icon_exit_MouseEnter);
            this.icon_exit.MouseLeave += new System.EventHandler(this.icon_exit_MouseLeave);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelRight.Location = new System.Drawing.Point(1, 1);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(320, 578);
            this.panelRight.TabIndex = 10;
            this.panelRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownEffekt)).EndInit();
            this.btnApply.ResumeLayout(false);
            this.btnApply.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dropdownPort)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.icon_hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon_exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox icon_exit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panelColormix;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox icon_hide;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelPort;
        private System.Windows.Forms.PictureBox dropdownPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelEffekt;
        private System.Windows.Forms.Label labelComPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelEffekt;
        private System.Windows.Forms.PictureBox dropdownEffekt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel btnApply;
        private System.Windows.Forms.Label btnApplyLabel;
        private System.Windows.Forms.Label labelZone;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox dropdownZone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelZone;
    }
}

