using System;
using System.Drawing;
using System.Windows.Forms;

namespace App1
{
    public partial class Form5 : Form
    {
        private Random random = new Random();
        private Timer fallTimer;
        private Snowflake currentSnowflake;

        public Form5()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Включить двойную буферизацию для уменьшения мерцания

            fallTimer = new Timer();
            fallTimer.Interval = 30; // Частота обновления снега
            fallTimer.Tick += FallTimer_Tick;

            this.MouseClick += Form5_MouseClick;
        }

       

        private void Form5_MouseClick(object sender, MouseEventArgs e)
        {
            int size = random.Next(50, 100); // Генерация случайного размера
            int nestingLevel = 3; // Уровень вложенности

            // Создаем новую снежинку
            currentSnowflake = new Snowflake(e.X, e.Y, size, nestingLevel);
            fallTimer.Start(); // Запуск таймера для анимации
        }

        private void FallTimer_Tick(object sender, EventArgs e)
        {
            if (currentSnowflake != null)
            {
                currentSnowflake.Fall(5); // Скорость падения

                // Проверка, достигла ли снежинка нижнего края формы
                if (currentSnowflake.PositionY > this.Height)
                {
                    fallTimer.Stop();
                    currentSnowflake = null;
                }

                this.Invalidate(); // Обновление формы для перерисовки
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Рисуем текущую снежинку
            if (currentSnowflake != null)
            {
                currentSnowflake.Draw(e.Graphics);
            }
        }
    }

    public class Snowflake
    {
        // Свойство, которое хранит текущую координату X снежинки
        public int PositionX;

        // Свойство, которое хранит текущую координату Y снежинки
        public int PositionY;

        // Переменная для хранения размера снежинки
        private int size;

        // Переменная для хранения уровня вложенности (глубины рекурсии)
        private int nestingLevel;

        // Конструктор класса Snowflake, принимающий координаты, размер и уровень вложенности
        public Snowflake(int x, int y, int size, int nestingLevel)
        {
            // Устанавливаем координату X снежинки
            this.PositionX = x;

            // Устанавливаем координату Y снежинки
            this.PositionY = y;

            // Устанавливаем размер снежинки
            this.size = size;

            // Устанавливаем уровень вложенности снежинки
            this.nestingLevel = nestingLevel;
        }

        // Метод, который управляет падением снежинки, увеличивая её координату Y
        public void Fall(int speed)
        {
            // Увеличиваем координату Y на значение скорости (перемещение вниз)
            PositionY += speed;
        }

        // Метод для рисования снежинки на заданной графической поверхности (Graphics)
        public void Draw(Graphics g)
        {
            // Вызываем рекурсивный метод рисования снежинки, передавая текущие координаты, размер и уровень вложенности
            DrawSnowflake(g, PositionX, PositionY, size, nestingLevel);
        }

        // Приватный метод, который рисует снежинку рекурсивным образом
        private void DrawSnowflake(Graphics g, int x, int y, int size, int nestingLevel)
        {
            // Базовый случай: если уровень вложенности равен нулю, останавливаем рекурсию
            if (nestingLevel == 0)
                return;

            // Создаем ручку для рисования линий (черного цвета, толщиной 1)
            Pen pen = new Pen(Color.Black, 1);

            // Угол между лучами снежинки (в радианах), здесь это 45 градусов (π / 4)
            double angleIncrement = Math.PI / 4;

            // Цикл для рисования 8 лучей снежинки
            for (int i = 0; i < 8; i++)
            {
                // Вычисляем угол текущего луча
                double angle = i * angleIncrement;

                // Вычисляем конечные координаты луча (по формуле для круговых координат)
                int xEnd = (int)(x + size * Math.Cos(angle));
                int yEnd = (int)(y + size * Math.Sin(angle));

                // Рисуем линию от центра (x, y) до конечной точки (xEnd, yEnd)
                g.DrawLine(pen, x, y, xEnd, yEnd);

                // Рекурсивный вызов для рисования меньших снежинок на концах текущих лучей
                DrawSnowflake(g, xEnd, yEnd, size / 3, nestingLevel - 1);
            }
        }
    }

}
