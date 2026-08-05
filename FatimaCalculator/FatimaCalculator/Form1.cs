using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatimaCalculator
{
    public partial class Form1 : Form
    {
        float a, b, c;
        string operation;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            //1
            textBox1.Text = textBox1.Text + "1";
        }
        private void button29_Click(object sender, EventArgs e)
        {
            //2
            textBox1.Text = textBox1.Text + "2";
        }
        private void button33_Click(object sender, EventArgs e)
        {
            //3
            textBox1.Text = textBox1.Text + "3";
        }
        private void button39_Click(object sender, EventArgs e)
        {
            //4
            textBox1.Text = textBox1.Text + "4";
        }
        private void button30_Click(object sender, EventArgs e)
        {
            //5
            textBox1.Text = textBox1.Text + "5";
        }
        private void button32_Click(object sender, EventArgs e)
        {
            //6
            textBox1.Text = textBox1.Text + "6";
        }
        private void button40_Click(object sender, EventArgs e)
        {
            //7
            textBox1.Text = textBox1.Text + "7";
        }
        private void button31_Click(object sender, EventArgs e)
        {
            //8
            textBox1.Text = textBox1.Text + "8";
        }
        private void button34_Click(object sender, EventArgs e)
        {
            //9
            textBox1.Text = textBox1.Text + "9";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            //0
            textBox1.Text = textBox1.Text + "0";
        }
        private void button36_Click(object sender, EventArgs e)
        {
             //Multiplication(*)
            a = float.Parse(textBox1.Text);
            textBox1.Text = "";
            operation="*";
        }
        private void button23_Click(object sender, EventArgs e)
        {
            //Addition(+)
            a = float.Parse(textBox1.Text);
            textBox1.Text = "";
            operation = "+";
        }
        private void button37_Click(object sender, EventArgs e)
        {
            //Subtraction(-)
            a = float.Parse(textBox1.Text);
            textBox1.Text = "";
            operation = "-";
        }
        private void button35_Click(object sender, EventArgs e)
        {
            //Division(/)
            a = float.Parse(textBox1.Text);
            textBox1.Text = "";
            operation = "/";
        }
        private void button22_Click(object sender, EventArgs e)
        {
            //Equal(=)
            b = float.Parse(textBox1.Text);
            if (operation == "+")
            {
                c = a + b;
            }
            if (operation == "-")
            {
                c = a - b;
            }
            if (operation == "*")
            {
                c = a * b;
            }
            if (operation == "/")
            {
                c = a / b;
            }
            if (operation == "%")
            {
                c = a % b;
            }
            if (operation == "^")
            {
                c = (float)Math.Pow(a, b);//typecasting
            }
            if (operation == "^(1/y)")
            {
                c = (float)Math.Ceiling(Math.Pow(a, (double)1 / b));
            }
            textBox1.Text = c.ToString();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            //Dot(.)
            textBox1.Text = textBox1.Text + ".";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Sin
            a = float.Parse(textBox1.Text);
            double y = Math.Asin(a);
            textBox1.Text = y.ToString();
        }
        private void button24_Click(object sender, EventArgs e)
        {
            //Cos
            a = float.Parse(textBox1.Text);
            double y = Math.Cos(a * Math.PI / 180);
            textBox1.Text = y.ToString();
        }
        private void button25_Click(object sender, EventArgs e)
        {
            //Tan
            a = float.Parse(textBox1.Text);
            double y = Math.Tan(a * Math.PI / 180);
            textBox1.Text = y.ToString();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            //Tanh
            a = float.Parse(textBox1.Text);
            double y = Math.Tanh(a);
            textBox1.Text = y.ToString();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            //Cosh
            a = float.Parse(textBox1.Text);
            double y = Math.Cosh(a);
            textBox1.Text = y.ToString();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            //Sinh
            a = float.Parse(textBox1.Text);
            double y = Math.Sinh(a);
            textBox1.Text = y.ToString();
        }
        private void button16_Click(object sender, EventArgs e)
        {
            //Mod
            a = float.Parse(textBox1.Text);
            textBox1.Text = "";
            operation = "%";
        }
        private void button44_Click(object sender, EventArgs e)
        {
            //x^y
            a = float.Parse(textBox1.Text);
            textBox1.Text = "";
            operation = "^";
        }
        private void button17_Click(object sender, EventArgs e)
        {
            //Log
            a = float.Parse(textBox1.Text);
            double y = Math.Log10(a);
            textBox1.Text = y.ToString();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            //Exp
            a = float.Parse(textBox1.Text);
            double y = Math.Exp(a);
            textBox1.Text = y.ToString();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            //Ln
            a = float.Parse(textBox1.Text);
            double y = Math.Log(a);
            textBox1.Text = y.ToString();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            //10^x
            a = float.Parse(textBox1.Text);
            double y = Math.Pow(10, a);
            textBox1.Text = y.ToString();
        }
        private void button41_Click(object sender, EventArgs e)
        {
            //x^(1/y)
            a = float.Parse(textBox1.Text);
            textBox1.Text = "";
            operation = "^(1/y)";
        }
        private void button13_Click(object sender, EventArgs e)
        {
            //Sqrt
            a = int.Parse(textBox1.Text);
            double sf = Math.Sqrt(a);
            textBox1.Text = sf.ToString();
        }
        private void button43_Click(object sender, EventArgs e)
        {
            //x^2
            a = float.Parse(textBox1.Text);
            c = a * a;
            textBox1.Text = c.ToString();
        }
        private void button26_Click(object sender, EventArgs e)
        {
            //x^3
            a = float.Parse(textBox1.Text);
            c = a * a*a;
            textBox1.Text = c.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //  "("
            textBox1.Text = textBox1.Text + "(";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //  ")"
            textBox1.Text = textBox1.Text + ")";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //1/X
             a = float.Parse(textBox1.Text);
             c = 1 / a;
            textBox1.Text = c.ToString();
        }
        private void button27_Click(object sender, EventArgs e)
        {
            //x^(1/3)
            a = float.Parse(textBox1.Text);
            double sf = Math.Ceiling(Math.Pow(a, (double)1 / 3));
            textBox1.Text = sf.ToString();
        }
        private void button42_Click(object sender, EventArgs e)
        {
            //Factorial
            a = int.Parse(textBox1.Text);
            double f = 1;
            for (int i = 1; i <= a; i++)
            {
                f = f * i;
            }
            textBox1.Text = f.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Pi
            textBox1.Text = textBox1.Text + "3.1415926535897932384626433832795";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

    }
}
