using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Uniform_Velocity_Simulation
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.Load += Form1_Load;
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

            g.Clear(Color.White);

            picGraph.Image = bmp;

            DrawAxes();
        }

        private void DrawAxes()
        {
            int margin = 40;

            int left = margin;
            int right = picGraph.Width - margin;
            int top = margin;
            int bottom = picGraph.Height - margin;

            int centerX = (left + right) / 2;
            int centerY = (top + bottom) / 2;

            using (Pen axisPen = new Pen(Color.Black, 2))
            {
                // Horizontal X-axis
                g.DrawLine(axisPen, left, centerY, right, centerY);

                // Vertical Y-axis
                g.DrawLine(axisPen, centerX, top, centerX, bottom);
            }

            Font font = new Font("Segoe UI", 9);

            g.DrawString(
                "Uniform Velocity Simulation",
                new Font("Segoe UI", 14, FontStyle.Bold),
                Brushes.DarkBlue,
                picGraph.Width / 2 - 120,
                10);

            g.DrawString("X", font, Brushes.Black, right - 15, centerY + 10);

            g.DrawString("Y", font, Brushes.Black, centerX + 10, top);

            // Tick marks
            int ticks = 10;

            float xStep = (right - left) / (float)ticks;
            float yStep = (bottom - top) / (float)ticks;

            for (int i = 0; i <= ticks; i++)
            {
                float x = left + i * xStep;

                g.DrawLine(Pens.Black,
                    x,
                    centerY - 4,
                    x,
                    centerY + 4);

                float y = top + i * yStep;

                g.DrawLine(Pens.Black,
                    centerX - 4,
                    y,
                    centerX + 4,
                    y);
            }

            picGraph.Refresh();
        }

        private void DrawGrid()
        {
            int margin = 40;

            int left = margin;
            int right = picGraph.Width - margin;
            int top = margin;
            int bottom = picGraph.Height - margin;

            using (Pen gridPen = new Pen(Color.LightGray))
            {
                gridPen.DashStyle =
                    System.Drawing.Drawing2D.DashStyle.Dash;

                int grid = 20;

                float dx = (right - left) / (float)grid;
                float dy = (bottom - top) / (float)grid;

                for (int i = 0; i <= grid; i++)
                {
                    float x = left + i * dx;

                    g.DrawLine(
                        gridPen,
                        x,
                        top,
                        x,
                        bottom);
                }

                for (int i = 0; i <= grid; i++)
                {
                    float y = top + i * dy;

                    g.DrawLine(
                        gridPen,
                        left,
                        y,
                        right,
                        y);
                }
            }
        }

        private void RunSimulation()
        {
            g.Clear(Color.White);

            DrawGrid();
            DrawAxes();

            double x0;
            double velocity;
            double dt;
            int iterations;

            if (!double.TryParse(txtInitialPosition.Text, out x0) ||
                !double.TryParse(txtVelocity.Text, out velocity) ||
                !double.TryParse(txtTimeStep.Text, out dt) ||
                !int.TryParse(txtSteps.Text, out iterations))
            {
                MessageBox.Show(
                    "Please enter valid numeric values.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (dt <= 0 || iterations <= 0)
            {
                MessageBox.Show(
                    "Time Step and Iterations must be greater than zero.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int margin = 60;

            double t = 0;
            double x = x0;

            double xmax = x0 + velocity * dt * iterations;

            float xScale =
                (picGraph.Width - 2 * margin) /
                (float)(iterations * dt);

            float yScale =
                (picGraph.Height - 2 * margin) /
                (float)(Math.Abs(xmax) + 20);

            int centerX = picGraph.Width / 2;
            int centerY = picGraph.Height / 2;

            PointF previous = new PointF(
                centerX,
                centerY - (float)(x * yScale));

            using (Pen graphPen = new Pen(Color.Blue, 3))
            {
                for (int i = 1; i <= iterations; i++)
                {
                    t += dt;

                    x = x0 + velocity * t;

                    PointF current = new PointF(
                        centerX + (float)(t * xScale),
                        centerY - (float)(x * yScale));

                    g.DrawLine(graphPen, previous, current);

                    g.FillEllipse(
                        Brushes.Red,
                        current.X - 2,
                        current.Y - 2,
                        4,
                        4);

                    previous = current;
                }
            }

            picGraph.Refresh();

            toolStripStatusLabel1.Text = "Simulation completed.";
        }

        private void ClearGraph()
        {
            if (MessageBox.Show(
                "Clear the graph?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            g.Clear(Color.White);

            DrawGrid();

            DrawAxes();

            picGraph.Image = bmp;

            picGraph.Refresh();

            toolStripStatusLabel1.Text = "Graph cleared.";
        }

        private void ResetParameters()
        {
            if (MessageBox.Show(
                "Reset all parameters?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            txtInitialPosition.Text = "0";
            txtVelocity.Text = "20";
            txtTimeStep.Text = "0.1";
            txtSteps.Text = "150";

            ClearGraph();

            toolStripStatusLabel1.Text = "Parameters reset.";
        }

        private void SaveGraph()
        {
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "UniformVelocity.png");

                bmp.Save(path, ImageFormat.Png);

                MessageBox.Show("Saved successfully to:\n" + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ExportCSV()
        {
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "UniformVelocity.csv");

                double x0 = double.Parse(txtInitialPosition.Text);
                double velocity = double.Parse(txtVelocity.Text);
                double dt = double.Parse(txtTimeStep.Text);
                int steps = int.Parse(txtSteps.Text);

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Step,Time,Position");

                    for (int i = 0; i <= steps; i++)
                    {
                        double t = i * dt;
                        double x = x0 + velocity * t;

                        sw.WriteLine($"{i},{t},{x}");
                    }
                }

                MessageBox.Show("CSV saved successfully to:\n" + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                RunSimulation();
                toolStripStatusLabel1.Text = "Simulation completed.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Simulation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ClearGraph();
            toolStripStatusLabel1.Text = "Graph cleared.";

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ResetParameters();
            toolStripStatusLabel1.Text = "Parameters reset.";

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveGraph();
            toolStripStatusLabel1.Text = "Graph saved.";

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ExportCSV();
            toolStripStatusLabel1.Text = "CSV exported.";

        }

        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text =
                $"X = {e.X}     Y = {e.Y}";
        }
       
    }
}