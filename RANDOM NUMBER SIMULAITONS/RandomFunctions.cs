using System;
using System.Drawing;
using System.Windows.Forms;

public class RandomFunctions
{
    private Random rd;

    public RandomFunctions()
    {
        rd = new Random();
    }

    // 0 - 32 integer
    public int Random0To32()
    {
        return rd.Next(33);
    }

    // Only 50 random numbers (0 - 50)
    public int Only50Random()
    {
        return rd.Next(51);
    }

    // 0 - 99 integer
    public int Random0To99()
    {
        return rd.Next(100);
    }

    // 0 - 0.9999 double
    public double Random0To1()
    {
        return rd.NextDouble();
    }

    // 10 - 19 integer
    public int Random10To19()
    {
        return rd.Next(10, 20);
    }

    // 10 - 19 float/double
    public double RandomFloat10To19()
    {
        return rd.Next(10, 20) + rd.NextDouble();
    }

    // Plot (Steps=500)(R=299)
    public void Plot(Form form)
    {
        Graphics gg = form.CreateGraphics();
        SolidBrush sb = new SolidBrush(Color.Blue);
        for (int i = 0; i < 10; i++)
        {
            //form.Refresh();
            for (int step = 0; step < 500; step++)
            {
                int r = rd.Next(300);
                gg.FillEllipse(sb, 150 + step, 450 - r, 5, 5);
            }
        }
        gg.Dispose();
        sb.Dispose();
    }

    // Correctness check (Steps=1000)(R=100-149)
    public void CorrectnessCheck()
    {
        int x = 0, y = 0;
        for (int i = 0; i < 1000; i++)
        {
            int r = rd.Next(100, 150);
            if (r >= 100 && r < 125)
            {
                x++;
            }
            else if (r >= 125 && r < 150)
            {
                y++;
            }
        }
        MessageBox.Show("x = " + x.ToString() + "    y = " + y.ToString());
    }
}
