using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POTIENTIAL_FIELD_SIMULATION
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

        private void potientialFieldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PotentialField pf = new PotentialField(this, 10, 10); // Pass form reference
            pf.Run();
        }
    }
}
