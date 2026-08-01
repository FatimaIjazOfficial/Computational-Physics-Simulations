using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Billiard_Ball_Simulation
{
    public partial class Form1 : Form
    {
        private Bitmap graphBitmap;

        private List<BilliardBall> balls =
            new List<BilliardBall>();

        private Timer simulationTimer =
            new Timer();

        private const double tableLeft = 100;
        private const double tableTop = 100;
        private const double tableWidth = 800;
        private const double tableHeight = 400;

        private Random random = new Random();

        private double movementStep = 2;

        private bool showPattern = true;


        public Form1()
        {
            InitializeComponent();

            graphPanel.Paint += GraphPanel_Paint;

            btnRun.Click += BtnRun_Click;
            btnAddBall.Click += BtnAddBall_Click;
            btnClear.Click += BtnClear_Click;

            chkPattern.CheckedChanged += chkPattern_CheckedChanged;
            btnSaveImage.Click += BtnSaveImage_Click;
            btnExportCSV.Click += BtnExportCSV_Click;

            trackSpeed.ValueChanged += TrackSpeed_ValueChanged;

            simulationTimer.Interval = 20;
            simulationTimer.Tick += SimulationTimer_Tick;

            Load += Form1_Load;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            graphBitmap =
                new Bitmap(
                    graphPanel.Width,
                    graphPanel.Height);

            UpdateBallHistory();
        }




        private void TrackSpeed_ValueChanged(
            object sender,
            EventArgs e)
        {
            movementStep =
                trackSpeed.Value * 0.5;
        }





        private void BtnAddBall_Click(
            object sender,
            EventArgs e)
        {

            int number =
                balls.Count + 1;



            BilliardBall ball =
                new BilliardBall();



            ball.Name =
                "Ball " + number;



            ball.X =
                random.Next(
                (int)tableLeft + 20,
                (int)(tableLeft + tableWidth - 20));



            ball.Y =
                random.Next(
                (int)tableTop + 20,
                (int)(tableTop + tableHeight - 20));



            ball.Vx =
                random.Next(-5, 6);



            ball.Vy =
                random.Next(-5, 6);



            if (ball.Vx == 0)
                ball.Vx = 1;


            if (ball.Vy == 0)
                ball.Vy = 1;



            ball.Path =
                new List<PointF>();



            ball.MaxSteps =
                random.Next(700, 1500);



            ball.CurrentSteps = 0;



            ball.Active = true;



            balls.Add(ball);



            UpdateBallHistory();


            graphPanel.Invalidate();

        }





        private void BtnRun_Click(
            object sender,
            EventArgs e)
        {

            foreach (BilliardBall ball in balls)
            {
                ball.Path.Clear();
                ball.CurrentSteps = 0;
                ball.Active = true;
            }


            simulationTimer.Start();

        }






        private void SimulationTimer_Tick(
            object sender,
            EventArgs e)
        {


            int movingBalls = 0;



            foreach (BilliardBall ball in balls)
            {


                if (!ball.Active)
                    continue;



                movingBalls++;



                ball.X +=
                    ball.Vx *
                    movementStep;



                ball.Y +=
                    ball.Vy *
                    movementStep;




                if (ball.X <= tableLeft)
                {
                    ball.X = tableLeft;
                    ball.Vx = Math.Abs(ball.Vx);
                }



                if (ball.X >= tableLeft + tableWidth)
                {
                    ball.X =
                        tableLeft + tableWidth;

                    ball.Vx =
                        -Math.Abs(ball.Vx);
                }




                if (ball.Y <= tableTop)
                {
                    ball.Y = tableTop;
                    ball.Vy = Math.Abs(ball.Vy);
                }




                if (ball.Y >= tableTop + tableHeight)
                {
                    ball.Y =
                        tableTop + tableHeight;

                    ball.Vy =
                        -Math.Abs(ball.Vy);
                }




                if (showPattern)
                {
                    ball.Path.Add(
    new PointF(
        (float)ball.X,
        (float)ball.Y));

                    if (ball.Path.Count > 2500)
                    {
                        ball.Path.RemoveAt(0);
                    }
                }



                ball.CurrentSteps++;



                if (ball.CurrentSteps >= ball.MaxSteps)
                {
                    ball.Active = false;
                }

            }




            if (movingBalls == 0)
            {
                simulationTimer.Stop();
                statusLabel.Text = "Simulation Finished";
            }
            else
            {
                statusLabel.Text =
                    "Moving Balls : " + movingBalls;
            }



            UpdateBallHistory();


            graphPanel.Invalidate();

        }






        private void chkPattern_CheckedChanged(
     object sender,
     EventArgs e)
        {
            showPattern = chkPattern.Checked;

            if (!showPattern)
            {
                foreach (BilliardBall ball in balls)
                    ball.Path.Clear();
            }

            graphPanel.Invalidate();
        }





        private void UpdateBallHistory()
        {

            lblInfo.Text =
                "BILLIARD BALL SIMULATION\r\n\r\n" +
                "TOTAL BALLS : " +
                balls.Count +
                "\r\n\r\n";




            foreach (BilliardBall ball in balls)
            {

                lblInfo.Text +=
                    ball.Name +
                    "\r\nPosition : (" +
                    ball.X.ToString("F1") +
                    "," +
                    ball.Y.ToString("F1") +
                    ")" +
                    "\r\nVelocity : (" +
                    ball.Vx.ToString("F1") +
                    "," +
                    ball.Vy.ToString("F1") +
                    ")" +
                    "\r\nSteps : " +
                    ball.CurrentSteps +
                    "/" +
                    ball.MaxSteps +
                    "\r\nStatus : " +
                    (ball.Active ? "Moving" : "Stopped") +
                    "\r\n\r\n";

            }
            lblInfo.Height = lblInfo.PreferredHeight;
        }





        private void BtnSaveImage_Click(
    object sender,
    EventArgs e)
        {

            string fileName =
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Billiard_Table.png");

            using (Bitmap bmp =
                new Bitmap(graphPanel.Width, graphPanel.Height))
            {
                graphPanel.DrawToBitmap(
                    bmp,
                    new Rectangle(0, 0, bmp.Width, bmp.Height));

                bmp.Save(fileName);
            }

            MessageBox.Show(
                "Image saved to Desktop.");
        }



        private void BtnExportCSV_Click(
            object sender,
            EventArgs e)
        {

            string fileName =
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "Billiard_Balls_Data.csv");

            StringBuilder csv =
                new StringBuilder();

            csv.AppendLine(
                "Ball,X,Y,Vx,Vy,CurrentSteps,MaxSteps,Status");

            foreach (BilliardBall ball in balls)
            {

                csv.AppendLine(
                    ball.Name + "," +
                    ball.X.ToString("F2") + "," +
                    ball.Y.ToString("F2") + "," +
                    ball.Vx.ToString("F2") + "," +
                    ball.Vy.ToString("F2") + "," +
                    ball.CurrentSteps + "," +
                    ball.MaxSteps + "," +
                    (ball.Active ? "Moving" : "Stopped"));

            }

            File.WriteAllText(
                fileName,
                csv.ToString());

            MessageBox.Show(
                "CSV exported to Desktop.");
        }



        private void BtnClear_Click(
            object sender,
            EventArgs e)
        {

            simulationTimer.Stop();

            balls.Clear();

            graphBitmap?.Dispose();

            graphBitmap = new Bitmap(
                graphPanel.Width,
                graphPanel.Height);

            statusLabel.Text = "Ready";

            UpdateBallHistory();

            graphPanel.Invalidate();

        }






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



                using (Pen tablePen =
                    new Pen(Color.Green, 8))
                {

                    g.DrawRectangle(
                        tablePen,
                        (float)tableLeft,
                        (float)tableTop,
                        (float)tableWidth,
                        (float)tableHeight);

                }




                Color[] colors =
                {
                    Color.Blue,
                    Color.Red,
                    Color.Purple,
                    Color.Orange,
                    Color.Brown,
                    Color.Black
                };



                int index = 0;



                foreach (BilliardBall ball in balls)
                {


                    if (showPattern &&
                       ball.Path.Count > 1)
                    {

                        using (Pen p =
                            new Pen(
                            colors[index % colors.Length],
                            2))
                        {

                            g.DrawLines(
                                p,
                                ball.Path.ToArray());

                        }

                    }




                    using (Brush brush =
                        new SolidBrush(
                        colors[index % colors.Length]))
                    {

                        g.FillEllipse(
                            brush,
                            (float)ball.X - 8,
                            (float)ball.Y - 8,
                            16,
                            16);

                    }



                    index++;

                }

            }




            e.Graphics.DrawImage(
                graphBitmap,
                0,
                0);

        }

    }




    public class BilliardBall
    {

        public string Name;

        public double X;

        public double Y;

        public double Vx;

        public double Vy;

        public List<PointF> Path;

        public int MaxSteps;

        public int CurrentSteps;

        public bool Active;

    }

}