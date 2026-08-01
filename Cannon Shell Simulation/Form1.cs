using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Cannon_Shell_Simulation
{
    public partial class Form1 : Form
    {
        private const double Gravity = 9.8;
        private const double DefaultDrag = 4e-5;
        private const double DefaultScaleHeight = 10000.0;

        private class Parameters
        {
            public double Speed;
            public double Angle;
            public double DragOverMass;
            public double ScaleHeight;
            public double Dt;
        }

        private class Trajectory
        {
            public string Name = "";
            public Color Color = Color.Blue;
            public List<double> X = new List<double>();
            public List<double> Y = new List<double>();
        }

        private class Simulation
        {
            public string Name;

            public Parameters Parameters = new Parameters();

            public Trajectory CurrentTrajectory = new Trajectory();

            public List<Trajectory> SavedTrajectories = new List<Trajectory>();
        }

        private Simulation noAir = new Simulation
        {
            Name = "No Air Resistance"
        };

        private Simulation airResistance = new Simulation
        {
            Name = "Air Resistance"
        };

        private Simulation densityCorrection = new Simulation
        {
            Name = "Density Correction"
        };

        private Simulation maximumRange = new Simulation
        {
            Name = "Maximum Range"
        };

        private Simulation currentSimulation;

        private Bitmap bitmap;
        private Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ConnectEvents();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateGraph();
            SelectNoAirResistance();
        }

        private void CreateGraph()
        {
            bitmap = new Bitmap(picGraph.Width, picGraph.Height);
            picGraph.Image = bitmap;
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
        }

        private void ConnectEvents()
        {
            menuNoAirResistance.Click += MenuNoAirResistance_Click;
            menuAirResistance.Click += MenuAirResistance_Click;
            menuDensityCorrection.Click += MenuDensityCorrection_Click;
            menuMaximumRange.Click += MenuMaximumRange_Click;

            btnRun.Click += BtnRun_Click;
            btnSaveTrajectory.Click += BtnSaveTrajectory_Click;
            btnClear.Click += BtnClear_Click;
            btnReset.Click += BtnReset_Click;
            btnSaveImage.Click += BtnSaveImage_Click;
            btnExportCSV.Click += BtnExportCSV_Click;
        }
        private List<double> ParseAngle(string text)
        {
            List<double> angles = new List<double>();

            if (text.Contains("-"))
            {
                string[] range = text.Split('-');

                double start = Convert.ToDouble(range[0]);
                double end = Convert.ToDouble(range[1]);

                for (double a = start; a <= end; a++)
                    angles.Add(a);
            }
            else if (text.Contains(","))
            {
                string[] values = text.Split(',');

                foreach (string value in values)
                    angles.Add(Convert.ToDouble(value));
            }
            else
            {
                angles.Add(Convert.ToDouble(text));
            }

            return angles;
        }
        private void BtnRun_Click(object sender, EventArgs e)
        {
            RunCurrentSimulation();
        }

        private void MenuNoAirResistance_Click(object sender, EventArgs e)
        {
            SelectNoAirResistance();
        }

        private void MenuAirResistance_Click(object sender, EventArgs e)
        {
            SelectAirResistance();
        }

        private void MenuDensityCorrection_Click(object sender, EventArgs e)
        {
            SelectDensityCorrection();
        }

        private void MenuMaximumRange_Click(object sender, EventArgs e)
        {
            SelectMaximumRange();
        }

        private void SelectNoAirResistance()
        {
            currentSimulation = noAir;
            LoadNoAirParameters();

            EnableParameters(false, false);

            lblEquation.Text =
                "Euler Method (2.15)\n\n" +
                "xᵢ₊₁ = xᵢ + vxΔt\n" +
                "vxᵢ₊₁ = vxᵢ\n\n" +
                "yᵢ₊₁ = yᵢ + vyΔt\n" +
                "vyᵢ₊₁ = vyᵢ - gΔt";

            lblStatus.Text = "No Air Resistance";

        }

        private void SelectAirResistance()
        {
            currentSimulation = airResistance;
            LoadAirParameters();

            EnableParameters(true, false);

            lblEquation.Text =
                "Euler Method (2.19)\n\n" +
"vxᵢ₊₁ = vxᵢ - (B₂/m)v vxᵢΔt\n\n" +
"vyᵢ₊₁ = vyᵢ - gΔt\n" +
"     - (B₂/m)v vyᵢΔt";

            lblStatus.Text = "Air Resistance";

        }

        private void SelectDensityCorrection()
        {
            currentSimulation = densityCorrection;
            LoadDensityParameters();

            EnableParameters(true,true);

            lblEquation.Text =
                "Density Correction (2.20,2.21)\n\n" +
                "ρ = ρ₀ exp(-y/y₀)\n\n" +
                "(B₂/m) → (B₂/m) exp(-y/y₀)";

            lblStatus.Text = "Density Correction";

        }

        private void SelectMaximumRange()
        {
            currentSimulation = maximumRange;
            LoadMaximumRangeParameters();

            EnableParameters(true, false);

            txtAngle.Enabled = false;

            lblEquation.Text =
                "Maximum Range\n\n" +
                "Test firing angle\n" +
                "and select largest range";

            lblStatus.Text = "Maximum Range";

        }

        private void LoadNoAirParameters()
        {
            currentSimulation.Parameters.Speed = 700;
            currentSimulation.Parameters.Angle = 45;
            currentSimulation.Parameters.Dt = 0.1;

            txtSpeed.Text = "700";
            txtAngle.Text = "45";
            txtDt.Text = "0.1";
        }

        private void LoadAirParameters()
        {
            currentSimulation.Parameters.Speed = 700;
            currentSimulation.Parameters.Angle = 45;
            currentSimulation.Parameters.DragOverMass = DefaultDrag;
            currentSimulation.Parameters.Dt = 0.1;


            txtSpeed.Text = "700";
            txtAngle.Text = "45";
            txtDrag.Text = "4E-05";
            txtDt.Text = "0.1";
        }

        private void LoadDensityParameters()
        {
            LoadAirParameters();

            currentSimulation.Parameters.ScaleHeight = DefaultScaleHeight;
            txtScaleHeight.Text = "10000";
        }

        private void LoadMaximumRangeParameters()
        {
            LoadDensityParameters();
        }

        private void EnableParameters(bool drag, bool scaleHeight)
        {
            txtDrag.Enabled = drag;
            txtScaleHeight.Enabled = scaleHeight;
        }

        private void RunCurrentSimulation()
        {
            ReadParameters();

            if (currentSimulation.Name == "Maximum Range")
            {
                CalculateMaximumRange();

                currentSimulation.SavedTrajectories.Clear();

                Trajectory result = CopyTrajectory(currentSimulation.CurrentTrajectory);
                result.Name = "Maximum Range";

                currentSimulation.SavedTrajectories.Add(result);

                DrawGraph();
                return;
            }

            List<double> angles = ParseAngle(txtAngle.Text);

            currentSimulation.SavedTrajectories.Clear();

            foreach (double angle in angles)
            {
                currentSimulation.Parameters.Angle = angle;

                switch (currentSimulation.Name)
                {
                    case "No Air Resistance":
                        CalculateNoAirResistance();
                        break;

                    case "Air Resistance":
                        CalculateAirResistance(false);
                        break;

                    case "Density Correction":
                        CalculateAirResistance(true);
                        break;
                }

                Trajectory result = CopyTrajectory(currentSimulation.CurrentTrajectory);
                result.Name = "Angle " + angle;

                currentSimulation.SavedTrajectories.Add(result);
            }

            DrawGraph();
        }

        private void ReadParameters()
        {
            currentSimulation.Parameters.Speed = Convert.ToDouble(txtSpeed.Text);
            currentSimulation.Parameters.Dt = Convert.ToDouble(txtDt.Text);

            if (txtDrag.Enabled)
                currentSimulation.Parameters.DragOverMass =
                    Convert.ToDouble(txtDrag.Text);

            if (txtScaleHeight.Enabled)
                currentSimulation.Parameters.ScaleHeight = Convert.ToDouble(txtScaleHeight.Text);
        }

        private void CalculateNoAirResistance()
        {
            Trajectory trajectory = new Trajectory();
            trajectory.Name = "No Air Resistance";

            double v0 = currentSimulation.Parameters.Speed;
            double angle = currentSimulation.Parameters.Angle * Math.PI / 180.0;
            double dt = currentSimulation.Parameters.Dt;

            double vx = v0 * Math.Cos(angle);
            double vy = v0 * Math.Sin(angle);

            double x = 0;
            double y = 0;

            while (true)
            {
                trajectory.X.Add(x);
                trajectory.Y.Add(y);

                // Euler update
                x += vx * dt;
                y += vy * dt;

                vy -= Gravity * dt;

                // store last point below ground for interpolation
                if (y < 0)
                {
                    trajectory.X.Add(x);
                    trajectory.Y.Add(y);
                    break;
                }
            }

            InterpolateLanding(trajectory);

            currentSimulation.CurrentTrajectory = trajectory;
        }

        private void CalculateAirResistance(bool density)
        {
            Trajectory trajectory = new Trajectory();

            trajectory.Name = density
                ? "Density Correction"
                : "Air Resistance";


            double v0 = currentSimulation.Parameters.Speed;

            double angle = currentSimulation.Parameters.Angle
                           * Math.PI / 180.0;


            double B2_over_m =
                currentSimulation.Parameters.DragOverMass;


            double y0 = currentSimulation.Parameters.ScaleHeight;

            double dt = currentSimulation.Parameters.Dt;


            double vx = v0 * Math.Cos(angle);
            double vy = v0 * Math.Sin(angle);


            double x = 0;
            double y = 0;


            while (true)
            {
                trajectory.X.Add(x);
                trajectory.Y.Add(y);


                // speed
                double v = Math.Sqrt(vx * vx + vy * vy);


                // drag coefficient
                double drag = B2_over_m;


                // density correction
                if (density)
                {
                    drag *= Math.Exp(-y / y0);
                }


                // Euler velocity update
                vx -= drag * v * vx * dt;

                vy -= Gravity * dt
                      + drag * v * vy * dt;


                // Euler position update
                x += vx * dt;

                y += vy * dt;


                // projectile hits ground
                if (y < 0)
                {
                    trajectory.X.Add(x);
                    trajectory.Y.Add(y);
                    break;
                }
            }


            InterpolateLanding(trajectory);


            currentSimulation.CurrentTrajectory = trajectory;
        }
        private void InterpolateLanding(Trajectory trajectory)
        {
            int n = trajectory.Y.Count - 1;

            if (n < 1 || trajectory.Y[n] >= 0)
                return;

            double y1 = trajectory.Y[n - 1];
            double y2 = trajectory.Y[n];

            double x1 = trajectory.X[n - 1];
            double x2 = trajectory.X[n];

            double fraction = -y1 / (y2 - y1);

            trajectory.X[n] = x1 + fraction * (x2 - x1);
            trajectory.Y[n] = 0;
        }

        private void CalculateMaximumRange()
        {
            double bestRange = 0;
            double bestAngle = 0;

            Trajectory bestTrajectory = null;


            for (double angle = 1; angle <= 89; angle++)
            {
                currentSimulation.Parameters.Angle = angle;


                // include density correction
                CalculateAirResistance(true);


                Trajectory test = currentSimulation.CurrentTrajectory;


                double range = test.X[test.X.Count - 1];


                if (range > bestRange)
                {
                    bestRange = range;
                    bestAngle = angle;

                    bestTrajectory = CopyTrajectory(test);
                }
            }


            if (bestTrajectory != null)
            {
                bestTrajectory.Name = "Maximum Range";

                currentSimulation.CurrentTrajectory = bestTrajectory;
            }


            lblStatus.Text =
                "Best Angle = " + bestAngle.ToString("F0")
                + "°   Range = "
                + (bestRange / 1000).ToString("F2")
                + " km";
        }
        private Trajectory CopyTrajectory(Trajectory original)
        {
            Trajectory copy = new Trajectory();

            copy.Name = original.Name;
            copy.Color = original.Color;
            copy.X = new List<double>(original.X);
            copy.Y = new List<double>(original.Y);

            return copy;
        }

        private void BtnSaveTrajectory_Click(object sender, EventArgs e)
        {
            if (currentSimulation.CurrentTrajectory.X.Count == 0)
            {
                MessageBox.Show("Run simulation first.");
                return;
            }

            Trajectory saved = CopyTrajectory(currentSimulation.CurrentTrajectory);

            saved.Name = "Saved " + (currentSimulation.SavedTrajectories.Count + 1);

            currentSimulation.SavedTrajectories.Add(saved);

            lblStatus.Text = "Trajectory Saved";

            DrawGraph();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            currentSimulation.CurrentTrajectory = new Trajectory();
            currentSimulation.SavedTrajectories.Clear();

            DrawGraph();

            lblStatus.Text = "Cleared";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            currentSimulation.CurrentTrajectory = new Trajectory();
            currentSimulation.SavedTrajectories.Clear();

            switch (currentSimulation.Name)
            {
                case "No Air Resistance":
                    SelectNoAirResistance();
                    break;

                case "Air Resistance":
                    SelectAirResistance();
                    break;

                case "Density Correction":
                    SelectDensityCorrection();
                    break;

                case "Maximum Range":
                    SelectMaximumRange();
                    break;
            }

            DrawGraph();
        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            string fileName = currentSimulation.Name.Replace(" ", "_")
                             + "_Trajectory.png";

            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                fileName);

            bitmap.Save(path, ImageFormat.Png);

            MessageBox.Show(
                currentSimulation.Name + " image saved");
        }

        private void BtnExportCSV_Click(object sender, EventArgs e)
        {
            string fileName = currentSimulation.Name.Replace(" ", "_")
                             + "_Data.csv";

            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                fileName);


            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(
                    "Simulation:," + currentSimulation.Name);

                writer.WriteLine("Trajectory,X,Y");


                foreach (Trajectory t in currentSimulation.SavedTrajectories)
                {
                    for (int i = 0; i < t.X.Count; i++)
                    {
                        writer.WriteLine(
                            t.Name + "," +
                            t.X[i] + "," +
                            t.Y[i]);
                    }
                }


                if (currentSimulation.CurrentTrajectory.X.Count > 0)
                {
                    Trajectory current =
                        currentSimulation.CurrentTrajectory;


                    for (int i = 0; i < current.X.Count; i++)
                    {
                        writer.WriteLine(
                            current.Name + "," +
                            current.X[i] + "," +
                            current.Y[i]);
                    }
                }
            }


            MessageBox.Show(
                currentSimulation.Name + " CSV exported");
        }
        private void DrawGraph()
        {
            if (bitmap == null)
                CreateGraph();

            graphics.Clear(Color.White);

            List<Trajectory> all = new List<Trajectory>();

            all.AddRange(currentSimulation.SavedTrajectories);

            if (currentSimulation.CurrentTrajectory.X.Count > 0)
                all.Add(currentSimulation.CurrentTrajectory);

            if (all.Count == 0)
            {
                picGraph.Refresh();
                return;
            }

            double xmin = double.MaxValue;
            double xmax = double.MinValue;
            double ymin = double.MaxValue;
            double ymax = double.MinValue;

            foreach (Trajectory t in all)
            {
                foreach (double x in t.X)
                {
                    xmin = Math.Min(xmin, x);
                    xmax = Math.Max(xmax, x);
                }

                foreach (double y in t.Y)
                {
                    ymin = Math.Min(ymin, y);
                    ymax = Math.Max(ymax, y);
                }
            }

            double dx = (xmax - xmin) * 0.1;
            double dy = (ymax - ymin) * 0.1;

            if (dx == 0)
                dx = 1;

            if (dy == 0)
                dy = 1;

            xmin -= dx;
            xmax += dx;
            ymin -= dy;
            ymax += dy;

            DrawGrid(xmin, xmax, ymin, ymax);
            DrawAxes(xmin, xmax, ymin, ymax);

            foreach (Trajectory t in currentSimulation.SavedTrajectories)
                DrawTrajectory(t, xmin, xmax, ymin, ymax, Color.Gray);

            if (currentSimulation.CurrentTrajectory.X.Count > 1)
                DrawTrajectory(currentSimulation.CurrentTrajectory, xmin, xmax, ymin, ymax, Color.Blue);

            graphics.DrawString(
                "Cannon Shell Trajectory",
                new Font("Arial", 14, FontStyle.Bold),
                Brushes.Black,
                300,
                10);

            graphics.DrawString(
                "Distance X (m)",
                new Font("Arial", 10),
                Brushes.Black,
                500,
                picGraph.Height - 40);

            graphics.DrawString(
                "Height Y (m)",
                new Font("Arial", 10),
                Brushes.Black,
                10,
                50);

            picGraph.Refresh();
        }

        private void DrawGrid(double xmin, double xmax, double ymin, double ymax)
        {
            Pen gridPen = new Pen(Color.LightGray, 1);

            for (double x = Math.Ceiling(xmin); x <= xmax; x += (xmax - xmin) / 10)
            {
                float px = MapX(x, xmin, xmax);

                graphics.DrawLine(
                    gridPen,
                    px,
                    40,
                    px,
                    picGraph.Height - 60);
            }

            for (double y = Math.Ceiling(ymin); y <= ymax; y += (ymax - ymin) / 10)
            {
                float py = MapY(y, ymin, ymax);

                graphics.DrawLine(
                    gridPen,
                    70,
                    py,
                    picGraph.Width - 40,
                    py);
            }
        }

        private void DrawAxes(double xmin, double xmax, double ymin, double ymax)
        {
            Pen axis = new Pen(Color.Black, 2);

            float xAxis;
            float yAxis;

            if (ymin <= 0 && ymax >= 0)
                xAxis = MapY(0, ymin, ymax);
            else if (ymin > 0)
                xAxis = picGraph.Height - 60;
            else
                xAxis = 40;

            if (xmin <= 0 && xmax >= 0)
                yAxis = MapX(0, xmin, xmax);
            else if (xmin > 0)
                yAxis = 70;
            else
                yAxis = picGraph.Width - 40;

            graphics.DrawLine(axis, 70, xAxis, picGraph.Width - 40, xAxis);
            graphics.DrawLine(axis, yAxis, 40, yAxis, picGraph.Height - 60);
        }

        private void DrawTrajectory(Trajectory trajectory, double xmin, double xmax, double ymin, double ymax, Color color)
        {
            if (trajectory.X.Count < 2)
                return;

            Pen pen = new Pen(color, 2);

            for (int i = 0; i < trajectory.X.Count - 1; i++)
            {
                float x1 = MapX(trajectory.X[i], xmin, xmax);
                float y1 = MapY(trajectory.Y[i], ymin, ymax);

                float x2 = MapX(trajectory.X[i + 1], xmin, xmax);
                float y2 = MapY(trajectory.Y[i + 1], ymin, ymax);

                graphics.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private float MapX(double x, double xmin, double xmax)
        {
            return 70 + (float)((x - xmin) / (xmax - xmin) * (picGraph.Width - 110));
        }

        private float MapY(double y, double ymin, double ymax)
        {
            return picGraph.Height - 60 -
                   (float)((y - ymin) / (ymax - ymin) * (picGraph.Height - 100));
        }
    }
}