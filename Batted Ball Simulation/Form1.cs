using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Batted_Ball_Simulation
{
    public partial class Form1 : Form
    {

        // ==========================
        // Simulation Data
        // ==========================

        private Bitmap graphBitmap;

        private List<TrajectoryPoint> allPoints =
            new List<TrajectoryPoint>();

        private double maxX = 1;
        private double maxY = 1;

        private int trajectoryCount = 0;

        private string currentModel = "Batted Ball";



        // Default Parameters

        private const double defaultV = 700;
        private const double defaultG = 9.8;
        private const double defaultDt = 0.1;

        private const double defaultDel = 5;
        private const double defaultVd = 35;

        private const double defaultY0 = 10000;

        private const double defaultT = 288.15;
        private const double defaultA = 0.0065;
        private const double defaultAlpha = 2.5;




        // ==========================
        // Constructor
        // ==========================

        public Form1()
        {

            InitializeComponent();


            graphPanel.Paint += GraphPanel_Paint;


            btnRun.Click += BtnRun_Click;

            btnClear.Click += BtnClear_Click;

            btnReset.Click += BtnReset_Click;

            btnSaveImage.Click += BtnSaveImage_Click;

            btnExportCSV.Click += BtnExportCSV_Click;


            cmbModel.SelectedIndexChanged +=
                CmbModel_SelectedIndexChanged;



            this.Load += Form1_Load;

        }





        private void Form1_Load(object sender, EventArgs e)
        {

            graphBitmap =
                new Bitmap(
                    graphPanel.Width,
                    graphPanel.Height);



            UpdateParameterState();

        }






        // ==========================
        // Model Selection
        // ==========================


        private void CmbModel_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {

            currentModel =
                cmbModel.SelectedItem.ToString();


            UpdateParameterState();

        }





        private void UpdateParameterState()
        {


            bool isothermal =
                currentModel == "Isothermal";


            bool adiabatic =
                currentModel == "Adiabatic";



            txtVelocity.Enabled = true;

            txtGravity.Enabled = true;

            txtTimeStep.Enabled = true;


            txtDel.Enabled = true;

            txtVd.Enabled = true;



            txtY0.Enabled =
                isothermal;



            txtTemperature.Enabled =
                adiabatic;


            txtGradient.Enabled =
                adiabatic;


            txtAlpha.Enabled =
                adiabatic;

        }





        // ==========================
        // Run Button
        // ==========================


        private void BtnRun_Click(
            object sender,
            EventArgs e)
        {

            statusLabel.Text =
                "Simulation Running...";



            RunSimulation();



            graphPanel.Invalidate();



            statusLabel.Text =
                "Simulation Completed" +
                " | Trajectories: " +
                trajectoryCount +
                " | Max Height: " +
                maxY.ToString("F2") +
                " | Max Range: " +
                maxX.ToString("F2");

        }





        // ==========================
        // Clear Graph
        // ==========================


        private void BtnClear_Click(
            object sender,
            EventArgs e)
        {

            allPoints.Clear();


            maxX = 1;

            maxY = 1;


            trajectoryCount = 0;


            graphPanel.Invalidate();


            statusLabel.Text =
                "Graph Cleared";

        }






        // ==========================
        // Read Parameters
        // ==========================


        private double ReadDouble(TextBox box)
        {

            double value;


            if (double.TryParse(
                box.Text,
                out value))
            {
                return value;
            }


            return 0;

        }





        // ==========================
        // Angle Parser
        // ==========================


        private List<double> GetAngles()
        {

            List<double> angles =
                new List<double>();


            string input =
                txtAngle.Text.Trim();



            if (input.Contains("-"))
            {

                string[] range =
                    input.Split('-');


                double start =
                    Convert.ToDouble(range[0]);


                double end =
                    Convert.ToDouble(range[1]);



                for (double a = start;
                    a < end;
                    a += 5)
                {

                    angles.Add(a);

                }

            }


            else if (input.Contains(","))
            {

                string[] values =
                    input.Split(',');


                foreach (string value in values)
                {

                    angles.Add(
                        Convert.ToDouble(value));

                }

            }


            else
            {

                angles.Add(
                    Convert.ToDouble(input));

            }


            return angles;

        }






        // ==========================
        // Data Class
        // ==========================


        private class TrajectoryPoint
        {

            public double Angle;

            public double Time;

            public double X;

            public double Y;

            public double Vx;

            public double Vy;

            public double Velocity;

        }

        // ==========================
        // Simulation Calculations
        // ==========================


        private void RunSimulation()
        {

            allPoints.Clear();


            maxX = 1;

            maxY = 1;


            trajectoryCount = 0;



            double V =
                ReadDouble(txtVelocity);


            double g =
                ReadDouble(txtGravity);


            double dt =
                ReadDouble(txtTimeStep);


            double del =
                ReadDouble(txtDel);


            double vd =
                ReadDouble(txtVd);



            double y0 =
                ReadDouble(txtY0);


            double T =
                ReadDouble(txtTemperature);


            double a =
                ReadDouble(txtGradient);


            double alpha =
                ReadDouble(txtAlpha);




            List<double> angles =
                GetAngles();




            foreach (double angle in angles)
            {

                List<TrajectoryPoint> result;



                if (currentModel == "Batted Ball")
                {

                    result =
                        SimulateNormal(
                            angle,
                            V,
                            g,
                            dt,
                            del,
                            vd);

                }


                else if (currentModel == "Isothermal")
                {

                    result =
                        SimulateIsothermal(
                            angle,
                            V,
                            g,
                            dt,
                            del,
                            vd,
                            y0);

                }


                else
                {

                    result =
                        SimulateAdiabatic(
                            angle,
                            V,
                            g,
                            dt,
                            del,
                            vd,
                            T,
                            a,
                            alpha);

                }




                foreach (TrajectoryPoint p in result)
                {

                    allPoints.Add(p);



                    if (p.X > maxX)
                        maxX = p.X;



                    if (p.Y > maxY)
                        maxY = p.Y;

                }



                trajectoryCount++;

            }

        }







        // ==========================
        // Normal Batted Ball
        // ==========================


        private List<TrajectoryPoint>
            SimulateNormal(
            double angle,
            double V0,
            double g,
            double dt,
            double del,
            double vd)
        {


            List<TrajectoryPoint> data =
                new List<TrajectoryPoint>();



            double rad =
                angle * Math.PI / 180;



            double x = 0;

            double y = 0;



            double Vx =
                V0 * Math.Cos(rad);


            double Vy =
                V0 * Math.Sin(rad);



            double time = 0;



            while (y >= 0)
            {


                double V =
                    Math.Sqrt(
                    Vx * Vx +
                    Vy * Vy);



                data.Add(
                    new TrajectoryPoint()
                    {

                        Angle = angle,

                        Time = time,

                        X = x,

                        Y = y,

                        Vx = Vx,

                        Vy = Vy,

                        Velocity = V

                    });





                double bm =
                    0.0039 +
                    0.0058 /
                    (1 +
                    Math.Exp(
                    (V - vd) / del));





                Vx =
                    Vx -
                    bm *
                    V *
                    Vx *
                    dt;




                Vy =
                    Vy -
                    g *
                    dt -
                    bm *
                    V *
                    Vy *
                    dt;





                x =
                    x +
                    Vx *
                    dt;



                y =
                    y +
                    Vy *
                    dt;




                time += dt;



                if (data.Count > 20000)
                    break;


            }



            return data;

        }







        // ==========================
        // Isothermal Atmosphere
        // ==========================


        private List<TrajectoryPoint>
            SimulateIsothermal(
            double angle,
            double V0,
            double g,
            double dt,
            double del,
            double vd,
            double y0)
        {


            List<TrajectoryPoint> data =
                new List<TrajectoryPoint>();


            double rad =
                angle * Math.PI / 180;



            double x = 0;

            double y = 0;



            double Vx =
                V0 * Math.Cos(rad);


            double Vy =
                V0 * Math.Sin(rad);



            double time = 0;



            while (y >= 0)
            {


                double V =
                    Math.Sqrt(
                    Vx * Vx +
                    Vy * Vy);



                double density =
                    Math.Exp(
                    -y / y0);




                double bm =
                    0.0039 +
                    0.0058 /
                    (1 +
                    Math.Exp(
                    (V - vd) / del));





                data.Add(
                    new TrajectoryPoint()
                    {

                        Angle = angle,

                        Time = time,

                        X = x,

                        Y = y,

                        Vx = Vx,

                        Vy = Vy,

                        Velocity = V

                    });





                Vx -=
                    bm *
                    density *
                    V *
                    Vx *
                    dt;




                Vy -=
                    g *
                    dt +
                    bm *
                    density *
                    V *
                    Vy *
                    dt;




                x +=
                    Vx *
                    dt;


                y +=
                    Vy *
                    dt;



                time += dt;




                if (data.Count > 20000)
                    break;


            }



            return data;


        }

        // ==========================
        // Adiabatic Atmosphere
        // ==========================


        private List<TrajectoryPoint>
            SimulateAdiabatic(
            double angle,
            double V0,
            double g,
            double dt,
            double del,
            double vd,
            double T,
            double a,
            double alpha)
        {


            List<TrajectoryPoint> data =
                new List<TrajectoryPoint>();



            double rad =
                angle * Math.PI / 180;



            double x = 0;

            double y = 0;



            double Vx =
                V0 * Math.Cos(rad);



            double Vy =
                V0 * Math.Sin(rad);



            double time = 0;



            while (y >= 0)
            {


                double V =
                    Math.Sqrt(
                    Vx * Vx +
                    Vy * Vy);




                double baseDensity =
                    1 -
                    (a * y / T);



                double density;



                if (baseDensity > 0)
                {

                    density =
                        Math.Pow(
                        baseDensity,
                        alpha);

                }
                else
                {

                    density = 0;

                }






                double bm =
                    0.0039 +
                    0.0058 /
                    (1 +
                    Math.Exp(
                    (V - vd) / del));






                data.Add(
                    new TrajectoryPoint()
                    {

                        Angle = angle,

                        Time = time,

                        X = x,

                        Y = y,

                        Vx = Vx,

                        Vy = Vy,

                        Velocity = V

                    });






                Vx -=
                    bm *
                    density *
                    V *
                    Vx *
                    dt;




                Vy -=
                    g *
                    dt +
                    bm *
                    density *
                    V *
                    Vy *
                    dt;





                x +=
                    Vx *
                    dt;



                y +=
                    Vy *
                    dt;



                time += dt;




                if (data.Count > 20000)
                    break;


            }



            return data;


        }








        // ==========================
        // Drawing System
        // ==========================


        private void GraphPanel_Paint(
            object sender,
            PaintEventArgs e)
        {



            if (graphBitmap == null ||
               graphBitmap.Width != graphPanel.Width ||
               graphBitmap.Height != graphPanel.Height)
            {

                graphBitmap =
                    new Bitmap(
                    graphPanel.Width,
                    graphPanel.Height);

            }






            using (Graphics g =
                Graphics.FromImage(graphBitmap))
            {


                g.Clear(Color.White);



                DrawAxis(g);



                DrawTrajectories(g);



            }




            e.Graphics.DrawImage(
                graphBitmap,
                0,
                0);


        }








        private void DrawAxis(Graphics g)
        {


            Pen axis =
                new Pen(
                Color.Black,
                2);




            float xAxis =
                40;



            float yAxis =
                graphPanel.Height - 40;





            g.DrawLine(
                axis,
                40,
                yAxis,
                graphPanel.Width - 20,
                yAxis);





            g.DrawLine(
                axis,
                xAxis,
                20,
                xAxis,
                graphPanel.Height - 40);






            g.DrawString(
                "X Distance",
                Font,
                Brushes.Black,
                graphPanel.Width - 120,
                yAxis + 5);




            g.DrawString(
                "Y Height",
                Font,
                Brushes.Black,
                xAxis + 5,
                20);


        }








        private void DrawTrajectories(
            Graphics g)
        {


            if (allPoints.Count == 0)
                return;





            double scaleX =
                (graphPanel.Width - 80)
                /
                maxX;




            double scaleY =
                (graphPanel.Height - 80)
                /
                maxY;





            double scale =
                Math.Min(
                scaleX,
                scaleY);





            Dictionary<double, List<PointF>>
                curves =
                new Dictionary<double, List<PointF>>();





            foreach (TrajectoryPoint p
                in allPoints)
            {



                if (!curves.ContainsKey(p.Angle))
                {

                    curves.Add(
                        p.Angle,
                        new List<PointF>());

                }




                float px =
                    (float)(
                    40 +
                    p.X *
                    scale);





                float py =
                    (float)(
                    graphPanel.Height - 40 -
                    p.Y *
                    scale);





                curves[p.Angle].Add(
                    new PointF(
                    px,
                    py));

            }







            Color[] colors =
            {

                Color.Blue,

                Color.Red,

                Color.Green,

                Color.Purple,

                Color.Orange,

                Color.Brown

            };




            int index = 0;



            foreach (var curve in curves)
            {


                if (curve.Value.Count < 2)
                    continue;




                using (Pen pen =
                    new Pen(
                    colors[index %
                    colors.Length],
                    2))
                {


                    g.DrawLines(
                        pen,
                        curve.Value.ToArray());


                }


                index++;

            }


        }

        // ==========================
        // Save Graph Image
        // ==========================


        private void BtnSaveImage_Click(
            object sender,
            EventArgs e)
        {


            if (graphBitmap == null)
            {

                statusLabel.Text =
                    "No graph available";

                return;

            }



            string folder =
                Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments);




            string fileName =
                "BattedBall_" +
                currentModel.Replace(" ", "_") +
                "_" +
                DateTime.Now.ToString(
                "yyyyMMdd_HHmmss") +
                ".png";




            string path =
                Path.Combine(
                folder,
                fileName);




            graphBitmap.Save(
                path,
                ImageFormat.Png);




            statusLabel.Text =
                "Saved Image Successfully";

        }








        // ==========================
        // Export CSV
        // ==========================


        private void BtnExportCSV_Click(
            object sender,
            EventArgs e)
        {


            if (allPoints.Count == 0)
            {

                statusLabel.Text =
                    "No simulation data";

                return;

            }




            StringBuilder csv =
                new StringBuilder();




            csv.AppendLine(
                "Angle,Time,X,Y,Vx,Vy,Velocity");





            foreach (TrajectoryPoint p
                in allPoints)
            {


                csv.AppendLine(

                    p.Angle + "," +

                    p.Time + "," +

                    p.X + "," +

                    p.Y + "," +

                    p.Vx + "," +

                    p.Vy + "," +

                    p.Velocity

                );


            }







            string folder =
                Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments);





            string fileName =
                "BattedBall_" +
                currentModel.Replace(" ", "_") +
                "_" +
                DateTime.Now.ToString(
                "yyyyMMdd_HHmmss") +
                ".csv";




            File.WriteAllText(
                Path.Combine(
                folder,
                fileName),
                csv.ToString());





            statusLabel.Text =
                "CSV Export Completed";

        }








        // ==========================
        // Reset Parameters
        // ==========================


        private void BtnReset_Click(
            object sender,
            EventArgs e)
        {


            txtVelocity.Text =
                defaultV.ToString();



            txtGravity.Text =
                defaultG.ToString();



            txtTimeStep.Text =
                defaultDt.ToString();



            txtDel.Text =
                defaultDel.ToString();



            txtVd.Text =
                defaultVd.ToString();



            txtY0.Text =
                defaultY0.ToString();




            txtTemperature.Text =
                defaultT.ToString();



            txtGradient.Text =
                defaultA.ToString();



            txtAlpha.Text =
                defaultAlpha.ToString();




            txtAngle.Text =
                "35-60";




            cmbModel.SelectedIndex =
                0;




            UpdateParameterState();




            statusLabel.Text =
                "Parameters Reset";


        }








        // ==========================
        // Resize Handling
        // ==========================


        protected override void OnResize(
            EventArgs e)
        {

            base.OnResize(e);



            if (graphPanel.Width > 0 &&
               graphPanel.Height > 0)
            {


                graphBitmap =
                    new Bitmap(
                    graphPanel.Width,
                    graphPanel.Height);



                graphPanel.Invalidate();

            }
        }
    }
}

