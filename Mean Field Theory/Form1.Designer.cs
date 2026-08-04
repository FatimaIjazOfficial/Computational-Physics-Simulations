namespace Mean_Field_Theory
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ssolutionMethod1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVsTanhzsTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssolutionMethod2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVersusTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssolutionMethod1ToolStripMenuItem,
            this.sVsTanhzsTToolStripMenuItem,
            this.ssolutionMethod2ToolStripMenuItem,
            this.buttonToolStripMenuItem,
            this.sVersusTToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1149, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ssolutionMethod1ToolStripMenuItem
            // 
            this.ssolutionMethod1ToolStripMenuItem.BackColor = System.Drawing.Color.Tan;
            this.ssolutionMethod1ToolStripMenuItem.Font = new System.Drawing.Font("News706 BT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssolutionMethod1ToolStripMenuItem.Name = "ssolutionMethod1ToolStripMenuItem";
            this.ssolutionMethod1ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ssolutionMethod1ToolStripMenuItem.Text = "s vs s";
            this.ssolutionMethod1ToolStripMenuItem.Click += new System.EventHandler(this.ssolutionMethod1ToolStripMenuItem_Click);
            // 
            // sVsTanhzsTToolStripMenuItem
            // 
            this.sVsTanhzsTToolStripMenuItem.Name = "sVsTanhzsTToolStripMenuItem";
            this.sVsTanhzsTToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.sVsTanhzsTToolStripMenuItem.Text = " s vs tanh(zs/T)";
            this.sVsTanhzsTToolStripMenuItem.Click += new System.EventHandler(this.sVsTanhzsTToolStripMenuItem_Click);
            // 
            // ssolutionMethod2ToolStripMenuItem
            // 
            this.ssolutionMethod2ToolStripMenuItem.BackColor = System.Drawing.Color.DarkOrange;
            this.ssolutionMethod2ToolStripMenuItem.Font = new System.Drawing.Font("News706 BT", 9.75F, System.Drawing.FontStyle.Bold);
            this.ssolutionMethod2ToolStripMenuItem.Name = "ssolutionMethod2ToolStripMenuItem";
            this.ssolutionMethod2ToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.ssolutionMethod2ToolStripMenuItem.Text = "s vs s - tanh(z*s/T)";
            this.ssolutionMethod2ToolStripMenuItem.Click += new System.EventHandler(this.ssolutionMethod2ToolStripMenuItem_Click);
            // 
            // buttonToolStripMenuItem
            // 
            this.buttonToolStripMenuItem.Font = new System.Drawing.Font("News706 BT", 9.75F, System.Drawing.FontStyle.Bold);
            this.buttonToolStripMenuItem.Name = "buttonToolStripMenuItem";
            this.buttonToolStripMenuItem.Size = new System.Drawing.Size(221, 20);
            this.buttonToolStripMenuItem.Text = "Spontaneous Magnetization s(T)";
            this.buttonToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonToolStripMenuItem.Click += new System.EventHandler(this.buttonToolStripMenuItem_Click);
            // 
            // sVersusTToolStripMenuItem
            // 
            this.sVersusTToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sVersusTToolStripMenuItem.Font = new System.Drawing.Font("News706 BT", 9.75F, System.Drawing.FontStyle.Bold);
            this.sVersusTToolStripMenuItem.Name = "sVersusTToolStripMenuItem";
            this.sVersusTToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.sVersusTToolStripMenuItem.Text = "s vs T (Fixed Points)";
            this.sVersusTToolStripMenuItem.Click += new System.EventHandler(this.sVersusTToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(12, 20);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(12, 20);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(170, 35);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(86, 13);
            this.lblTemperature.TabIndex = 5;
            this.lblTemperature.Text = "Temperature (T):";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(265, 32);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(80, 20);
            this.txtTemperature.TabIndex = 6;
            this.txtTemperature.Text = "2.5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 875);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblTemperature);
            this.Controls.Add(this.txtTemperature);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.TextBox txtTemperature;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ssolutionMethod1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ssolutionMethod2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVersusTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem sVsTanhzsTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}

