using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Uniform_Velocity_Simulation
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private const int GraphMargin = 60;

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
            ClearCanvas();
        }

        private void ClearCanvas()
        {
            g.Clear(Color.White);
            DrawGrid();
            DrawAxes();
            picGraph.Refresh();
        }

        private bool ReadInputs(out double x0, out double velocity, out double dt, out int steps)
        {
            x0 = 0;
            velocity = 0;
            dt = 0;
            steps = 0;

            bool ok =
                double.TryParse(txtInitialPosition.Text, out x0) &
                double.TryParse(txtVelocity.Text, out velocity) &
                double.TryParse(txtTimeStep.Text, out dt) &
                int.TryParse(txtSteps.Text, out steps);

            if (!ok)
            {
                MessageBox.Show("Please enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dt <= 0 || steps <= 0)
            {
                MessageBox.Show("Time Step and Iterations must be greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void CalculateMotion(double[] x, double[] t, double velocity, double dt, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                x[i + 1] = x[i] + velocity * dt;
                t[i + 1] = t[i] + dt;
            }
        }

        private void DrawAxes()
        {
            int centerX = picGraph.Width / 2;
            int centerY = picGraph.Height / 2;

            using (Pen axisPen = new Pen(Color.Black, 2))
            {
                g.DrawLine(axisPen, GraphMargin, centerY, picGraph.Width - GraphMargin, centerY);
                g.DrawLine(axisPen, centerX, GraphMargin, centerX, picGraph.Height - GraphMargin);
            }

            Font font = new Font("Segoe UI", 9);

            g.DrawString("Uniform Velocity Simulation", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.DarkBlue, picGraph.Width / 2 - 120, 10);
            g.DrawString("Time", font, Brushes.Black, picGraph.Width - 55, centerY + 10);
            g.DrawString("Position", font, Brushes.Black, centerX + 10, GraphMargin);

            float dx = (picGraph.Width - 2 * GraphMargin) / 10f;
            float dy = (picGraph.Height - 2 * GraphMargin) / 10f;

            for (int i = 0; i <= 10; i++)
            {
                float x = GraphMargin + i * dx;
                g.DrawLine(Pens.Black, x, centerY - 4, x, centerY + 4);

                float y = GraphMargin + i * dy;
                g.DrawLine(Pens.Black, centerX - 4, y, centerX + 4, y);
            }
        }

        private void DrawGrid()
        {
            int centerX = picGraph.Width / 2;
            int centerY = picGraph.Height / 2;

            using (Pen gridPen = new Pen(Color.LightGray))
            {
                gridPen.DashStyle = DashStyle.Dash;

                float dx = (picGraph.Width - 2 * GraphMargin) / 10f;
                float dy = (picGraph.Height - 2 * GraphMargin) / 10f;

                for (int i = -5; i <= 5; i++)
                {
                    float x = centerX + i * dx;
                    g.DrawLine(gridPen, x, GraphMargin, x, picGraph.Height - GraphMargin);
                }

                for (int i = -5; i <= 5; i++)
                {
                    float y = centerY + i * dy;
                    g.DrawLine(gridPen, GraphMargin, y, picGraph.Width - GraphMargin, y);
                }
            }
        }

        private void RunSimulation()
        {
            double x0;
            double velocity;
            double dt;
            int steps;

            if (!ReadInputs(out x0, out velocity, out dt, out steps))
                return;

            ClearCanvas();

            double[] x = new double[steps + 1];
            double[] t = new double[steps + 1];

            x[0] = x0;
            t[0] = 0;

            CalculateMotion(x, t, velocity, dt, steps);

            DrawGraph(x, t, steps);

            toolStripStatusLabel1.Text = "Simulation completed.";
        }

        private void DrawGraph(double[] x, double[] t, int steps)
        {
            double max = Math.Max(Math.Abs(x[0]), Math.Abs(x[steps]));

            if (max == 0)
                max = 1;

            float xScale = (picGraph.Width - 2 * GraphMargin) / (float)t[steps];
            float yScale = (picGraph.Height - 2 * GraphMargin) / (float)(max * 1.2);

            int centerX = picGraph.Width / 2;
            int centerY = picGraph.Height / 2;

            using (Pen graphPen = new Pen(Color.Blue, 3))
            {
                for (int i = 0; i < steps; i++)
                {
                    PointF p1 = new PointF(centerX + (float)(t[i] * xScale), centerY - (float)(x[i] * yScale));
                    PointF p2 = new PointF(centerX + (float)(t[i + 1] * xScale), centerY - (float)(x[i + 1] * yScale));

                    g.DrawLine(graphPen, p1, p2);
                    g.FillEllipse(Brushes.Red, p2.X - 2, p2.Y - 2, 4, 4);
                }
            }

            picGraph.Refresh();
        }

        private void ClearGraph()
        {
            if (MessageBox.Show("Clear the graph?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ClearCanvas();

            toolStripStatusLabel1.Text = "Graph cleared.";
        }

        private void ResetParameters()
        {
            if (MessageBox.Show("Reset all parameters?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            txtInitialPosition.Text = "150";
            txtVelocity.Text = "-40";
            txtTimeStep.Text = "0.1";
            txtSteps.Text = "150";

            ClearCanvas();

            toolStripStatusLabel1.Text = "Parameters reset.";
        }

        private void SaveGraph()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "UniformVelocity.png");
                bmp.Save(path, ImageFormat.Png);
                MessageBox.Show("Saved successfully to:\n" + path);
                toolStripStatusLabel1.Text = "Graph saved.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportCSV()
        {
            try
            {
                double x0;
                double velocity;
                double dt;
                int steps;

                if (!ReadInputs(out x0, out velocity, out dt, out steps))
                    return;

                double[] x = new double[steps + 1];
                double[] t = new double[steps + 1];

                x[0] = x0;
                t[0] = 0;

                CalculateMotion(x, t, velocity, dt, steps);

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "UniformVelocity.csv");

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Step,Time,Position");

                    for (int i = 0; i <= steps; i++)
                        sw.WriteLine($"{i},{t[i]},{x[i]}");
                }

                MessageBox.Show("CSV saved successfully to:\n" + path);

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
            toolStripStatusLabel1.Text = $"X={e.X}  Y={e.Y}";
        }
    }
}

