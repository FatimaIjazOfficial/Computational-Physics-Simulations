using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ising_Model
{
    public partial class Form1 : Form
    {
        Random rnd; // Random number generator for Monte Carlo
        int no_electron = 30; // Lattice size   
        int[,] Lattice; // 2D spin lattice: +1 (up) or -1 (down)
        double KB, E1, E2; // Boltzmann constant and temporary energy variables       
        float x, y, xoffset, yoffset; // GUI drawing coordinates
        Graphics gg; // Graphics and double buffering
        Bitmap buffer;
        SolidBrush sbw, sbr;// Spin colors: white = up (+1), red = down (-1)

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeSystem();   // Setup lattice and GUI
            TemperatureSweep();   // Run Monte Carlo simulation over temperature
        }

        // ============================
        // Initialize the Lattice + GUI
        // ============================
        public void InitializeSystem()
        {
            KB = 1;                  // Boltzmann constant
            rnd = new Random();       // Random number generator
            Lattice = new int[no_electron, no_electron];

            // Double buffering for smooth drawing
            buffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            gg = Graphics.FromImage(buffer);

            sbw = new SolidBrush(Color.White); // Spin up
            sbr = new SolidBrush(Color.Red);   // Spin down

            // Center offsets for drawing
            x = this.ClientSize.Width / 2;
            y = this.ClientSize.Height / 2;
            xoffset = x / 2;
            yoffset = y / 2;

            // Initialize lattice randomly with ±1 spins
            for (int i = 0; i < no_electron; i++)
            {
                for (int j = 0; j < no_electron; j++)
                {
                    Lattice[i, j] = rnd.Next(2) * 2 - 1; // random ±1

                    // Draw initial spin
                    if (Lattice[i, j] == 1)
                        gg.FillEllipse(sbw, x - xoffset + j * 6, y - yoffset + i * 6, 5, 5);
                    else
                        gg.FillEllipse(sbr, x - xoffset + j * 6, y - yoffset + i * 6, 5, 5);
                }
            }

            this.Invalidate(); // Trigger repaint
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the buffered image
            if (buffer != null)
            {
                e.Graphics.DrawImage(buffer, 0, 0);
            }
        }

        // ============================
        // Temperature Sweep (Monte Carlo)
        // ============================
        // Simulates the Ising lattice over a range of temperatures
        public void TemperatureSweep()
        {
            int sweeps = 40;                 // Number of Monte Carlo sweeps per temperature
            SolidBrush plotbrush = new SolidBrush(Color.Red);

            for (double T = 0.1; T <= 5; T += 0.1) // Sweep temperature
            {
                double ma = 0;  // Accumulate magnetization

                for (int k = 0; k < sweeps; k++)
                {
                    // Monte Carlo step: randomly select spins
                    for (int n = 0; n < no_electron * no_electron; n++)
                    {
                        int i = rnd.Next(no_electron);
                        int j = rnd.Next(no_electron);
                        DecideFlip(i, j, T);  // Apply Metropolis algorithm
                    }

                    ma += Mag(); // Add magnetization for this sweep
                }

                ma /= sweeps; // Average magnetization

                // Plot magnetization vs temperature
                gg.FillEllipse(plotbrush, 550 + (float)T * 40, 250 - (float)ma * 120, 4, 4);
                this.Invalidate();
                Application.DoEvents();
            }
        }

        // ============================
        // Energy Calculation
        // ============================
        // Returns the energy of spin (r,c) due to nearest neighbors
        // Periodic boundary conditions are applied
        public double EnergyCal(int r, int c)
        {
            int up = Lattice[(r - 1 + no_electron) % no_electron, c];
            int down = Lattice[(r + 1) % no_electron, c];
            int left = Lattice[r, (c - 1 + no_electron) % no_electron];
            int right = Lattice[r, (c + 1) % no_electron];

            return -Lattice[r, c] * (up + down + left + right); // J=1
        }

        // ============================
        // Metropolis Spin Flip
        // ============================
        // Flip a spin at (r,c) according to Metropolis criterion
        public void DecideFlip(int r, int c, double T)
        {
            E1 = EnergyCal(r, c);   // Current energy

            Lattice[r, c] = -Lattice[r, c];   // Trial flip
            E2 = EnergyCal(r, c);   // New energy

            if (E2 <= E1)            // Accept if energy decreases
            {
                DrawSpin(r, c);
            }
            else
            {
                // Accept with probability exp(-(E2-E1)/kT)
                if (rnd.NextDouble() <= Math.Exp(-(E2 - E1) / (KB * T)))
                {
                    DrawSpin(r, c);
                }
                else
                {
                    Lattice[r, c] = -Lattice[r, c]; // Reject flip
                }
            }
        }

        // ============================
        // Draw a single spin
        // ============================
        public void DrawSpin(int r, int c)
        {
            if (Lattice[r, c] == -1)
                gg.FillEllipse(sbr, x - xoffset + c * 6, y - yoffset + r * 6, 5, 5);
            else
                gg.FillEllipse(sbw, x - xoffset + c * 6, y - yoffset + r * 6, 5, 5);
        }

        // ============================
        // Magnetization
        // ============================
        // Returns average magnetization of the lattice
        public double Mag()
        {
            double m = 0;

            for (int i = 0; i < no_electron; i++)
                for (int j = 0; j < no_electron; j++)
                    m += Lattice[i, j];

            return Math.Abs(m) / (no_electron * no_electron);
        }
    }
}
