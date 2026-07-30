namespace PARACHUTE_MOTION_SIMULATION
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

        #region Windows Form Designer generated code

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
            this.labelVelocity = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.labelGravity = new System.Windows.Forms.Label();
            this.txtGravity = new System.Windows.Forms.TextBox();
            this.labelDrag = new System.Windows.Forms.Label();
            this.txtDrag = new System.Windows.Forms.TextBox();
            this.labelTimeStep = new System.Windows.Forms.Label();
            this.txtTimeStep = new System.Windows.Forms.TextBox();
            this.labelSteps = new System.Windows.Forms.Label();
            this.txtSteps = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.toolStrip1.Size = new System.Drawing.Size(900, 30);
            this.toolStrip1.TabIndex = 2;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 27);
            this.toolStripButton1.Text = "▶ Run";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = this.toolStripButton1.Font;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(84, 27);
            this.toolStripButton2.Text = "⏹ Clear";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Font = this.toolStripButton1.Font;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(86, 27);
            this.toolStripButton3.Text = "🔄 Reset";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Font = this.toolStripButton1.Font;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(78, 27);
            this.toolStripButton4.Text = "💾 Save";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Font = this.toolStripButton1.Font;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(131, 27);
            this.toolStripButton5.Text = "📊 Export CSV";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // panelParameters
            // 
            this.panelParameters.BackColor = System.Drawing.Color.AliceBlue;
            this.panelParameters.Controls.Add(this.labelTitle);
            this.panelParameters.Controls.Add(this.labelVelocity);
            this.panelParameters.Controls.Add(this.txtVelocity);
            this.panelParameters.Controls.Add(this.labelGravity);
            this.panelParameters.Controls.Add(this.txtGravity);
            this.panelParameters.Controls.Add(this.labelDrag);
            this.panelParameters.Controls.Add(this.txtDrag);
            this.panelParameters.Controls.Add(this.labelTimeStep);
            this.panelParameters.Controls.Add(this.txtTimeStep);
            this.panelParameters.Controls.Add(this.labelSteps);
            this.panelParameters.Controls.Add(this.txtSteps);
            this.panelParameters.Controls.Add(this.statusStrip1);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelParameters.Location = new System.Drawing.Point(0, 30);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(260, 470);
            this.panelParameters.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("News706 BT", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(15, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(227, 22);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Simulation Parameters";
            // 
            // labelVelocity
            // 
            this.labelVelocity.AutoSize = true;
            this.labelVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelVelocity.Location = new System.Drawing.Point(20, 70);
            this.labelVelocity.Name = "labelVelocity";
            this.labelVelocity.Size = new System.Drawing.Size(151, 17);
            this.labelVelocity.TabIndex = 1;
            this.labelVelocity.Text = "Initial Velocity (m/s)";
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(170, 70);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(70, 20);
            this.txtVelocity.TabIndex = 2;
            this.txtVelocity.Text = "50";
            // 
            // labelGravity
            // 
            this.labelGravity.AutoSize = true;
            this.labelGravity.Font = this.labelVelocity.Font;
            this.labelGravity.Location = new System.Drawing.Point(20, 110);
            this.labelGravity.Name = "labelGravity";
            this.labelGravity.Size = new System.Drawing.Size(108, 17);
            this.labelGravity.TabIndex = 3;
            this.labelGravity.Text = "Gravity (m/s²)";
            // 
            // txtGravity
            // 
            this.txtGravity.Location = new System.Drawing.Point(170, 110);
            this.txtGravity.Name = "txtGravity";
            this.txtGravity.Size = new System.Drawing.Size(70, 20);
            this.txtGravity.TabIndex = 4;
            this.txtGravity.Text = "9.8";
            // 
            // labelDrag
            // 
            this.labelDrag.AutoSize = true;
            this.labelDrag.Font = this.labelVelocity.Font;
            this.labelDrag.Location = new System.Drawing.Point(20, 150);
            this.labelDrag.Name = "labelDrag";
            this.labelDrag.Size = new System.Drawing.Size(125, 17);
            this.labelDrag.TabIndex = 5;
            this.labelDrag.Text = "Drag Coefficient";
            // 
            // txtDrag
            // 
            this.txtDrag.Location = new System.Drawing.Point(170, 150);
            this.txtDrag.Name = "txtDrag";
            this.txtDrag.Size = new System.Drawing.Size(70, 20);
            this.txtDrag.TabIndex = 6;
            this.txtDrag.Text = "1";
            // 
            // labelTimeStep
            // 
            this.labelTimeStep.AutoSize = true;
            this.labelTimeStep.Font = this.labelVelocity.Font;
            this.labelTimeStep.Location = new System.Drawing.Point(20, 190);
            this.labelTimeStep.Name = "labelTimeStep";
            this.labelTimeStep.Size = new System.Drawing.Size(106, 17);
            this.labelTimeStep.TabIndex = 7;
            this.labelTimeStep.Text = "Time Step (s)";
            // 
            // txtTimeStep
            // 
            this.txtTimeStep.Location = new System.Drawing.Point(170, 190);
            this.txtTimeStep.Name = "txtTimeStep";
            this.txtTimeStep.Size = new System.Drawing.Size(70, 20);
            this.txtTimeStep.TabIndex = 8;
            this.txtTimeStep.Text = "0.1";
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Font = this.labelVelocity.Font;
            this.labelSteps.Location = new System.Drawing.Point(20, 230);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(129, 17);
            this.labelSteps.TabIndex = 9;
            this.labelSteps.Text = "Number of Steps";
            // 
            // txtSteps
            // 
            this.txtSteps.Location = new System.Drawing.Point(170, 230);
            this.txtSteps.Name = "txtSteps";
            this.txtSteps.Size = new System.Drawing.Size(70, 20);
            this.txtSteps.TabIndex = 10;
            this.txtSteps.Text = "150";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LavenderBlush;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 444);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(260, 26);
            this.statusStrip1.TabIndex = 11;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(58, 21);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // picGraph
            // 
            this.picGraph.BackColor = System.Drawing.Color.NavajoWhite;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraph.Location = new System.Drawing.Point(260, 30);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(640, 470);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            this.picGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picGraph_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computational Physics - Parachute Velocity-Time Simulation";
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

        //==================================================
        // DECLARATIONS
        //==================================================

        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;

        private System.Windows.Forms.Panel panelParameters;

        private System.Windows.Forms.Label labelTitle;

        private System.Windows.Forms.Label labelVelocity;
        private System.Windows.Forms.Label labelGravity;
        private System.Windows.Forms.Label labelDrag;
        private System.Windows.Forms.Label labelTimeStep;
        private System.Windows.Forms.Label labelSteps;

        private System.Windows.Forms.TextBox txtVelocity;
        private System.Windows.Forms.TextBox txtGravity;
        private System.Windows.Forms.TextBox txtDrag;
        private System.Windows.Forms.TextBox txtTimeStep;
        private System.Windows.Forms.TextBox txtSteps;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

        private System.Windows.Forms.PictureBox picGraph;
    }
}
