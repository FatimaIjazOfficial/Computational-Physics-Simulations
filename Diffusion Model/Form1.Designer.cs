namespace Diffusion_Model
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
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diffusionEquationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diffusionEqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.particleDiffusionIn2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Desktop;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.diffusionEquationToolStripMenuItem,
            this.diffusionEqToolStripMenuItem,
            this.particleDiffusionIn2DToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(19, 7, 0, 7);
            this.menuStrip1.Size = new System.Drawing.Size(1284, 65);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.BackColor = System.Drawing.Color.DarkKhaki;
            this.refreshToolStripMenuItem.Font = new System.Drawing.Font("Sitka Subheading", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(143, 51);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // diffusionEquationToolStripMenuItem
            // 
            this.diffusionEquationToolStripMenuItem.BackColor = System.Drawing.Color.Khaki;
            this.diffusionEquationToolStripMenuItem.Font = new System.Drawing.Font("Sitka Banner", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.diffusionEquationToolStripMenuItem.Name = "diffusionEquationToolStripMenuItem";
            this.diffusionEquationToolStripMenuItem.Size = new System.Drawing.Size(212, 51);
            this.diffusionEquationToolStripMenuItem.Text = "1D Diffusion Equation";
            this.diffusionEquationToolStripMenuItem.Click += new System.EventHandler(this.diffusionEquationToolStripMenuItem_Click);
            // 
            // diffusionEqToolStripMenuItem
            // 
            this.diffusionEqToolStripMenuItem.BackColor = System.Drawing.Color.BurlyWood;
            this.diffusionEqToolStripMenuItem.Font = new System.Drawing.Font("Sitka Banner", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.diffusionEqToolStripMenuItem.Name = "diffusionEqToolStripMenuItem";
            this.diffusionEqToolStripMenuItem.Size = new System.Drawing.Size(183, 51);
            this.diffusionEqToolStripMenuItem.Text = "Entropy Evolution";
            this.diffusionEqToolStripMenuItem.Click += new System.EventHandler(this.diffusionEqToolStripMenuItem_Click);
            // 
            // particleDiffusionIn2DToolStripMenuItem
            // 
            this.particleDiffusionIn2DToolStripMenuItem.BackColor = System.Drawing.Color.Wheat;
            this.particleDiffusionIn2DToolStripMenuItem.Font = new System.Drawing.Font("Sitka Banner", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.particleDiffusionIn2DToolStripMenuItem.Name = "particleDiffusionIn2DToolStripMenuItem";
            this.particleDiffusionIn2DToolStripMenuItem.Size = new System.Drawing.Size(364, 51);
            this.particleDiffusionIn2DToolStripMenuItem.Text = "Particle Diffusion in 2D (With Entropy)";
            this.particleDiffusionIn2DToolStripMenuItem.Click += new System.EventHandler(this.particleDiffusionIn2DToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 47F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1284, 1005);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Sitka Subheading", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diffusionEquationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diffusionEqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem particleDiffusionIn2DToolStripMenuItem;
    }
}

