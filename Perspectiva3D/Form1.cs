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
        Figura cubo;
        bool ejex, ejey, ejez, ejeXYZ;
        Scene scene;



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
            Pen pen1 = new Pen(Color.White, 1);
            g.DrawLine(pen1, 0, PCT_CANVAS.Height / 2, PCT_CANVAS.Width, PCT_CANVAS.Height / 2);
            g.DrawLine(pen1, PCT_CANVAS.Width / 2, 0, PCT_CANVAS.Width / 2, PCT_CANVAS.Height);

            proj = new Projection();

            a = new Vertex(new float[] { -1, -1, 1 });
            b = new Vertex(new float[] { 1, -1, 1 });
            c = new Vertex(new float[] { 1, 1, 1 });
            d = new Vertex(new float[] { -1, 1, 1 });
            f = new Vertex(new float[] { -1, -1, -1 });
            h = new Vertex(new float[] { 1, -1, -1 });
            i = new Vertex(new float[] { 1, 1, -1 });
            j = new Vertex(new float[] { -1, 1, -1 });

            cubo = new Figura(a, b, c, d, f, h, i, j);
            scene = new Scene();
            scene.Cubes.Add(cubo);

            for (int k = 0; k < scene.Cubes.Count(); k++)
            {
                if (ejex)
                {
                    a = TransformPointX(angle, a);
                    b = TransformPointX(angle, b);
                    c = TransformPointX(angle, c);
                    d = TransformPointX(angle, d);
                    f = TransformPointX(angle, f);
                    h = TransformPointX(angle, h);
                    i = TransformPointX(angle, i);
                    j = TransformPointX(angle, j);
                }
                else if (ejey)
                {
                    a = TransformPointY(angle, a);
                    b = TransformPointY(angle, b);
                    c = TransformPointY(angle, c);
                    d = TransformPointY(angle, d);
                    f = TransformPointY(angle, f);
                    h = TransformPointY(angle, h);
                    i = TransformPointY(angle, i);
                    j = TransformPointY(angle, j);
                }
                else if (ejez)
                {
                    a = TransformPointZ(angle, a);
                    b = TransformPointZ(angle, b);
                    c = TransformPointZ(angle, c);
                    d = TransformPointZ(angle, d);
                    f = TransformPointZ(angle, f);
                    h = TransformPointZ(angle, h);
                    i = TransformPointZ(angle, i);
                    j = TransformPointZ(angle, j);
                }
                else
                {
                    a = TransformPoint(angle, a);
                    b = TransformPoint(angle, b);
                    c = TransformPoint(angle, c);
                    d = TransformPoint(angle, d);
                    f = TransformPoint(angle, f);
                    h = TransformPoint(angle, h);
                    i = TransformPoint(angle, i);
                    j = TransformPoint(angle, j);
                }


                a = proj.Perspective(a);
                b = proj.Perspective(b);
                c = proj.Perspective(c);
                d = proj.Perspective(d);
                f = proj.Perspective(f);
                h = proj.Perspective(h);
                i = proj.Perspective(i);
                j = proj.Perspective(j);

                a = ScaleVertex(a, 110);
                b = ScaleVertex(b, 110);
                c = ScaleVertex(c, 110);
                d = ScaleVertex(d, 110);
                f = ScaleVertex(f, 110);
                h = ScaleVertex(h, 110);
                i = ScaleVertex(i, 110);
                j = ScaleVertex(j, 110);

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
            }

            PCT_CANVAS.Invalidate();
            angle += .03f;
        }

        private Vertex TransformPointX(float angle, Vertex a)
        {
            a = rot.Rotx(angle, a);
            return a;
        }

        private Vertex TransformPointY(float angle, Vertex a)
        {
            a = rot.Roty(angle, a);
            return a;
        }

        private Vertex TransformPointZ(float angle, Vertex a)
        {
            a = rot.Rotz(angle, a);
            return a;
        }

        private Vertex TransformPoint(float angle, Vertex a)
        {
            a = rot.Rotx(angle, a);
            a = rot.Roty(angle, a);
            a = rot.Rotz(angle, a);
            return a;
        }

        private void ejeX_Click(object sender, EventArgs e)
        { 
            if (!timer1.Enabled)
                timer1.Start();
            
            ejeXYZ = false;
            ejex = true;
            ejey = false;
            ejez = false;
        }

        private void ejeY_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Start();

            ejeXYZ = false;
            ejex = false;
            ejey = true;
            ejez = false;
        }

        private void ejeZ_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Start();

            ejeXYZ = false;
            ejex = false;
            ejey = false;
            ejez = true;
        }

        private void ejeall_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Start();

            ejeXYZ = true;
            ejex = false;
            ejey = false;
            ejez = false;
        }
    }
    
}
