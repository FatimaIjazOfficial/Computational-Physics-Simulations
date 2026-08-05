using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class RandomWalkSimulator
{
    private Form form;
    private Graphics gg;
    private SolidBrush sbp = new SolidBrush(Color.Purple), sbg = new SolidBrush(Color.Green), sbf, sbb = new SolidBrush(Color.Blue), sbr = new SolidBrush(Color.Red);
    public RandomWalkSimulator(Form f)
    {
        form = f;
        gg = form.CreateGraphics();
    }

    // 1D RW for 1 Walker
    public void Run1DWalker(int steps = 150)
    {
        Random rnd = new Random();
        sbf = new SolidBrush(form.BackColor);
        int x = 0;
        for (int i = 0; i < steps; i++)
        {
            double r = rnd.NextDouble();
            x += (r < 0.5) ? 1 : -1;

            gg.FillEllipse(sbp, 150 + x * 2, 250, 10, 10);
            Thread.Sleep(10);
            gg.FillEllipse(sbf, 150 + x * 2, 250, 10, 10);
            gg.FillEllipse(sbp, 300 + i * 2, 250 - x * 2, 5, 5);
        }

        sbp.Dispose();
        sbf.Dispose();
    }

    // 1D RW for multiple walkers
    public void Run1DMultipleWalkers(int steps = 150, int walkers = 100)
    {
        Random rnd = new Random();
        double[] x2avg = new double[steps];
        sbf = new SolidBrush(form.BackColor);
        for (int j = 0; j < walkers; j++)
        {
            int x = 0;
            for (int i = 0; i < steps; i++)
            {
                double r = rnd.NextDouble();
                x += (r < 0.5) ? 1 : -1;

                gg.FillEllipse(sbr, 50 + x * 2, 750, 10, 10);
                gg.FillEllipse(sbf, 50 + x * 2, 750, 10, 10);
                gg.FillEllipse(sbr, 200 + i * 2, 750 - x * 2, 5, 5);

                x2avg[i] += x * x;
            }
        }

        for (int i = 0; i < steps; i++)
        {
            x2avg[i] /= walkers;
            gg.FillEllipse(sbb, 200 + i * 2, 750 - (float)x2avg[i], 5, 5); // ms
            gg.FillEllipse(sbp, 200 + i * 2, 750 - (float)Math.Sqrt(x2avg[i]), 5, 5); // rms
        }

        sbr.Dispose(); sbb.Dispose(); sbp.Dispose(); sbf.Dispose();
    }

    // 2D RW for 1 walker
    public void Run2DWalker(int steps = 150)
    {
        Random rnd = new Random();
        sbf = new SolidBrush(form.BackColor);
        int x = 0, y = 0;

        for (int i = 0; i < steps; i++)
        {
            double r = rnd.NextDouble();
            if (r < 0.25) x++;
            else if (r < 0.5) x--;
            else if (r < 0.75) y++;
            else y--;

            gg.FillEllipse(sbp, 750 + x * 2, 250 + y * 2, 10, 10); // walker
            Thread.Sleep(10);
            gg.FillEllipse(sbf, 750 + x * 2, 250 + y * 2, 10, 10); // erase
            gg.FillEllipse(sbp, 900 + x * 2, 250 - y * 2, 5, 5);     // walker path
        }

        sbp.Dispose();
        sbf.Dispose();
    }

    // 2D RW for multiple walkers
    public void Run2DMultipleWalkers(int steps = 299, int walkers = 100)
    {
        Random rnd = new Random();
        sbf = new SolidBrush(form.BackColor);
        double[] r2avg = new double[steps];

        for (int j = 0; j < walkers; j++)
        {
            int x = 0, y = 0;
            for (int i = 0; i < steps; i++)
            {
                double r = rnd.NextDouble();
                if (r < 0.25) x++;
                else if (r < 0.5) x--;
                else if (r < 0.75) y++;
                else y--;

                gg.FillEllipse(sbg, 750 + x * 4, 750 - y * 4, 10, 10);
                gg.FillEllipse(sbf, 750 + x * 4, 750 - y * 4, 10, 10);
                gg.FillEllipse(sbg, 900 + x * 2, 750 - y * 2, 5, 5); // walker path

                r2avg[i] += x * x + y * y;
            }
        }

        for (int i = 0; i < steps; i++)
        {
            r2avg[i] /= walkers;
            gg.FillEllipse(sbb, 900 + i * 2, 750 - (float)r2avg[i], 5, 5);           // ms
            gg.FillEllipse(sbp, 900 + i * 2, 750 - (float)Math.Sqrt(r2avg[i]), 5, 5); // rms
        }

        sbg.Dispose(); sbb.Dispose(); sbp.Dispose(); sbf.Dispose();
    }

}
