
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonApply = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxZone = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxEffect = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panelColormix = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelPort = new System.Windows.Forms.Panel();
            this.icon_hide = new System.Windows.Forms.PictureBox();
            this.icon_exit = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(320, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 555);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 37);
            this.label2.TabIndex = 6;
            this.label2.Text = "Rear Light";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonApply);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.comboBoxZone);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.comboBoxEffect);
            this.panel3.Location = new System.Drawing.Point(56, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(418, 57);
            this.panel3.TabIndex = 5;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(260, 25);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(103, 23);
            this.buttonApply.TabIndex = 7;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(137, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Zone";
            // 
            // comboBoxZone
            // 
            this.comboBoxZone.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxZone.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxZone.FormattingEnabled = true;
            this.comboBoxZone.Items.AddRange(new object[] {
            "Sync",
            "1",
            "2",
            "3"});
            this.comboBoxZone.Location = new System.Drawing.Point(140, 25);
            this.comboBoxZone.Name = "comboBoxZone";
            this.comboBoxZone.Size = new System.Drawing.Size(105, 21);
            this.comboBoxZone.TabIndex = 5;
            this.comboBoxZone.SelectedIndexChanged += new System.EventHandler(this.comboBoxZone_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Effect";
            // 
            // comboBoxEffect
            // 
            this.comboBoxEffect.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxEffect.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEffect.FormattingEnabled = true;
            this.comboBoxEffect.Items.AddRange(new object[] {
            "Rainbow",
            "Single color"});
            this.comboBoxEffect.Location = new System.Drawing.Point(16, 25);
            this.comboBoxEffect.Name = "comboBoxEffect";
            this.comboBoxEffect.Size = new System.Drawing.Size(105, 21);
            this.comboBoxEffect.TabIndex = 1;
            this.comboBoxEffect.SelectedIndexChanged += new System.EventHandler(this.comboBoxEffect_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panelColormix);
            this.panel5.Controls.Add(this.trackBar1);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.trackBar2);
            this.panel5.Controls.Add(this.trackBar3);
            this.panel5.Location = new System.Drawing.Point(56, 235);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(418, 138);
            this.panel5.TabIndex = 5;
            // 
            // panelColormix
            // 
            this.panelColormix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColormix.Location = new System.Drawing.Point(52, 205);
            this.panelColormix.Name = "panelColormix";
            this.panelColormix.Size = new System.Drawing.Size(230, 40);
            this.panelColormix.TabIndex = 5;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.Red;
            this.trackBar1.Location = new System.Drawing.Point(52, 52);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(230, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.BackColor = System.Drawing.Color.Blue;
            this.trackBar2.Location = new System.Drawing.Point(52, 103);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(230, 45);
            this.trackBar2.TabIndex = 7;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.BackColor = System.Drawing.Color.Green;
            this.trackBar3.Location = new System.Drawing.Point(52, 154);
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
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelRight.Location = new System.Drawing.Point(1, 1);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(320, 578);
            this.panelRight.TabIndex = 10;
            this.panelRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // panelPort
            // 
            this.panelPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panelPort.Location = new System.Drawing.Point(26, 82);
            this.panelPort.Name = "panelPort";
            this.panelPort.Size = new System.Drawing.Size(82, 42);
            this.panelPort.TabIndex = 7;
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
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxEffect;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxZone;
        private System.Windows.Forms.Panel panelColormix;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.PictureBox icon_hide;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelPort;
    }
}

