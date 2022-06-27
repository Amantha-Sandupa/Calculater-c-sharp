using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Calculator : Form
    {

        Double resultValue = 0;
        String operetionPerfomed = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((txtResult.Text == "0") || (isOperationPerformed)) {
                txtResult.Clear();
            }
            isOperationPerformed = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if(!txtResult.Text.Contains("."))
                    txtResult.Text = txtResult.Text + button.Text;
            }
        
            else
            {
                txtResult.Text = txtResult.Text + button.Text;
            }
        }

        private void operetorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                buttonEq.PerformClick();
                operetionPerfomed = button.Text;
                lblText.Text = resultValue + " " + operetionPerfomed;
                isOperationPerformed = true;

            }
            else
            {

                operetionPerfomed = button.Text;
                resultValue = Double.Parse(txtResult.Text);
                lblText.Text = resultValue + " " + operetionPerfomed;
                isOperationPerformed = true;
            }
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
           
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            resultValue = 0;
            lblText.Text = "";
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            switch (operetionPerfomed) {
                case "+":
                    txtResult.Text = (resultValue+Double.Parse(txtResult.Text)).ToString();
                    break;
                case "-":
                    txtResult.Text = (resultValue - Double.Parse(txtResult.Text)).ToString();
                    break;
                case "*":
                    txtResult.Text = (resultValue * Double.Parse(txtResult.Text)).ToString();
                    break;
                case "/":
                    txtResult.Text = (resultValue / Double.Parse(txtResult.Text)).ToString();
                    break;
                default:
                    break;
            }

            resultValue = Double.Parse(txtResult.Text);
            lblText.Text = "";
        }
    }
}
