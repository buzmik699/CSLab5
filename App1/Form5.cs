using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace App1 
{
    public partial class Form5 : Form
    { 
        Graphics Graph;
        DateTime sec;
        Random Rand;
        Pen MyPen;
        SolidBrush MyBrush = new SolidBrush(Color.Black); 
        Font MyFont;

        public Form5()  
        {
            InitializeComponent(); 
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black, 1);
            Rand = new Random();
            MyFont = new Font("Arial", 11);
        }

        private void Form5_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox1.Visible = false;
            TextBox1.Enabled = false;
            label1.Visible = false;

            int k = Rand.Next(this.ClientSize.Height);
            pictureBox1.Size = new Size(k, k);
            pictureBox1.Location = new Point(e.X - k / 2, e.Y - k / 2);

            pictureBox1.Image = new Bitmap(k, k);

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))  // Создать объект графики для рисования на изображении
            {
                var forksCount = 8;  // Количество ветвей у снежинки

                // Вызов метода для рисования снежинки
                DrawSnowflake(
                    graphics: g,
                    center: new Point(pictureBox1.Width / 2, pictureBox1.Height / 2),  // Центр снежинки
                    radius: pictureBox1.Width / 3,  // Радиус снежинки
                    radiusScale: 1f / 3,  // Масштаб радиуса для ветвей
                    forksCount: forksCount,  // Количество ветвей снежинки
                    layersCount: int.Parse(TextBox1.Text),  // Количество ярусов снежинки, полученное из TextBox1
                    layer: 1,  // Первый ярус снежинки
                    angle: (float)(360 / forksCount * (Math.PI / 180)),  // Угол между ветвями снежинки
                    color: Color.Black);  // Цвет снежинки
            }

            timer1.Enabled = true;  // Включить таймер для анимации
        }

        private void timer1_Tick(object sender, EventArgs e)  // Обработчик события тика таймера
        {
            sec = sec.AddSeconds(1);  // Увеличить счетчик времени на 1 секунду

            // Если верхняя граница pictureBox1 не достигла нижней границы окна формы
            if (pictureBox1.Location.Y <= this.ClientSize.Height)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 1);  // Перемещаем картинку вниз на 1 пиксель
            }
            else timer1.Enabled = false;  // Отключаем таймер, когда картинка достигла нижней границы формы
        }

        // Метод для рисования снежинки с рекурсией
        private void DrawSnowflake(Graphics graphics, Point center, int radius, float radiusScale, int forksCount, int layersCount, int layer, float angle, Color color)
        {
            for (int localForkIndex = 0; localForkIndex < forksCount; localForkIndex++)  // Цикл по количеству ветвей
            {
                var forkCenter = new Point(  // Рассчитываем точку окончания каждой ветви
                    (int)(center.X + radius * Math.Cos(localForkIndex * angle)),
                    (int)(center.Y + radius * Math.Sin(localForkIndex * angle)));

                graphics.DrawLine(new Pen(color), center.X, center.Y, forkCenter.X, forkCenter.Y);  // Рисуем линию от центра к точке окончания ветви

                if (layer != layersCount)  // Если текущий ярус не последний
                {
                    // Рекурсивно рисуем ветви следующего яруса
                    DrawSnowflake(
                        graphics: graphics,
                        center: forkCenter,
                        radius: (int)(radius * radiusScale),  // Новый радиус для следующего яруса
                        radiusScale: radiusScale,
                        forksCount: forksCount,
                        layersCount: layersCount,
                        layer: layer + 1,  // Следующий ярус
                        angle: angle,
                        color: color);
                }
            }
        }

        /// <summary>
        /// Нарисовать снежинку
        /// </summary>
        /// <param name="graphics">Графика для рисования</param>
        /// <param name="center">Центральная точка снежинки</param>
        /// <param name="radius">Радиус снежинки</param>
        /// <param name="forksCount">Количество ветвлений у снежинки</param>
        /// <param name="layersCount">Количество ярусов снежинки</param>
        /// <param name="angle">Угол между ветвями</param>
        /// <param name="color">Цвет снежинки</param>
        public void DrawSnowflake(Graphics graphics, Point center, int radius, float radiusScale,
            int forksCount, int layersCount, float angle, Color color)
        {
            DrawSnowflake(  // Вызов основного метода рисования снежинки
                graphics: graphics,
                center: center,
                radius: radius,
                radiusScale: radiusScale,
                forksCount: forksCount,
                layersCount: layersCount,
                layer: 1,  // Начинаем с первого яруса
                angle: angle,
                color: color);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form5_Load(object sender, EventArgs e) 
        {
        }
    }
}
