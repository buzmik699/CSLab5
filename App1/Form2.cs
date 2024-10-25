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
       

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
{
    int k = 1, sh = 1;
    try
    {
        k = int.Parse(TextBox1.Text);
        sh = int.Parse(TextBox2.Text);
    }
    catch
    {
        MessageBox.Show("Некорректный ввод исходных данных", "Ошибка",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    if(k <= 0 || sh <= 0)
    {
        MessageBox.Show("Некорректный ввод исходных данных", "Ошибка",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
        Close();
    }

    Graph.Clear(this.BackColor); // Очищаем форму перед рисованием

    wd = this.ClientSize.Width - sh;
    hg = this.ClientSize.Height - sh;
    Point[] Courn = new Point[5];
    Courn[0] = new Point(wd / 2, hg / 2);
    Courn[1] = new Point(wd / 2 + sh, hg / 2);
    Courn[2] = new Point(wd / 2 + sh, hg / 2 + sh);
    Courn[3] = new Point(wd / 2, hg / 2 + sh);
    Courn[4] = new Point(wd / 2, hg / 2);
    DrawSquares(Graph, MyPen, Courn, k);
}



        static void DrawSquares(Graphics g, Pen pn, Point[] Courners, int Count)
        {
            if (g == null || Count <= 0)
                return;
            for(int i = 0; i < 4; i++)
            {
                g.DrawLine(pn, Courners[i], Courners[i + 1]);
            }

            Point[] newCourners = new Point[5];

            for (int i = 0; i < 4; i++)
                newCourners[i] = new Point((Courners[i].X + Courners[i + 1].X) / 2, (Courners[i].Y + Courners[i + 1].Y) / 2);

            newCourners[4] = newCourners[0];

            DrawSquares(g, pn, newCourners, Count - 1);

        }
    }
}
