namespace Demo3D
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        float angle;
        Rotation rot;
        Vertex a, b, c, d;
        Projection proj;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            angle = 0;
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            rot = new Rotation();
            PCT_CANVAS.Image = bmp;
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
            proj = new Projection();

            a = new Vertex(new float[] { -1, -1, 1 });
            b = new Vertex(new float[] { 1, -1, 1 });
            c = new Vertex(new float[] { 1, 1, 1 });
            d = new Vertex(new float[] { -1, 1, 1 });

            a = TransformPoint(angle, a);
            b = TransformPoint(angle, b);
            c = TransformPoint(angle, c);
            d = TransformPoint(angle, d);

            a = proj.Perspective(a);
            b = proj.Perspective(b);
            c = proj.Perspective(c);
            d = proj.Perspective(d);

            a = ScaleVertex(a, 100);
            b = ScaleVertex(b, 100);
            c = ScaleVertex(c, 100);
            d = ScaleVertex(d, 100);

            a = TraslateCenter(a, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            b = TraslateCenter(b, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            c = TraslateCenter(c, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);
            d = TraslateCenter(d, PCT_CANVAS.Width / 2, PCT_CANVAS.Height / 2);

            g.DrawLine(Pens.Red, a.x, a.y, b.x, b.y);
            g.DrawLine(Pens.Green, b.x, b.y, c.x, c.y);
            g.DrawLine(Pens.Blue, c.x, c.y, d.x, d.y);
            g.DrawLine(Pens.BlueViolet, d.x, d.y, a.x, a.y);

            g.FillEllipse(Brushes.AliceBlue, a.x-5, a.y-5, 10, 10);
            g.FillEllipse(Brushes.AliceBlue, b.x-5, b.y-5, 10, 10);
            g.FillEllipse(Brushes.AliceBlue, c.x-5, c.y-5, 10, 10);
            g.FillEllipse(Brushes.AliceBlue, d.x-5, d.y-5, 10, 10);

            PCT_CANVAS.Invalidate();
            angle += .03f;
        }

        private Vertex TransformPoint(float angle, Vertex a)
        {
            a = rot.Rotz(angle, a);
            return a;
        }
    }
}