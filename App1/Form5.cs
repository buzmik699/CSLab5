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
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                var forksCount = 8;

                DrawSnowflake(
                    graphics: g,
                    center: new Point(pictureBox1.Width / 2 ,pictureBox1.Height / 2),
                    radius: pictureBox1.Width / 3,
                    radiusScale: 1f / 3,
                    forksCount: forksCount,
                    layersCount: int.Parse(TextBox1.Text),
                    layer: 1,
                    angle: (float)(360 / forksCount * (Math.PI / 180)),
                    color: Color.Black);
            }
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec = sec.AddSeconds(1);
            if(pictureBox1.Location.Y <= this.ClientSize.Height)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 1);
            }
            else timer1.Enabled = false;
        }





        private void DrawSnowflake(Graphics graphics, Point center, int radius, float radiusScale, int forksCount, int layersCount, int layer, float angle, Color color)
        {
            for (int localForkIndex = 0; localForkIndex < forksCount; localForkIndex++)
            {
                var forkCenter = new Point(
                    (int)(center.X + radius * Math.Cos(localForkIndex * angle)),
                    (int)(center.Y + radius * Math.Sin(localForkIndex * angle)));

                graphics.DrawLine(new Pen(color), center.X, center.Y, forkCenter.X, forkCenter.Y);

                if (layer != layersCount)
                {
                    DrawSnowflake(
                        graphics: graphics,
                        center: forkCenter,
                        radius: (int)(radius * radiusScale),
                        radiusScale: radiusScale,
                        forksCount: forksCount,
                        layersCount: layersCount,
                        layer: layer + 1,
                        angle: angle,
                        color: color);
                }
            }
        }

        /// <summary>
        /// Нарисовать снежинку
        /// </summary>
        /// <param name="graphics">Графика</param>
        /// <param name="center">Центральная точка</param>
        /// <param name="radius">Радиус</param>
        /// <param name="forksCount">Количество ветвлений</param>
        /// <param name="layersCount">Количество ярусов</param>
        /// <param name="angle">Угол</param>
        /// <param name="color">Цвет</param>
        public void DrawSnowflake(Graphics graphics, Point center, int radius, float radiusScale,
            int forksCount, int layersCount, float angle, Color color)
        {
            DrawSnowflake(
                graphics: graphics,
                center: center,
                radius: radius,
                radiusScale: radiusScale,
                forksCount: forksCount,
                layersCount: layersCount,
                layer: 1,
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
