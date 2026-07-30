namespace Radioactive_Decay_Simulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeStep = new System.Windows.Forms.TextBox();
            this.txtLambda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInitialAtoms = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.panelParameters.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.BurlyWood;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(770, 53);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 50);
            this.toolStripButton1.Text = "▶ Run\n";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 50);
            this.toolStripButton2.Text = "⏹ Clear\n";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(86, 50);
            this.toolStripButton3.Text = "🔄 Reset\n";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(78, 50);
            this.toolStripButton4.Text = "💾 Save\n";
            this.toolStripButton4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(131, 50);
            this.toolStripButton5.Text = "📊 Export CSV";
            this.toolStripButton5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.BackColor = System.Drawing.Color.Thistle;
            this.panelParameters.Controls.Add(this.statusStrip1);
            this.panelParameters.Controls.Add(this.label5);
            this.panelParameters.Controls.Add(this.txtIterations);
            this.panelParameters.Controls.Add(this.label4);
            this.panelParameters.Controls.Add(this.label3);
            this.panelParameters.Controls.Add(this.txtTimeStep);
            this.panelParameters.Controls.Add(this.txtLambda);
            this.panelParameters.Controls.Add(this.label2);
            this.panelParameters.Controls.Add(this.txtInitialAtoms);
            this.panelParameters.Controls.Add(this.label1);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelParameters.Location = new System.Drawing.Point(0, 53);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(250, 397);
            this.panelParameters.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LavenderBlush;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 367);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(250, 30);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 25);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("News706 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Simulation Parameters\n";
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(163, 178);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(72, 20);
            this.txtIterations.TabIndex = 6;
            this.txtIterations.Text = "150";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(18, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Iterations";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(18, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Time Step (Δt)";
            // 
            // txtTimeStep
            // 
            this.txtTimeStep.Location = new System.Drawing.Point(163, 140);
            this.txtTimeStep.Name = "txtTimeStep";
            this.txtTimeStep.Size = new System.Drawing.Size(72, 20);
            this.txtTimeStep.TabIndex = 4;
            this.txtTimeStep.Text = "0.1";
            // 
            // txtLambda
            // 
            this.txtLambda.Location = new System.Drawing.Point(163, 102);
            this.txtLambda.Name = "txtLambda";
            this.txtLambda.Size = new System.Drawing.Size(72, 20);
            this.txtLambda.TabIndex = 3;
            this.txtLambda.Text = "0.5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(18, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Decay Constant (λ)";
            // 
            // txtInitialAtoms
            // 
            this.txtInitialAtoms.Location = new System.Drawing.Point(163, 65);
            this.txtInitialAtoms.Name = "txtInitialAtoms";
            this.txtInitialAtoms.Size = new System.Drawing.Size(72, 20);
            this.txtInitialAtoms.TabIndex = 1;
            this.txtInitialAtoms.Text = "150";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Initial Atoms (N₀)";
            // 
            // picGraph
            // 
            this.picGraph.BackColor = System.Drawing.Color.NavajoWhite;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraph.Location = new System.Drawing.Point(250, 53);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(520, 397);
            this.picGraph.TabIndex = 3;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 450);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Computational Physics - Radioactive Decay Simulation";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInitialAtoms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLambda;
        private System.Windows.Forms.TextBox txtTimeStep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIterations;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox picGraph;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

