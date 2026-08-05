using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Two_Body_Solar_System_Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Solar System
        //TwoBodyProblem

        //Array
        private void twoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            SolarSystem ss = new SolarSystem();
            ss.DrawTwoBodyArray(this);
        }
        //Without Array
        private void wToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            SolarSystem ss = new SolarSystem();
            ss.DrawTwoBodyWithoutArray(this);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
