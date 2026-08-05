namespace Lorenz_Model
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zVsTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zVsXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zVsYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xVsTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xVsYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xVsZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yVsTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yVsXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yVsZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.zVsTToolStripMenuItem,
            this.zVsXToolStripMenuItem,
            this.zVsYToolStripMenuItem,
            this.xVsTToolStripMenuItem,
            this.xVsYToolStripMenuItem,
            this.xVsZToolStripMenuItem,
            this.yVsTToolStripMenuItem,
            this.yVsXToolStripMenuItem,
            this.yVsZToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 39);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(129, 35);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // zVsTToolStripMenuItem
            // 
            this.zVsTToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.zVsTToolStripMenuItem.Name = "zVsTToolStripMenuItem";
            this.zVsTToolStripMenuItem.Size = new System.Drawing.Size(57, 35);
            this.zVsTToolStripMenuItem.Text = "Z vs T";
            this.zVsTToolStripMenuItem.Click += new System.EventHandler(this.zVsTToolStripMenuItem_Click_1);
            // 
            // zVsXToolStripMenuItem
            // 
            this.zVsXToolStripMenuItem.BackColor = System.Drawing.Color.LavenderBlush;
            this.zVsXToolStripMenuItem.Name = "zVsXToolStripMenuItem";
            this.zVsXToolStripMenuItem.Size = new System.Drawing.Size(58, 35);
            this.zVsXToolStripMenuItem.Text = "Z vs X";
            this.zVsXToolStripMenuItem.Click += new System.EventHandler(this.zVsXToolStripMenuItem_Click_1);
            // 
            // zVsYToolStripMenuItem
            // 
            this.zVsYToolStripMenuItem.BackColor = System.Drawing.Color.Violet;
            this.zVsYToolStripMenuItem.Name = "zVsYToolStripMenuItem";
            this.zVsYToolStripMenuItem.Size = new System.Drawing.Size(57, 35);
            this.zVsYToolStripMenuItem.Text = "Z vs Y";
            this.zVsYToolStripMenuItem.Click += new System.EventHandler(this.zVsYToolStripMenuItem_Click_1);
            // 
            // xVsTToolStripMenuItem
            // 
            this.xVsTToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.xVsTToolStripMenuItem.Name = "xVsTToolStripMenuItem";
            this.xVsTToolStripMenuItem.Size = new System.Drawing.Size(58, 35);
            this.xVsTToolStripMenuItem.Text = "X vs T";
            this.xVsTToolStripMenuItem.Click += new System.EventHandler(this.xVsTToolStripMenuItem_Click_1);
            // 
            // xVsYToolStripMenuItem
            // 
            this.xVsYToolStripMenuItem.BackColor = System.Drawing.Color.Violet;
            this.xVsYToolStripMenuItem.Name = "xVsYToolStripMenuItem";
            this.xVsYToolStripMenuItem.Size = new System.Drawing.Size(58, 35);
            this.xVsYToolStripMenuItem.Text = "X vs Y";
            this.xVsYToolStripMenuItem.Click += new System.EventHandler(this.xVsYToolStripMenuItem_Click_1);
            // 
            // xVsZToolStripMenuItem
            // 
            this.xVsZToolStripMenuItem.BackColor = System.Drawing.Color.Thistle;
            this.xVsZToolStripMenuItem.Name = "xVsZToolStripMenuItem";
            this.xVsZToolStripMenuItem.Size = new System.Drawing.Size(58, 35);
            this.xVsZToolStripMenuItem.Text = "X vs Z";
            this.xVsZToolStripMenuItem.Click += new System.EventHandler(this.xVsZToolStripMenuItem_Click_1);
            // 
            // yVsTToolStripMenuItem
            // 
            this.yVsTToolStripMenuItem.BackColor = System.Drawing.Color.PaleVioletRed;
            this.yVsTToolStripMenuItem.Name = "yVsTToolStripMenuItem";
            this.yVsTToolStripMenuItem.Size = new System.Drawing.Size(57, 35);
            this.yVsTToolStripMenuItem.Text = "Y vs T";
            this.yVsTToolStripMenuItem.Click += new System.EventHandler(this.yVsTToolStripMenuItem_Click_1);
            // 
            // yVsXToolStripMenuItem
            // 
            this.yVsXToolStripMenuItem.BackColor = System.Drawing.Color.LavenderBlush;
            this.yVsXToolStripMenuItem.Name = "yVsXToolStripMenuItem";
            this.yVsXToolStripMenuItem.Size = new System.Drawing.Size(58, 35);
            this.yVsXToolStripMenuItem.Text = "Y vs X";
            this.yVsXToolStripMenuItem.Click += new System.EventHandler(this.yVsXToolStripMenuItem_Click_1);
            // 
            // yVsZToolStripMenuItem
            // 
            this.yVsZToolStripMenuItem.BackColor = System.Drawing.Color.Thistle;
            this.yVsZToolStripMenuItem.Name = "yVsZToolStripMenuItem";
            this.yVsZToolStripMenuItem.Size = new System.Drawing.Size(57, 35);
            this.yVsZToolStripMenuItem.Text = "Y vs Z";
            this.yVsZToolStripMenuItem.Click += new System.EventHandler(this.yVsZToolStripMenuItem_Click_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Lorenz Model";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zVsTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zVsXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zVsYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xVsTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xVsYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xVsZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yVsTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yVsXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yVsZToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
    }
}

