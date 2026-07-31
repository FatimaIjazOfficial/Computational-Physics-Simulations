using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Growth_Population_Simulation
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private const int GraphMargin = 50;
        private string mode = "";

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Load += Form1_Load;
            Resize+=Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            InitializeGraph();
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
            using (Pen p = new Pen(Color.LightGray))
            {
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                for (int i = 0; i <= 20; i++)
                {
                    float x = GraphMargin + i * (picGraph.Width - 2 * GraphMargin) / 20f;
                    float y = GraphMargin + i * (picGraph.Height - 2 * GraphMargin) / 20f;

                    g.DrawLine(p, x, GraphMargin, x, picGraph.Height - GraphMargin);
                    g.DrawLine(p, GraphMargin, y, picGraph.Width - GraphMargin, y);
                }
            }
        }

        private void DrawAxes()
        {
            using (Pen p = new Pen(Color.Black, 2))
            {
                g.DrawLine(p, GraphMargin, picGraph.Height - GraphMargin, picGraph.Width - GraphMargin, picGraph.Height - GraphMargin);
                g.DrawLine(p, GraphMargin, GraphMargin, GraphMargin, picGraph.Height - GraphMargin);
            }

            Font f = new Font("Segoe UI", 9);

            g.DrawString("Population Growth Simulation", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.DarkBlue, 100, 10);

            g.DrawString("Time", f, Brushes.Black, picGraph.Width - 80, picGraph.Height - 35);

            g.DrawString("Population N", f, Brushes.Black, 5, 40);

            g.DrawString("0", f, Brushes.Black, GraphMargin - 15, picGraph.Height - GraphMargin + 5);

            g.DrawString("t", f, Brushes.Black, picGraph.Width - GraphMargin, picGraph.Height - GraphMargin + 5);

            g.DrawString("N", f, Brushes.Black, GraphMargin - 25, GraphMargin - 10);
        }


        private bool ReadInputs(out double N0, out double a, out double b, out double dt, out int steps)
        {
            N0 = a = b = dt = 0;
            steps = 0;

            bool ok = double.TryParse(txtN0.Text, out N0) &
            double.TryParse(txtA.Text, out a) &
            double.TryParse(txtB.Text, out b) &
            double.TryParse(txtDT.Text, out dt) &
            int.TryParse(txtSteps.Text, out steps);

            if (!ok)
            {
                MessageBox.Show("Invalid values");
                return false;
            }

            if (N0 <= 0 || dt <= 0 || steps <= 0)
            {
                MessageBox.Show("Values must be positive");
                return false;
            }

            return true;
        }


        private void RunSimulation()
        {
            if (!ReadInputs(out double N0, out double a, out double b, out double dt, out int steps))
                return;

            mode = "Population";

            DrawGraph();

            double[] N = new double[steps + 1];
            double[] exact = new double[steps + 1];
            double[] t = new double[steps + 1];

            N[0] = N0;

            for (int i = 0; i < steps; i++)
            {
                N[i + 1] = N[i] + (a * N[i] - b * N[i] * N[i]) * dt;

                if (N[i + 1] < 0)
                    N[i + 1] = 0;
                
                t[i + 1] = t[i] + dt;
            }


            if (b == 0)
            {
                for (int i = 0; i <= steps; i++)
                    exact[i] = N0 * Math.Exp(a * t[i]);
            }

            DrawCurves(N, exact, t, steps, b);

            toolStripStatusLabel1.Text = "Simulation completed";
        }



        private void DrawCurves(double[] N, double[] exact, double[] t, int steps, double b)
        {
            double max = 1;

            for (int i = 0; i <= steps; i++)
            {
                if (N[i] > max) max = N[i];
                if (b == 0 && exact[i] > max) max = exact[i];
            }


            float maxTime = (float)t[steps];
            float maxPopulation = (float)(max * 1.2);

            float xs = (picGraph.Width - 2 * GraphMargin) / maxTime;
            float ys = (picGraph.Height - 2 * GraphMargin) / maxPopulation;


            using (Pen p1 = new Pen(Color.Brown, 3))
            using (Pen p2 = new Pen(Color.Blue, 3))
            {
                for (int i = 0; i < steps; i++)
                {
                    PointF n1 = new PointF(GraphMargin + (float)t[i] * xs, picGraph.Height - GraphMargin - (float)N[i] * ys);
                    PointF n2 = new PointF(GraphMargin + (float)t[i + 1] * xs, picGraph.Height - GraphMargin - (float)N[i + 1] * ys);

                    g.DrawLine(p1, n1, n2);


                    if (b == 0)
                    {
                        PointF e1 = new PointF(GraphMargin + (float)t[i] * xs, picGraph.Height - GraphMargin - (float)exact[i] * ys);
                        PointF e2 = new PointF(GraphMargin + (float)t[i + 1] * xs, picGraph.Height - GraphMargin - (float)exact[i + 1] * ys);

                        g.DrawLine(p2, e1, e2);
                    }
                }
            }


            g.DrawString("Euler", new Font("Segoe UI", 10), Brushes.Brown, 70, 50);

            if (b == 0)
                g.DrawString("Exact", new Font("Segoe UI", 10), Brushes.Blue, 70, 70);


            picGraph.Refresh();
        }


        private void ClearGraph()
        {
            DrawGraph();
            mode = "";
            toolStripStatusLabel1.Text = "Graph cleared";
        }


        private void ResetParameters()
        {
            txtN0.Text = "1";
            txtA.Text = "10";
            txtB.Text = "3";
            txtDT.Text = "0.001";
            txtSteps.Text = "10000";

            ClearGraph();
        }


        private void SaveGraph()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PopulationGraph.png");

            bmp.Save(path, ImageFormat.Png);

            MessageBox.Show("Saved:\n" + path);
        }


        private void ExportCSV()
        {
            if (mode == "")
            {
                MessageBox.Show("Run simulation first");
                return;
            }

            ReadInputs(out double N0, out double a, out double b, out double dt, out int steps);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Population.csv");


            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Step,Time,Population");

                double N = N0;
                double time = 0;

                for (int i = 0; i <= steps; i++)
                {
                    sw.WriteLine($"{i},{time},{N}");

                    N = N + (a * N - b * N * N) * dt;
                    if (N < 0)
                        N = 0;
                    time += dt;
                }
            }

            MessageBox.Show("CSV exported");
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

