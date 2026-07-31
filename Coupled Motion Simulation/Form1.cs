using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Coupled_Motion_Simulation
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;
        private const int GraphMargin = 50;
        private string currentMode = "";

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

            g.DrawString("Coupled Decay Simulation", new Font("Segoe UI", 14, FontStyle.Bold), Brushes.DarkBlue, 120, 10);
            g.DrawString("Time (s)", new Font("Segoe UI", 10), Brushes.Black, picGraph.Width - 90, picGraph.Height - 45);
            g.DrawString("Population", new Font("Segoe UI", 10), Brushes.Black, 5, GraphMargin);
        }


        private bool ReadInputs(out double NA, out double NB, out double tauA, out double tauB, out double dt, out int steps)
        {
            NA = NB = tauA = tauB = dt = 0;
            steps = 0;

            bool ok = double.TryParse(txtNA.Text, out NA) &
            double.TryParse(txtNB.Text, out NB) &
            double.TryParse(txtTauA.Text, out tauA) &
            double.TryParse(txtTauB.Text, out tauB) &
            double.TryParse(txtDT.Text, out dt) &
            int.TryParse(txtSteps.Text, out steps);

            if (!ok)
            {
                MessageBox.Show("Invalid values");
                return false;
            }

            if (NA < 0 || NB < 0 || tauA <= 0 || tauB <= 0 || dt <= 0 || steps <= 0)
            {
                MessageBox.Show("Values must be positive");
                return false;
            }
            if (dt > tauA / 10 || dt > tauB / 10)
            {
                MessageBox.Show("Warning: Time step is large. Euler method may become unstable.");
            }
            return true;
        }


        private void OneWaySimulation()
        {
            if (!ReadInputs(out double NA, out double NB, out double tauA, out double tauB, out double dt, out int steps))
                return;

            currentMode = "OneWay";

            DrawGraph();

            double[] A = new double[steps + 1];
            double[] B = new double[steps + 1];
            double[] t = new double[steps + 1];

            A[0] = NA;
            B[0] = NB;

            for (int i = 0; i < steps; i++)
            {
                A[i + 1] = A[i] + (-A[i] / tauA) * dt;
                B[i + 1] = B[i] + ((A[i] / tauA) - (B[i] / tauB)) * dt;
                t[i + 1] = t[i] + dt;
            }

            DrawCurves(A, B, t, steps);

            toolStripStatusLabel1.Text = "One way decay completed";
        }


        private void TwoWaySimulation()
        {
            if (!ReadInputs(out double NA, out double NB, out double tauA, out double tauB, out double dt, out int steps))
                return;

            currentMode = "TwoWay";

            DrawGraph();

            double[] A = new double[steps + 1];
            double[] B = new double[steps + 1];
            double[] t = new double[steps + 1];

            A[0] = NA;
            B[0] = NB;

            double tau = tauA;

            for (int i = 0; i < steps; i++)
            {
                A[i + 1] = A[i] + ((B[i] / tau) - (A[i] / tau)) * dt;
                B[i + 1] = B[i] + ((A[i] / tau) - (B[i] / tau)) * dt;
                t[i + 1] = t[i] + dt;
            }

            DrawCurves(A, B, t, steps);

            toolStripStatusLabel1.Text = "Two way decay completed";
        }

        private void DrawCurves(double[] A, double[] B, double[] t, int steps)
        {
            double max = 1;

            for (int i = 0; i <= steps; i++)
            {
                if (A[i] > max) max = A[i];
                if (B[i] > max) max = B[i];
            }

            float xScale = (picGraph.Width - 2 * GraphMargin) / (float)t[steps];
            float yScale = (picGraph.Height - 2 * GraphMargin) / (float)(max*1.2);

            using (Pen p1 = new Pen(Color.Brown, 3))
            using (Pen p2 = new Pen(Color.Green, 3))
            {
                for (int i = 0; i < steps; i++)
                {
                    PointF a1 = new PointF((float)(GraphMargin + t[i] * xScale), (float)(picGraph.Height - GraphMargin - A[i] * yScale));
                    PointF a2 = new PointF((float)(GraphMargin + t[i + 1] * xScale), (float)(picGraph.Height - GraphMargin - A[i + 1] * yScale));

                    PointF b1 = new PointF((float)(GraphMargin + t[i] * xScale), (float)(picGraph.Height - GraphMargin - B[i] * yScale));
                    PointF b2 = new PointF((float)(GraphMargin + t[i + 1] * xScale), (float)(picGraph.Height - GraphMargin - B[i + 1] * yScale));

                    g.DrawLine(p1, a1, a2);
                    g.DrawLine(p2, b1, b2);
                }
            }

            g.DrawString("A Nuclei", new Font("Segoe UI", 10), Brushes.Brown, 70, 50);
            g.DrawString("B Nuclei", new Font("Segoe UI", 10), Brushes.Green, 70, 70);

            picGraph.Refresh();
        }


        private void ClearGraph()
        {
            DrawGraph();
            currentMode = "";
            toolStripStatusLabel1.Text = "Graph cleared";
        }


        private void ResetParameters()
        {
            txtNA.Text = "100";
            txtNB.Text = "0";
            txtTauA.Text = "10";
            txtTauB.Text = "5";
            txtDT.Text = "0.1";
            txtSteps.Text = "500";

            ClearGraph();

            toolStripStatusLabel1.Text = "Parameters reset";
        }


        private void SaveGraph()
        {
            try
            {
                string name = currentMode == "" ? "CoupledGraph" : currentMode + "Graph";

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name + ".png");

                bmp.Save(path, ImageFormat.Png);

                MessageBox.Show("Saved:\n" + path);

                toolStripStatusLabel1.Text = "Graph saved";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ExportCSV()
        {
            if (!ReadInputs(out double NA, out double NB, out double tauA, out double tauB, out double dt, out int steps))
                return;

            if (currentMode == "")
            {
                MessageBox.Show("Run simulation first");
                return;
            }


            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), currentMode + ".csv");


            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Step,Time,NA,NB");

                double A = NA;
                double B = NB;
                double time = 0;


                sw.WriteLine($"0,{time},{A},{B}");


                for (int i = 1; i <= steps; i++)
                {

                    if (currentMode == "OneWay")
                    {
                        double oldA = A;
                        double oldB = B;
                        A = oldA + (-oldA / tauA) * dt;
                        B = oldB + ((oldA / tauA) - (oldB / tauB)) * dt;
                    }

                    if (currentMode == "TwoWay")
                    {
                        double oldA = A;
                        double oldB = B;
                        A = oldA + ((oldB / tauA) - (oldA / tauA)) * dt;
                        B = oldB + ((oldA / tauA) - (oldB / tauA)) * dt;
                    }


                    time += dt;

                    sw.WriteLine($"{i},{time},{A},{B}");
                }
            }


            MessageBox.Show("CSV exported:\n" + path);

            toolStripStatusLabel1.Text = "CSV exported";
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OneWaySimulation();
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TwoWaySimulation();
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ClearGraph();
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ResetParameters();
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SaveGraph();
        }


        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            ExportCSV();
        }


        private void picGraph_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = $"X={e.X} Y={e.Y}";
        }
    }
}