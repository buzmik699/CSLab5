using System;
using System.Drawing;
using System.Windows.Forms;

namespace App1
{
    public partial class Form6 : Form
    {
        // Поле для работы с графикой
        Graphics Graph;

        // Поле для работы с временем
        DateTime sec;

        // Поле для генерации случайных чисел
        Random Rand;

        // Поле для хранения объекта пера, которым будут рисоваться контуры эллипсов
        Pen MyPen;

        // Поле для хранения кисти, используемой для заливки (изначально чёрного цвета)
        SolidBrush MyBrush = new SolidBrush(Color.Black);

        // Массив цветов, которые будут использоваться на каждом уровне вложенности
        Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Yellow };

        
        public Form6()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black, 1);
            Rand = new Random();
        }

        
        void Ellipse(int n, int x, int y, int r, int r1)
        {
            // Заливка эллипса на текущем уровне вложенности с использованием цвета из массива
            Graph.FillEllipse(new SolidBrush(colors[n]), x, y, r, r);

            // Проверка, достигнут ли последний уровень вложенности (n > 0)
            if (n > 0)
            {
                // Рекурсивный вызов для рисования левого эллипса
                Ellipse(n - 1, x - r1 - r / 2, y + r / 4, r / 2, r1 / 4);

                // Рекурсивный вызов для рисования правого эллипса
                Ellipse(n - 1, x + r1 + r, y + r / 4, r / 2, r1 / 4);

                // Рекурсивный вызов для рисования верхнего эллипса
                Ellipse(n - 1, x + r / 4, y - r1 - r / 2, r / 2, r1 / 4);

                // Рекурсивный вызов для рисования нижнего эллипса
                Ellipse(n - 1, x + r / 4, y + r1 + r, r / 2, r1 / 4);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
        }

        private void Form6_Shown(object sender, EventArgs e)
        {
            // Вызов метода для рисования эллипсов с заданным уровнем вложенности и координатами центра
            Ellipse(3, ClientSize.Width / 2 - 25, ClientSize.Height / 2 - 25, 50, 60);
        }
    }
}

