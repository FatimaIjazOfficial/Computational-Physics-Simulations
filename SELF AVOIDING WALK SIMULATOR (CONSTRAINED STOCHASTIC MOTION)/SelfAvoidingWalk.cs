using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

public class SelfAvoidingWalk
{
    private int size;       // Grid size
    private int steps;      // Total steps
    private int cellSize;   // Size of each cell in pixels
    private Random rnd;
    private int xOffset = 250; // X starting offset
    private int yOffset = 450; // Y starting offset

    public SelfAvoidingWalk(int gridSize = 100, int totalSteps = 300, int cellPixelSize = 15)
    {
        size = gridSize;
        steps = totalSteps;
        cellSize = cellPixelSize;
        rnd = new Random();
    }

    // Start the simulation using Graphics from main form
    public async void Start(Graphics gg)
    {
        if (gg == null) return;

        // Clear previous drawing
        gg.Clear(Color.White);

        int[,] plan = new int[size, size];

        // Ensure starting position is always valid
        int x = Math.Min(7, size - 1);
        int y = Math.Min(7, size - 1);

        plan[x, y] = 1;

        List<Point> vs = new List<Point>();
        vs.Add(new Point(x, y));
        int index = 1;

        Point prevPoint = new Point(xOffset + x * cellSize, yOffset - y * cellSize);

        for (int i = 0; i < steps; i++)
        {
            int oldX = x;
            int oldY = y;

            int[] directions = { 0, 1, 2, 3 };

            // Shuffle directions
            for (int j = directions.Length - 1; j > 0; j--)
            {
                int k = rnd.Next(j + 1);
                int temp = directions[j];
                directions[j] = directions[k];
                directions[k] = temp;
            }

            bool moved = false;

            // Try all directions until one works
            foreach (int dir in directions)
            {
                if (dir == 0 && x < size - 1 && plan[x + 1, y] == 0)
                {
                    x++;
                    moved = true;
                    break;
                }
                else if (dir == 1 && x > 0 && plan[x - 1, y] == 0)
                {
                    x--;
                    moved = true;
                    break;
                }
                else if (dir == 2 && y < size - 1 && plan[x, y + 1] == 0)
                {
                    y++;
                    moved = true;
                    break;
                }
                else if (dir == 3 && y > 0 && plan[x, y - 1] == 0)
                {
                    y--;
                    moved = true;
                    break;
                }
            }

            if (moved)
            {
                plan[x, y] = 1;
                vs.Add(new Point(x, y));
                index++;

                Point currentPoint = new Point(xOffset + x * cellSize, yOffset - y * cellSize);

                // Draw step with gradient and connecting line
                DrawStep(gg, prevPoint, currentPoint, i);
                prevPoint = currentPoint;
            }

            // Bounds-safe dead-end check
            bool rightBlocked = (x == size - 1) || (plan[x + 1, y] == 1);
            bool leftBlocked = (x == 0) || (plan[x - 1, y] == 1);
            bool upBlocked = (y == size - 1) || (plan[x, y + 1] == 1);
            bool downBlocked = (y == 0) || (plan[x, y - 1] == 1);

            if (rightBlocked && leftBlocked && upBlocked && downBlocked && index > 1)
            {
                // Unmark dead-end cell
                plan[x, y] = 0;

                // Remove dead-end from path history
                vs.RemoveAt(vs.Count - 1);
                index--;

                // Move back to previous position
                x = vs[vs.Count - 1].X;
                y = vs[vs.Count - 1].Y;

                prevPoint = new Point(xOffset + x * cellSize, yOffset - y * cellSize);
            }

            await Task.Delay(100); // smooth animation
        }
    }

    // Draw a single step with color gradient and line connecting previous point
    private void DrawStep(Graphics gg, Point prev, Point current, int stepIndex)
    {
        // Clamp colors between 0-255
        int r = Math.Max(0, Math.Min(255, (stepIndex * 5) % 256));
        int g = Math.Max(0, Math.Min(255, 255 - stepIndex * 3));
        int b = Math.Max(0, Math.Min(255, (stepIndex * 7) % 256));

        using (Pen pen = new Pen(Color.FromArgb(r, g, b), 2))
        using (SolidBrush sb = new SolidBrush(Color.FromArgb(r, g, b)))
        {
            // Draw connecting line
            gg.DrawLine(pen, prev, current);

            // Draw dot safely
            int size = 5 + (stepIndex % 3);
            int drawX = Math.Max(0, current.X - size / 2);
            int drawY = Math.Max(0, current.Y - size / 2);
            gg.FillEllipse(sb, drawX, drawY, size, size);
        }
    }
}