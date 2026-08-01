using System;
using System.Drawing;
using System.Windows.Forms;

namespace Batted_Ball_Simulation
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            this.toolPanel = new System.Windows.Forms.Panel();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.parameterPanel = new System.Windows.Forms.Panel();
            this.lblModel = new System.Windows.Forms.Label();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.lblGravity = new System.Windows.Forms.Label();
            this.txtGravity = new System.Windows.Forms.TextBox();
            this.lblTimeStep = new System.Windows.Forms.Label();
            this.txtTimeStep = new System.Windows.Forms.TextBox();
            this.lblAngle = new System.Windows.Forms.Label();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.lblDel = new System.Windows.Forms.Label();
            this.txtDel = new System.Windows.Forms.TextBox();
            this.lblVd = new System.Windows.Forms.Label();
            this.txtVd = new System.Windows.Forms.TextBox();
            this.lblY0 = new System.Windows.Forms.Label();
            this.txtY0 = new System.Windows.Forms.TextBox();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.txtTemperature = new System.Windows.Forms.TextBox();
            this.lblGradient = new System.Windows.Forms.Label();
            this.txtGradient = new System.Windows.Forms.TextBox();
            this.lblAlpha = new System.Windows.Forms.Label();
            this.txtAlpha = new System.Windows.Forms.TextBox();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.parameterPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolPanel
            // 
            this.toolPanel.BackColor = System.Drawing.Color.Bisque;
            this.toolPanel.Controls.Add(this.btnRun);
            this.toolPanel.Controls.Add(this.btnSaveImage);
            this.toolPanel.Controls.Add(this.btnExportCSV);
            this.toolPanel.Controls.Add(this.btnReset);
            this.toolPanel.Controls.Add(this.btnClear);
            this.toolPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolPanel.Location = new System.Drawing.Point(0, 0);
            this.toolPanel.Name = "toolPanel";
            this.toolPanel.Size = new System.Drawing.Size(1200, 45);
            this.toolPanel.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(10, 10);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(120, 30);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run Simulation";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.Location = new System.Drawing.Point(140, 10);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(130, 30);
            this.btnSaveImage.TabIndex = 1;
            this.btnSaveImage.Text = "Save Graph Image";
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCSV.Location = new System.Drawing.Point(280, 10);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(100, 30);
            this.btnExportCSV.TabIndex = 2;
            this.btnExportCSV.Text = "Export CSV";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(390, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 30);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset Parameters";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(520, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear Graph";
            // 
            // mainSplit
            // 
            this.mainSplit.BackColor = System.Drawing.Color.BurlyWood;
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 45);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.parameterPanel);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.graphPanel);
            this.mainSplit.Size = new System.Drawing.Size(1200, 683);
            this.mainSplit.SplitterDistance = 276;
            this.mainSplit.TabIndex = 0;
            // 
            // parameterPanel
            // 
            this.parameterPanel.AutoScroll = true;
            this.parameterPanel.Controls.Add(this.lblModel);
            this.parameterPanel.Controls.Add(this.cmbModel);
            this.parameterPanel.Controls.Add(this.lblVelocity);
            this.parameterPanel.Controls.Add(this.txtVelocity);
            this.parameterPanel.Controls.Add(this.lblGravity);
            this.parameterPanel.Controls.Add(this.txtGravity);
            this.parameterPanel.Controls.Add(this.lblTimeStep);
            this.parameterPanel.Controls.Add(this.txtTimeStep);
            this.parameterPanel.Controls.Add(this.lblAngle);
            this.parameterPanel.Controls.Add(this.txtAngle);
            this.parameterPanel.Controls.Add(this.lblDel);
            this.parameterPanel.Controls.Add(this.txtDel);
            this.parameterPanel.Controls.Add(this.lblVd);
            this.parameterPanel.Controls.Add(this.txtVd);
            this.parameterPanel.Controls.Add(this.lblY0);
            this.parameterPanel.Controls.Add(this.txtY0);
            this.parameterPanel.Controls.Add(this.lblTemperature);
            this.parameterPanel.Controls.Add(this.txtTemperature);
            this.parameterPanel.Controls.Add(this.lblGradient);
            this.parameterPanel.Controls.Add(this.txtGradient);
            this.parameterPanel.Controls.Add(this.lblAlpha);
            this.parameterPanel.Controls.Add(this.txtAlpha);
            this.parameterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parameterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parameterPanel.Location = new System.Drawing.Point(0, 0);
            this.parameterPanel.Name = "parameterPanel";
            this.parameterPanel.Size = new System.Drawing.Size(276, 683);
            this.parameterPanel.TabIndex = 0;
            // 
            // lblModel
            // 
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(20, 20);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(236, 23);
            this.lblModel.TabIndex = 0;
            this.lblModel.Text = "Model";
            // 
            // cmbModel
            // 
            this.cmbModel.Items.AddRange(new object[] {
            "Batted Ball",
            "Isothermal",
            "Adiabatic"});
            this.cmbModel.Location = new System.Drawing.Point(20, 45);
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.Size = new System.Drawing.Size(200, 24);
            this.cmbModel.TabIndex = 1;
            // 
            // lblVelocity
            // 
            this.lblVelocity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVelocity.Location = new System.Drawing.Point(20, 85);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(236, 23);
            this.lblVelocity.TabIndex = 2;
            this.lblVelocity.Text = "Initial Velocity (V)";
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(20, 110);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(100, 22);
            this.txtVelocity.TabIndex = 3;
            this.txtVelocity.Text = "700";
            // 
            // lblGravity
            // 
            this.lblGravity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravity.Location = new System.Drawing.Point(20, 150);
            this.lblGravity.Name = "lblGravity";
            this.lblGravity.Size = new System.Drawing.Size(236, 23);
            this.lblGravity.TabIndex = 4;
            this.lblGravity.Text = "Gravity (g)";
            // 
            // txtGravity
            // 
            this.txtGravity.Location = new System.Drawing.Point(20, 175);
            this.txtGravity.Name = "txtGravity";
            this.txtGravity.Size = new System.Drawing.Size(100, 22);
            this.txtGravity.TabIndex = 5;
            this.txtGravity.Text = "9.8";
            // 
            // lblTimeStep
            // 
            this.lblTimeStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeStep.Location = new System.Drawing.Point(20, 215);
            this.lblTimeStep.Name = "lblTimeStep";
            this.lblTimeStep.Size = new System.Drawing.Size(236, 23);
            this.lblTimeStep.TabIndex = 6;
            this.lblTimeStep.Text = "Time Step (dt)";
            // 
            // txtTimeStep
            // 
            this.txtTimeStep.Location = new System.Drawing.Point(20, 240);
            this.txtTimeStep.Name = "txtTimeStep";
            this.txtTimeStep.Size = new System.Drawing.Size(100, 22);
            this.txtTimeStep.TabIndex = 7;
            this.txtTimeStep.Text = "0.1";
            // 
            // lblAngle
            // 
            this.lblAngle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngle.Location = new System.Drawing.Point(20, 280);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(236, 23);
            this.lblAngle.TabIndex = 8;
            this.lblAngle.Text = "Launch Angle";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(20, 305);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(100, 22);
            this.txtAngle.TabIndex = 9;
            this.txtAngle.Text = "35-60";
            // 
            // lblDel
            // 
            this.lblDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDel.Location = new System.Drawing.Point(20, 345);
            this.lblDel.Name = "lblDel";
            this.lblDel.Size = new System.Drawing.Size(236, 23);
            this.lblDel.TabIndex = 10;
            this.lblDel.Text = "del";
            // 
            // txtDel
            // 
            this.txtDel.Location = new System.Drawing.Point(20, 370);
            this.txtDel.Name = "txtDel";
            this.txtDel.Size = new System.Drawing.Size(100, 22);
            this.txtDel.TabIndex = 11;
            this.txtDel.Text = "5";
            // 
            // lblVd
            // 
            this.lblVd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVd.Location = new System.Drawing.Point(20, 410);
            this.lblVd.Name = "lblVd";
            this.lblVd.Size = new System.Drawing.Size(236, 23);
            this.lblVd.TabIndex = 12;
            this.lblVd.Text = "vd";
            // 
            // txtVd
            // 
            this.txtVd.Location = new System.Drawing.Point(20, 435);
            this.txtVd.Name = "txtVd";
            this.txtVd.Size = new System.Drawing.Size(100, 22);
            this.txtVd.TabIndex = 13;
            this.txtVd.Text = "35";
            // 
            // lblY0
            // 
            this.lblY0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblY0.Location = new System.Drawing.Point(20, 475);
            this.lblY0.Name = "lblY0";
            this.lblY0.Size = new System.Drawing.Size(236, 23);
            this.lblY0.TabIndex = 14;
            this.lblY0.Text = "Atmosphere y0";
            // 
            // txtY0
            // 
            this.txtY0.Location = new System.Drawing.Point(20, 500);
            this.txtY0.Name = "txtY0";
            this.txtY0.Size = new System.Drawing.Size(100, 22);
            this.txtY0.TabIndex = 15;
            this.txtY0.Text = "10000";
            // 
            // lblTemperature
            // 
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperature.Location = new System.Drawing.Point(20, 540);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(236, 23);
            this.lblTemperature.TabIndex = 16;
            this.lblTemperature.Text = "Temperature T";
            // 
            // txtTemperature
            // 
            this.txtTemperature.Location = new System.Drawing.Point(20, 565);
            this.txtTemperature.Name = "txtTemperature";
            this.txtTemperature.Size = new System.Drawing.Size(100, 22);
            this.txtTemperature.TabIndex = 17;
            this.txtTemperature.Text = "288.15";
            // 
            // lblGradient
            // 
            this.lblGradient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGradient.Location = new System.Drawing.Point(20, 605);
            this.lblGradient.Name = "lblGradient";
            this.lblGradient.Size = new System.Drawing.Size(236, 23);
            this.lblGradient.TabIndex = 18;
            this.lblGradient.Text = "Gradient a";
            // 
            // txtGradient
            // 
            this.txtGradient.Location = new System.Drawing.Point(20, 630);
            this.txtGradient.Name = "txtGradient";
            this.txtGradient.Size = new System.Drawing.Size(100, 22);
            this.txtGradient.TabIndex = 19;
            this.txtGradient.Text = "0.0065";
            // 
            // lblAlpha
            // 
            this.lblAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlpha.Location = new System.Drawing.Point(20, 670);
            this.lblAlpha.Name = "lblAlpha";
            this.lblAlpha.Size = new System.Drawing.Size(236, 23);
            this.lblAlpha.TabIndex = 20;
            this.lblAlpha.Text = "Alpha";
            // 
            // txtAlpha
            // 
            this.txtAlpha.Location = new System.Drawing.Point(20, 695);
            this.txtAlpha.Name = "txtAlpha";
            this.txtAlpha.Size = new System.Drawing.Size(100, 22);
            this.txtAlpha.TabIndex = 21;
            this.txtAlpha.Text = "2.5";
            // 
            // graphPanel
            // 
            this.graphPanel.BackColor = System.Drawing.Color.Thistle;
            this.graphPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphPanel.Font = new System.Drawing.Font("News706 BT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphPanel.Location = new System.Drawing.Point(0, 0);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(920, 683);
            this.graphPanel.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 728);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainSplit);
            this.Controls.Add(this.toolPanel);
            this.Controls.Add(this.statusStrip);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batted Ball Simulation";
            this.toolPanel.ResumeLayout(false);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.parameterPanel.ResumeLayout(false);
            this.parameterPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion



        // Toolbar

        private Panel toolPanel;

        private Button btnRun;
        private Button btnSaveImage;
        private Button btnExportCSV;
        private Button btnReset;
        private Button btnClear;



        // Layout

        private SplitContainer mainSplit;

        private Panel parameterPanel;

        private Panel graphPanel;



        // Parameters

        private Label lblModel;
        private ComboBox cmbModel;


        private Label lblVelocity;
        private TextBox txtVelocity;


        private Label lblGravity;
        private TextBox txtGravity;


        private Label lblTimeStep;
        private TextBox txtTimeStep;


        private Label lblAngle;
        private TextBox txtAngle;


        private Label lblDel;
        private TextBox txtDel;


        private Label lblVd;
        private TextBox txtVd;


        private Label lblY0;
        private TextBox txtY0;


        private Label lblTemperature;
        private TextBox txtTemperature;


        private Label lblGradient;
        private TextBox txtGradient;


        private Label lblAlpha;
        private TextBox txtAlpha;



        // Status

        private StatusStrip statusStrip;

        private ToolStripStatusLabel statusLabel;


    }
}