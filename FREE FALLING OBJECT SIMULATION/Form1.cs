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
        private string currentGraphName = "Height";

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



        private void DrawGrid()
        {
            int margin = 40;

            using (Pen pen = new Pen(Color.LightGray))
            {
                pen.DashStyle =
                System.Drawing.Drawing2D
                .DashStyle.Dash;


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



        private void DrawAxes()
        {
            int centerX = picGraph.Width / 2;
            int centerY = picGraph.Height / 2;


            using (Pen pen = new Pen(Color.Black, 2))
            {

                // X axis
                g.DrawLine(
                    pen,
                    40,
                    centerY,
                    picGraph.Width - 40,
                    centerY);


                // Y axis
                g.DrawLine(
                    pen,
                    centerX,
                    40,
                    centerX,
                    picGraph.Height - 40);

            }



            g.DrawString(
            "Free Falling Object Simulation",
            new Font("Segoe UI", 14, FontStyle.Bold),
            Brushes.DarkBlue,
            100,
            10);



            g.DrawString(
            "Time (s)",
            new Font("Segoe UI", 10),
            Brushes.Black,
            picGraph.Width - 80,
            centerY + 10);



            g.DrawString(
            "Height / Displacement",
            new Font("Segoe UI", 10),
            Brushes.Black,
            centerX + 10,
            40);

        }
        // ================= HEIGHT SIMULATION =================

        private void RunHeightSimulation()
        {
            if (!ReadInputs(
                out double height,
                out double velocity,
                out double gravity,
                out double dt,
                out int steps))
                return;

            DrawGraph();

            float W = picGraph.Width / 2;
            float H = picGraph.Height / 2;

            float xScale = 20;

            // Maximum height reached
            double maxHeight = height;

            if (velocity > 0)
                maxHeight += (velocity * velocity) / (2 * gravity);

            if (maxHeight < 1)
                maxHeight = 1;

            float yScale =
                (picGraph.Height - 80) /
                (float)maxHeight;

            using (Pen pen = new Pen(Color.Blue, 3))
            {
                PointF previous = new PointF(
                    W,
                    H - (float)(height * yScale));

                for (int i = 1; i <= steps; i++)
                {
                    double t = i * dt;

                    double y =
                        height +
                        velocity * t -
                        0.5 * gravity * t * t;

                    if (y < 0)
                        break;

                    PointF current = new PointF(
                        W + (float)(t * xScale),
                        H - (float)(y * yScale));

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
                }
            }

            picGraph.Refresh();

            toolStripStatusLabel1.Text =
                "Height simulation completed.";
        }
        // ================= DISPLACEMENT SIMULATION =================
        private void RunDisplacementSimulation()
        {
            if (!ReadInputs(
                out double height,
                out double velocity,
                out double gravity,
                out double dt,
                out int steps))
                return;

            DrawGraph();

            float W = picGraph.Width / 2;
            float H = picGraph.Height / 2;

            float xScale = 20;

            // Calculate the maximum displacement that will occur
            double maxDisplacement = 0;

            for (int i = 0; i <= steps; i++)
            {
                double t = i * dt;

                double s =
                    velocity * t -
                    0.5 * gravity * t * t;

                if (Math.Abs(s) > maxDisplacement)
                    maxDisplacement = Math.Abs(s);

                // Stop when the object has reached the ground
                double currentHeight =
                    height +
                    velocity * t -
                    0.5 * gravity * t * t;

                if (currentHeight < 0)
                    break;
            }

            if (maxDisplacement < 1)
                maxDisplacement = 1;

            float yScale =
                (picGraph.Height - 400) /
                (float)maxDisplacement;

            using (Pen pen = new Pen(Color.Green, 3))
            {
                PointF previous = new PointF(W, H);

                for (int i = 1; i <= steps; i++)
                {
                    double t = i * dt;

                    double displacement =
                        velocity * t -
                        0.5 * gravity * t * t;

                    double currentHeight =
                        height +
                        velocity * t -
                        0.5 * gravity * t * t;

                    if (currentHeight < 0)
                        break;

                    PointF current = new PointF(
                        W + (float)(t * xScale),
                        H - (float)(displacement * yScale));

                    g.DrawLine(
                        pen,
                        previous,
                        current);

                    g.FillEllipse(
                        Brushes.DarkGreen,
                        current.X - 3,
                        current.Y - 3,
                        6,
                        6);

                    previous = current;
                }
            }

            picGraph.Refresh();

            toolStripStatusLabel1.Text =
                "Displacement simulation completed.";
        }
        
        // ================= INPUT VALIDATION =================


        private bool ReadInputs(
            out double height,
            out double velocity,
            out double gravity,
            out double dt,
            out int steps)
        {

            height = 0;
            velocity = 0;
            gravity = 0;
            dt = 0;
            steps = 0;


            if (!double.TryParse(txtHeight.Text, out height) ||
               !double.TryParse(txtVelocity.Text, out velocity) ||
               !double.TryParse(txtGravity.Text, out gravity) ||
               !double.TryParse(txtTimeStep.Text, out dt) ||
               !int.TryParse(txtSteps.Text, out steps))
            {

                MessageBox.Show(
                "Please enter valid numbers.");

                return false;
            }



            if (height < 0 ||
               gravity <= 0 ||
               dt <= 0 ||
               steps <= 0)
            {

                MessageBox.Show(
                "Values must be greater than zero.");

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




        // ================= RESET =================


        private void ResetParameters()
        {
            txtHeight.Text = "100";
            txtVelocity.Text = "0";
            txtGravity.Text = "9.8";
            txtTimeStep.Text = "0.1";
            txtSteps.Text = "200";


            ClearGraph();


            toolStripStatusLabel1.Text =
            "Parameters reset.";
        }


        // ================= SAVE GRAPH =================

        private void SaveGraph()
        {
            try
            {
                string graphName;

                // Determine which graph is currently selected
                if (toolStripStatusLabel1.Text.Contains("Height"))
                    graphName = "HeightGraph";
                else if (toolStripStatusLabel1.Text.Contains("Displacement"))
                    graphName = "DisplacementGraph";
                else
                    graphName = "Graph";

                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    graphName + ".png");

                bmp.Save(path, ImageFormat.Png);

                MessageBox.Show(
                    $"{graphName} saved successfully.\n\nLocation:\n{path}",
                    "Save Graph",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }





        // ================= EXPORT CSV =================
        private void ExportCSV()
        {
            try
            {
                string path = Path.Combine(
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.Desktop),
                    $"FreeFalling_{currentGraphName}.csv");

                if (!ReadInputs(
                    out double height,
                    out double velocity,
                    out double gravity,
                    out double dt,
                    out int steps))
                    return;

                using (StreamWriter sw = new StreamWriter(path))
                {
                    if (currentGraphName == "Height")
                        sw.WriteLine("Iteration,Time,Height,Velocity");
                    else
                        sw.WriteLine("Iteration,Time,Displacement,Velocity");

                    for (int i = 0; i <= steps; i++)
                    {
                        double t = i * dt;

                        double currentHeight =
                            height +
                            velocity * t -
                            0.5 * gravity * t * t;

                        double displacement =
                            velocity * t -
                            0.5 * gravity * t * t;

                        double currentVelocity =
                            velocity -
                            gravity * t;

                        if (currentGraphName == "Height")
                        {
                            sw.WriteLine(
                                $"{i},{t:F3},{currentHeight:F3},{currentVelocity:F3}");

                            if (currentHeight <= 0)
                                break;
                        }
                        else
                        {
                            sw.WriteLine(
                                $"{i},{t:F3},{displacement:F3},{currentVelocity:F3}");

                            if (currentHeight <= 0)
                                break;
                        }
                    }
                }

                MessageBox.Show(
                    $"CSV exported successfully.\n\n{path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================= TOOLSTRIP EVENTS =================


        private void toolStripButton1_Click(
        object sender, EventArgs e)
        {
            RunHeightSimulation();
        }



        private void toolStripButton2_Click(
        object sender, EventArgs e)
        {
            ClearGraph();
        }




        private void toolStripButton3_Click(
        object sender, EventArgs e)
        {
            ResetParameters();
        }




        private void toolStripButton4_Click(
        object sender, EventArgs e)
        {
            SaveGraph();
        }




        private void toolStripButton5_Click(
        object sender, EventArgs e)
        {
            ExportCSV();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            currentGraphName = "Height";
            RunHeightSimulation();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            currentGraphName = "Displacement";
            RunDisplacementSimulation();
        }





        // ================= MOUSE COORDINATE =================


        private void picGraph_MouseMove(
        object sender,
        MouseEventArgs e)
        {

            toolStripStatusLabel1.Text =
            $"X={e.X}  Y={e.Y}";

        }

  
    }
}