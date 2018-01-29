using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace udaljenost_tocaka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Point point1 = new Point();
        private Point point2 = new Point();
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private double Udaljenost(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2)+ Math.Pow((y2 - y1), 2));
        }
        private void ClearColor()
        {
            // Clear screen with teal background.
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
        }
        public void DrawLinePoint()
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Graphics g = CreateGraphics();
            g.DrawLine(blackPen, point1, point2);
        }
        public void Nacrtaj_lik(MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 1);
            //g.DrawRectangle(new Pen(Brushes.Black), new Rectangle(new Point(e.X, e.Y), new Size(5, 5)));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawLine(blackPen, e.X - 3, e.Y + 3, e.X + 3, e.Y - 3);
            g.DrawLine(blackPen, e.X + 3, e.Y + 3, e.X - 3, e.Y - 3);
        
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            point2.X = e.X;
            point2.Y = e.Y;
            Nacrtaj_lik(e);
            textBox2.Text = point2.X.ToString() + "," + point2.Y.ToString();
            DrawLinePoint();
            textBox3.Text = Udaljenost(point1.X,point2.X,point1.Y,point2.Y).ToString();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            
            base.OnMouseDown(e);
            ClearColor();
            point1.X = e.X;
            point1.Y = e.Y;
            Pen blackPen = new Pen(Color.Black, 1);
            Nacrtaj_lik(e);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Text = point1.X.ToString() + "," + point1.Y.ToString();
        }

    }
}
