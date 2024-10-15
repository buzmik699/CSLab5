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
    public partial class Form1 : Form
    {
        int p1, p2, p3, p4, p5;
        Graphics Graph;
        Random Rand;
        Pen MyPen;
        Pen MyPen2;
        DateTime sec;
        int size_of_sun = 0, loc = 0;
        bool fl = false, fl2 = false, fl3 = false, fl4 = false, fl5 = false, fl6 = false;
        SolidBrush brush;
        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Yellow, 5);
            MyPen2 = new Pen(Color.Blue, 2);
            timer1.Enabled = true;
            brush = new SolidBrush(Color.Yellow);
            Rand = new Random();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            sec = sec.AddSeconds(1);
            if (SunBox.Location.Y + SunBox.ClientSize.Width + 5 < this.ClientSize.Height && fl)// down
            {
                SunBox.Location = new Point(SunBox.Location.X, SunBox.Location.Y + 5);
                SunBox.Height -= 2;
                SunBox.Width -= 2;
            }
            else if(SunBox.Location.Y + SunBox.ClientSize.Width + 5 >= this.ClientSize.Height)
            {
                fl = false;
            }
            if(SunBox.Location.Y - 5 > 175 && !fl) // up
            {
                SunBox.Location = new Point(SunBox.Location.X, SunBox.Location.Y - 5);
                SunBox.Height += 2;
                SunBox.Width += 2;
            }
            else if (SunBox.Location.Y - 5 <= 175)
            {
                fl = true;
            }





            if (pictureBox1.Location.X + p1 < this.ClientSize.Width && fl2)// right
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + p1, pictureBox1.Location.Y);

            }
            else if (pictureBox1.Location.X + p1 >= this.ClientSize.Width)
            {
                fl2 = false;

                p1 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox1.Size = new Size(wd2, hg2);

                pictureBox1.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }
            if (pictureBox1.Location.X + pictureBox1.Width - p1 > 0 && !fl2) // left
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X - p1, pictureBox1.Location.Y);
                
            }
            else if (pictureBox1.Location.X + pictureBox1.Width - p1 <= 0)
            {
                fl2 = true;

                p1 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox1.Size = new Size(wd2, hg2);

                pictureBox1.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }


            if (pictureBox2.Location.X  + p2 < this.ClientSize.Width && fl3)// right
            {
                pictureBox2.Location = new Point(pictureBox2.Location.X + p2, pictureBox2.Location.Y);
            }
            else if (pictureBox2.Location.X + p2 >= this.ClientSize.Width)
            {
                fl3 = false;

                p2 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox2.Size = new Size(wd2, hg2);

                pictureBox2.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox2.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }
            if (pictureBox2.Location.X + pictureBox2.ClientSize.Height - p2 > 0 && !fl3) // left
            {
                pictureBox2.Location = new Point(pictureBox2.Location.X - p2, pictureBox2.Location.Y);    
            }
            else if (pictureBox2.Location.X + pictureBox2.ClientSize.Height - p2 <= 0)
            {
                fl3 = true;

                p2 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox2.Size = new Size(wd2, hg2);

                pictureBox2.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox2.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }


            if (pictureBox3.Location.X + p3 < this.ClientSize.Width && fl4)// right
            {        
                pictureBox3.Location = new Point(pictureBox3.Location.X + p3, pictureBox3.Location.Y);
            }
            else if (pictureBox3.Location.X  + p3 >= this.ClientSize.Width)
            {
                fl4 = false;

                p3 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox3.Size = new Size(wd2, hg2);

                pictureBox3.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox3.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2  - 1);
                }
            }
            if (pictureBox3.Location.X + pictureBox3.ClientSize.Height - p3 > 0 && !fl4) // left
            {
                
                pictureBox3.Location = new Point(pictureBox3.Location.X - p3, pictureBox3.Location.Y);
                
            }
            else if (pictureBox3.Location.X + pictureBox3.ClientSize.Height - p3 <= 0)
            {
                fl4 = true;

                p3 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox3.Size = new Size(wd2, hg2);

                pictureBox3.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox3.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }



            if (pictureBox4.Location.X + p4 < this.ClientSize.Width && fl5)// right
            {
               
                pictureBox4.Location = new Point(pictureBox4.Location.X + p4, pictureBox4.Location.Y);
            }
            else if (pictureBox4.Location.X  + p4 >= this.ClientSize.Width)
            {
                fl5 = false;

                p4 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox4.Size = new Size(wd2, hg2);

                pictureBox4.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox4.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }
            if (pictureBox4.Location.X + pictureBox4.ClientSize.Height - p4 > 0 && !fl5) // left
            {
                pictureBox4.Location = new Point(pictureBox4.Location.X - p4, pictureBox4.Location.Y);
               
            }
            else if (pictureBox4.Location.X + pictureBox4.ClientSize.Height - p4 <= 0)
            {
                fl5 = true;

                p4 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox4.Size = new Size(wd2 , hg2);

                pictureBox4.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox4.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }




            if (pictureBox5.Location.X + p5 < this.ClientSize.Width && fl6)// right
            {
                pictureBox5.Location = new Point(pictureBox5.Location.X + p5, pictureBox5.Location.Y);

            }
            else if (pictureBox5.Location.X  + p5 >= this.ClientSize.Width)
            {
                fl6 = false;

                p5 = Rand.Next(30);


                int wd2 = Rand.Next(100)+1;
                int hg2 = Rand.Next(100) + 1;
                pictureBox5.Size = new Size(wd2, hg2);

                pictureBox5.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox5.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }
            if (pictureBox5.Location.X + pictureBox5.ClientSize.Height - p5 > 0 && !fl6) // left
            {
                pictureBox5.Location = new Point(pictureBox5.Location.X - p5, pictureBox5.Location.Y);
            }
            else if (pictureBox5.Location.X + pictureBox5.ClientSize.Height - p5 <= 0)
            {
                fl6 = true;

                p5 = Rand.Next(30);

                int wd2 = Rand.Next(100) + 1;
                int hg2 = Rand.Next(100) +1;
                pictureBox5.Size = new Size(wd2, hg2);

                pictureBox5.Image = new Bitmap(wd2, hg2);
                using (Graphics g = Graphics.FromImage(pictureBox5.Image))
                {
                    g.Clear(BackColor);
                    g.DrawEllipse(MyPen2, 0, 0, wd2 - 1, hg2 - 1);
                }
            }







            int wd = SunBox.Width;
            int hg = SunBox.Height;
            SunBox.Image = new Bitmap(wd, hg);
            using (Graphics g = Graphics.FromImage(SunBox.Image))
            {
                g.Clear(BackColor);
                g.DrawEllipse(MyPen, 0 + wd / 4, hg / 4, wd / 2, hg / 2);
                g.FillEllipse(brush, wd / 4, hg / 4, wd / 2, hg / 2);

                g.DrawLine(MyPen, wd / 2 - wd, hg / 2, wd / 2 + wd, hg / 2);
                g.DrawLine(MyPen, wd / 2, hg / 2 - hg, wd / 2, hg / 2 + hg);

                g.DrawLine(MyPen, 0 + wd / 8, 0 + hg / 8, wd - wd / 9, wd - hg / 9);
                g.DrawLine(MyPen, 0 + wd / 8, hg - hg / 8, wd - wd / 8, 0 + hg / 8);
            }






        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int wd2 = Rand.Next(pictureBox1.Width) + 1;
            int hg2 = Rand.Next(pictureBox1.Height) + 1;

            p1 = Rand.Next(30); p2 = Rand.Next(30); p3 = Rand.Next(30); p4 = Rand.Next(30); p5 = Rand.Next(30);
            pictureBox1.Image = new Bitmap(wd2, hg2);
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                g.Clear(BackColor);
                g.DrawEllipse(MyPen2, 0, 0, wd2, hg2);
            }
            wd2 = Rand.Next(pictureBox1.Width) + 1;
            hg2 = Rand.Next(pictureBox1.Height) + 1;
            pictureBox2.Image = new Bitmap(wd2, hg2);
            using (Graphics g = Graphics.FromImage(pictureBox2.Image))
            {
                g.Clear(BackColor);
                g.DrawEllipse(MyPen2, 0, 0, wd2, hg2);
            }
            wd2 = Rand.Next(pictureBox1.Width) + 1;
            hg2 = Rand.Next(pictureBox1.Height) + 1;
            pictureBox3.Image = new Bitmap(wd2, hg2);
            using (Graphics g = Graphics.FromImage(pictureBox3.Image))
            {
                g.Clear(BackColor);
                g.DrawEllipse(MyPen2, 0, 0, wd2, hg2);
            }
            wd2 = Rand.Next(pictureBox1.Width) + 1;
            hg2 = Rand.Next(pictureBox1.Height) + 1;
            pictureBox4.Image = new Bitmap(wd2, hg2);
            using (Graphics g = Graphics.FromImage(pictureBox4.Image))
            {
                g.Clear(BackColor);
                g.DrawEllipse(MyPen2, 0, 0, wd2, hg2);
            }
            wd2 = Rand.Next(pictureBox1.Width) + 1;
            hg2 = Rand.Next(pictureBox1.Height) + 1;
            pictureBox5.Image = new Bitmap(wd2, hg2);
            using (Graphics g = Graphics.FromImage(pictureBox5.Image))
            {
                g.Clear(BackColor);
                g.DrawEllipse(MyPen2, 0, 0, wd2, hg2);
            }

        }

        private void SunBox_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
