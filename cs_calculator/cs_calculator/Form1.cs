using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_calculator
{
    public partial class Form1 : Form
    {
        //Global Variables
        Double results = 0;
        String operation = "";
        bool enter_value = false;
        float icel, ifah, iKelvin;
        float iOperation;

        public Form1()
        {
            InitializeComponent();
        }

        // Menu strip "File" = Standard Mode
        private void StandardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 220;
            txtDisplay.Width = 190;
        }

        // Menu strip "File" = Scientific Mode
        private void ScientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 425;
            txtDisplay.Width = 395;
        }

        // Menu strip "File" = Temperature Mode
        private void TemperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 720;
            txtDisplay.Width = 395;
            txtConvert.Focus();

            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = false;

            groupBox3.Location = new Point(580, 26);
            groupBox3.Width = 400;
            groupBox3.Height = 350;


        }

        // Menu strip "File" = Mulitiplication
        private void MulitiplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 720;
            txtDisplay.Width = 395;
            txtMultiply.Focus();

            groupBox1.Visible = false;
            groupBox2.Visible = false;

            groupBox3.Visible = true;
            groupBox3.Location = new Point(420, 26);
            groupBox3.Width = 410;
            groupBox3.Height = 350;

        }

        // Initial Loading
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 220;
            txtDisplay.Width = 190;
        }

        // Button Pads(0 - 9) & "." Button Controls = button_Click
        private void button_Click(object sender, EventArgs e)
        {
            // enter_value is initially set as false as a global variable
            // if the txtDisplay = 0, it means no value has been added and the enter_value is false
            // then show no message, and reset enter_value to zero
            if ((txtDisplay.Text == "0") || (enter_value))
                txtDisplay.Text = "";
            enter_value = false;

            Button num = (Button)sender;
            if (num.Text == ".") 
            {
                // If the "." is pressed, and txtDisplay has a "." then do nothing.
                // If the "." is pressed, and txtDisplay does not have a ".", then append the button info.
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + num.Text;
               
            }
            else
                txtDisplay.Text = txtDisplay.Text + num.Text;
                // When other buttons (0 - 9) are pressed, then append the button info to the txtDisplay

        }

        // CE button Control
        private void Button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblShowOp.Text = "";
        }

        // C button Control
        private void Button3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblShowOp.Text = "";
        }

        // Back Space Button
        private void BtnSpace_Click(object sender, EventArgs e)
        {
            // Back Space Button must only work when txtDisplay is not zero
            if(txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
                // 12345 => 1234 => 123 => 12 => 1 ... Index # (0123'4') vs 1234'5'
                // txtDisplay.Text.Length => error occurs
                // txtDisplay.Text.Length -2 => error occurs
            }

            // When the txtDisplay shows nothing then it should show 0
            if(txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }

        }

        // "+", "-", "*", "/" Button Operations
        private void Arithmetic(object sender, EventArgs e)
        {
            Button num = (Button)sender; // Button Control define
            operation = num.Text; // Set the button info to operation variable
            results = Double.Parse(txtDisplay.Text);
            txtDisplay.Text = "";
            lblShowOp.Text = System.Convert.ToString(results) + " " + operation;
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            // the actual calculation carries out with this button operation

            lblShowOp.Text = "";
            switch(operation)
            {
                case "+":
                    txtDisplay.Text = (results + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (results - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (results * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (results / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "Mod":
                    txtDisplay.Text = (results % Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "Exp":
                    double i = Double.Parse(txtDisplay.Text);
                    double q;
                    q = (results);
                    txtDisplay.Text = Math.Exp(i*Math.Log(q*4)).ToString();
                    break;
  
            }

        }

        // "Pi" Button
        private void Button21_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "3.141592653589976323";
        }

        // "Log" Button
        private void BtnLog_Click(object sender, EventArgs e)
        {
            double ilog = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("log" + "(" + (txtDisplay.Text) + ")");
            ilog = Math.Log10(ilog);
            txtDisplay.Text = System.Convert.ToString(ilog);

        }

        // "Sqrt" Button
        private void BtnSqrt_Click(object sender, EventArgs e)
        {
            double sq = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Sqrt" + "(" + (txtDisplay.Text) + ")");
            sq = Math.Sqrt(sq);
            txtDisplay.Text = System.Convert.ToString(sq);
        }

        //"Sinh" Button
        private void BtnSinh_Click(object sender, EventArgs e)
        {
            double qSinh = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Sinh" + "(" + (txtDisplay.Text) + ")");
            qSinh = Math.Sinh(qSinh);
            txtDisplay.Text = System.Convert.ToString(qSinh);
        }

        // "Sin" Button
        private void BtnSin_Click(object sender, EventArgs e)
        {
            double qSin = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Sin" + "(" + (txtDisplay.Text) + ")");
            qSin = Math.Sin(qSin);
            txtDisplay.Text = System.Convert.ToString(qSin);
        }

        // "Cosh" Button
        private void BtnCosh_Click(object sender, EventArgs e)
        {
            double qCosh = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Cosh" + "(" + (txtDisplay.Text) + ")");
            qCosh = Math.Cosh(qCosh);
            txtDisplay.Text = System.Convert.ToString(qCosh);
        }

        // "Cos" Button
        private void BtnCos_Click(object sender, EventArgs e)
        {
            double qCos = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Cos" + "(" + (txtDisplay.Text) + ")");
            qCos = Math.Cos(qCos);
            txtDisplay.Text = System.Convert.ToString(qCos);
        }

        // "Tanh" Button
        private void BtnTanh_Click(object sender, EventArgs e)
        {
            double qTanh = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Tanh" + "(" + (txtDisplay.Text) + ")");
            qTanh = Math.Tanh(qTanh);
            txtDisplay.Text = System.Convert.ToString(qTanh);
        }

        // "Tan" Button
        private void BtnTan_Click(object sender, EventArgs e)
        {
            double qTan = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("Tan" + "(" + (txtDisplay.Text) + ")");
            qTan = Math.Tan(qTan);
            txtDisplay.Text = System.Convert.ToString(qTan);
        }

        // "Bin" Button
        private void Bin_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(a, 2);
        }

        // "Hex" Buttton
        private void BtnHex_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(a, 16);
        }

        // "Oct" Button
        private void BtnOct_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(a, 8);
        }

        // "Dec" Button
        private void BtnDec_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtDisplay.Text);
            txtDisplay.Text = System.Convert.ToString(a);
        }

        // "X^2" Button
        private void Btnx2_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(txtDisplay.Text);
            double b = a * a;
            txtDisplay.Text = System.Convert.ToString(b);
        }

        // "X^3" Button
        private void Btnx3_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(txtDisplay.Text);
            double b = a * a * a;
            txtDisplay.Text = System.Convert.ToString(b);
        }

        // "1/X" Button
        private void Btn1overx_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(txtDisplay.Text);
            double b = 1.0 / a;
            txtDisplay.Text = System.Convert.ToString(b);
        }

        // "lnx" Button
        private void Btnlnx_Click(object sender, EventArgs e)
        {
            double ilog = Double.Parse(txtDisplay.Text);
            lblShowOp.Text = System.Convert.ToString("ln" + "(" + (txtDisplay.Text) + ")");
            ilog = Math.Log(ilog);
            txtDisplay.Text = System.Convert.ToString(ilog);
        }

        // "%" Button
        private void Btnpercent_Click(object sender, EventArgs e)
        {
            double a = Double.Parse(txtDisplay.Text);
            double b = a/100.0;
            txtDisplay.Text = System.Convert.ToString(b);
        }

        // Temperature, Radio Button : Celcius to Fahrenheit
        private void RbCeltoFah_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'C';
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            switch(iOperation)
            {

                case 'C':
                    icel = float.Parse(txtConvert.Text);
                    txtConvertResult.Text = ((((9 * icel)) / 5) + 32).ToString();
                    break;

                case 'F':
                    ifah = float.Parse(txtConvert.Text);
                    txtConvertResult.Text = (((ifah - 32) * 9) / 5).ToString();
                    break;

                case 'K':
                    iKelvin = float.Parse(txtConvert.Text);
                    txtConvertResult.Text = ((((9 * iKelvin) / 5) + 32) + 273.15).ToString();
                    break;
                   
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtConvert.Clear();
            txtConvertResult.Clear();
            rbCeltoFah.Checked = false;
            rbFahtoCel.Checked = false;
            rbKel.Checked = false;

        }

        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            int a = 0;
            a = Convert.ToInt32(txtMultiply.Text);
            for (int i = 1; i < 13; i++)
            {
                lstMultiply.Items.Add(i + "x" + a + " = " + a * i);

            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Reset Button for the multiplication section
        private void Button19_Click(object sender, EventArgs e)
        {
            txtMultiply.Clear();
            lstMultiply.Items.Clear();
        }

        // Temperature, Radio Button: Fahrenheit to Celcius
        private void RbFahtoCel_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'F';
        }

        // Temperature, Radio Button : Kelvin
        private void RbKel_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'K';
        }


    }
}
