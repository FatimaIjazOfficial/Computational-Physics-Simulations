using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FREE_FALLING_OBJECT_SIMULATION
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private const int GraphMargin = 40;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGraph();
            toolStripStatusLabel1.Text = "Ready";
        }

        private void InitializeGraph()
        {
            bmp = new Bitmap(picGraph.Width, picGraph.Height);
            g = Graphics.FromImage(bmp);
            picGraph.Image = bmp;
            DrawGraph("Height (m)");
        }

        private void DrawGraph(string yLabel)
        {
            g.Clear(Color.White);
            DrawGrid();
            DrawAxes(yLabel);
            picGraph.Refresh();
        }

        private bool ReadInputs(out double height, out double velocity, out double gravity, out double dt, out int steps)
        {
            height = 0;
            velocity = 0;
            gravity = 0;
            dt = 0;
            steps = 0;

            bool ok = double.TryParse(txtHeight.Text, out height) & double.TryParse(txtVelocity.Text, out velocity) & double.TryParse(txtGravity.Text, out gravity) & double.TryParse(txtTimeStep.Text, out dt) & int.TryParse(txtSteps.Text, out steps);

            if (!ok)
            {
                MessageBox.Show("Please enter valid numbers.");
                return false;
            }

            if (height <= 0 || gravity <= 0 || dt <= 0 || steps <= 0)
            {
                MessageBox.Show("Values must be greater than zero.");
                return false;
            }

            return true;
        }

        private int CalculateMotion(double[] h, double[] v, double[] t, double height, double velocity, double gravity, double dt, int steps)
        {
            h[0] = height;
            v[0] = velocity;
            t[0] = 0;

            int last = 0;

            for (int i = 0; i < steps; i++)
            {
                v[i + 1] = v[i] - gravity * dt;
                h[i + 1] = h[i] + v[i] * dt;
                t[i + 1] = t[i] + dt;
                last = i + 1;

                if (h[i + 1] <= 0)
                    break;
            }

            return last;
        }

        private void DrawGrid()
        {
            using (Pen pen = new Pen(Color.LightGray))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                for (int i = 0; i <= 20; i++)
                {
                    float x = GraphMargin + i * (picGraph.Width - 2 * GraphMargin) / 20f;
                    float y = GraphMargin + i * (picGraph.Height - 2 * GraphMargin) / 20f;

                    g.DrawLine(pen, x, GraphMargin, x, picGraph.Height - GraphMargin);
                    g.DrawLine(pen, GraphMargin, y, picGraph.Width - GraphMargin, y);
                }
            }
        }

        private void DrawAxes(string yLabel)
        {
            int left = GraphMargin;
            int bottom = picGraph.Height - GraphMargin;

            using (Pen pen = new Pen(Color.Black, 2))
            {
                // X axis
                g.DrawLine(
                    pen,
                    left,
                    bottom,
                    picGraph.Width - GraphMargin,
                    bottom);

                // Y axis
                g.DrawLine(
                    pen,
                    left,
                    GraphMargin,
                    left,
                    bottom);
            }

            Font font = new Font("Segoe UI", 10);

            g.DrawString(
                "Free Falling Object Simulation",
                new Font("Segoe UI", 14, FontStyle.Bold),
                Brushes.DarkBlue,
                100,
                10);

            g.DrawString(
                "Time (s)",
                font,
                Brushes.Black,
                picGraph.Width - 80,
                bottom + 5);

            g.DrawString(
                yLabel,
                font,
                Brushes.Black,
                5,
                40);
        }

        private void DrawHeightGraph(double[] h, double[] t, int steps)
        {
            double max = 1;

            for (int i = 0; i <= steps; i++) if (Math.Abs(h[i]) > max) max = Math.Abs(h[i]);

            if (t[steps] == 0) return;
            float xScale = (picGraph.Width - 2 * GraphMargin) / (float)t[steps]; float yScale = (picGraph.Height - 2 * GraphMargin) / (float)(max * 1.2f);
           
            int left = GraphMargin;
            int bottom = picGraph.Height - GraphMargin;

            using (Pen pen = new Pen(Color.Blue, 3))
            {
                for (int i = 0; i < steps; i++)
                {
                    PointF p1 = new PointF(left + (float)(t[i] * xScale), bottom - (float)(h[i] * yScale));
                    PointF p2 = new PointF(left + (float)(t[i + 1] * xScale), bottom - (float)(h[i + 1] * yScale));

                    g.DrawLine(pen, p1, p2);
                    g.FillEllipse(Brushes.Red, p2.X - 3, p2.Y - 3, 6, 6);

                    if (h[i + 1] <= 0) break;
                }
            }

            picGraph.Refresh();
        }

        private void DrawDisplacementGraph(double[] h, double[] t, double initialHeight, int steps)
        {
            double max = 1;

            for (int i = 0; i <= steps; i++)
            {
                double displacement = initialHeight - h[i];

                if (Math.Abs(displacement) > max)
                    max = Math.Abs(displacement);
            }

            if (t[steps] == 0)
                return;

            float xScale =
                (picGraph.Width - 2 * GraphMargin) /
                (float)t[steps];

            float yScale =
                (picGraph.Height - 2 * GraphMargin) /
                (float)(max * 1.2);

            int left = GraphMargin;
            int bottom = picGraph.Height - GraphMargin;

            using (Pen pen = new Pen(Color.Green, 3))
            {
                for (int i = 0; i < steps; i++)
                {
                    double d1 = initialHeight - h[i];
                    double d2 = initialHeight - h[i + 1];

                    PointF p1 = new PointF(
                        left + (float)(t[i] * xScale),
                        bottom - (float)(d1 * yScale));

                    PointF p2 = new PointF(
                        left + (float)(t[i + 1] * xScale),
                        bottom - (float)(d2 * yScale));


                    g.DrawLine(pen, p1, p2);

                    g.FillEllipse(
                        Brushes.Green,
                        p2.X - 3,
                        p2.Y - 3,
                        6,
                        6);

                    if (h[i + 1] <= 0)
                        break;
                }
            }

            picGraph.Refresh();
        }

        private void RunHeightSimulation()
        {
            if (!ReadInputs(out double height,
                out double velocity,
                out double gravity,
                out double dt,
                out int steps))
                return;

            DrawGraph("Height (m)");

            double[] h = new double[steps + 1];
            double[] v = new double[steps + 1];
            double[] t = new double[steps + 1];

            int last = CalculateMotion(
                h,
                v,
                t,
                height,
                velocity,
                gravity,
                dt,
                steps);

            DrawHeightGraph(h, t, last);

            toolStripStatusLabel1.Text =
                "Height simulation completed.";
        }

        private void RunDisplacementSimulation()
        {
            if (!ReadInputs(out double height,
                out double velocity,
                out double gravity,
                out double dt,
                out int steps))
                return;

            DrawGraph("Displacement (m)");

            double[] h = new double[steps + 1];
            double[] v = new double[steps + 1];
            double[] t = new double[steps + 1];

            int last = CalculateMotion(
                h,
                v,
                t,
                height,
                velocity,
                gravity,
                dt,
                steps);

            DrawDisplacementGraph(
                h,
                t,
                height,
                last);

            toolStripStatusLabel1.Text =
                "Displacement simulation completed.";
        }

        private void ClearGraph()
        {
            DrawGraph("Height (m)");
            toolStripStatusLabel1.Text = "Graph cleared.";
        }

        private void ResetParameters()
        {
            txtHeight.Text = "100";
            txtVelocity.Text = "0";
            txtGravity.Text = "9.8";
            txtTimeStep.Text = "0.1";
            txtSteps.Text = "100";

            ClearGraph();

            toolStripStatusLabel1.Text = "Parameters reset.";
        }

        private void SaveGraph()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FreeFallingGraph.png");
                bmp.Save(path, ImageFormat.Png);
                MessageBox.Show("Graph saved:\n" + path);
                toolStripStatusLabel1.Text = "Graph saved.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportCSV()
        {
            if (!ReadInputs(out double height, out double velocity, out double gravity, out double dt, out int steps)) return;

            double[] h = new double[steps + 1];
            double[] v = new double[steps + 1];
            double[] t = new double[steps + 1];

            int last = CalculateMotion(h, v, t, height, velocity, gravity, dt, steps);
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "FreeFalling.csv");

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Iteration,Time,Height,Displacement,Velocity");

                    for (int i = 0; i <= last; i++)
                    {
                        double displacement = height - h[i];
                        sw.WriteLine($"{i},{t[i]},{h[i]},{displacement},{v[i]}");
                        if (h[i] <= 0) break;
                    }
                }

                MessageBox.Show("CSV exported:\n" + path);
                toolStripStatusLabel1.Text = "CSV exported.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) { RunHeightSimulation(); }
        private void toolStripButton2_Click(object sender, EventArgs e) { ClearGraph(); }
        private void toolStripButton3_Click(object sender, EventArgs e) { ResetParameters(); }
        private void toolStripButton4_Click(object sender, EventArgs e) { SaveGraph(); }
        private void toolStripButton5_Click(object sender, EventArgs e) { ExportCSV(); }
        private void toolStripButton6_Click(object sender, EventArgs e) { RunHeightSimulation(); }
        private void toolStripButton7_Click(object sender, EventArgs e) { RunDisplacementSimulation(); }
        private void picGraph_MouseMove(object sender, MouseEventArgs e) { toolStripStatusLabel1.Text = $"X={e.X}  Y={e.Y}"; }
    }
}