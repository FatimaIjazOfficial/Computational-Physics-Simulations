namespace Pendulum_Simulator
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
            this.eulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idealCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eulerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cromerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forSmallAngleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.realisticCaseByEulerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dampingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonLinearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.realisticCaseByEulerCromerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dampingToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nonLinearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.BurlyWood;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eulerToolStripMenuItem,
            this.idealCaseToolStripMenuItem,
            this.realisticCaseByEulerToolStripMenuItem,
            this.realisticCaseByEulerCromerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eulerToolStripMenuItem
            // 
            this.eulerToolStripMenuItem.BackColor = System.Drawing.Color.YellowGreen;
            this.eulerToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.eulerToolStripMenuItem.Name = "eulerToolStripMenuItem";
            this.eulerToolStripMenuItem.Size = new System.Drawing.Size(129, 35);
            this.eulerToolStripMenuItem.Text = "Refresh";
            // 
            // idealCaseToolStripMenuItem
            // 
            this.idealCaseToolStripMenuItem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.idealCaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eulerToolStripMenuItem1,
            this.cromerToolStripMenuItem,
            this.forSmallAngleToolStripMenuItem});
            this.idealCaseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.idealCaseToolStripMenuItem.Name = "idealCaseToolStripMenuItem";
            this.idealCaseToolStripMenuItem.Size = new System.Drawing.Size(82, 35);
            this.idealCaseToolStripMenuItem.Text = "Ideal Case";
            // 
            // eulerToolStripMenuItem1
            // 
            this.eulerToolStripMenuItem1.BackColor = System.Drawing.Color.SandyBrown;
            this.eulerToolStripMenuItem1.Name = "eulerToolStripMenuItem1";
            this.eulerToolStripMenuItem1.Size = new System.Drawing.Size(174, 22);
            this.eulerToolStripMenuItem1.Text = "Euler";
            this.eulerToolStripMenuItem1.Click += new System.EventHandler(this.eulerToolStripMenuItem1_Click);
            // 
            // cromerToolStripMenuItem
            // 
            this.cromerToolStripMenuItem.BackColor = System.Drawing.Color.Peru;
            this.cromerToolStripMenuItem.Name = "cromerToolStripMenuItem";
            this.cromerToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.cromerToolStripMenuItem.Text = "Cromer";
            this.cromerToolStripMenuItem.Click += new System.EventHandler(this.cromerToolStripMenuItem_Click);
            // 
            // forSmallAngleToolStripMenuItem
            // 
            this.forSmallAngleToolStripMenuItem.BackColor = System.Drawing.Color.Wheat;
            this.forSmallAngleToolStripMenuItem.Name = "forSmallAngleToolStripMenuItem";
            this.forSmallAngleToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.forSmallAngleToolStripMenuItem.Text = "For Small Angle";
            this.forSmallAngleToolStripMenuItem.Click += new System.EventHandler(this.forSmallAngleToolStripMenuItem_Click_1);
            // 
            // realisticCaseByEulerToolStripMenuItem
            // 
            this.realisticCaseByEulerToolStripMenuItem.BackColor = System.Drawing.Color.NavajoWhite;
            this.realisticCaseByEulerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dampingToolStripMenuItem,
            this.drivingToolStripMenuItem,
            this.nonLinearToolStripMenuItem1});
            this.realisticCaseByEulerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.realisticCaseByEulerToolStripMenuItem.Name = "realisticCaseByEulerToolStripMenuItem";
            this.realisticCaseByEulerToolStripMenuItem.Size = new System.Drawing.Size(157, 35);
            this.realisticCaseByEulerToolStripMenuItem.Text = "Realistic Case By Euler";
            // 
            // dampingToolStripMenuItem
            // 
            this.dampingToolStripMenuItem.BackColor = System.Drawing.Color.Gold;
            this.dampingToolStripMenuItem.Name = "dampingToolStripMenuItem";
            this.dampingToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dampingToolStripMenuItem.Text = "Damping";
            this.dampingToolStripMenuItem.Click += new System.EventHandler(this.dampingToolStripMenuItem_Click_1);
            // 
            // drivingToolStripMenuItem
            // 
            this.drivingToolStripMenuItem.BackColor = System.Drawing.Color.LemonChiffon;
            this.drivingToolStripMenuItem.Name = "drivingToolStripMenuItem";
            this.drivingToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.drivingToolStripMenuItem.Text = "Driving";
            this.drivingToolStripMenuItem.Click += new System.EventHandler(this.drivingToolStripMenuItem_Click_1);
            // 
            // nonLinearToolStripMenuItem1
            // 
            this.nonLinearToolStripMenuItem1.BackColor = System.Drawing.Color.Khaki;
            this.nonLinearToolStripMenuItem1.Name = "nonLinearToolStripMenuItem1";
            this.nonLinearToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.nonLinearToolStripMenuItem1.Text = "Non-Linear";
            this.nonLinearToolStripMenuItem1.Click += new System.EventHandler(this.nonLinearToolStripMenuItem1_Click_1);
            // 
            // realisticCaseByEulerCromerToolStripMenuItem
            // 
            this.realisticCaseByEulerCromerToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.realisticCaseByEulerCromerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dampingToolStripMenuItem2,
            this.drivingToolStripMenuItem1,
            this.nonLinearToolStripMenuItem});
            this.realisticCaseByEulerCromerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.realisticCaseByEulerCromerToolStripMenuItem.Name = "realisticCaseByEulerCromerToolStripMenuItem";
            this.realisticCaseByEulerCromerToolStripMenuItem.Size = new System.Drawing.Size(206, 35);
            this.realisticCaseByEulerCromerToolStripMenuItem.Text = "Realistic Case By Euler Cromer";
            // 
            // dampingToolStripMenuItem2
            // 
            this.dampingToolStripMenuItem2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.dampingToolStripMenuItem2.Name = "dampingToolStripMenuItem2";
            this.dampingToolStripMenuItem2.Size = new System.Drawing.Size(145, 22);
            this.dampingToolStripMenuItem2.Text = "Damping";
            this.dampingToolStripMenuItem2.Click += new System.EventHandler(this.dampingToolStripMenuItem2_Click);
            // 
            // drivingToolStripMenuItem1
            // 
            this.drivingToolStripMenuItem1.BackColor = System.Drawing.Color.MintCream;
            this.drivingToolStripMenuItem1.Name = "drivingToolStripMenuItem1";
            this.drivingToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.drivingToolStripMenuItem1.Text = "Driving";
            this.drivingToolStripMenuItem1.Click += new System.EventHandler(this.drivingToolStripMenuItem1_Click_1);
            // 
            // nonLinearToolStripMenuItem
            // 
            this.nonLinearToolStripMenuItem.BackColor = System.Drawing.Color.MediumAquamarine;
            this.nonLinearToolStripMenuItem.Name = "nonLinearToolStripMenuItem";
            this.nonLinearToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.nonLinearToolStripMenuItem.Text = "Non-Linear";
            this.nonLinearToolStripMenuItem.Click += new System.EventHandler(this.nonLinearToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Pendulum Simulator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idealCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eulerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cromerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forSmallAngleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem realisticCaseByEulerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dampingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonLinearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem realisticCaseByEulerCromerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dampingToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem drivingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nonLinearToolStripMenuItem;
    }
}

