using System;
using System.Drawing;
using System.Windows.Forms;

namespace Billiard_Ball_Simulation
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


        private void InitializeComponent()
        {

            this.toolPanel = new Panel();
            this.btnRun = new Button();
            this.btnAddBall = new Button();
            this.btnClear = new Button();
            this.btnSaveImage = new Button();
            this.btnExportCSV = new Button();

            this.mainSplit = new SplitContainer();

            this.parameterPanel = new Panel();
            this.lblInfo = new Label();

            this.lblSpeed = new Label();
            this.trackSpeed = new TrackBar();

            this.chkPattern = new CheckBox();

            this.graphPanel = new Panel();

            this.statusStrip = new StatusStrip();
            this.statusLabel = new ToolStripStatusLabel();


            this.toolPanel.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.mainSplit)).BeginInit();

            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();

            this.mainSplit.SuspendLayout();

            this.parameterPanel.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)
                (this.trackSpeed)).BeginInit();

            this.statusStrip.SuspendLayout();

            this.SuspendLayout();



            // toolPanel

            this.toolPanel.BackColor = Color.Bisque;
            this.toolPanel.Dock = DockStyle.Top;
            this.toolPanel.Height = 45;

            this.toolPanel.Controls.Add(this.btnRun);
            this.toolPanel.Controls.Add(this.btnAddBall);
            this.toolPanel.Controls.Add(this.btnClear);
            this.toolPanel.Controls.Add(this.btnSaveImage);
            this.toolPanel.Controls.Add(this.btnExportCSV);



            // btnRun

            this.btnRun.Location =
                new Point(10, 10);

            this.btnRun.Size =
                new Size(130, 30);

            this.btnRun.Text =
                "Run Simulation";



            // btnAddBall

            this.btnAddBall.Location =
                new Point(150, 10);

            this.btnAddBall.Size =
                new Size(120, 30);

            this.btnAddBall.Text =
                "Add Ball";



            // btnClear

            this.btnClear.Location =
                new Point(280, 10);

            this.btnClear.Size =
                new Size(100, 30);

            this.btnClear.Text =
                "Clear";



            // btnSaveImage

            this.btnSaveImage.Location =
                new Point(390, 10);

            this.btnSaveImage.Size =
                new Size(120, 30);

            this.btnSaveImage.Text =
                "Save Image";



            // btnExportCSV

            this.btnExportCSV.Location =
                new Point(520, 10);

            this.btnExportCSV.Size =
                new Size(120, 30);

            this.btnExportCSV.Text =
                "Export CSV";





            // mainSplit

            this.mainSplit.Dock =
                DockStyle.Fill;

            this.mainSplit.SplitterDistance =
                300;



            // parameterPanel

            this.parameterPanel.BackColor =
                Color.Wheat;

            this.parameterPanel.Dock =
                DockStyle.Fill;

            this.parameterPanel.AutoScroll =
                false;

            this.parameterPanel.Controls.Add(
                this.lblSpeed);

            this.parameterPanel.Controls.Add(
                this.trackSpeed);

            this.parameterPanel.Controls.Add(
                this.chkPattern);




            // lblInfo

            this.lblInfo.Location =
                new Point(10, 10);

            
            this.lblInfo.Font =
                new Font(
                    "Microsoft Sans Serif",
                    10,
                    FontStyle.Bold);

            this.lblInfo.AutoSize =
                true;


            historyPanel = new Panel();

            historyPanel.Location = new Point(10, 10);
            historyPanel.Size = new Size(270, 520);
            historyPanel.BorderStyle = BorderStyle.FixedSingle;

            historyPanel.AutoScroll = true;

            historyPanel.Controls.Add(lblInfo);

            parameterPanel.Controls.Add(historyPanel);



            // lblSpeed

            this.lblSpeed.Location =
                new Point(10, 545);

            this.lblSpeed.Size =
                new Size(200, 25);

            this.lblSpeed.Text =
                "Movement Speed";




            // trackSpeed

            this.trackSpeed.Location =
                new Point(10, 575);

            this.trackSpeed.Size =
                new Size(250, 45);

            this.trackSpeed.Minimum =
                1;

            this.trackSpeed.Maximum =
                20;

            this.trackSpeed.Value =
                5;




            // chkPattern

            this.chkPattern.Location =
                new Point(10, 625);

            this.chkPattern.Size =
                new Size(220, 30);

            this.chkPattern.Text =
                "Show Ball Pattern";

            this.chkPattern.Checked =
                true;





            // graphPanel

            this.graphPanel.BackColor =
                Color.White;

            this.graphPanel.Dock =
                DockStyle.Fill;






            // statusStrip

            this.statusStrip.Items.AddRange(
                new ToolStripItem[]
                {
                    this.statusLabel
                });


            this.statusLabel.Text =
                "Ready";





            // Form1

            this.ClientSize =
                new Size(1200, 750);


            this.Controls.Add(
                this.mainSplit);

            this.Controls.Add(
                this.toolPanel);

            this.Controls.Add(
                this.statusStrip);



            this.mainSplit.Panel1.Controls.Add(
                this.parameterPanel);


            this.mainSplit.Panel2.Controls.Add(
                this.graphPanel);



            this.Text =
                "Billiard Ball Simulation";

            this.StartPosition =
                FormStartPosition.CenterScreen;



            this.toolPanel.ResumeLayout(false);

            this.mainSplit.Panel1.ResumeLayout(false);

            this.mainSplit.Panel2.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.mainSplit)).EndInit();

            this.mainSplit.ResumeLayout(false);

            this.parameterPanel.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)
                (this.trackSpeed)).EndInit();

            this.statusStrip.ResumeLayout(false);

            this.statusStrip.PerformLayout();

            this.ResumeLayout(false);

            this.PerformLayout();
        }



        private Panel toolPanel;
        private Panel historyPanel;
        private Button btnRun;
        private Button btnAddBall;
        private Button btnClear;
        private Button btnSaveImage;
        private Button btnExportCSV;


        private SplitContainer mainSplit;


        private Panel parameterPanel;


        private Label lblInfo;

        private Label lblSpeed;


        private TrackBar trackSpeed;


        private CheckBox chkPattern;


        private Panel graphPanel;


        private StatusStrip statusStrip;

        private ToolStripStatusLabel statusLabel;
    }
}