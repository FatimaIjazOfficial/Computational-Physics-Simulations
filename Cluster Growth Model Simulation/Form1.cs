using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cluster_Growth_Model_Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Generic cluster growth method
        private void StartCluster(int size, Point offset, Color color, bool isDLA)
        {
            bool[,] occupied = new bool[size, size];
            bool[,] perimeter = new bool[size, size];
            occupied[size / 2, size / 2] = true;

            Graphics g = CreateGraphics();
            SolidBrush sb = new SolidBrush(color);
            Timer timer = new Timer();
            timer.Interval = 10;
            Random rnd = new Random();

            timer.Tick += (s, ev) =>
            {
                // Update perimeter
                bool[,] newPerimeter = new bool[size, size];
                for (int i = 1; i < size - 1; i++)
                {
                    for (int j = 1; j < size - 1; j++)
                    {
                        if (occupied[i, j])
                        {
                            if (!occupied[i + 1, j]) newPerimeter[i + 1, j] = true;
                            if (!occupied[i - 1, j]) newPerimeter[i - 1, j] = true;
                            if (!occupied[i, j + 1]) newPerimeter[i, j + 1] = true;
                            if (!occupied[i, j - 1]) newPerimeter[i, j - 1] = true;
                        }
                    }
                }
                perimeter = newPerimeter;

                int x, y;
                if (isDLA)
                {
                    // Start walker from a random boundary
                    int edge = rnd.Next(4);
                    switch (edge)
                    {
                        case 0: x = 0; y = rnd.Next(size); break;
                        case 1: x = size - 1; y = rnd.Next(size); break;
                        case 2: x = rnd.Next(size); y = 0; break;
                        default: x = rnd.Next(size); y = size - 1; break;
                    }

                    while (true)
                    {
                        // Check if walker is adjacent to the cluster
                        bool stick = false;

                        if (x > 0 && occupied[x - 1, y]) stick = true;
                        if (x < size - 1 && occupied[x + 1, y]) stick = true;
                        if (y > 0 && occupied[x, y - 1]) stick = true;
                        if (y < size - 1 && occupied[x, y + 1]) stick = true;

                        if (stick)
                            break;

                        // Random walk
                        int dir = rnd.Next(4);

                        switch (dir)
                        {
                            case 0:
                                if (x > 0) x--;
                                break;

                            case 1:
                                if (x < size - 1) x++;
                                break;

                            case 2:
                                if (y > 0) y--;
                                break;

                            case 3:
                                if (y < size - 1) y++;
                                break;
                        }
                    }
                }
                else
                {
                    // Random perimeter selection (ECGM)
                    List<Point> perimeterPoints = new List<Point>();
                    for (int i = 1; i < size - 1; i++)
                    {
                        for (int j = 1; j < size - 1; j++)
                        {
                            if (perimeter[i, j]) perimeterPoints.Add(new Point(i, j));
                        }
                    }
                    if (perimeterPoints.Count == 0) return;
                    Point chosen = perimeterPoints[rnd.Next(perimeterPoints.Count)];
                    x = chosen.X;
                    y = chosen.Y;
                }

                occupied[x, y] = true;
                int scale = 1;
                g.FillEllipse(sb, offset.X + x * scale, offset.Y - y * scale, 5, 5);
            };

            timer.Start();
        }

        private void dLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // DLA on the left side
            StartCluster(300, new Point(250, 650), Color.DeepSkyBlue, true);
        }

        private void eCGMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ECGM on the right side
            StartCluster(300, new Point(700, 650), Color.PaleVioletRed, false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
