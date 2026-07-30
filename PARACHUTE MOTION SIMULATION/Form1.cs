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
            bmp = new Bitmap(
                picGraph.Width,
                picGraph.Height);

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

        // ================= GRID =================

        private void DrawGrid()
        {
            int margin = 40;

            using (Pen pen = new Pen(Color.LightGray))
            {
                pen.DashStyle =
                    System.Drawing.Drawing2D.DashStyle.Dash;

                for (int i = 0; i <= 20; i++)
                {
                    float x =
                        margin +
                        i * (picGraph.Width - 2 * margin) / 20f;

                    g.DrawLine(
                        pen,
                        x,
                        margin,
                        x,
                        picGraph.Height - margin);

                    float y =
                        margin +
                        i * (picGraph.Height - 2 * margin) / 20f;

                    g.DrawLine(
                        pen,
                        margin,
                        y,
                        picGraph.Width - margin,
                        y);
                }
            }
        }

        // ================= AXES =================

        private void DrawAxes()
        {
            int centerX = picGraph.Width / 2;
            int centerY = picGraph.Height / 2;

            using (Pen pen = new Pen(Color.Black, 2))
            {
                // X Axis
                g.DrawLine(
                    pen,
                    40,
                    centerY,
                    picGraph.Width - 40,
                    centerY);

                // Y Axis
                g.DrawLine(
                    pen,
                    centerX,
                    40,
                    centerX,
                    picGraph.Height - 40);
            }

            g.DrawString(
                "Parachute Motion Simulation",
                new Font("Segoe UI", 14, FontStyle.Bold),
                Brushes.DarkBlue,
                110,
                10);

            g.DrawString(
                "Time (s)",
                new Font("Segoe UI", 10),
                Brushes.Black,
                picGraph.Width - 80,
                centerY + 10);

            g.DrawString(
                "Velocity (m/s)",
                new Font("Segoe UI", 10),
                Brushes.Black,
                centerX + 10,
                40);
        }

        // ================= PARACHUTE SIMULATION =================

        private void RunSimulation()
        {
            if (!ReadInputs(
                out double velocity,
                out double gravity,
                out double drag,
                out double dt,
                out int steps))
                return;

            DrawGraph();

            float W = picGraph.Width / 2;
            float H = picGraph.Height / 2;

            float totalTime = steps * (float)dt;

            float xScale =
                (picGraph.Width - 80) / totalTime;

            double[] time = new double[steps + 1];
            double[] v = new double[steps + 1];

            time[0] = 0;
            v[0] = velocity;

            // Find maximum velocity for graph scaling
            double maxVelocity = Math.Abs(velocity);
            double terminalVelocity = gravity / drag;
            for (int i = 0; i < steps; i++)
            {
                v[i + 1] =
                    v[i] +
                    (gravity - drag * v[i]) * dt;

                time[i + 1] =
                    time[i] + dt;

                if (Math.Abs(v[i + 1]) > maxVelocity)
                    maxVelocity = Math.Abs(v[i + 1]);
            }

            if (maxVelocity < 1)
                maxVelocity = 1;

            float yScale =
                (picGraph.Height - 80) /
                (float)maxVelocity;

            using (Pen pen = new Pen(Color.Blue, 3))
            {
                PointF previous =
                    new PointF(
                        W,
                        H - (float)(Math.Abs(v[0]) * yScale));

                for (int i = 1; i <= steps; i++)
                {
                    PointF current =
                        new PointF(
                            W + (float)(time[i] * xScale),
                            H - (float)(Math.Abs(v[i]) * yScale)
                        );


                    g.DrawLine(
                        pen,
                        previous,
                        current);


                    g.FillEllipse(
                        Brushes.Red,
                        current.X - 3,
                        current.Y - 3,
                        6,
                        6);


                    previous = current;


                    // Stop when terminal velocity is reached
                    if (Math.Abs(v[i] - v[i - 1]) < 0.001)
                        break;
                }
            }

            picGraph.Refresh();

            toolStripStatusLabel1.Text =
$"Completed. Terminal velocity = {terminalVelocity:F2} m/s";
        }

        // ================= INPUT VALIDATION =================

        private bool ReadInputs(
            out double velocity,
            out double gravity,
            out double drag,
            out double dt,
            out int steps)
        {
            velocity = 0;
            gravity = 0;
            drag = 0;
            dt = 0;
            steps = 0;

            if (!double.TryParse(txtVelocity.Text, out velocity) ||
                !double.TryParse(txtGravity.Text, out gravity) ||
                !double.TryParse(txtDrag.Text, out drag) ||
                !double.TryParse(txtTimeStep.Text, out dt) ||
                !int.TryParse(txtSteps.Text, out steps))
            {
                MessageBox.Show(
                    "Please enter valid numeric values.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (gravity <= 0)
            {
                MessageBox.Show(
                    "Gravity must be greater than zero.");
                return false;
            }

            if (drag <= 0)
            {
                MessageBox.Show(
                    "Drag coefficient must be greater than zero.");
                return false;
            }

            if (dt <= 0)
            {
                MessageBox.Show(
                    "Time step must be greater than zero.");
                return false;
            }

            if (steps <= 0)
            {
                MessageBox.Show(
                    "Number of steps must be greater than zero.");
                return false;
            }

            return true;
        }

        // ================= CLEAR GRAPH =================

        private void ClearGraph()
        {
            DrawGraph();

            toolStripStatusLabel1.Text =
                "Graph cleared.";
        }

        // ================= RESET PARAMETERS =================

        private void ResetParameters()
        {
            txtVelocity.Text = "150";
            txtGravity.Text = "9.8";
            txtDrag.Text = "1";
            txtTimeStep.Text = "0.1";
            txtSteps.Text = "150";

            ClearGraph();

            toolStripStatusLabel1.Text =
                "Parameters reset.";
        }

        // ================= SAVE GRAPH =================

        private void SaveGraph()
        {
            try
            {
                string path =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.Desktop),
                        "ParachuteMotionGraph.png");

                bmp.Save(
                    path,
                    ImageFormat.Png);

                MessageBox.Show(
                    "Graph saved successfully.\n\n" + path);

                toolStripStatusLabel1.Text =
                    "Graph saved.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= EXPORT CSV =================

        private void ExportCSV()
        {
            try
            {
                if (!ReadInputs(
                    out double velocity,
                    out double gravity,
                    out double drag,
                    out double dt,
                    out int steps))
                    return;

                string path =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.Desktop),
                        "ParachuteMotionData.csv");

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Step,Time(s),Velocity(m/s)");

                    double t = 0;
                    double v = velocity;

                    sw.WriteLine($"0,{t:F2},{v:F4}");

                    for (int i = 1; i <= steps; i++)
                    {
                        v = v + (gravity - drag * v) * dt;
                        t += dt;

                        sw.WriteLine(
                            $"{i},{t:F2},{v:F4}");

                        // Stop when terminal velocity is reached
                        if (Math.Abs(
                            gravity - drag * v) < 0.001)
                            break;
                    }
                }

                MessageBox.Show(
                    "CSV exported successfully.\n\n" + path);

                toolStripStatusLabel1.Text =
                    "CSV exported.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= TOOLSTRIP EVENTS =================

        private void toolStripButton1_Click(
            object sender,
            EventArgs e)
        {
            RunSimulation();
        }

        private void toolStripButton2_Click(
            object sender,
            EventArgs e)
        {
            ClearGraph();
        }

        private void toolStripButton3_Click(
            object sender,
            EventArgs e)
        {
            ResetParameters();
        }

        private void toolStripButton4_Click(
            object sender,
            EventArgs e)
        {
            SaveGraph();
        }

        private void toolStripButton5_Click(
            object sender,
            EventArgs e)
        {
            ExportCSV();
        }

        // ================= MOUSE COORDINATES =================

        private void picGraph_MouseMove(
            object sender,
            MouseEventArgs e)
        {
            toolStripStatusLabel1.Text =
                $"X = {e.X}    Y = {e.Y}";
        }

  
    }
}