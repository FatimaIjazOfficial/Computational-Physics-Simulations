using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lorenz_Model
{
    public class LorenzModel
    {
        private readonly double sigma = 10.0;
        private readonly double r = 25.0;
        private readonly double b = 8.0 / 3.0;

        private readonly double dt = 0.0009;
        private readonly int size = 30000;
        private readonly int transient = 5000;

        public Bitmap PlotXvsT(Form form) => Plot(form, Color.Red, (t, x, y, z) => (t, x));
        public Bitmap PlotYvsT(Form form) => Plot(form, Color.Blue, (t, x, y, z) => (t, y));
        public Bitmap PlotZvsT(Form form) => Plot(form, Color.Green, (t, x, y, z) => (t, z));

        public Bitmap PlotYvsX(Form form) => Plot(form, Color.AliceBlue, (t, x, y, z) => (x, y));
        public Bitmap PlotZvsX(Form form) => Plot(form, Color.Orange, (t, x, y, z) => (x, z));
        public Bitmap PlotXvsY(Form form) => Plot(form, Color.Purple, (t, x, y, z) => (y, x));

        public Bitmap PlotZvsY(Form form) => Plot(form, Color.Brown, (t, x, y, z) => (y, z));
        public Bitmap PlotXvsZ(Form form) => Plot(form, Color.HotPink, (t, x, y, z) => (z, x));
        public Bitmap PlotYvsZ(Form form) => Plot(form, Color.Tomato, (t, x, y, z) => (z, y));


        private Bitmap Plot(
            Form form,
            Color color,
            Func<double, double, double, double, (double X, double Y)> selector)
        {

            double[] x = new double[size];
            double[] y = new double[size];
            double[] z = new double[size];
            double[] t = new double[size];


            x[0] = 1.0;
            y[0] = 1.0;
            z[0] = 1.0;


            // RK4 integration
            for (int i = 0; i < size - 1; i++)
            {

                var k1 = Derivatives(x[i], y[i], z[i]);

                var k2 = Derivatives(
                    x[i] + k1.dx * dt / 2,
                    y[i] + k1.dy * dt / 2,
                    z[i] + k1.dz * dt / 2);


                var k3 = Derivatives(
                    x[i] + k2.dx * dt / 2,
                    y[i] + k2.dy * dt / 2,
                    z[i] + k2.dz * dt / 2);


                var k4 = Derivatives(
                    x[i] + k3.dx * dt,
                    y[i] + k3.dy * dt,
                    z[i] + k3.dz * dt);


                x[i + 1] =
                    x[i] + dt / 6 *
                    (k1.dx + 2 * k2.dx + 2 * k3.dx + k4.dx);


                y[i + 1] =
                    y[i] + dt / 6 *
                    (k1.dy + 2 * k2.dy + 2 * k3.dy + k4.dy);


                z[i + 1] =
                    z[i] + dt / 6 *
                    (k1.dz + 2 * k2.dz + 2 * k3.dz + k4.dz);


                t[i + 1] = t[i] + dt;
            }



            double xMin = double.MaxValue;
            double xMax = double.MinValue;
            double yMin = double.MaxValue;
            double yMax = double.MinValue;


            for (int i = transient; i < size; i++)
            {
                var p = selector(t[i], x[i], y[i], z[i]);

                xMin = Math.Min(xMin, p.X);
                xMax = Math.Max(xMax, p.X);

                yMin = Math.Min(yMin, p.Y);
                yMax = Math.Max(yMax, p.Y);
            }


            double xRange = xMax - xMin;
            double yRange = yMax - yMin;

            if (xRange == 0)
            {
                xRange = 1;
            }

            if (yRange == 0)
            {
                yRange = 1;
            }


            Bitmap bitmap = new Bitmap(
                form.ClientSize.Width,
                form.ClientSize.Height);


            using (Graphics g = Graphics.FromImage(bitmap))
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.Clear(form.BackColor);


                for (int i = transient; i < size; i++)
                {
                    var p = selector(t[i], x[i], y[i], z[i]);


                    float px =
                        40 +
                        (float)((p.X - xMin) / xRange *
                        (form.ClientSize.Width - 80));


                    float py =
                        form.ClientSize.Height - 40 -
                        (float)((p.Y - yMin) / yRange *
                        (form.ClientSize.Height - 80));


                    g.FillEllipse(
                        brush,
                        px,
                        py,
                        2,
                        2);
                }
            }


            using (Graphics screen = form.CreateGraphics())
            {
                screen.DrawImage(bitmap, 0, 0);
            }


            return bitmap;
        }



        private (double dx, double dy, double dz) Derivatives(
            double x,
            double y,
            double z)
        {

            double dx = sigma * (y - x);
            double dy = r * x - y - x * z;
            double dz = x * y - b * z;

            return (dx, dy, dz);
        }
    }
}