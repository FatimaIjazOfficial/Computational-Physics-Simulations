using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Bicycle_Racing_Simulation
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        private Graphics g;

        private enum SimulationType
        {
            NoAirResistance,
            ExactCompare,
            AirResistance,
            Drafting,
            Uphill,
            Downhill,
            ConstantForce
        }

        private SimulationType currentSimulation;

        private List<double> time = new List<double>();
        private List<double> velocity = new List<double>();
        private List<double> exactVelocity = new List<double>();

        private const double AirDensity = 1.225;
        private const double Gravity = 9.8;

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            LoadDefaultValues();

            ConnectEvents();

            currentSimulation = SimulationType.NoAirResistance;

            SetParameters();

            this.Load += Form1_Load;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CreateGraph();
        }

        private void LoadDefaultValues()
        {
            txtMass.Text = "70";
            txtVelocity.Text = "4";
            txtPower.Text = "400";
            txtDt.Text = "0.1";
            txtTotalTime.Text = "200";

            txtDrag.Text = "0.5";
            txtArea.Text = "0.33";
            txtDensity.Text = "1.225";

            txtGrade.Text = "0.1";

            txtForce.Text = "80";
            txtCrossVelocity.Text = "7";
        }

        private void ConnectEvents()
        {
            menuNoAir.Click += menuNoAir_Click;
            menuExact.Click += menuExact_Click;
            menuAir.Click += menuAir_Click;
            menuDraft.Click += menuDraft_Click;
            menuUphill.Click += menuUphill_Click;
            menuDownhill.Click += menuDownhill_Click;
            menuForce.Click += menuForce_Click;


            btnClear.Click += new EventHandler(btnClear_Click);
            btnReset.Click += new EventHandler(btnReset_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCSV.Click += new EventHandler(btnCSV_Click);
        }

        private void menuNoAir_Click(object sender, EventArgs e)
        {
            currentSimulation = SimulationType.NoAirResistance;
            SetParameters();
            RunSimulation();
        }

        private void menuExact_Click(object sender, EventArgs e)
        {
            currentSimulation = SimulationType.ExactCompare;
            SetParameters();
            RunSimulation();
        }

        private void menuAir_Click(object sender, EventArgs e)
        {
            currentSimulation = SimulationType.AirResistance;
            SetParameters();
            RunSimulation();
        }

        private void menuDraft_Click(object sender, EventArgs e)
        {
            currentSimulation = SimulationType.Drafting;
            SetParameters();
            RunSimulation();
        }


        private void menuUphill_Click(object sender, EventArgs e)
        {
            currentSimulation = SimulationType.Uphill;
            SetParameters();
            RunSimulation();
        }

        private void menuDownhill_Click(object sender, EventArgs e)
        {
            currentSimulation = SimulationType.Downhill;
            SetParameters();
            RunSimulation();
        }


        private void menuForce_Click(object sender, EventArgs e)
        {
            currentSimulation = SimulationType.ConstantForce;
            SetParameters();
            RunSimulation();
        }

        private void SetParameters()
        {
            EnableAllParameters(false);

            switch (currentSimulation)
            {
                case SimulationType.NoAirResistance:

                    EnableParameter(txtMass, true);
                    EnableParameter(txtVelocity, true);
                    EnableParameter(txtPower, true);
                    EnableParameter(txtDt, true);
                    EnableParameter(txtTotalTime, true);

                    break;


                case SimulationType.ExactCompare:

                    EnableParameter(txtMass, true);
                    EnableParameter(txtVelocity, true);
                    EnableParameter(txtPower, true);
                    EnableParameter(txtDt, true);
                    EnableParameter(txtTotalTime, true);

                    break;


                case SimulationType.AirResistance:

                    EnableParameter(txtMass, true);
                    EnableParameter(txtVelocity, true);
                    EnableParameter(txtPower, true);
                    EnableParameter(txtDt, true);
                    EnableParameter(txtTotalTime, true);

                    EnableParameter(txtDrag, true);
                    EnableParameter(txtArea, true);
                    EnableParameter(txtDensity, true);

                    break;


                case SimulationType.Drafting:

                    EnableParameter(txtArea, true);
                    EnableParameter(txtDrag, true);
                    EnableParameter(txtVelocity, true);

                    break;


                case SimulationType.Uphill:

                    EnableParameter(txtMass, true);
                    EnableParameter(txtVelocity, true);
                    EnableParameter(txtPower, true);
                    EnableParameter(txtDt, true);
                    EnableParameter(txtTotalTime, true);

                    EnableParameter(txtDrag, true);
                    EnableParameter(txtArea, true);
                    EnableParameter(txtDensity, true);
                    EnableParameter(txtGrade, true);

                    break;


                case SimulationType.Downhill:

                    EnableParameter(txtMass, true);
                    EnableParameter(txtVelocity, true);
                    EnableParameter(txtPower, true);
                    EnableParameter(txtDt, true);
                    EnableParameter(txtTotalTime, true);

                    EnableParameter(txtDrag, true);
                    EnableParameter(txtArea, true);
                    EnableParameter(txtDensity, true);
                    EnableParameter(txtGrade, true);

                    break;


                case SimulationType.ConstantForce:

                    EnableParameter(txtMass, true);
                    EnableParameter(txtVelocity, true);
                    EnableParameter(txtPower, true);
                    EnableParameter(txtForce, true);
                    EnableParameter(txtCrossVelocity, true);

                    EnableParameter(txtDt, true);
                    EnableParameter(txtTotalTime, true);

                    break;
            }


            lblStatus.Text = currentSimulation.ToString();
        }



        private void EnableAllParameters(bool value)
        {
            txtMass.Enabled = value;
            txtVelocity.Enabled = value;
            txtPower.Enabled = value;
            txtDt.Enabled = value;
            txtTotalTime.Enabled = value;

            txtDrag.Enabled = value;
            txtArea.Enabled = value;
            txtDensity.Enabled = value;

            txtGrade.Enabled = value;

            txtForce.Enabled = value;
            txtCrossVelocity.Enabled = value;
        }



        private void EnableParameter(Control control, bool value)
        {
            control.Enabled = value;
        }



        private void CreateGraph()
        {
            bmp = new Bitmap(
                picGraph.Width,
                picGraph.Height);

            using (Graphics temp = Graphics.FromImage(bmp))
            {
                temp.Clear(Color.White);
            }

            picGraph.Image = bmp;

            g = Graphics.FromImage(bmp);
        }

        private void RunSimulation()
        {
            time.Clear();
            velocity.Clear();
            exactVelocity.Clear();

            switch (currentSimulation)
            {
                case SimulationType.NoAirResistance:
                    CalculateNoAirResistance();
                    break;

                case SimulationType.ExactCompare:
                    CalculateExactCompare();
                    break;

                case SimulationType.AirResistance:
                    CalculateAirResistance();
                    break;

                case SimulationType.Drafting:
                    CalculateDrafting();
                    break;

                case SimulationType.Uphill:
                    CalculateHill(true);
                    break;

                case SimulationType.Downhill:
                    CalculateHill(false);
                    break;

                case SimulationType.ConstantForce:
                    CalculateConstantForce();
                    break;
            }

            DrawGraph();
        }



        // Equation (2.7)
        // v(i+1)=v(i)+(P/(m*v(i)))dt

        private void CalculateNoAirResistance()
        {
            double mass = Convert.ToDouble(txtMass.Text);
            double v = Convert.ToDouble(txtVelocity.Text);
            double power = Convert.ToDouble(txtPower.Text);
            double dt = Convert.ToDouble(txtDt.Text);
            double total = Convert.ToDouble(txtTotalTime.Text);

            double t = 0;


            while (t <= total)
            {
                time.Add(t);
                velocity.Add(v);

                if (v > 0)
                    v = v + (power / (mass * v)) * dt;

                t += dt;
            }
        }




        // Exercise 1
        // Exact solution comparison

        private void CalculateExactCompare()
        {
            double mass = Convert.ToDouble(txtMass.Text);
            double v0 = Convert.ToDouble(txtVelocity.Text);
            double power = Convert.ToDouble(txtPower.Text);
            double dt = Convert.ToDouble(txtDt.Text);
            double total = Convert.ToDouble(txtTotalTime.Text);


            double v = v0;
            double t = 0;


            while (t <= total)
            {
                time.Add(t);


                velocity.Add(v);


                double exact = Math.Sqrt(
                    (v0 * v0) +
                    ((2 * power * t) / mass)
                );


                exactVelocity.Add(exact);



                if (v > 0)
                    v = v + (power / (mass * v)) * dt;


                t += dt;
            }
        }




        // Equation (2.10)
        //
        // v(i+1)=v(i)
        // +(P/(mv)-C rho A v^2/m)dt

        private void CalculateAirResistance()
        {
            double mass = Convert.ToDouble(txtMass.Text);
            double v = Convert.ToDouble(txtVelocity.Text);
            double power = Convert.ToDouble(txtPower.Text);

            double dt = Convert.ToDouble(txtDt.Text);
            double total = Convert.ToDouble(txtTotalTime.Text);

            double drag = Convert.ToDouble(txtDrag.Text);
            double area = Convert.ToDouble(txtArea.Text);
            double rho = Convert.ToDouble(txtDensity.Text);


            double t = 0;


            while (t <= total)
            {
                time.Add(t);
                velocity.Add(v);


                if (v > 0)
                {
                    double acceleration =
                    (power / (mass * v))
                    -
                    ((drag * rho * area * v * v) / mass);


                    v = v + acceleration * dt;

                    if (v < 0)
                        v = 0;
                }


                t += dt;
            }
        }

        // Exercise 2
        // Drafting effect
        // Effective frontal area reduced by 30%
        // Aeffective = 0.7A
        //
        // Calculates power required at the same velocity

        private void CalculateDrafting()
        {
            double area = Convert.ToDouble(txtArea.Text);
            double drag = Convert.ToDouble(txtDrag.Text);
            double v = Convert.ToDouble(txtVelocity.Text);


            double frontArea = area;
            double packArea = 0.7 * area;


            // Drag force
            double rho = Convert.ToDouble(txtDensity.Text);

            double frontForce = 0.5 * drag * rho * frontArea * v * v;

            double packForce = 0.5 * drag * rho * packArea * v * v;


            // Power needed to overcome air resistance
            double frontPower =
                frontForce * v;

            double packPower =
                packForce * v;


            // Store values for display
            // Time axis:
            // 0 = rider at front
            // 1 = rider in pack

            time.Add(0);
            velocity.Add(frontPower);


            time.Add(1);
            velocity.Add(packPower);


            double saving =
                ((frontPower - packPower) / frontPower) * 100;


            lblStatus.Text =
                "Front Power: "
                + frontPower.ToString("F2")
                + " W, Pack Power: "
                + packPower.ToString("F2")
                + " W, Saving: "
                + saving.ToString("F2")
                + "%";
        }




        // Exercise 3
        // Mountain terrain
        // Uphill: gravity opposes motion
        // Downhill: gravity assists motion

        private void CalculateHill(bool uphill)
        {
            double mass = Convert.ToDouble(txtMass.Text);
            double v = Convert.ToDouble(txtVelocity.Text);
            double power = Convert.ToDouble(txtPower.Text);

            double dt = Convert.ToDouble(txtDt.Text);
            double total = Convert.ToDouble(txtTotalTime.Text);

            double drag = Convert.ToDouble(txtDrag.Text);
            double area = Convert.ToDouble(txtArea.Text);
            double rho = Convert.ToDouble(txtDensity.Text);

            double grade = Convert.ToDouble(txtGrade.Text);


            double theta = Math.Atan(grade);

            double t = 0;


            while (t <= total)
            {
                time.Add(t);
                velocity.Add(v);


                if (v > 0)
                {
                    double acceleration =
                    (power / (mass * v))
                    -
                    ((drag * rho * area * v * v) / mass);



                    if (uphill)
                    {
                        acceleration =
                        acceleration -
                        Gravity * Math.Sin(theta);
                    }
                    else
                    {
                        acceleration =
                        acceleration +
                        Gravity * Math.Sin(theta);
                    }


                    v = v + acceleration * dt;

                    if (v < 0)
                        v = 0;
                }


                t += dt;
            }
        }




        // Exercise 4
        // Constant force at low velocity
        //
        // dv/dt=F0/m
        //
        // high velocity:
        // dv/dt=P/(mv)

        private void CalculateConstantForce()
        {
            double mass = Convert.ToDouble(txtMass.Text);

            double v = Convert.ToDouble(txtVelocity.Text);

            double force = Convert.ToDouble(txtForce.Text);

            double power = Convert.ToDouble(txtPower.Text);

            double cross = Convert.ToDouble(txtCrossVelocity.Text);


            double dt = Convert.ToDouble(txtDt.Text);

            double total = Convert.ToDouble(txtTotalTime.Text);



            double t = 0;


            while (t <= total)
            {
                time.Add(t);
                velocity.Add(v);


                if (v < cross)
                {
                    v = v + (force / mass) * dt;

                    if (v < 0)
                        v = 0;
                }
                else
                {
                    if (v > 0)
                    {
                        v = v +
                        (power / (mass * v)) * dt;

                        if (v < 0)
                            v = 0;
                    }
                }


                t += dt;
            }
        }

        private void DrawGraph()
        {
            if (bmp == null)
                CreateGraph();


            g.Clear(Color.White);


            if (time.Count < 2)
                return;


            double maxX = time[time.Count - 1];
            if (maxX == 0)
                maxX = 1;
            double maxY = 0;


            for (int i = 0; i < velocity.Count; i++)
            {
                if (velocity[i] > maxY)
                    maxY = velocity[i];
            }


            if (exactVelocity.Count > 0)
            {
                for (int i = 0; i < exactVelocity.Count; i++)
                {
                    if (exactVelocity[i] > maxY)
                        maxY = exactVelocity[i];
                }
            }


            if (maxY == 0)
                maxY = 1;



            int left = 70;
            int bottom = picGraph.Height - 60;
            int top = 40;
            int right = picGraph.Width - 40;



            Pen axisPen = new Pen(Color.Black, 2);


            g.DrawLine(axisPen, left, bottom, right, bottom);
            g.DrawLine(axisPen, left, bottom, left, top);



            Font font = new Font("Arial", 10);



            if (currentSimulation == SimulationType.Drafting)
            {
                g.DrawString(
                "Rider Type",
                font,
                Brushes.Black,
                right - 60,
                bottom + 20);
            }
            else
            {
                g.DrawString(
                "Time (s)",
                font,
                Brushes.Black,
                right - 60,
                bottom + 20);
            }



            if (currentSimulation == SimulationType.Drafting)
            {
                g.DrawString(
                    "Power Required (W)",
                    font,
                    Brushes.Black,
                    5,
                    top);
            }
            else
            {
                g.DrawString(
                    "Velocity (m/s)",
                    font,
                    Brushes.Black,
                    5,
                    top);
            }



            Pen curvePen = new Pen(Color.Blue, 2);



            for (int i = 0; i < velocity.Count - 1; i++)
            {
                float x1;
                float x2;

                if (currentSimulation == SimulationType.Drafting)
                {
                    x1 = left + (float)(time[i] * (right - left));
                }
                else
                {
                    x1 =
                    left +
                    (float)(time[i] / maxX) * (right - left);
                }

                if (currentSimulation == SimulationType.Drafting)
                {
                    x2 = left + (float)(time[i+1] * (right - left));
                }
                else
                {
                    x2 =
                    left +
                    (float)(time[i+1] / maxX) * (right - left);
                }
         

                float y1 =
                bottom -
                (float)(velocity[i] / maxY) * (bottom - top);


                float y2 =
                bottom -
                (float)(velocity[i + 1] / maxY) * (bottom - top);



                g.DrawLine(curvePen, x1, y1, x2, y2);
            }



            // Exact solution curve

            if (exactVelocity.Count > 0)
            {
                Pen exactPen = new Pen(Color.Red, 2);


                for (int i = 0; i < exactVelocity.Count - 1; i++)
                {
                    float x1 =
                    left +
                    (float)(time[i] / maxX) * (right - left);


                    float x2 =
                    left +
                    (float)(time[i + 1] / maxX) * (right - left);



                    float y1 =
                    bottom -
                    (float)(exactVelocity[i] / maxY) * (bottom - top);


                    float y2 =
                    bottom -
                    (float)(exactVelocity[i + 1] / maxY) * (bottom - top);



                    g.DrawLine(exactPen, x1, y1, x2, y2);
                }
            }



            picGraph.Refresh();
        }





        private void btnClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            picGraph.Refresh();

            time.Clear();
            velocity.Clear();
            exactVelocity.Clear();

            lblStatus.Text = "Graph Cleared";
        }




        private void btnReset_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            LoadDefaultValues();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (bmp == null)
            {
                MessageBox.Show("No graph available.");
                return;
            }

            string desktop = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);

            string fileName = currentSimulation.ToString()
                              + "_Graph.png";

            string path = Path.Combine(desktop, fileName);

            try
            {
                using (Bitmap copy = new Bitmap(bmp))
                {
                    copy.Save(path, ImageFormat.Png);
                }

                lblStatus.Text = "Saved: " + fileName;
                MessageBox.Show(
                    "Graph saved on Desktop:\n" + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            if (time.Count == 0)
            {
                MessageBox.Show("Run simulation first.");
                return;
            }


            string desktop = Environment.GetFolderPath(
                Environment.SpecialFolder.Desktop);


            string fileName = currentSimulation.ToString()
                              + "_Data.csv";


            string path = Path.Combine(desktop, fileName);


            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {

                    if (currentSimulation == SimulationType.ExactCompare)
                    {
                        writer.WriteLine(
                            "Time,Numerical Velocity,Exact Velocity");


                        for (int i = 0; i < time.Count; i++)
                        {
                            writer.WriteLine(
                                time[i] + "," +
                                velocity[i] + "," +
                                exactVelocity[i]);
                        }
                    }


                    else if (currentSimulation == SimulationType.Drafting)
                    {
                        writer.WriteLine("Rider,Power");

                        writer.WriteLine(
                            "Front," + velocity[0]);

                        writer.WriteLine(
                            "Pack," + velocity[1]);
                    }


                    else
                    {
                        writer.WriteLine(
                            "Time,Velocity");


                        for (int i = 0; i < time.Count; i++)
                        {
                            writer.WriteLine(
                                time[i] + "," +
                                velocity[i]);
                        }
                    }
                }


                lblStatus.Text = "CSV Saved: " + fileName;

                MessageBox.Show(
                    "CSV saved on Desktop:\n" + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}