using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bicycle_Racing_Simulation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.ToolStripMenuItem menuNoAir;
        private System.Windows.Forms.ToolStripMenuItem menuExact;
        private System.Windows.Forms.ToolStripMenuItem menuAir;
        private System.Windows.Forms.ToolStripMenuItem menuDraft;
        private System.Windows.Forms.ToolStripMenuItem menuUphill;
        private System.Windows.Forms.ToolStripMenuItem menuDownhill;
        private System.Windows.Forms.ToolStripMenuItem menuForce;

        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnReset;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCSV;

        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.PictureBox picGraph;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;


        private System.Windows.Forms.Label lblMass;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Label lblDt;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblDrag;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblDensity;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblForce;
        private System.Windows.Forms.Label lblCrossVelocity;


        private System.Windows.Forms.TextBox txtMass;
        private System.Windows.Forms.TextBox txtVelocity;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.TextBox txtDt;
        private System.Windows.Forms.TextBox txtTotalTime;
        private System.Windows.Forms.TextBox txtDrag;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtDensity;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.TextBox txtForce;
        private System.Windows.Forms.TextBox txtCrossVelocity;


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuAir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNoAir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExact = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDraft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUphill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDownhill = new System.Windows.Forms.ToolStripMenuItem();
            this.menuForce = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnReset = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCSV = new System.Windows.Forms.ToolStripButton();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.lblMass = new System.Windows.Forms.Label();
            this.txtMass = new System.Windows.Forms.TextBox();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.lblPower = new System.Windows.Forms.Label();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.lblDt = new System.Windows.Forms.Label();
            this.txtDt = new System.Windows.Forms.TextBox();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.txtTotalTime = new System.Windows.Forms.TextBox();
            this.lblDrag = new System.Windows.Forms.Label();
            this.txtDrag = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.lblDensity = new System.Windows.Forms.Label();
            this.txtDensity = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.lblForce = new System.Windows.Forms.Label();
            this.txtForce = new System.Windows.Forms.TextBox();
            this.lblCrossVelocity = new System.Windows.Forms.Label();
            this.txtCrossVelocity = new System.Windows.Forms.TextBox();
            this.picGraph = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGraph)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Chartreuse;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAir,
            this.menuNoAir,
            this.menuExact,
            this.menuDraft,
            this.menuUphill,
            this.menuDownhill,
            this.menuForce});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 25);
            this.menuStrip1.TabIndex = 3;
            // 
            // menuAir
            // 
            this.menuAir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuAir.Name = "menuAir";
            this.menuAir.Size = new System.Drawing.Size(106, 21);
            this.menuAir.Text = "Air Resistance";
            // 
            // menuNoAir
            // 
            this.menuNoAir.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuNoAir.Name = "menuNoAir";
            this.menuNoAir.Size = new System.Drawing.Size(128, 21);
            this.menuNoAir.Text = "No Air Resistance";
            // 
            // menuExact
            // 
            this.menuExact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuExact.Name = "menuExact";
            this.menuExact.Size = new System.Drawing.Size(111, 21);
            this.menuExact.Text = "Exact Compare";
            // 
            // menuDraft
            // 
            this.menuDraft.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuDraft.Name = "menuDraft";
            this.menuDraft.Size = new System.Drawing.Size(72, 21);
            this.menuDraft.Text = "Drafting";
            // 
            // menuUphill
            // 
            this.menuUphill.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuUphill.Name = "menuUphill";
            this.menuUphill.Size = new System.Drawing.Size(57, 21);
            this.menuUphill.Text = "Uphill";
            // 
            // menuDownhill
            // 
            this.menuDownhill.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuDownhill.Name = "menuDownhill";
            this.menuDownhill.Size = new System.Drawing.Size(76, 21);
            this.menuDownhill.Text = "Downhill";
            // 
            // menuForce
            // 
            this.menuForce.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.menuForce.Name = "menuForce";
            this.menuForce.Size = new System.Drawing.Size(112, 21);
            this.menuForce.Text = "Constant Force";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.CadetBlue;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClear,
            this.btnReset,
            this.btnSave,
            this.btnCSV});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(43, 22);
            this.btnClear.Text = "Clear";
            // 
            // btnReset
            // 
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 22);
            this.btnReset.Text = "Reset";
            // 
            // btnSave
            // 
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 22);
            this.btnSave.Text = "Save PNG";
            // 
            // btnCSV
            // 
            this.btnCSV.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(80, 22);
            this.btnCSV.Text = "Export CSV";
            // 
            // panelParameters
            // 
            this.panelParameters.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panelParameters.Controls.Add(this.lblMass);
            this.panelParameters.Controls.Add(this.txtMass);
            this.panelParameters.Controls.Add(this.lblVelocity);
            this.panelParameters.Controls.Add(this.txtVelocity);
            this.panelParameters.Controls.Add(this.lblPower);
            this.panelParameters.Controls.Add(this.txtPower);
            this.panelParameters.Controls.Add(this.lblDt);
            this.panelParameters.Controls.Add(this.txtDt);
            this.panelParameters.Controls.Add(this.lblTotalTime);
            this.panelParameters.Controls.Add(this.txtTotalTime);
            this.panelParameters.Controls.Add(this.lblDrag);
            this.panelParameters.Controls.Add(this.txtDrag);
            this.panelParameters.Controls.Add(this.lblArea);
            this.panelParameters.Controls.Add(this.txtArea);
            this.panelParameters.Controls.Add(this.lblDensity);
            this.panelParameters.Controls.Add(this.txtDensity);
            this.panelParameters.Controls.Add(this.lblGrade);
            this.panelParameters.Controls.Add(this.txtGrade);
            this.panelParameters.Controls.Add(this.lblForce);
            this.panelParameters.Controls.Add(this.txtForce);
            this.panelParameters.Controls.Add(this.lblCrossVelocity);
            this.panelParameters.Controls.Add(this.txtCrossVelocity);
            this.panelParameters.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelParameters.ForeColor = System.Drawing.Color.BlueViolet;
            this.panelParameters.Location = new System.Drawing.Point(0, 50);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(230, 579);
            this.panelParameters.TabIndex = 1;
            // 
            // lblMass
            // 
            this.lblMass.Location = new System.Drawing.Point(10, 20);
            this.lblMass.Name = "lblMass";
            this.lblMass.Size = new System.Drawing.Size(100, 23);
            this.lblMass.TabIndex = 0;
            this.lblMass.Text = "Mass (kg)";
            // 
            // txtMass
            // 
            this.txtMass.Location = new System.Drawing.Point(10, 44);
            this.txtMass.Name = "txtMass";
            this.txtMass.Size = new System.Drawing.Size(190, 20);
            this.txtMass.TabIndex = 1;
            // 
            // lblVelocity
            // 
            this.lblVelocity.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelocity.Location = new System.Drawing.Point(10, 70);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(100, 23);
            this.lblVelocity.TabIndex = 2;
            this.lblVelocity.Text = "Initial Velocity (m/s)";
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(10, 93);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(190, 20);
            this.txtVelocity.TabIndex = 3;
            // 
            // lblPower
            // 
            this.lblPower.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower.Location = new System.Drawing.Point(10, 120);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(100, 23);
            this.lblPower.TabIndex = 4;
            this.lblPower.Text = "Power (W)";
            // 
            // txtPower
            // 
            this.txtPower.Location = new System.Drawing.Point(10, 143);
            this.txtPower.Name = "txtPower";
            this.txtPower.Size = new System.Drawing.Size(190, 20);
            this.txtPower.TabIndex = 5;
            // 
            // lblDt
            // 
            this.lblDt.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDt.Location = new System.Drawing.Point(10, 170);
            this.lblDt.Name = "lblDt";
            this.lblDt.Size = new System.Drawing.Size(100, 23);
            this.lblDt.TabIndex = 6;
            this.lblDt.Text = "Time Step (s)";
            // 
            // txtDt
            // 
            this.txtDt.Location = new System.Drawing.Point(10, 193);
            this.txtDt.Name = "txtDt";
            this.txtDt.Size = new System.Drawing.Size(190, 20);
            this.txtDt.TabIndex = 7;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTime.Location = new System.Drawing.Point(10, 220);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(100, 23);
            this.lblTotalTime.TabIndex = 8;
            this.lblTotalTime.Text = "Total Time (s)";
            // 
            // txtTotalTime
            // 
            this.txtTotalTime.Location = new System.Drawing.Point(10, 243);
            this.txtTotalTime.Name = "txtTotalTime";
            this.txtTotalTime.Size = new System.Drawing.Size(190, 20);
            this.txtTotalTime.TabIndex = 9;
            // 
            // lblDrag
            // 
            this.lblDrag.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrag.Location = new System.Drawing.Point(10, 270);
            this.lblDrag.Name = "lblDrag";
            this.lblDrag.Size = new System.Drawing.Size(100, 23);
            this.lblDrag.TabIndex = 10;
            this.lblDrag.Text = "Drag Coefficient";
            // 
            // txtDrag
            // 
            this.txtDrag.Location = new System.Drawing.Point(10, 293);
            this.txtDrag.Name = "txtDrag";
            this.txtDrag.Size = new System.Drawing.Size(190, 20);
            this.txtDrag.TabIndex = 11;
            // 
            // lblArea
            // 
            this.lblArea.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.Location = new System.Drawing.Point(10, 320);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(100, 23);
            this.lblArea.TabIndex = 12;
            this.lblArea.Text = "Frontal Area (m²)";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(10, 343);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(190, 20);
            this.txtArea.TabIndex = 13;
            // 
            // lblDensity
            // 
            this.lblDensity.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDensity.Location = new System.Drawing.Point(10, 370);
            this.lblDensity.Name = "lblDensity";
            this.lblDensity.Size = new System.Drawing.Size(100, 23);
            this.lblDensity.TabIndex = 14;
            this.lblDensity.Text = "Air Density";
            // 
            // txtDensity
            // 
            this.txtDensity.Location = new System.Drawing.Point(10, 393);
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.Size = new System.Drawing.Size(190, 20);
            this.txtDensity.TabIndex = 15;
            // 
            // lblGrade
            // 
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(10, 420);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(100, 23);
            this.lblGrade.TabIndex = 16;
            this.lblGrade.Text = "Grade";
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(10, 443);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(190, 20);
            this.txtGrade.TabIndex = 17;
            // 
            // lblForce
            // 
            this.lblForce.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForce.Location = new System.Drawing.Point(10, 470);
            this.lblForce.Name = "lblForce";
            this.lblForce.Size = new System.Drawing.Size(100, 23);
            this.lblForce.TabIndex = 18;
            this.lblForce.Text = "Force";
            // 
            // txtForce
            // 
            this.txtForce.Location = new System.Drawing.Point(10, 493);
            this.txtForce.Name = "txtForce";
            this.txtForce.Size = new System.Drawing.Size(190, 20);
            this.txtForce.TabIndex = 19;
            // 
            // lblCrossVelocity
            // 
            this.lblCrossVelocity.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrossVelocity.Location = new System.Drawing.Point(10, 520);
            this.lblCrossVelocity.Name = "lblCrossVelocity";
            this.lblCrossVelocity.Size = new System.Drawing.Size(100, 23);
            this.lblCrossVelocity.TabIndex = 20;
            this.lblCrossVelocity.Text = "Crossover Velocity";
            // 
            // txtCrossVelocity
            // 
            this.txtCrossVelocity.Location = new System.Drawing.Point(10, 543);
            this.txtCrossVelocity.Name = "txtCrossVelocity";
            this.txtCrossVelocity.Size = new System.Drawing.Size(190, 20);
            this.txtCrossVelocity.TabIndex = 21;
            // 
            // picGraph
            // 
            this.picGraph.BackColor = System.Drawing.Color.LightGray;
            this.picGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picGraph.Location = new System.Drawing.Point(230, 50);
            this.picGraph.Name = "picGraph";
            this.picGraph.Size = new System.Drawing.Size(954, 579);
            this.picGraph.TabIndex = 0;
            this.picGraph.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Chocolate;
            this.statusStrip1.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 629);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1184, 32);
            this.statusStrip1.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 27);
            this.lblStatus.Text = "Ready";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.picGraph);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Bicycle Racing Simulation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}
