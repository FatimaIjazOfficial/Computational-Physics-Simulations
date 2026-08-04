using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diffusion_Model
{
    public partial class Form1 : Form
    {
        double D = 1, dx = 2, dt = 0.05;
        double[,] rho = new double[100, 100];

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        // -------- Initialize Gaussian --------
        private void InitializeGaussian()
        {
            double t0 = 0.1; // small initial diffusion time

            double sigma = Math.Sqrt(2 * D * t0);

            int x = -50;

            for (int i = 0; i < 100; i++)
            {
                rho[i, 0] = (1.0 / sigma) *
                            Math.Exp(-(x * x) / (2 * sigma * sigma));
                x++;
            }
        }

        // -------- Finite-Difference Diffusion --------
        private void ComputeDiffusion()
        {
            for (int t = 0; t < 99; t++)
            {
                for (int i = 1; i < 99; i++)
                {
                    rho[i, t + 1] = rho[i, t] + D * (rho[i + 1, t] - 2 * rho[i, t] + rho[i - 1, t]) / (dx * dx) * dt;
                }
                // Boundary conditions
                rho[0, t + 1] = rho[1, t + 1];
                rho[99, t + 1] = rho[98, t + 1];
            }
        }

        // -------- Draw Density --------
        private void DrawDensity(int offsetX, int offsetY, Color color, float scale)
        {
            Graphics gg = this.CreateGraphics();
            SolidBrush sb = new SolidBrush(color);

            for (int t = 0; t < 100; t++)
            {
                for (int i = 0; i < 100; i++)
                {
                    gg.FillEllipse(sb, offsetX + i * 2, offsetY - (float)(rho[i, t] * scale), 5, 5);
                }
            }
        }

        // -------- Draw Entropy --------
        private void DrawEntropy(int offsetX, int offsetY, Color color, float scale)
        {
            Graphics ggg = this.CreateGraphics();
            SolidBrush sb1 = new SolidBrush(color);

            for (int t = 0; t < 100; t++)
            {
                double total = 0;

                for (int i = 0; i < 100; i++)
                    total += rho[i, t];

                if (total == 0)
                    continue;

                double entropy = 0;

                for (int i = 0; i < 100; i++)
                {
                    double p = rho[i, t] / total;

                    if (p > 0)
                        entropy -= p * Math.Log(p);
                }

                ggg.FillEllipse(sb1,
                    offsetX + t,
                    offsetY - (float)entropy * scale,
                    5,
                    5);
            }
        }
        //1D Diffusion Equation
        private void diffusionEquationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGaussian();
            ComputeDiffusion();
            DrawDensity(550, 950, Color.Maroon, 5000);
        }



        //Entropy Evolution
        private void diffusionEqToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGaussian();
            ComputeDiffusion();

            DrawEntropy(205, 250, Color.Chocolate, 50);
        }

        //Refresh
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreateGraphics().Clear(this.BackColor);
        }

        // Particle Diffusion in 2D with Entropy
        private void particleDiffusionIn2DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Panel Container;
            Container = new Panel();
            Container.Size = new Size(400, 300);
            Container.Location = new Point(50, 650);
            Container.BackColor = Color.Black;
            this.Controls.Add(Container);

            Random rnd = new Random();
            int xc = Container.Width / 2;
            int yc = Container.Height / 2;
            int xmin = xc - 10, xmax = xc + 10, ymin = yc - 10, ymax = yc + 10;
            int xleft = 0, xright = Container.Width, yup = 0, ydown = Container.Height;
            int mol = 500;
            Point[] Particles = new Point[mol];

            Graphics gg = Container.CreateGraphics();
            SolidBrush sbParticle = new SolidBrush(Color.White);
            SolidBrush sbPrev = new SolidBrush(Color.Black);
            SolidBrush sbEntropy = new SolidBrush(Color.Coral);

            double r;

            // Initialize particles
            for (int i = 0; i < mol; i++)
            {
                Particles[i] = new Point();
                r = rnd.NextDouble();
                Particles[i].X = (int)(xmin + (xmax - xmin) * r);
                r = rnd.NextDouble();
                Particles[i].Y = (int)(ymin + (ymax - ymin) * r);
                gg.FillEllipse(sbParticle, Particles[i].X, Particles[i].Y, 4, 4);
            }

            double t = 0;
            Graphics ggForm = this.CreateGraphics();

            for (int step = 0; step < 5000; step++)
            {
                double[,] rho = new double[Container.Width / 20 + 1, Container.Height / 20 + 1];

                for (int i = 0; i < mol; i++)
                {
                    gg.FillEllipse(sbPrev, Particles[i].X, Particles[i].Y, 4, 4);

                    r = rnd.NextDouble();
                    Particles[i].X += (r < 0.5) ? 2 : -2;
                    r = rnd.NextDouble();
                    Particles[i].Y += (r < 0.5) ? 2 : -2;

                    if (Particles[i].X < xleft) Particles[i].X = xleft;
                    if (Particles[i].X > xright) Particles[i].X = xright;
                    if (Particles[i].Y < yup) Particles[i].Y = yup;
                    if (Particles[i].Y > ydown) Particles[i].Y = ydown;

                    gg.FillEllipse(sbParticle, Particles[i].X, Particles[i].Y, 4, 4);

                    int xx = Particles[i].X / 20;
                    int yy = Particles[i].Y / 20;
                    rho[xx, yy] += 1;
                }

                // Compute entropy
                double entropy = 0;
                for (int i = 0; i < rho.GetLength(0); i++)
                {
                    for (int j = 0; j < rho.GetLength(1); j++)
                    {
                        if (rho[i, j] != 0)
                        {
                            double p = rho[i, j] / mol;
                            entropy -= p * Math.Log(p);
                        }
                    }
                }

                // Draw entropy outside container on the right
                float entropyX = Container.Right + 10 + (float)t; // start a bit outside container
                float entropyY = Container.Top + Container.Height - 50 - (float)entropy * 50; // relative to container bottom
                ggForm.FillEllipse(sbEntropy, entropyX, entropyY, 5, 5);

                t++;
                Application.DoEvents();
            }
        }

    }
}
