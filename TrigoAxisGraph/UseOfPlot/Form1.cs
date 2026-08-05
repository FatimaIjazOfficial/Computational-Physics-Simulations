using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UseOfPlot
{
    public partial class Form1 : Form
    {
        private const double Pi = Math.PI;

        private readonly List<GraphPlot> plots = new List<GraphPlot>();

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            this.Paint += Form1_Paint;
        }

        private enum FunctionType
        {
            Sin,
            Cos,
            Tan,
            SinCos,
            CosSec,
            TanCot,
            Csc,
            Sec,
            Cot,

            Asin,
            Acos,
            Atan,

            Acsc,
            Asec,
            Acot,

            Sinh,
            Cosh,
            Tanh,

            Csch,
            Sech,
            Coth
        }

        private class GraphArea
        {
            public Rectangle Bounds;

            public GraphArea(Rectangle rectangle)
            {
                Bounds = rectangle;
            }

            public int Left => Bounds.Left;
            public int Right => Bounds.Right;
            public int Top => Bounds.Top;
            public int Bottom => Bounds.Bottom;

            public int Width => Bounds.Width;
            public int Height => Bounds.Height;

            public Point Center =>
                new Point(
                    Bounds.Left + Bounds.Width / 2,
                    Bounds.Top + Bounds.Height / 2
                );
        }

        private class GraphPlot
        {
            public Func<double, double> Function;
            public string Title;
            public Color Color;

            public double XMin;
            public double XMax;

            public double YMin;
            public double YMax;

            public GraphPlot(
                Func<double, double> function,
                string title,
                Color color,
                double xmin,
                double xmax,
                double ymin,
                double ymax)
            {
                Function = function;
                Title = title;
                Color = color;

                XMin = xmin;
                XMax = xmax;

                YMin = ymin;
                YMax = ymax;
            }
        }


        // ============================
        // BUTTON EVENTS
        // ============================

        private void button1_Click(object sender, EventArgs e)
        {
            AddGraph(
                Math.Sin,
                "sin(x)",
                Color.Purple,
                -2 * Pi,
                2 * Pi,
                -1.2,
    1.2);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AddGraph(
                Math.Cos,
                "cos(x)",
                Color.Green,
                -2 * Pi,
                2 * Pi,
                -1.2,
    1.2);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            AddGraph(
                x => Math.Tan(x),
                "tan(x)",
                Color.Blue,
                -2 * Pi,
                2 * Pi,
                -5,5);
        }


        private void button4_Click(object sender, EventArgs e)
        {
            AddGraph(
                Math.Asin,
                "asin(x)",
                Color.Red,
                -1,
                1,-2,2);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            AddGraph(
                Math.Acos,
                "acos(x)",
                Color.Orange,
                -1,
                1,-2,4);
        }


        private void button6_Click(object sender, EventArgs e)
        {
            AddGraph(
                Math.Atan,
                "atan(x)",
                Color.Black,
                -10,
                10,-2,2);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            AddGraph(
                Math.Sinh,
                "sinh(x)",
                Color.Brown,
                -5,
                5,-80,80);
        }


        private void button8_Click(object sender, EventArgs e)
        {
            AddGraph(
                Math.Cosh,
                "cosh(x)",
                Color.Aqua,
                -5,
                5,0,80);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            AddGraph(
                Math.Tanh,
                "tanh(x)",
                Color.DarkGreen,
                -5,
                5, -1.2,
1.2);
        }


        private void button10_Click(object sender, EventArgs e)
        {
            AddGraph(
                x =>
                {
                    if (Math.Abs(Math.Sin(x)) < 1e-10)
                        return double.NaN;

                    return 1.0 / Math.Sin(x);
                },
                "csc(x)",
                Color.Purple,
                -2 * Pi,
                2 * Pi, -5,
5);
        }


        private void button11_Click(object sender, EventArgs e)
        {
            AddGraph(
                x =>
                {
                    if (Math.Abs(Math.Cos(x)) < 1e-10)
                        return double.NaN;

                    return 1.0 / Math.Cos(x);
                },
                "sec(x)",
                Color.Green,
                -2 * Pi,
                2 * Pi, -5,
5);
        }


        private void button12_Click(object sender, EventArgs e)
        {
            AddGraph(
                x =>
                {
                    if (Math.Abs(Math.Sin(x)) < 1e-10)
                        return double.NaN;

                    return Math.Cos(x) / Math.Sin(x);
                },
                "cot(x)",
                Color.Blue,
                -2 * Pi,
                2 * Pi, -5,
5);
        }


        private void button13_Click(object sender, EventArgs e)
        {
            AddGraph(
                x =>
                {
                    if (Math.Abs(x) < 1e-10)
                        return Pi / 2;

                    if (x > 0)
                        return Math.Atan(1.0 / x);

                    return Math.Atan(1.0 / x) + Pi;
                },
                "acot(x)",
                Color.Black,
                -10,
                10, 0,
Pi);
        }


        private void button14_Click(object sender, EventArgs e)
        {
            AddGraph(
                x =>
                {
                    if (Math.Abs(x) < 1)
                        return double.NaN;

                    return Math.Acos(1 / x);
                },
                "asec(x)",
                Color.Orange,
                -10,
                10, 0,
Pi);
        }


        private void button15_Click(object sender, EventArgs e)
        {
            AddGraph(
                x =>
                {
                    if (Math.Abs(x) < 1)
                        return double.NaN;

                    return Math.Asin(1 / x);
                },
                "acsc(x)",
                Color.Red,
                -10,
                10, -Pi / 2,
Pi / 2);
        }


        private void button16_Click(object sender, EventArgs e)
        {
            AddGraph(
                x =>
                {
                    if (Math.Abs(Math.Sinh(x)) < 1e-10)
                        return double.NaN;

                    return 1 / Math.Sinh(x);
                },
                "csch(x)",
                Color.Brown,
                -5,
                5, -5,
5);
        }


        private void button17_Click(object sender, EventArgs e)
        {
            AddGraph(
                x => 1 / Math.Cosh(x),
                "sech(x)",
                Color.Aqua,
                -5,
                5, 0,
1.2);
        }


        private void button18_Click(object sender, EventArgs e)
        {
            AddGraph(
                x =>
                {
                    if (Math.Abs(Math.Tanh(x)) < 1e-10)
                        return double.NaN;

                    return 1 / Math.Tanh(x);
                },
                "coth(x)",
                Color.DarkGreen,
                -5,
                5, -5,
5);
        }


        private void button20_Click(object sender, EventArgs e)
        {
            plots.Clear();
            Refresh();
        }


        // ============================
        // GRAPH MANAGEMENT
        // ============================

        private void AddGraph(
    Func<double, double> function,
    string title,
    Color color,
    double xmin,
    double xmax,
    double ymin,
    double ymax)
        {
            plots.Clear();

            plots.Add(
               new GraphPlot(
    function,
    title,
    color,
    xmin,
    xmax,
    ymin,
    ymax));

            Refresh();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (plots.Count == 0)
                return;

            List<GraphArea> areas =
                CreateGraphAreas(
                    plots.Count,
                    ClientSize.Width,
                    ClientSize.Height);

            for (int i = 0; i < plots.Count; i++)
            {
                DrawGraph(
                    e.Graphics,
                    areas[i],
                    plots[i]);
            }
        }


        private List<GraphArea> CreateGraphAreas(
            int count,
            int width,
            int height)
        {
            List<GraphArea> areas =
                new List<GraphArea>();

            int margin = 25;
            int spacing = 20;

            int columns =
                (int)Math.Ceiling(Math.Sqrt(count));

            int rows =
                (int)Math.Ceiling((double)count / columns);


            int areaWidth =
                (width -
                (2 * margin) -
                ((columns - 1) * spacing))
                / columns;


            int areaHeight =
                (height -
                (2 * margin) -
                ((rows - 1) * spacing))
                / rows;


            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    if (areas.Count >= count)
                        break;


                    Rectangle rect =
                        new Rectangle(
                            margin +
                            c * (areaWidth + spacing),

                            margin +
                            r * (areaHeight + spacing),

                            areaWidth,
                            areaHeight);


                    areas.Add(
                        new GraphArea(rect));
                }
            }

            return areas;
        }

        // ============================
        // GENERAL GRAPH DRAWING ENGINE
        // ============================

        private void DrawGraph(
            Graphics g,
            GraphArea area,
            GraphPlot plot)
        {
            DrawBackground(g, area);
            double yMin = plot.YMin;
            double yMax = plot.YMax;

            DrawGrid(
                g,
                area,
                plot.XMin,
                plot.XMax,
                yMin,
                yMax);

            DrawAxes(
                g,
                area,
                plot.XMin,
                plot.XMax,
                yMin,
                yMax);


            DrawCurve(
                g,
                area,
                plot,
                yMin,
                yMax);
        }



        private void DrawBackground(
            Graphics g,
            GraphArea area)
        {
            using (Pen border =
                   new Pen(Color.Gray, 1))
            {
                g.DrawRectangle(
                    border,
                    area.Bounds);
            }
        }



        // ============================
        // GRID
        // ============================

        private void DrawGrid(
            Graphics g,
            GraphArea area,
            double xmin,
            double xmax,
            double ymin,
            double ymax)
        {
            using (Pen gridPen =
                   new Pen(
                       Color.LightGray,
                       1))
            {

                int divisions = 10;


                for (int i = 0; i <= divisions; i++)
                {
                    int x =
                        area.Left +
                        (int)(
                        i *
                        area.Width /
                        (double)divisions);


                    g.DrawLine(
                        gridPen,
                        x,
                        area.Top,
                        x,
                        area.Bottom);
                }


                for (int i = 0; i <= divisions; i++)
                {
                    int y =
                        area.Top +
                        (int)(
                        i *
                        area.Height /
                        (double)divisions);


                    g.DrawLine(
                        gridPen,
                        area.Left,
                        y,
                        area.Right,
                        y);
                }
            }
        }



        // ============================
        // AXES
        // ============================

        private void DrawAxes(
            Graphics g,
            GraphArea area,
            double xmin,
            double xmax,
            double ymin,
            double ymax)
        {
            using (Pen axis =
                   new Pen(Color.Black, 2))
            {

                int zeroX =
                    ScaleX(
                        0,
                        area,
                        xmin,
                        xmax);


                int zeroY =
                    ScaleY(
                        0,
                        area,
                        ymin,
                        ymax);



                if (zeroX >= area.Left &&
                    zeroX <= area.Right)
                {
                    g.DrawLine(
                        axis,
                        zeroX,
                        area.Top,
                        zeroX,
                        area.Bottom);
                }


                if (zeroY >= area.Top &&
                    zeroY <= area.Bottom)
                {
                    g.DrawLine(
                        axis,
                        area.Left,
                        zeroY,
                        area.Right,
                        zeroY);
                }


                using (Font font =
                       new Font(
                           "Arial",
                           9))
                using (Brush brush =
                       new SolidBrush(
                           Color.Black))
                {
                    g.DrawString(
                        "X",
                        font,
                        brush,
                        area.Right - 15,
                        zeroY + 5);


                    g.DrawString(
                        "Y",
                        font,
                        brush,
                        zeroX + 5,
                        area.Top + 5);
                }
            }
        }



        // ============================
        // CURVE PLOTTING
        // ============================

        private void DrawCurve(
            Graphics g,
            GraphArea area,
            GraphPlot plot,
            double ymin,
            double ymax)
        {


            double previousY =
                double.NaN;



            int samples = 1500;


            using (Pen curvePen =
                   new Pen(
                       plot.Color,
                       2))
            {

                PointF? previousPoint = null;


                for (int i = 0;
                     i <= samples;
                     i++)
                {

                    double x =
                        plot.XMin +
                        i *
                        (plot.XMax -
                        plot.XMin)
                        /
                        samples;


                    double y;


                    try
                    {
                        y =
                            plot.Function(x);
                    }
                    catch
                    {
                        y =
                            double.NaN;
                    }



                    if (!IsValidPoint(y))
                    {
                        previousPoint = null;
                        continue;
                    }



                    // Break curve at asymptotes
                    if (!double.IsNaN(previousY))
                    {
                        if (Math.Abs(y - previousY)
                            > (ymax - ymin) * 2)
                        {
                            previousPoint = null;
                        }
                    }



                    PointF currentPoint =
                        new PointF(
                            ScaleX(
                                x,
                                area,
                                plot.XMin,
                                plot.XMax),

                            ScaleY(
                                y,
                                area,
                                ymin,
                                ymax));



                    if (previousPoint != null)
                    {
                        if (IsInside(
                            currentPoint,
                            area)
                            &&
                            IsInside(
                            previousPoint.Value,
                            area))
                        {

                            g.DrawLine(
                                curvePen,
                                previousPoint.Value,
                                currentPoint);
                        }
                    }


                    previousPoint =
                        currentPoint;


                    previousY =
                        y;
                }
            }



            DrawTitle(
                g,
                area,
                plot.Title,
                plot.Color);
        }



        private void DrawTitle(
            Graphics g,
            GraphArea area,
            string title,
            Color color)
        {
            using (Font font =
                   new Font(
                       "Arial",
                       10,
                       FontStyle.Bold))

            using (Brush brush =
                   new SolidBrush(
                       color))
            {
                g.DrawString(
                    title,
                    font,
                    brush,
                    area.Left + 5,
                    area.Top + 5);
            }
        }



        // ============================
        // SCALING FUNCTIONS
        // ============================

        private int ScaleX(
            double x,
            GraphArea area,
            double xmin,
            double xmax)
        {
            return area.Left +
                (int)(
                (x - xmin)
                /
                (xmax - xmin)
                *
                area.Width);
        }



        private int ScaleY(
            double y,
            GraphArea area,
            double ymin,
            double ymax)
        {
            return area.Bottom -
                (int)(
                (y - ymin)
                /
                (ymax - ymin)
                *
                area.Height);
        }



        // ============================
        // VALIDATION
        // ============================

        private bool IsValidPoint(
            double value)
        {
            return
                !double.IsNaN(value)
                &&
                !double.IsInfinity(value)
                &&
                Math.Abs(value)
                < 1e6;
        }



        private bool IsInside(
            PointF point,
            GraphArea area)
        {
            return
                point.X >= area.Left
                &&
                point.X <= area.Right
                &&
                point.Y >= area.Top
                &&
                point.Y <= area.Bottom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
