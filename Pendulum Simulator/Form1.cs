using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pendulum_Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        public void drawaxis(PointF origin, string sx, string sy)
        {
            Graphics gg = CreateGraphics();
            Pen p = new Pen(Color.Green, 4);
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            Font f = new Font("Times New Roman", 30);
            SolidBrush sb = new SolidBrush(Color.DarkSeaGreen);

            int xLength = 500;  // right
            int yLength = 300;  // up
            int tickLength = 10;
            int interval = 50;

            // X-axis
            gg.DrawLine(p, origin.X, origin.Y, origin.X + xLength, origin.Y);
            gg.DrawString(sx, f, sb, origin.X + xLength / 2, origin.Y + 10);

            // Y-axis
            gg.DrawLine(p, origin.X, origin.Y, origin.X, origin.Y - yLength);
            gg.DrawString(sy, f, sb, origin.X - 70, origin.Y - yLength / 2);

            // X-axis ticks
            for (int x = (int)origin.X + interval; x <= origin.X + xLength; x += interval)
                gg.DrawLine(p, x, origin.Y - tickLength / 2, x, origin.Y + tickLength / 2);

            // Y-axis ticks
            for (int y = (int)origin.Y; y >= origin.Y - yLength; y -= interval)
                gg.DrawLine(p, origin.X - tickLength / 2, y, origin.X + tickLength / 2, y);
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

                using (Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height))
                {
                    using (Graphics g2 = Graphics.FromImage(bmp))
                    {
                        g2.CopyFromScreen(
                            this.PointToScreen(Point.Empty),
                            Point.Empty,
                            this.ClientSize
                        );
                    }

                    bmp.Save(path, ImageFormat.Png);
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

        //Simple Pendulum

        private PointF origin1 => new PointF(ClientSize.Width / 8f, 2 * ClientSize.Height / 3f);
        private PointF origin2 => new PointF(ClientSize.Width / 8f, 2 * ClientSize.Height / 5f);
        private PendulumSimulator GetSimulator()
        {
            Graphics g = CreateGraphics();
            var sim = new PendulumSimulator(g);
            sim.DrawAxis(origin1, "t", "θ");
            sim.DrawAxis(origin2, "t", "ω");
            return sim;
        }

        //ideal Case by Euler
        private void eulerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.IdealEuler(origin1, origin2);
            AfterDraw();
        }

        //ideal Case by Euler Cromer

        private void cromerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.IdealEulerCromer(origin1, origin2);
            AfterDraw();
        }

        //For Smal Angle

        private void forSmallAngleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.SmallAngle(origin1, origin2);
            AfterDraw();
        }
        //RealisticCaseByEuler

        //Damping

        private void dampingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.DampingEuler(origin1, origin2);
            AfterDraw();
        }
        
        //Driving
        private void drivingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.DrivingEuler(origin1, origin2);
            AfterDraw();
        }
        //Non Linear
        private void nonLinearToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.NonLinearEuler(origin1, origin2);
            AfterDraw();
        }

        //Realestic Case By Euler Cromer

        //Damping
        private void dampingToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.DampingEulerCromer(origin1, origin2);
            AfterDraw();
        }
        //Driving
        private void drivingToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.DrivingEulerCromer(origin1, origin2);
            AfterDraw();
        }
        //Non Linear
        private void nonLinearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            var sim = GetSimulator();
            sim.NonLinearEulerCromer(origin1, origin2);
            AfterDraw();
        }

    }
}
