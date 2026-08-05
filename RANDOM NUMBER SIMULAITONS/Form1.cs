using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RANDOM_NUMBER_SIMULAITONS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private RandomFunctions rf = new RandomFunctions();

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
        private void randomNumber032IntegerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = rf.Random0To32();
            MessageBox.Show(x.ToString());
        }

        private void only50RandomNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int x = rf.Only50Random();
            MessageBox.Show(x.ToString());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int x = rf.Random0To99();
            MessageBox.Show(x.ToString());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            double x = rf.Random0To1();
            MessageBox.Show(x.ToString());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int x = rf.Random10To19();
            MessageBox.Show(x.ToString());
        }

        private void floatRandomGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double x = rf.RandomFloat10To19();
            MessageBox.Show(x.ToString());
        }
        private void plotSteps500R299ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            rf.Plot(this);
        }
        private void correctnessSteps1000R100149ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rf.CorrectnessCheck();
        }
    }
}
