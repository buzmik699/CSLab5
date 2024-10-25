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

        private void Form3_Load(object sender, EventArgs e) { }

        private void Form3_Activated(object sender, EventArgs e) { }

        private void Form3_Click(object sender, EventArgs e)
        {
            int curx = 60, cury = 0; // Инициализируем координаты для рисования квадратов.
            string s = "abcdefgh";

            
            for (int i = 0; i < 8; i++)
            {
                Graph.DrawString(s[i].ToString(), MyFont, Brushes.Black, curx, 30);
                Graph.DrawString((8 - i).ToString(), MyFont, Brushes.Black, 30, curx);
                curx += 63 - 11; // Увеличиваем координату по X для следующей буквы.
            }

            curx = 50; cury = 50; // Сброс координат для рисования шахматной доски.

            // Рисуем шахматную доску.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 != 0) // Проверяем, является ли квадрат черным (по шахматным правилам).
                    {
                        Graph.DrawRectangle(MyPen, curx, cury, 50, 50); // Рисуем контур квадрата.
                        Graph.FillRectangle(MyBrush, curx, cury, 50, 50); // Закрашиваем черный квадрат.
                    }
                    curx += 50; // Увеличиваем координату по X для следующего квадрата.
                }
                cury += 50; // Увеличиваем координату по Y для следующей строки.
                curx = 50; // Сбрасываем координату по X для новой строки.
            }

            // Рисуем рамку вокруг доски.
            Graph.DrawRectangle(MyPen, 50, 50, 400, 400); // Рисуем рамку размером 400x400 пикселей.
        }
    }
}
