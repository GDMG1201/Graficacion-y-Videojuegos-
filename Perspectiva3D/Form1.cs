using System.Windows.Forms;

namespace Demo3D
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        float angle = 0;
        Rotation rot = new Rotation();
        Vertex a, b, c, d, f, h, i, j;
        Projection proj;

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            PCT_CANVAS.Image = bmp;
            g = Graphics.FromImage(bmp);
            Init();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Init()
        { 
            PCT_CANVAS.Invalidate();
        }

        private Vertex TraslateCenter(Vertex a, int x, int y)
        {
            return new Vertex(new float[]
            {
                a.x + x, a.y + y,a.z 
            });
        }

        private Vertex ScaleVertex(Vertex a, float f)
        {
            return new Vertex(new float[]
            {
                a.x *f, a.y *f, a.z *f
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Black);

            Pen pen = new Pen(Color.White, 3);
            g.DrawLine(pen, 0, PCT_CANVAS.Height / 2, PCT_CANVAS.Width, PCT_CANVAS.Height / 2);
            g.DrawLine(pen, PCT_CANVAS.Width / 2, 0, PCT_CANVAS.Width / 2, PCT_CANVAS.Height);

            proj = new Projection();

            a = new Vertex(new float[] { -1, -1, -1 });
            b = new Vertex(new float[] { 1, -1, -1 });
            c = new Vertex(new float[] { 1, 1, -1 });
            d = new Vertex(new float[] { -1, 1, -1 });
            f = new Vertex(new float[] { -1, -1, 1 });
            h = new Vertex(new float[] { 1, -1, 1 });
            i = new Vertex(new float[] { 1, 1, 1 });
            j = new Vertex(new float[] { -1, 1, 1 });

            a = TransformPoint(angle, a);
            b = TransformPoint(angle, b);
            c = TransformPoint(angle, c);
            d = TransformPoint(angle, d);
            f = TransformPoint(angle, f);
            h = TransformPoint(angle, h);
            i = TransformPoint(angle, i);
            j = TransformPoint(angle, j);

            a = proj.Perspective(a);
            b = proj.Perspective(b);
            c = proj.Perspective(c);
            d = proj.Perspective(d);
            f = proj.Perspective(f);
            h = proj.Perspective(h);
            i = proj.Perspective(i);
            j = proj.Perspective(j);

            a = ScaleVertex(a, 15);
            b = ScaleVertex(b, 15);
            c = ScaleVertex(c, 15);
            d = ScaleVertex(d, 15);
            f = ScaleVertex(f, 15);
            h = ScaleVertex(h, 15);
            i = ScaleVertex(i, 15);
            j = ScaleVertex(j, 15);

            a = TraslateCenter(a, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            b = TraslateCenter(b, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            c = TraslateCenter(c, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            d = TraslateCenter(d, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            f = TraslateCenter(f, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            h = TraslateCenter(h, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            i = TraslateCenter(i, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            j = TraslateCenter(j, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);

            // Cara delantera
            g.DrawLine(pen, a.x, a.y, b.x, b.y);
            g.DrawLine(pen, b.x, b.y, c.x, c.y);
            g.DrawLine(pen, c.x, c.y, d.x, d.y);
            g.DrawLine(pen, d.x, d.y, a.x, a.y);

            //Cara posterior
            g.DrawLine(pen, f.x, f.y, h.x, h.y);
            g.DrawLine(pen, h.x, h.y, i.x, i.y);
            g.DrawLine(pen, i.x, i.y, j.x, j.y);
            g.DrawLine(pen, j.x, j.y, f.x, f.y);

            //Cara superior
            g.DrawLine(pen, a.x, a.y, f.x, f.y);
            g.DrawLine(pen, f.x, f.y, h.x, h.y);
            g.DrawLine(pen, h.x, h.y, b.x, b.y);
            g.DrawLine(pen, b.x, b.y, a.x, a.y);

            //Cara inferior
            g.DrawLine(pen, d.x, d.y, c.x, c.y);
            g.DrawLine(pen, c.x, c.y, i.x, i.y);
            g.DrawLine(pen, i.x, i.y, j.x, j.y);
            g.DrawLine(pen, j.x, j.y, d.x, d.y);

            //Cara lateral derecha
            g.DrawLine(pen, b.x, b.y, h.x, h.y);
            g.DrawLine(pen, h.x, h.y, i.x, i.y);
            g.DrawLine(pen, i.x, i.y, c.x, c.y);
            g.DrawLine(pen, c.x, c.y, b.x, b.y);

            //Cara lateral izquierda
            g.DrawLine(pen, a.x, a.y, d.x, d.y);
            g.DrawLine(pen, d.x, d.y, j.x, j.y);
            g.DrawLine(pen, j.x, j.y, f.x, f.y);
            g.DrawLine(pen, f.x, f.y, a.x, a.y);

            /*g.FillEllipse(Brushes.AliceBlue, a.x - 5, a.y - 5, 10, 10);
            g.FillEllipse(Brushes.AliceBlue, b.x - 5, b.y - 5, 10, 10);
            g.FillEllipse(Brushes.AliceBlue, c.x - 5, c.y - 5, 10, 10);
            g.FillEllipse(Brushes.AliceBlue, d.x - 5, d.y - 5, 10, 10);*/

            PCT_CANVAS.Invalidate();
            angle += .03f;
        }

        private Vertex TransformPoint(float angle, Vertex a)
        {
            a = rot.Roty(angle, a);
            return a;
        }
    }
}
