using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;


namespace Pelotas
{
    public partial class Pelotas : Form
    {
        static List<Pelota> balls;
        static Bitmap bmp;
        static Graphics g;
        static Random rand = new Random();
        static float deltaTime; 
        Emitter emitter;
        //Image image = Image.FromFile("C:/Users/garci/Downloads/burbuja.png");
        Image image = Resource1.Burbuja;
        int transparencia = 50;


        public Pelotas()
        {
            InitializeComponent();
            
        }

        private void Init()
        {
            if (PCT_CANVAS.Width == 0)
                return;

            balls       = new List<Pelota>();
            bmp         = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g           = Graphics.FromImage(bmp);
            deltaTime   = 1;
            PCT_CANVAS.Image = bmp;
            emitter = new Emitter(600, 480);

            for (int b = 0; b < 10; b++)
                balls.Add(new Pelota(rand, PCT_CANVAS.Size, b));
        }

        private void Pelotas_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Pelotas_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.Transparent);

            

            Parallel.For(0, balls.Count, b =>//ACTUALIZAMOS EN PARALELO
            {
                Pelota P;
                balls[b].Update(deltaTime, balls);
                P = balls[b];
            });

            Pelota p;

            for (int b = 0; b < balls.Count; b++)
            {
                //p = balls[b];

                p = balls[b];

                // ----  codigo para variar transparencia a las burbujas// --------

                /*Bitmap bitmap = new Bitmap(image);
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        Color nuevoColor = Color.FromArgb(transparencia, pixel.R, pixel.G, pixel.B);
                        bitmap.SetPixel(x, y, nuevoColor);
                    }
                }*/
                //g.DrawImage(bitmap, new Rectangle((int)(p.x - p.radio), (int)(p.y - p.radio), (int)(p.radio * 2), (int)(p.radio * 2)));

                // ----  codigo para dibujar a las burbujas sin transparencia// --------

                g.DrawImage(image, new Rectangle((int)(p.x - p.radio), (int)(p.y - p.radio), (int)(p.radio * 2), (int)(p.radio * 2)));

                // ----  codigo para pintar pelotas de colores // --------

                //g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            }

        

            emitter = new Emitter(620, 425);
            emitter.DrawPalita(g);

            PCT_CANVAS.Invalidate();
            deltaTime += .1f;
        }
    }
}
