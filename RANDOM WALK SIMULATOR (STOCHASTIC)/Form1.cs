using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RANDOM_WALK_SIMULATOR__STOCHASTIC_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void dRW1For1WalkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomWalkSimulator sim = new RandomWalkSimulator(this);
            sim.Run1DWalker();
        }

        private void dRW1For100WalkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomWalkSimulator sim = new RandomWalkSimulator(this);
            sim.Run1DMultipleWalkers();
        }

        private void dRW2For1WalkerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RandomWalkSimulator sim = new RandomWalkSimulator(this);
            sim.Run2DWalker();
        }

        private void dRW2For100WalkerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RandomWalkSimulator sim = new RandomWalkSimulator(this);
            sim.Run2DMultipleWalkers();
        }
    }
}
