using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace App1
{
    public partial class Form2 : Form
    {
        Graphics Graph;
        Random Rand;
        Pen MyPen;
        int wd, hg;
        public Form2()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black, 2);
            Rand = new Random();
        }

        private void Form2_Load(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            int k = 1, sh = 1; // Переменные для количества фигур и длины стороны квадрата
            try
            {
                // Читаем значения из текстовых полей
                k = int.Parse(TextBox1.Text);
                sh = int.Parse(TextBox2.Text);
            }
            catch
            {
                // Если введенные данные некорректны, выводим сообщение об ошибке
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Проверяем, что значения больше нуля
            if (k <= 0 || sh <= 0)
            {
                MessageBox.Show("Некорректный ввод исходных данных", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close(); // Закрываем форму в случае ошибки
            }
            Graph.Clear(this.BackColor);

            // Вычисляем центр формы и координаты для рисования первого квадрата
            wd = this.ClientSize.Width - sh;
            hg = this.ClientSize.Height - sh;
            Point[] Courn = new Point[5]; // Массив точек для углов квадрата
            Courn[0] = new Point(wd / 2, hg / 2); // Левая верхняя точка
            Courn[1] = new Point(wd / 2 + sh, hg / 2); // Правая верхняя точка
            Courn[2] = new Point(wd / 2 + sh, hg / 2 + sh); // Правая нижняя точка
            Courn[3] = new Point(wd / 2, hg / 2 + sh); // Левая нижняя точка
            Courn[4] = new Point(wd / 2, hg / 2); // Замыкаем квадрат

            // Рисуем квадраты
            DrawSquares(Graph, MyPen, Courn, k);
        }

        // Статический метод для рисования вложенных квадратов
        static void DrawSquares(Graphics g, Pen pn, Point[] Courners, int Count)
        {
            // Проверяем, что графика и количество фигур корректны
            if (g == null || Count <= 0)
                return;

            // Рисуем линии между углами квадрата
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(pn, Courners[i], Courners[i + 1]);
            }

            Point[] newCourners = new Point[5]; // Массив для новых углов квадрата

            // Проходим по всем углам квадрата
            for (int i = 0; i < 4; i++)
            {
                // Рассчитываем новые углы, находя средние значения координат двух соседних углов
                newCourners[i] = new Point(
                    // X-координата нового угла: среднее значение X текущего и следующего углов
                    (Courners[i].X + Courners[i + 1].X) / 2,
                    // Y-координата нового угла: среднее значение Y текущего и следующего углов
                    (Courners[i].Y + Courners[i + 1].Y) / 2
                );
            }
            newCourners[4] = newCourners[0]; // Замыкаем новый квадрат

            // Рекурсивно вызываем метод для рисования вложенных квадратов
            DrawSquares(g, pn, newCourners, Count - 1);
        }
    }
}

