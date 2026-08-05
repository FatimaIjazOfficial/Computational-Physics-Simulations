using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two_Body_Solar_System_Simulation
{
    public class SolarSystem
    {
        // Two-Body Problem (Array)
        public void DrawTwoBodyArray(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            Graphics gg = form.CreateGraphics();

            SolidBrush sun = new SolidBrush(Color.Orange);
            SolidBrush earth = new SolidBrush(Color.Green);
            SolidBrush border = new SolidBrush(Color.Black);

            gg.FillEllipse(sun, W - 40, H - 40, 80, 80); // Center Sun

            int size = 20000;
            double dt = 0.0002, pi = Math.PI, beta = 2, r;
            double[] vx = new double[size], vy = new double[size];
            double[] x = new double[size], y = new double[size];

            x[0] = 1;
            y[0] = 0;
            vx[0] = 0;
            vy[0] = 2 * pi;

            for (int i = 0; i < size - 1; i++)
            {
                r = Math.Sqrt(x[i] * x[i] + y[i] * y[i]);

                vx[i + 1] = vx[i] - 4 * pi * pi * x[i] * dt / Math.Pow(r, beta + 1);
                vy[i + 1] = vy[i] - 4 * pi * pi * y[i] * dt / Math.Pow(r, beta + 1);

                x[i + 1] = x[i] + vx[i + 1] * dt;
                y[i + 1] = y[i] + vy[i + 1] * dt;

                gg.FillEllipse(earth, W + (float)(x[i] * 100), H + (float)(y[i] * 100), 40, 40);
                gg.FillEllipse(border, W + (float)(x[i] * 100), H + (float)(y[i] * 100), 40, 40);
            }
        }

        // Two-Body Problem (Without Array)
        public void DrawTwoBodyWithoutArray(Form1 form)
        {
            float W = form.ClientSize.Width / 2;
            float H = form.ClientSize.Height / 2;
            Graphics gg = form.CreateGraphics();

            SolidBrush sun = new SolidBrush(Color.Orange);
            SolidBrush earth = new SolidBrush(Color.Green);
            SolidBrush border = new SolidBrush(Color.Black);

            gg.FillEllipse(sun, W - 40, H - 40, 80, 80); // Center Sun

            double dt = 0.0002, pi = Math.PI, beta = 2, r;
            double vx = 0, vy = 2 * pi, x = 1, y = 0;

            for (int i = 0; i < 20000 - 1; i++)
            {
                r = Math.Sqrt(x * x + y * y);

                vx -= 4 * pi * pi * x * dt / Math.Pow(r, beta + 1);
                vy -= 4 * pi * pi * y * dt / Math.Pow(r, beta + 1);

                x += vx * dt;
                y += vy * dt;

                gg.FillEllipse(earth, W + (float)(x * 100), H + (float)(y * 100), 40, 40);
                gg.FillEllipse(border, W + (float)(x * 100), H + (float)(y * 100), 40, 40);
            }
        }
    }
}
