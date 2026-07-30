using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Radioactive_Decay_Simulation
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
            int margin = 60;

            using (Pen axisPen = new Pen(Color.Black, 2))
            {
                // Draw X Axis
                g.DrawLine(axisPen,
                    margin,
                    picGraph.Height - margin,
                    picGraph.Width - margin,
                    picGraph.Height - margin);

                // Draw Y Axis
                g.DrawLine(axisPen,
                    margin,
                    margin,
                    margin,
                    picGraph.Height - margin);
            }
            Font font = new Font("Segoe UI", 9);

            Brush brush = Brushes.Black;

            // Graph Title
            g.DrawString(
                "Radioactive Decay Simulation",
                new Font("Segoe UI", 14, FontStyle.Bold),
                Brushes.DarkBlue,
                picGraph.Width / 2 - 120,
                10);

            // X Label
            g.DrawString(
                "Time",
                font,
                brush,
                picGraph.Width - 70,
                picGraph.Height - 40);

            // Y Label
            g.DrawString(
                "Atoms (N)",
                font,
                brush,
                5,
                40);

            // Draw Tick Marks
            int ticks = 10;

            for (int i = 0; i <= ticks; i++)
            {
                float x = margin + i * (picGraph.Width - 2 * margin) / (float)ticks;

                g.DrawLine(Pens.Black,
                    x,
                    picGraph.Height - margin - 5,
                    x,
                    picGraph.Height - margin + 5);

                float y = picGraph.Height - margin - i * (picGraph.Height - 2 * margin) / (float)ticks;

                g.DrawLine(Pens.Black,
                    margin - 5,
                    y,
                    margin + 5,
                    y);
            }

            picGraph.Refresh();
        }

        private void DrawGrid()
        {
            int margin = 60;

            using (Pen gridPen = new Pen(Color.LightGray))
            {
                gridPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                int grid = 10;

                // Vertical grid lines
                for (int i = 0; i <= grid; i++)
                {
                    float x = margin + i * (picGraph.Width - 2 * margin) / (float)grid;

                    g.DrawLine(
                        gridPen,
                        x,
                        margin,
                        x,
                        picGraph.Height - margin);
                }


                // Horizontal grid lines
                for (int i = 0; i <= grid; i++)
                {
                    float y = margin + i * (picGraph.Height - 2 * margin) / (float)grid;

                    g.DrawLine(
                        gridPen,
                        margin,
                        y,
                        picGraph.Width - margin,
                        y);
                }
            }
        }
        private void RunSimulation()
        {
            g.Clear(Color.White);

            DrawGrid();
            DrawAxes();


            // Read input values safely
            double N0;
            double lambda;
            double dt;
            int iterations;


            if (!double.TryParse(txtInitialAtoms.Text, out N0) ||
                !double.TryParse(txtLambda.Text, out lambda) ||
                !double.TryParse(txtTimeStep.Text, out dt) ||
                !int.TryParse(txtIterations.Text, out iterations))
            {
                MessageBox.Show(
                    "Please enter valid numeric values.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            // Check values
            if (N0 <= 0 || lambda <= 0 || dt <= 0 || iterations <= 0)
            {
                MessageBox.Show(
                    "All values must be greater than zero.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int margin = 60;


            double N = N0;
            double t = 0;


            float xScale =
                (picGraph.Width - 2 * margin) /
                (float)(iterations * dt);


            float yScale =
                (picGraph.Height - 2 * margin) /
                (float)(N0 * 1.2);



            using (Pen graphPen = new Pen(Color.Blue, 3))
            {

                PointF previous = new PointF(
                    margin,
                    picGraph.Height - margin - (float)(N * yScale)
                );


                for (int i = 1; i < iterations; i++)
                {

                    // Euler method for radioactive decay
                    N = N - lambda * N * dt;

                    t += dt;



                    PointF current = new PointF(
                        margin + (float)(t * xScale),
                        picGraph.Height - margin - (float)(N * yScale)
                    );



                    // Draw decay curve
                    g.DrawLine(
                        graphPen,
                        previous,
                        current);



                    // Draw data points
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


            toolStripStatusLabel1.Text =
                "Simulation completed.";
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

            txtInitialAtoms.Text = "150";
            txtLambda.Text = "0.5";
            txtTimeStep.Text = "0.1";
            txtIterations.Text = "150";

            ClearGraph();

            toolStripStatusLabel1.Text = "Parameters reset.";
        }

        private void SaveGraph()
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter =
                "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg"; save.Title = "Save Graph";
            save.FileName = "RadioactiveDecay.png";

            if (save.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(save.FileName).ToLower() == ".jpg")
                {
                    bmp.Save(save.FileName, ImageFormat.Jpeg);
                }
                else
                {
                    bmp.Save(save.FileName, ImageFormat.Png);
                }
                MessageBox.Show("Graph saved successfully.");
            }
        }

        private void ExportCSV()
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "CSV File|*.csv";
            save.FileName = "RadioactiveDecay.csv";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            double N0;
            double lambda;
            double dt;
            int iterations;

            if (!double.TryParse(txtInitialAtoms.Text, out N0) ||
                !double.TryParse(txtLambda.Text, out lambda) ||
                !double.TryParse(txtTimeStep.Text, out dt) ||
                !int.TryParse(txtIterations.Text, out iterations))
            {
                MessageBox.Show(
                    "Please enter valid numeric values.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (N0 <= 0 || lambda <= 0 || dt <= 0 || iterations <= 0)
            {
                MessageBox.Show(
                    "All values must be greater than zero.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            double N = N0;

            double t = 0;

            using (StreamWriter sw = new StreamWriter(save.FileName))
            {
                sw.WriteLine("Iteration,Time,Atoms");
                sw.WriteLine($"0,{t},{N}");
                for (int i = 1; i < iterations; i++)
                {
                    N = N - lambda * N * dt;

                    t += dt;

                    sw.WriteLine($"{i},{t},{N}");
                }
            }

            MessageBox.Show("CSV exported successfully.");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                RunSimulation();
                toolStripStatusLabel1.Text = "Simulation completed.";

            }
            catch
            {
                MessageBox.Show(
                    "Please enter valid numeric values.",
                    "Input Error",
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