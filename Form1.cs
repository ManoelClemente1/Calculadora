using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        double results = 0;
        string operador = "";
        bool enter_value = false;
        float CelsiusT, FahrenheitT;
        char operadorT;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void click_num(object sender, EventArgs e)
        {
            if ((txtValor.Text == "0") || (enter_value))
                txtValor.Clear();
                 //label1.Text   = "";

            enter_value = false;

            Button num = (Button)sender;

            if (num.Text == ",")
            {
                if (!txtValor.Text.Contains(","))

                    txtValor.Text = txtValor.Text + num.Text;
                  //  label1.Text   = label1.Text   + num.Text;
            }
            else
                 txtValor.Text = txtValor.Text + num.Text;
                 //label1.Text   = txtValor.Text + num.Text;
        }   

        private void btnZera_Click(object sender, EventArgs e)
        {
            txtValor.Text = "";
            //label1.Text   = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 342;
            txtValor.Width = 298;

        }

        private void temperaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 691;
            txtConvert.Focus();
            
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 342;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            if (txtValor.Text .Length > 0)
            {
                txtValor.Text = txtValor.Text.Remove(txtValor.Text.Length - 1, 1);                
            }
            //if (label1.Text.Length > 0)
            //    label1.Text = txtValor.Text.Remove(label1.Text.Length - 1, 1);

            if (txtValor.Text == "")
            {
                txtValor.Text = "0";
            }
            //if (label1.Text == "")
            //{
            //   label1.Text = "0";
            ////}
        }

        private void click_operacao(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            operador = num.Text;
            results = Double.Parse(txtValor.Text);
            txtValor.Text = "";
            enter_value = true;
            //label1.Text = System.Convert.ToString(results) + " " + operador;
            txtValor.Text = System.Convert.ToString(results) + "" + operador;
        }

        private void rbCelParaFah_CheckedChanged(object sender, EventArgs e)
        {
            operadorT = 'C';
        }

        private void rbFahParaCel_CheckedChanged(object sender, EventArgs e)
        {
            operadorT = 'F';
        }

        private void rbKevin_CheckedChanged(object sender, EventArgs e)
        {
            operadorT = 'K';
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            
            switch(operador)
            {
                case "+":
                    txtValor.Text = (results + Double.Parse(txtValor.Text)).ToString();
                    break;
                case "-":
                    txtValor.Text = (results - Double.Parse(txtValor.Text)).ToString();
                    break;
                case "*":
                    txtValor.Text = (results * Double.Parse(txtValor.Text)).ToString();
                    break;
                case "/":
                    txtValor.Text = (results / Double.Parse(txtValor.Text)).ToString();
                    break;
                case "%":
                    double a;
                    a = Convert.ToDouble(txtValor.Text) / Convert.ToDouble(100);
                    txtValor.Text = System.Convert.ToString(a);
                    break;
                default:
                    break;
              
                

            }
            results = Double.Parse(txtValor.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtResultT.Clear();
            txtConvert.Text = "";
            rbCelParaFah.Checked = false;
            rbFahParaCel.Checked = false;
        }

        private void btnResetMulti_Click(object sender, EventArgs e)
        {            
            txtM.Clear();
            lstMulti.Items.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int a;
            a = Convert.ToInt32(txtM.Text);
            for (int i = 1; i<13; i++)
            {
                lstMulti.Items.Add(i + " x" + a + " = " + a * i);

            }
       

        }

        private void tabuadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 959;
            txtM.Focus();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            switch (operadorT)
            {
                case 'C':
                
                    if ((txtConvert.Text == "") || (txtResultT.Text == " "))
                    {
                        
                        MessageBox.Show("Nenhum valor encontrado para conversão");
                        
                    }
                    else
                        CelsiusT = float.Parse(txtConvert.Text);
                        txtResultT.Text = (((CelsiusT * 1.8) + 32).ToString());

                    break;
                case 'F':
                   
                    if(txtConvert.Text == "")
                    {
                        MessageBox.Show("Nenhum valor encontrado para conversão");
                       

                    }
                    else
                        FahrenheitT = float.Parse(txtConvert.Text);
                        txtResultT.Text = ((((FahrenheitT - 32) * 5) / 9).ToString());

                    break;
                default:
                    break;
            }
        }
    }
}
