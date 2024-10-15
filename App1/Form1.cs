using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace App1
{
    public partial class MainForm : Form
    {
        Form1 form1;
        Form2 form2;
        Form3 form3;
        Form4 form4;
        Form5 form5;
        Form6 form6;
        public bool fl = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }  

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                form1 = new Form1();
                form1.Show();
                form1.Activate();
                fl = true;
            }
            if (radioButton2.Checked)
            {
                form2 = new Form2();
                form2.Show();
                form2.Activate();
                fl = true;
            }
            if (radioButton3.Checked)
            {
                form3 = new Form3();
                form3.Show();
                form3.Activate();
                fl = true;
            }
            if (radioButton4.Checked)
            {
                form4 = new Form4();
                form4.Show();
                form4.Activate();
                fl = true;
            }
            if (radioButton5.Checked)
            {
                form5 = new Form5();
                form5.Show();
                form5.Activate();
                fl = true;
            }
            if (radioButton6.Checked)
            {
                form6 = new Form6();
                form6.Show();
                form6.Activate();
                fl = true;
            }
        }
    }
}
