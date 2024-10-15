using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form3 : Form
    {
        Graphics Graph;
        Random Rand;
        Pen MyPen;
        SolidBrush MyBrush = new SolidBrush(Color.Black);
        Font MyFont;
        public Form3()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black, 2);
            Rand = new Random();
            MyFont = new Font("Arial", 11);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void Form3_Activated(object sender, EventArgs e)
        {
            
        }

        private void Form3_Click(object sender, EventArgs e)
        {
            int curx = 60, cury = 0;
            string s = "abcdefgh";
            for (int i = 0; i < 8; i++)
            {
                Graph.DrawString(s[i].ToString(), MyFont, Brushes.Black, curx, 30);
                Graph.DrawString((8 - i).ToString(), MyFont, Brushes.Black, 30, curx);
                curx += 63 - 11;
            }
            curx = 50; cury = 50;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 != 0)
                    {
                        Graph.DrawRectangle(MyPen, curx, cury, 50, 50);
                        Graph.FillRectangle(MyBrush, curx, cury, 50, 50);
                    }
                    curx += 50;
                }
                cury += 50;
                curx = 50;
            }
            Graph.DrawRectangle(MyPen, 50, 50, 400, 400);
        }
    }
}
