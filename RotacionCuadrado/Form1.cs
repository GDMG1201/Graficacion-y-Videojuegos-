using System.Drawing;

namespace RotacionCuadrado
{
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        static Graphics g;
        private Point a, b, c, d;
        private int width, height;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            pictureBox1.Image = bmp;
            
            InitializePictureBox(width, height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializePictureBox(width, height);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            InitializePictureBox(width, height);

            a = new Point(0, 0);
            b = new Point(0, 100);
            c = new Point(100, 100);
            d = new Point(100, 0);

            Double.TryParse(textBox1.Text, out double text);
            double angle = text * (Math.PI / 180);

            Render(a, b,angle);
            Render(b, c,angle);
            Render(c, d,angle);
            Render(d, a,angle);

            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InitializePictureBox(width, height);
            a = new Point(-50, -50);
            b = new Point(-50, 50);
            c = new Point(50, 50);
            d = new Point(50, -50);

            Double.TryParse(textBox1.Text, out double text);
            double angle = text * (Math.PI / 180);

            Render(a, b,angle);
            Render(b, c,angle);
            Render(c, d, angle);
            Render(d, a,angle);

            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InitializePictureBox(width, height);
            a = new Point(0, 0);
            b = new Point(0, 100);
            c = new Point(100, 100);
            d = new Point(100, 0);

            Double.TryParse(textBox1.Text, out double text);
            double angle = text * (Math.PI / 180);

            RenderLine(a, b,angle);
            RenderLine(b, c,angle);
            RenderLine(c, d,angle);
            RenderLine(d, a,angle);

            pictureBox1.Invalidate();
        }

       

        private void Render(Point a, Point b, double angle)
        {

            PointF a2, b2;
            int Sx = (bmp.Width / 2);
            int Sy = (bmp.Height / 2);
            a2 = new PointF(Sx + a.X, Sy - a.Y);
            b2 = new PointF(Sx + b.X, Sy - b.Y);
            a2.X = Sx + (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            a2.Y = Sy - (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));
            b2.X = Sx + (float)((b.X * Math.Cos(angle)) - (b.Y * Math.Sin(angle)));
            b2.Y = Sy - (float)((b.X * Math.Sin(angle)) + (b.Y * Math.Cos(angle)));
            g.DrawLine(Pens.PaleGreen, a2, b2);
            pictureBox1.Invalidate();
        }

        private PointF Rotate(PointF a, double angle)
        {
            PointF b = new PointF();
            b.X = (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            b.Y = (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));
            return b;
        }

        private PointF Translate(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        private PointF TranslateToCenter(PointF a)
        {
            int Sx = (bmp.Width / 2); // origen central en x
            int Sy = (bmp.Height / 2); // origen central en y

            return new PointF(Sx + a.X, Sy - a.Y);
        }

        private void RenderLine(PointF a, PointF b, double angle)
        {
            a = Translate(a, new PointF(-50, -50)); // centroide
            b = Translate(b, new PointF(-50, -50)); // centroide
            PointF c = Rotate(a, angle);
            PointF d = Rotate(b, angle);
            c = TranslateToCenter(c);
            d = TranslateToCenter(d);
            c = Translate(c, new PointF(50, -50));
            d = Translate(d, new PointF(50, -50));

            g.DrawLine(Pens.PaleGreen, c, d);
        }



        private void InitializePictureBox(int width, int height)
        {
            bmp = new Bitmap(width, height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);

            Pen pen = new Pen(Color.White, 3);
            g.DrawLine(pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
        }

    }
}