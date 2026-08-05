using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

public class PotentialField
{
    private Form form;       // Reference to the form for drawing
    private double[,] v;     // Matrix for potential
    private int rows;
    private int cols;

    public PotentialField(Form parentForm, int rows = 10, int cols = 10)
    {
        this.form = parentForm;
        this.rows = rows;
        this.cols = cols;
        v = new double[rows, cols];
    }

    // Start the simulation
    public void Run()
    {
        // Initialize first and last columns
        for (int i = 0; i < rows; i++)
        {
            v[i, 0] = 1;             // left column
            v[i, cols - 1] = 1;      // right column
        }

        DrawPotiential();

        int maxIterations = 1000;
        double tolerance = 1e-5;

        for (int step = 0; step < maxIterations; step++)
        {
            form.Refresh();

            double[,] temp = (double[,])v.Clone();
            double maxDiff = 0;

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                {
                    double newVal = 0.25 * (v[i + 1, j] + v[i - 1, j] + v[i, j + 1] + v[i, j - 1]);
                    maxDiff = Math.Max(maxDiff, Math.Abs(newVal - v[i, j]));
                    temp[i, j] = newVal;
                }
            }

            v = temp;

            DrawPotiential();

            Thread.Sleep(50);

            if (maxDiff < tolerance)
            {
                MessageBox.Show("Simulation converged and stopped.");
                break;
            }
        }
    }

    // Draw potential values
    private void DrawPotiential()
    {
        Graphics gg = form.CreateGraphics();
        Font f = new Font("Arial", 15);
        SolidBrush sb = new SolidBrush(Color.Maroon);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                gg.DrawString(Math.Round(v[i, j], 4).ToString(), f, sb, 100 + j * 100, 650 - i * 70);
            }
        }

        gg.Dispose();
        f.Dispose();
        sb.Dispose();
    }
}
