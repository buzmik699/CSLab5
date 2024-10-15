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
    public partial class Form4 : Form
    {

        Graphics Graph;
        Random Rand;
        Pen MyPen;
        SolidBrush MyBrush = new SolidBrush(Color.Black);
        Font MyFont;
        public Form4()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black, 1);
            Rand = new Random();
            MyFont = new Font("Arial", 11);
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            int x0 = this.ClientSize.Width / 2;
            int y0 = this.ClientSize.Height / 2;
            int x1, y1, x2, y2, nk = 0;
            double x, y;
            const double xMin = -30;
            const double xMax = 30;
            const double step = 0.01;
            const double k = 5;
            x = xMin;
            y = x * Math.Sin(x);

            Graph.DrawLine(MyPen, x0 + (int)xMin * 5, y0, x0 + (int)xMax * 5, y0);
            Graph.DrawLine(MyPen, x0, y0 + 150, x0, y0 - 150);

            Graph.DrawString("x", MyFont, Brushes.Black, x0 + (int)xMax * 5 + 5, y0 - 5);
            Graph.DrawString("y", MyFont, Brushes.Black, x0 - 5, y0 - 150 - 20);

            Graph.DrawLine(MyPen, x0 + (int)xMax * 5, y0, x0 + (int)xMax * 5 - 10, y0 - 10);
            Graph.DrawLine(MyPen, x0 + (int)xMax * 5, y0, x0 + (int)xMax * 5 - 10, y0 + 10);

            Graph.DrawLine(MyPen, x0, y0 - 150, x0 - 10, y0 - 150 + 10);
            Graph.DrawLine(MyPen, x0, y0 - 150, x0 + 10, y0 - 150 + 10);

            while(nk != 13)
            {
                Graph.DrawLine(MyPen, x0 - 150 + 5 * nk * 5, y0 -3, x0 - 150 + 5 * nk * 5, y0 + 3);
                Graph.DrawLine(MyPen, x0 - 3, y0 - 150 + 5 * nk * 5, x0 + 3, y0 - 150 + 5 * nk * 5);
                nk++;
            }
            //соответствующие им экранные координаты
            x1 = (int)(x0 + x * k);
            y1 = (int)(y0 - y * k);
            while (x < xMax)
            {
                //определение фактических координат графика в следующей точке
                x = x + step;
                y = x * Math.Sin(x);
                //соответствующие им экранные координаты
                x2 = (int)(x0 + x * k);
                y2 = (int)(y0 - y * k);
                //вывод отрезка графика на экран
                Graph.DrawLine(MyPen, x1, y1, x2, y2);
                //запоминаем текущие координаты
                x1 = x2;
                y1 = y2;

            }
            int c = 5;
        }
    }
}
