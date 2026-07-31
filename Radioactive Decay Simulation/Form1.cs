using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Radioactive_Decay_Simulation
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

        private bool ReadInputs(out double N0, out double lambda, out double dt, out int iterations)
        {
            N0 = 0;
            lambda = 0;
            dt = 0;
            iterations = 0;

            bool valid =
                double.TryParse(txtInitialAtoms.Text, out N0) &
                double.TryParse(txtLambda.Text, out lambda) &
                double.TryParse(txtTimeStep.Text, out dt) &
                int.TryParse(txtIterations.Text, out iterations);

            if (!valid)
            {
                MessageBox.Show(
                    "Please enter valid numeric values.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (N0 <= 0 || lambda <= 0 || dt <= 0 || iterations <= 0)
            {
                MessageBox.Show(
                    "All values must be greater than zero.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void CalculateDecay(
            double[] N,
            double[] t,
            double lambda,
            double dt,
            int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                N[i + 1] = N[i] - lambda * N[i] * dt;
                t[i + 1] = t[i] + dt;
            }
        }

        private void DrawAxes()
        {
            using (Pen axisPen = new Pen(Color.Black, 2))
            {
                g.DrawLine(
                    axisPen,
                    GraphMargin,
                    picGraph.Height - GraphMargin,
                    picGraph.Width - GraphMargin,
                    picGraph.Height - GraphMargin);

                g.DrawLine(
                    axisPen,
                    GraphMargin,
                    GraphMargin,
                    GraphMargin,
                    picGraph.Height - GraphMargin);
            }

            Font font = new Font("Segoe UI", 9);

            g.DrawString(
                "Radioactive Decay Simulation",
                new Font("Segoe UI", 14, FontStyle.Bold),
                Brushes.DarkBlue,
                picGraph.Width / 2 - 120,
                10);

            g.DrawString(
                "Time",
                font,
                Brushes.Black,
                picGraph.Width - 70,
                picGraph.Height - 40);

            g.DrawString(
                "Atoms (N)",
                font,
                Brushes.Black,
                5,
                40);

            for (int i = 0; i <= 10; i++)
            {
                float x = GraphMargin + i * (picGraph.Width - 2 * GraphMargin) / 10f;

                g.DrawLine(
                    Pens.Black,
                    x,
                    picGraph.Height - GraphMargin - 5,
                    x,
                    picGraph.Height - GraphMargin + 5);

                float y = picGraph.Height - GraphMargin - i * (picGraph.Height - 2 * GraphMargin) / 10f;

                g.DrawLine(
                    Pens.Black,
                    GraphMargin - 5,
                    y,
                    GraphMargin + 5,
                    y);
            }
        }

        private void DrawGrid()
        {
            using (Pen gridPen = new Pen(Color.LightGray))
            {
                gridPen.DashStyle = DashStyle.Dash;

                for (int i = 0; i <= 10; i++)
                {
                    float x = GraphMargin + i * (picGraph.Width - 2 * GraphMargin) / 10f;

                    g.DrawLine(
                        gridPen,
                        x,
                        GraphMargin,
                        x,
                        picGraph.Height - GraphMargin);
                }

                for (int i = 0; i <= 10; i++)
                {
                    float y = GraphMargin + i * (picGraph.Height - 2 * GraphMargin) / 10f;

                    g.DrawLine(
                        gridPen,
                        GraphMargin,
                        y,
                        picGraph.Width - GraphMargin,
                        y);
                }
            }
        }

        private void RunSimulation()
        {
            double N0;
            double lambda;
            double dt;
            int iterations;

            if (!ReadInputs(out N0, out lambda, out dt, out iterations))
                return;

            ClearCanvas();

            double[] N = new double[iterations + 1];
            double[] t = new double[iterations + 1];

            N[0] = N0;
            t[0] = 0;

            CalculateDecay(
                N,
                t,
                lambda,
                dt,
                iterations);

            DrawGraph(
                N,
                t,
                N0,
                iterations,
                dt);

            toolStripStatusLabel1.Text = "Simulation completed.";
        }

        private void DrawGraph(
            double[] N,
            double[] t,
            double N0,
            int iterations,
            double dt)
        {
            float xScale =
                (picGraph.Width - 2 * GraphMargin) /
                (float)(iterations * dt);

            float yScale =
                (picGraph.Height - 2 * GraphMargin) /
                (float)(N0 * 1.2);

            using (Pen graphPen = new Pen(Color.Blue, 3))
            {
                for (int i = 0; i < iterations; i++)
                {
                    PointF p1 = new PointF(
                        GraphMargin + (float)(t[i] * xScale),
                        picGraph.Height - GraphMargin - (float)(N[i] * yScale));

                    PointF p2 = new PointF(
                        GraphMargin + (float)(t[i + 1] * xScale),
                        picGraph.Height - GraphMargin - (float)(N[i + 1] * yScale));

                    g.DrawLine(
                        graphPen,
                        p1,
                        p2);

                    g.FillEllipse(
                        Brushes.Red,
                        p2.X - 2,
                        p2.Y - 2,
                        4,
                        4);
                }
            }

            picGraph.Refresh();
        }

        private void ClearGraph()
        {
            if (MessageBox.Show(
                "Clear the graph?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            ClearCanvas();

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

            txtInitialAtoms.Text = "150";
            txtLambda.Text = "0.5";
            txtTimeStep.Text = "0.1";
            txtIterations.Text = "150";

            ClearCanvas();

            toolStripStatusLabel1.Text = "Parameters reset.";
        }

        private void SaveGraph()
        {
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Radioactive_Decay.png");

                bmp.Save(path, ImageFormat.Png);

                MessageBox.Show(
                    "Saved successfully to:\n" + path);

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
                double N0;
                double lambda;
                double dt;
                int iterations;

                if (!ReadInputs(out N0, out lambda, out dt, out iterations))
                    return;

                double[] N = new double[iterations + 1];
                double[] t = new double[iterations + 1];

                N[0] = N0;
                t[0] = 0;

                CalculateDecay(
                    N,
                    t,
                    lambda,
                    dt,
                    iterations);

                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "RadioactiveDecay.csv");

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Iteration,Time,Atoms");

                    for (int i = 0; i <= iterations; i++)
                    {
                        sw.WriteLine(
                            $"{i},{t[i]},{N[i]}");
                    }
                }

                MessageBox.Show(
                    "CSV saved successfully to:\n" + path);

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
            toolStripStatusLabel1.Text =
                $"X = {e.X}     Y = {e.Y}";
        }
    }
}