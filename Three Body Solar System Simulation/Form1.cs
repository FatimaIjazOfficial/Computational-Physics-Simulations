using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Three_Body_Solar_System_Simulation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Solar System
        //ThreeBodyProblem

        //Array
        private void threeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            SolarSystem ss = new SolarSystem();
            ss.DrawThreeBodyArray(this);
        }
        //Without Array
        private void wToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
            SolarSystem ss = new SolarSystem();
            ss.DrawThreeBodyWithoutArray(this);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
