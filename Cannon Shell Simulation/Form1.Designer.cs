using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cannon_Shell_Simulation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private MenuStrip menuStrip1;

        private ToolStripMenuItem menuNoAirResistance;
        private ToolStripMenuItem menuAirResistance;
        private ToolStripMenuItem menuDensityCorrection;
        private ToolStripMenuItem menuMaximumRange;
        private ToolStripButton btnRun;
        private ToolStrip toolStrip1;

        private ToolStripButton btnSaveTrajectory;
        private ToolStripButton btnClear;
        private ToolStripButton btnReset;
        private ToolStripButton btnSaveImage;
        private ToolStripButton btnExportCSV;

        private Panel panelParameters;

        private Label lblParameters;

        private Label lblSpeed;
        private Label lblAngle;
        private Label lblMass;
        private Label lblDrag;
        private Label lblScaleHeight;
        private Label lblDt;

        private TextBox txtSpeed;
        private TextBox txtAngle;
        private TextBox txtMass;
        private TextBox txtDrag;
        private TextBox txtScaleHeight;
        private TextBox txtDt;

        private GroupBox grpEquation;
        private Label lblEquation;

        private PictureBox picGraph;

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuNoAirResistance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAirResistance = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDensityCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMaximumRange = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.btnSaveTrajectory = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.btnSaveImage = new System.Windows.Forms.ToolStripButton();
            this.btnExportCSV = new System.Windows.Forms.ToolStripButton();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.lblParameters = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.lblAngle = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.lblMass = new System.Windows.Forms.Label();
            this.txtMass = new System.Windows.Forms.TextBox();
            this.lblDrag = new System.Windows.Forms.Label();
            this.txtDrag = new System.Windows.Forms.TextBox();
            this.lblScaleHeight = new System.Windows.Forms.Label();
            this.txtScaleHeight = new System.Windows.Forms.TextBox();
            this.lblDt = new System.Windows.Forms.Label();
            this.txtDt = new System.Windows.Forms.TextBox();
            this.grpEquation = new System.Windows.Forms.GroupBox();
            this.lblEquation = new System.Windows.Forms.Label();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelParameters.SuspendLayout();
            this.grpEquation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNoAirResistance,
            this.menuAirResistance,
            this.menuDensityCorrection,
            this.menuMaximumRange});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1101, 27);
            this.menuStrip1.TabIndex = 3;
            // 
            // menuNoAirResistance
            // 
            this.menuNoAirResistance.Name = "menuNoAirResistance";
            this.menuNoAirResistance.Size = new System.Drawing.Size(138, 23);
            this.menuNoAirResistance.Text = "No Air Resistance";
            // 
            // menuAirResistance
            // 
            this.menuAirResistance.Name = "menuAirResistance";
            this.menuAirResistance.Size = new System.Drawing.Size(114, 23);
            this.menuAirResistance.Text = "Air Resistance";
            // 
            // menuDensityCorrection
            // 
            this.menuDensityCorrection.Name = "menuDensityCorrection";
            this.menuDensityCorrection.Size = new System.Drawing.Size(145, 23);
            this.menuDensityCorrection.Text = "Density Correction";
            // 
            // menuMaximumRange
            // 
            this.menuMaximumRange.Name = "menuMaximumRange";
            this.menuMaximumRange.Size = new System.Drawing.Size(134, 23);
            this.menuMaximumRange.Text = "Maximum Range";
            // 
            // toolStrip1
            // 

        
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveTrajectory,
            this.btnClear,
            this.btnReset,
            this.btnSaveImage,
            this.btnRun,
            this.btnExportCSV});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1101, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // btnSaveTrajectory
            // 
            this.btnSaveTrajectory.Name = "btnSaveTrajectory";
            this.btnSaveTrajectory.Size = new System.Drawing.Size(89, 22);
            this.btnSaveTrajectory.Text = "Save Trajectory";
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 22);
            this.btnClear.Text = "Clear";
            // 
            // btnReset
            // 
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(39, 22);
            this.btnReset.Text = "Reset";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(71, 22);
            this.btnSaveImage.Text = "Save Image";
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(69, 22);
            this.btnExportCSV.Text = "Export CSV";

            btnRun.Text = "Run";
            // 
            // panelParameters
            // 
            this.panelParameters.BackColor = System.Drawing.Color.AliceBlue;
            this.panelParameters.Controls.Add(this.lblParameters);
            this.panelParameters.Controls.Add(this.lblSpeed);
            this.panelParameters.Controls.Add(this.txtSpeed);
            this.panelParameters.Controls.Add(this.lblAngle);
            this.panelParameters.Controls.Add(this.txtAngle);
           
            this.panelParameters.Controls.Add(this.lblDrag);
            this.panelParameters.Controls.Add(this.txtDrag);
            this.panelParameters.Controls.Add(this.lblScaleHeight);
            this.panelParameters.Controls.Add(this.txtScaleHeight);
            this.panelParameters.Controls.Add(this.lblDt);
            this.panelParameters.Controls.Add(this.txtDt);
            this.panelParameters.Controls.Add(this.grpEquation);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelParameters.Location = new System.Drawing.Point(0, 52);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(214, 574);
            this.panelParameters.TabIndex = 1;
            // 
            // lblParameters
            // 
            this.lblParameters.AutoSize = true;
            this.lblParameters.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblParameters.Location = new System.Drawing.Point(17, 13);
            this.lblParameters.Name = "lblParameters";
            this.lblParameters.Size = new System.Drawing.Size(106, 20);
            this.lblParameters.TabIndex = 0;
            this.lblParameters.Text = "PARAMETERS";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(17, 48);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(92, 13);
            this.lblSpeed.TabIndex = 1;
            this.lblSpeed.Text = "Initial Speed (m/s)";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(17, 68);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(163, 20);
            this.txtSpeed.TabIndex = 2;
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(17, 102);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(86, 13);
            this.lblAngle.TabIndex = 3;
            this.lblAngle.Text = "Launch Angle (°)";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(17, 122);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(163, 20);
            this.txtAngle.TabIndex = 4;
            // 
         
            
            // 
            // lblDrag
            // 
            this.lblDrag.AutoSize = true;
            this.lblDrag.Location = new System.Drawing.Point(17, 157);
            this.lblDrag.Name = "lblDrag";
            this.lblDrag.Size = new System.Drawing.Size(61, 13);
            this.lblDrag.TabIndex = 7;
            this.lblDrag.Text = "B₂ / m (m⁻¹)";
            // 
            // txtDrag
            // 
            this.txtDrag.Location = new System.Drawing.Point(17, 177);
            this.txtDrag.Name = "txtDrag";
            this.txtDrag.Size = new System.Drawing.Size(163, 20);
            this.txtDrag.TabIndex = 8;
            // 
            // lblScaleHeight
            // 
            this.lblScaleHeight.AutoSize = true;
            this.lblScaleHeight.Location = new System.Drawing.Point(17, 220);
            this.lblScaleHeight.Name = "lblScaleHeight";
            this.lblScaleHeight.Size = new System.Drawing.Size(85, 13);
            this.lblScaleHeight.TabIndex = 9;
            this.lblScaleHeight.Text = "Scale Height (m)";
            // 
            // txtScaleHeight
            // 
            this.txtScaleHeight.Location = new System.Drawing.Point(17, 240);
            this.txtScaleHeight.Name = "txtScaleHeight";
            this.txtScaleHeight.Size = new System.Drawing.Size(163, 20);
            this.txtScaleHeight.TabIndex = 10;
            // 
            // lblDt
            // 
            this.lblDt.AutoSize = true;
            this.lblDt.Location = new System.Drawing.Point(17, 285);
            this.lblDt.Name = "lblDt";
            this.lblDt.Size = new System.Drawing.Size(31, 13);
            this.lblDt.TabIndex = 11;
            this.lblDt.Text = "Δt (s)";
            // 
            // txtDt
            // 
            this.txtDt.Location = new System.Drawing.Point(17, 305);
            this.txtDt.Name = "txtDt";
            this.txtDt.Size = new System.Drawing.Size(163, 20);
            this.txtDt.TabIndex = 12;
            // 
            // grpEquation
            // 
            this.grpEquation.Controls.Add(this.lblEquation);
            this.grpEquation.Location = new System.Drawing.Point(13, 386);
            this.grpEquation.Name = "grpEquation";
            this.grpEquation.Size = new System.Drawing.Size(184, 104);
            this.grpEquation.TabIndex = 13;
            this.grpEquation.TabStop = false;
            this.grpEquation.Text = "Current Equation";
            // 
            // lblEquation
            // 
            this.lblEquation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEquation.Font = new System.Drawing.Font("Consolas", 10F);
            this.lblEquation.Location = new System.Drawing.Point(3, 16);
            this.lblEquation.Name = "lblEquation";
            this.lblEquation.Size = new System.Drawing.Size(178, 85);
            this.lblEquation.TabIndex = 0;
            this.lblEquation.Text = "Select a simulation";
            this.lblEquation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picGraph
            // 
            this.picGraph.BackColor = System.Drawing.Color.White;
            this.picGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraph.Location = new System.Drawing.Point(214, 52);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(887, 574);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 626);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1101, 24);
            this.statusStrip1.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(51, 19);
            this.lblStatus.Text = "Ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1101, 650);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(945, 612);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Projectile Motion : Cannon Shell Simulation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            this.grpEquation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}