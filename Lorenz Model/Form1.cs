using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Lorenz_Model
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap graphBitmap;

        //Refresh
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        void AfterDraw()
        {
            try
            {
                string picturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                string path = Path.Combine(
                    picturesFolder,
                    "graph_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png"
                );

                if (graphBitmap != null)
                {
                    graphBitmap.Save(path, ImageFormat.Png);
                }
                else
                {
                    throw new Exception("No graph available to save.");
                }

                MessageBox.Show(
                    "Graph saved successfully!\n\nLocation:\n" + path,
                    "Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while saving image:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void zVsTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotZvsT(this);
            AfterDraw();
        }

        private void zVsXToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotZvsX(this);
            AfterDraw();
        }

        private void zVsYToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotZvsY(this);
            AfterDraw();
        }

        private void xVsTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotXvsT(this);
            AfterDraw();
        }

        private void xVsYToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotXvsY(this);
            AfterDraw();
        }

        private void xVsZToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotXvsZ(this);
            AfterDraw();
        }

        private void yVsTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotYvsT(this);
            AfterDraw();
        }

        private void yVsXToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotYvsX(this);
            AfterDraw();
        }

        private void yVsZToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            LorenzModel lm = new LorenzModel();
            graphBitmap = lm.PlotYvsZ(this);
            AfterDraw();
        }
    }
}
