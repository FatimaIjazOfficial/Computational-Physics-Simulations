namespace Coupled_Motion_Simulation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelNA = new System.Windows.Forms.Label();
            this.labelNB = new System.Windows.Forms.Label();
            this.labelTauA = new System.Windows.Forms.Label();
            this.labelTauB = new System.Windows.Forms.Label();
            this.labelDT = new System.Windows.Forms.Label();
            this.labelSteps = new System.Windows.Forms.Label();
            this.txtNA = new System.Windows.Forms.TextBox();
            this.txtNB = new System.Windows.Forms.TextBox();
            this.txtTauA = new System.Windows.Forms.TextBox();
            this.txtTauB = new System.Windows.Forms.TextBox();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.txtSteps = new System.Windows.Forms.TextBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.toolStrip1.TabIndex = 3;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton1.Text = "▶ One Way";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton2.Text = "⇄ Two Way";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(38, 22);
            this.toolStripButton3.Text = "Clear";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(39, 22);
            this.toolStripButton4.Text = "Reset";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(35, 22);
            this.toolStripButton5.Text = "Save";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(32, 22);
            this.toolStripButton6.Text = "CSV";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.BackColor = System.Drawing.Color.AliceBlue;
            this.panelParameters.Controls.Add(this.labelTitle);
            this.panelParameters.Controls.Add(this.labelNA);
            this.panelParameters.Controls.Add(this.labelNB);
            this.panelParameters.Controls.Add(this.labelTauA);
            this.panelParameters.Controls.Add(this.labelTauB);
            this.panelParameters.Controls.Add(this.labelDT);
            this.panelParameters.Controls.Add(this.labelSteps);
            this.panelParameters.Controls.Add(this.txtNA);
            this.panelParameters.Controls.Add(this.txtNB);
            this.panelParameters.Controls.Add(this.txtTauA);
            this.panelParameters.Controls.Add(this.txtTauB);
            this.panelParameters.Controls.Add(this.txtDT);
            this.panelParameters.Controls.Add(this.txtSteps);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelParameters.Location = new System.Drawing.Point(0, 25);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(250, 503);
            this.panelParameters.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(50, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(145, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Coupled Decay";
            // 
            // labelNA
            // 
            this.labelNA.AutoSize = true;
            this.labelNA.Location = new System.Drawing.Point(20, 70);
            this.labelNA.Name = "labelNA";
            this.labelNA.Size = new System.Drawing.Size(55, 13);
            this.labelNA.TabIndex = 1;
            this.labelNA.Text = "Initial N(A)";
            // 
            // labelNB
            // 
            this.labelNB.AutoSize = true;
            this.labelNB.Location = new System.Drawing.Point(20, 110);
            this.labelNB.Name = "labelNB";
            this.labelNB.Size = new System.Drawing.Size(55, 13);
            this.labelNB.TabIndex = 2;
            this.labelNB.Text = "Initial N(B)";
            // 
            // labelTauA
            // 
            this.labelTauA.AutoSize = true;
            this.labelTauA.Location = new System.Drawing.Point(20, 150);
            this.labelTauA.Name = "labelTauA";
            this.labelTauA.Size = new System.Drawing.Size(36, 13);
            this.labelTauA.TabIndex = 3;
            this.labelTauA.Text = "Tau A";
            // 
            // labelTauB
            // 
            this.labelTauB.AutoSize = true;
            this.labelTauB.Location = new System.Drawing.Point(20, 190);
            this.labelTauB.Name = "labelTauB";
            this.labelTauB.Size = new System.Drawing.Size(36, 13);
            this.labelTauB.TabIndex = 4;
            this.labelTauB.Text = "Tau B";
            // 
            // labelDT
            // 
            this.labelDT.AutoSize = true;
            this.labelDT.Location = new System.Drawing.Point(20, 230);
            this.labelDT.Name = "labelDT";
            this.labelDT.Size = new System.Drawing.Size(55, 13);
            this.labelDT.TabIndex = 5;
            this.labelDT.Text = "Time Step";
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(20, 270);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(34, 13);
            this.labelSteps.TabIndex = 6;
            this.labelSteps.Text = "Steps";
            // 
            // txtNA
            // 
            this.txtNA.Location = new System.Drawing.Point(150, 70);
            this.txtNA.Name = "txtNA";
            this.txtNA.Size = new System.Drawing.Size(70, 20);
            this.txtNA.TabIndex = 7;
            this.txtNA.Text = "100";
            // 
            // txtNB
            // 
            this.txtNB.Location = new System.Drawing.Point(150, 110);
            this.txtNB.Name = "txtNB";
            this.txtNB.Size = new System.Drawing.Size(70, 20);
            this.txtNB.TabIndex = 8;
            this.txtNB.Text = "0";
            // 
            // txtTauA
            // 
            this.txtTauA.Location = new System.Drawing.Point(150, 150);
            this.txtTauA.Name = "txtTauA";
            this.txtTauA.Size = new System.Drawing.Size(70, 20);
            this.txtTauA.TabIndex = 9;
            this.txtTauA.Text = "10";
            // 
            // txtTauB
            // 
            this.txtTauB.Location = new System.Drawing.Point(150, 190);
            this.txtTauB.Name = "txtTauB";
            this.txtTauB.Size = new System.Drawing.Size(70, 20);
            this.txtTauB.TabIndex = 10;
            this.txtTauB.Text = "5";
            // 
            // txtDT
            // 
            this.txtDT.Location = new System.Drawing.Point(150, 230);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(70, 20);
            this.txtDT.TabIndex = 11;
            this.txtDT.Text = "0.1";
            // 
            // txtSteps
            // 
            this.txtSteps.Location = new System.Drawing.Point(150, 270);
            this.txtSteps.Name = "txtSteps";
            this.txtSteps.Size = new System.Drawing.Size(70, 20);
            this.txtSteps.TabIndex = 12;
            this.txtSteps.Text = "500";
            // 
            // picGraph
            // 
            this.picGraph.BackColor = System.Drawing.Color.NavajoWhite;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraph.Location = new System.Drawing.Point(250, 25);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(650, 503);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 22);
            this.statusStrip1.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computational Physics - Coupled Decay Simulation";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;

        private System.Windows.Forms.Panel panelParameters;

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelNA;
        private System.Windows.Forms.Label labelNB;
        private System.Windows.Forms.Label labelTauA;
        private System.Windows.Forms.Label labelTauB;
        private System.Windows.Forms.Label labelDT;
        private System.Windows.Forms.Label labelSteps;

        private System.Windows.Forms.TextBox txtNA;
        private System.Windows.Forms.TextBox txtNB;
        private System.Windows.Forms.TextBox txtTauA;
        private System.Windows.Forms.TextBox txtTauB;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.TextBox txtSteps;

        private System.Windows.Forms.PictureBox picGraph;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}