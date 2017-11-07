using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace logic_gates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int and(int Num1, int Num2)
        {
            int answer = 0;
            answer = Num1 & Num2;
            return answer;

        }
        private int OR(int Num1, int Num2)
        {
            int answer = 0;
            answer = Num1 | Num2;
            return answer;

        }
        private int XOR(int Num1, int Num2)
        {
            int answer = 0;
            if (Num1 == Num2)
            {

                return answer;
            }
            else
                return 1;
        }
        private int NOT(int Num1)
        {
            int answer = 0;
            if (Num1 == 1)
            {

                return answer;
            }
            else
                return 1;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int Number1 = int.Parse(textBox1.Text);
            int Number2 = int.Parse(textBox2.Text);

            int result = 0;
            result+= and(Number1, Number2);
           textBox3.Text = " The Result  =" + result.ToString();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            int Number1 = int.Parse(textBox1.Text);
            int Number2 = int.Parse(textBox2.Text);

            int result = 0;
            result += XOR(Number1, Number2);
            textBox3.Text = " The Result  =" + result.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Number1 = int.Parse(textBox1.Text);
            int Number2 = int.Parse(textBox2.Text);

            int result = 0;
            result += OR(Number1, Number2);
            textBox3.Text = " The Result  =" + result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Number1 = int.Parse(textBox1.Text);
           
            int result = 0;
            result += NOT(Number1);
            textBox3.Text = " The Result  =" + result.ToString();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.button1, "The AND gate is an electronic circuit that gives a high output (1) only if all its inputs are high.Similar to the process of multiplication ");
            toolTip1.SetToolTip(this.button2, "The 'Exclusive-OR' gate is a circuit which will give a high output if either, but not both, of its two inputs are high.Opposite of (OR) ");
           toolTip1.SetToolTip(this.button3, "The NOT gate is an electronic circuit that produces an inverted version of the input at its output.  It is also known as an inverter. ");
           toolTip1.SetToolTip(this.button4, "The OR gate is an electronic circuit that gives a high output (1) if one or more of its inputs are high.  A plus (+) is used to show the OR operation.");
           toolTip1.SetToolTip(this.label1, "A logic gate is an elementary building block of a digital circuit. Most logic gates have two inputs and one output.");
           
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }
    }
}
