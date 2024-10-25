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
        // Объявление переменных для графики, случайного числа, пера, кисти и шрифта
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
        private void Form4_Load(object sender, EventArgs e) { }
        private void Form4_Shown(object sender, EventArgs e)
        {
            // Определение центра координат
            int x0 = this.ClientSize.Width / 2;
            int y0 = this.ClientSize.Height / 2;

            // Переменные для экранных координат
            int x1, y1, x2, y2, nk = 0;

            // Переменные для фактических координат графика
            double x, y;

            // Границы по оси X и шаг
            const double xMin = -30;
            const double xMax = 30;
            const double step = 0.01;
            const double k = 5; // Коэффициент масштабирования

            // Начальная точка
            x = xMin;
            y = x * Math.Sin(x);

            // Рисуем ось X
            Graph.DrawLine(MyPen, x0 + (int)xMin * 5, y0, x0 + (int)xMax * 5, y0);

            // Рисуем ось Y
            Graph.DrawLine(MyPen, x0, y0 + 150, x0, y0 - 150);

            // Подпись оси X
            Graph.DrawString("x", MyFont, Brushes.Black, x0 + (int)xMax * 5 + 5, y0 - 5);

            // Подпись оси Y
            Graph.DrawString("y", MyFont, Brushes.Black, x0 - 5, y0 - 150 - 20);

            // Рисуем стрелку на оси X
            Graph.DrawLine(MyPen, x0 + (int)xMax * 5, y0, x0 + (int)xMax * 5 - 10, y0 - 10);
            Graph.DrawLine(MyPen, x0 + (int)xMax * 5, y0, x0 + (int)xMax * 5 - 10, y0 + 10);

            // Рисуем стрелку на оси Y
            Graph.DrawLine(MyPen, x0, y0 - 150, x0 - 10, y0 - 150 + 10);
            Graph.DrawLine(MyPen, x0, y0 - 150, x0 + 10, y0 - 150 + 10);

            // Рисуем деления на осях
            while (nk != 13)
            {
                // Деления на оси X
                Graph.DrawLine(MyPen, x0 - 150 + 5 * nk * 5, y0 - 3, x0 - 150 + 5 * nk * 5, y0 + 3);

                // Деления на оси Y
                Graph.DrawLine(MyPen, x0 - 3, y0 - 150 + 5 * nk * 5, x0 + 3, y0 - 150 + 5 * nk * 5);
                nk++;
            }

            // Определяем экранные координаты для первой точки графика
            x1 = (int)(x0 + x * k);
            y1 = (int)(y0 - y * k);

            // Построение графика
            while (x < xMax)
            {
                // Определяем координаты следующей точки
                x = x + step;
                y = x * Math.Sin(x);

                // Преобразуем координаты в экранные
                x2 = (int)(x0 + x * k);
                y2 = (int)(y0 - y * k);

                // Рисуем линию между текущей и следующей точкой
                Graph.DrawLine(MyPen, x1, y1, x2, y2);

                // Сохраняем текущие координаты
                x1 = x2;
                y1 = y2;
            }
        }
    }
}

