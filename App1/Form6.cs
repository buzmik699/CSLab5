using System;
using System.Drawing;
using System.Windows.Forms;

namespace App1
{
    public partial class Form6 : Form
    {
        Graphics Graph;
        DateTime sec;
        Random Rand;
        Pen MyPen;
        SolidBrush MyBrush = new SolidBrush(Color.Black);
        Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Yellow};
        //Font MyFont;
        public Form6()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black, 1);
            Rand = new Random();
           // MyFont = new Font("Arial", 11);
        }

        void Ellipse(int n, int x, int y, int r, int r1)
        {
            Graph.FillEllipse(new SolidBrush(colors[n]), x, y, r, r);
            if (n > 0)
            { 
                Ellipse(n - 1, x - r1 - r / 2, y + r / 4, r / 2, r1 / 4);
                Ellipse(n - 1, x + r1 + r, y + r / 4, r / 2, r1 / 4);
                Ellipse(n - 1, x + r / 4, y - r1 - r / 2, r / 2, r1 / 4);
                Ellipse(n - 1, x + r / 4, y + r1 + r, r / 2, r1 / 4);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
           
        }

        private void Form6_Shown(object sender, EventArgs e)
        {
            Ellipse(3, ClientSize.Width / 2 - 25, ClientSize.Height / 2 - 25, 50, 60);
        }
    }
}
