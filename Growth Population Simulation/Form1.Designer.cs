namespace Growth_Population_Simulation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
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
            this.panelParameters = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelN0 = new System.Windows.Forms.Label();
            this.txtN0 = new System.Windows.Forms.TextBox();
            this.labelA = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.labelB = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.labelDT = new System.Windows.Forms.Label();
            this.txtDT = new System.Windows.Forms.TextBox();
            this.labelSteps = new System.Windows.Forms.Label();
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
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 25);
            this.toolStrip1.TabIndex = 3;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripButton1.Text = "▶ Run";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(53, 22);
            this.toolStripButton2.Text = "⏹ Clear";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(54, 22);
            this.toolStripButton3.Text = "🔄 Reset";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton4.Text = "💾 Save";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton5.Text = "📊 CSV";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.BackColor = System.Drawing.Color.AliceBlue;
            this.panelParameters.Controls.Add(this.labelTitle);
            this.panelParameters.Controls.Add(this.labelN0);
            this.panelParameters.Controls.Add(this.txtN0);
            this.panelParameters.Controls.Add(this.labelA);
            this.panelParameters.Controls.Add(this.txtA);
            this.panelParameters.Controls.Add(this.labelB);
            this.panelParameters.Controls.Add(this.txtB);
            this.panelParameters.Controls.Add(this.labelDT);
            this.panelParameters.Controls.Add(this.txtDT);
            this.panelParameters.Controls.Add(this.labelSteps);
            this.panelParameters.Controls.Add(this.txtSteps);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelParameters.Location = new System.Drawing.Point(0, 25);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(260, 453);
            this.panelParameters.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(182, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Population Growth";
            // 
            // labelN0
            // 
            this.labelN0.AutoSize = true;
            this.labelN0.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelN0.Location = new System.Drawing.Point(20, 70);
            this.labelN0.Name = "labelN0";
            this.labelN0.Size = new System.Drawing.Size(146, 19);
            this.labelN0.TabIndex = 1;
            this.labelN0.Text = "Initial Population N0";
            // 
            // txtN0
            // 
            this.txtN0.Location = new System.Drawing.Point(170, 70);
            this.txtN0.Name = "txtN0";
            this.txtN0.Size = new System.Drawing.Size(70, 20);
            this.txtN0.TabIndex = 2;
            this.txtN0.Text = "1";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Font = this.labelN0.Font;
            this.labelA.Location = new System.Drawing.Point(20, 110);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(104, 19);
            this.labelA.TabIndex = 3;
            this.labelA.Text = "Growth Rate a";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(170, 110);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(70, 20);
            this.txtA.TabIndex = 4;
            this.txtA.Text = "10";
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Font = this.labelN0.Font;
            this.labelB.Location = new System.Drawing.Point(20, 150);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(95, 19);
            this.labelB.TabIndex = 5;
            this.labelB.Text = "Death Rate b";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(170, 150);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(70, 20);
            this.txtB.TabIndex = 6;
            this.txtB.Text = "3";
            // 
            // labelDT
            // 
            this.labelDT.AutoSize = true;
            this.labelDT.Font = this.labelN0.Font;
            this.labelDT.Location = new System.Drawing.Point(20, 190);
            this.labelDT.Name = "labelDT";
            this.labelDT.Size = new System.Drawing.Size(94, 19);
            this.labelDT.TabIndex = 7;
            this.labelDT.Text = "Time Step dt";
            // 
            // txtDT
            // 
            this.txtDT.Location = new System.Drawing.Point(170, 190);
            this.txtDT.Name = "txtDT";
            this.txtDT.Size = new System.Drawing.Size(70, 20);
            this.txtDT.TabIndex = 8;
            this.txtDT.Text = "0.001";
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Font = this.labelN0.Font;
            this.labelSteps.Location = new System.Drawing.Point(20, 230);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(104, 19);
            this.labelSteps.TabIndex = 9;
            this.labelSteps.Text = "Number Steps";
            // 
            // txtSteps
            // 
            this.txtSteps.Location = new System.Drawing.Point(170, 230);
            this.txtSteps.Name = "txtSteps";
            this.txtSteps.Size = new System.Drawing.Size(70, 20);
            this.txtSteps.TabIndex = 10;
            this.txtSteps.Text = "10000";
            // 
            // picGraph
            // 
            this.picGraph.BackColor = System.Drawing.Color.NavajoWhite;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraph.Location = new System.Drawing.Point(260, 25);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(640, 453);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
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
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computational Physics - Population Growth Simulation";
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


        private System.Windows.Forms.Panel panelParameters;


        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelN0;
        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelDT;
        private System.Windows.Forms.Label labelSteps;


        private System.Windows.Forms.TextBox txtN0;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtDT;
        private System.Windows.Forms.TextBox txtSteps;


        private System.Windows.Forms.PictureBox picGraph;


        private System.Windows.Forms.StatusStrip statusStrip1;

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}