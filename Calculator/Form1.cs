using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caculator;

namespace Calculator
{
    public partial class Form1 : Form
    {

        private Calculator caculator;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            caculator = new Calculator();
        }

        private void num_Click(object sender, EventArgs e)
        {
            Button numBtn = (Button)sender;
            caculator.putElement(numBtn.Text.First());
            result.Text = caculator.getDisplay();
        }

        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            caculator.putElement(btn.Text.First());
            result.Text = caculator.getDisplay();
        }

        private void dot_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            caculator.putElement(btn.Text.First());
            result.Text = caculator.getDisplay();
        }

        private void calc_Click(object sender, EventArgs e)
        {
            string calc = caculator.calc();
            if (calc != null)
            {
                result.Text = calc;
                caculator.reset();
                caculator.initLeftValue(calc);
            }
        }
    }
}
