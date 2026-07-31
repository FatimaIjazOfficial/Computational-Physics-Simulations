using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PARACHUTE_MOTION_SIMULATION
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
            DrawGraph();
        }

        private void DrawGraph()
        {
            g.Clear(Color.White);
            DrawGrid();
            DrawAxes();
            picGraph.Refresh();
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

        private void DrawAxes()
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawLine(pen, GraphMargin, picGraph.Height - GraphMargin, picGraph.Width - GraphMargin, picGraph.Height - GraphMargin);
                g.DrawLine(pen, GraphMargin, GraphMargin, GraphMargin, picGraph.Height - GraphMargin);
            }

            g.DrawString("Parachute Motion Simulation", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.DarkBlue, 100, 10);
            g.DrawString("Time (s)", new Font("Segoe UI", 10), Brushes.Black, picGraph.Width - 80, picGraph.Height - 30);
            g.DrawString("Velocity (m/s)", new Font("Segoe UI", 10), Brushes.Black, 5, 40);
        }

        private bool ReadInputs(out double velocity, out double gravity, out double drag, out double dt, out int steps)
        {
            velocity = gravity = drag = dt = 0;
            steps = 0;

            bool ok = double.TryParse(txtVelocity.Text, out velocity) & double.TryParse(txtGravity.Text, out gravity) & double.TryParse(txtDrag.Text, out drag) & double.TryParse(txtTimeStep.Text, out dt) & int.TryParse(txtSteps.Text, out steps);

            if (!ok)
            {
                MessageBox.Show("Please enter valid numbers.");
                return false;
            }

            if (gravity <= 0 || drag <= 0 || dt <= 0 || steps <= 0)
            {
                MessageBox.Show("Values must be greater than zero.");
                return false;
            }

            return true;
        }

        private void RunSimulation()
        {
            if (!ReadInputs(out double velocity, out double gravity, out double drag, out double dt, out int steps)) return;

            DrawGraph();

            double[] v = new double[steps + 1];
            double[] t = new double[steps + 1];

            v[0] = velocity;
            t[0] = 0;

            double terminalVelocity = gravity / drag;

            for (int i = 0; i < steps; i++)
            {
                v[i + 1] = v[i] + (gravity - drag * v[i]) * dt;
                t[i + 1] = t[i] + dt;

                if (Math.Abs(v[i + 1] - v[i]) < 0.001)
                {
                    steps = i + 1;
                    break;
                }
            }

            double max = Math.Abs(v[0]);

            for (int i = 0; i <= steps; i++)
            {
                if (Math.Abs(v[i]) > max) max = Math.Abs(v[i]);
            }

            if (max < 1) max = 1;

            float xScale = (picGraph.Width - 2 * GraphMargin) / (float)t[steps];
            float yScale = (picGraph.Height - 2 * GraphMargin) / (float)(max * 1.2);

            using (Pen pen = new Pen(Color.Blue, 3))
            {
                PointF previous = new PointF(GraphMargin, picGraph.Height - GraphMargin - (float)(v[0] * yScale));
                for (int i = 1; i <= steps; i++)
                {
                    PointF current = new PointF(GraphMargin + (float)(t[i] * xScale), picGraph.Height - GraphMargin - (float)(v[i] * yScale));
                    g.DrawLine(pen, previous, current);
                    g.FillEllipse(Brushes.Red, current.X - 3, current.Y - 3, 6, 6);

                    previous = current;
                }
            }

            picGraph.Refresh();

            toolStripStatusLabel1.Text = $"Completed. Terminal Velocity = {terminalVelocity:F2}";
        }


        private void ClearGraph()
        {
            DrawGraph();
            toolStripStatusLabel1.Text = "Graph cleared.";
        }


        private void ResetParameters()
        {
            txtVelocity.Text = "0";
            txtGravity.Text = "10";
            txtDrag.Text = "1";
            txtTimeStep.Text = "0.1";
            txtSteps.Text = "100";

            ClearGraph();

            toolStripStatusLabel1.Text = "Parameters reset.";
        }


        private void SaveGraph()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ParachuteMotionGraph.png");
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
            if (!ReadInputs(out double velocity, out double gravity, out double drag, out double dt, out int steps)) return;

            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ParachuteMotionData.csv");

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Step,Time,Velocity");

                    double t = 0;
                    double v = velocity;

                    sw.WriteLine($"0,{t},{v}");

                    for (int i = 1; i <= steps; i++)
                    {
                        v = v + (gravity - drag * v) * dt;
                        t += dt;

                        sw.WriteLine($"{i},{t},{v}");

                        if (Math.Abs(gravity - drag * v) < 0.001) break;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            RunSimulation();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ClearGraph();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ResetParameters();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveGraph();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = $"X={e.X} Y={e.Y}";
        }
    }
}