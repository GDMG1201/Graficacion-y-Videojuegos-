namespace pruebacolisionq
{
    public partial class Form1 : Form
    {
        private Bitmap bmp;
        static Graphics g;
        private pelota pelota1, pelota2, pelota3, pelota4, pelota5;

        public Form1()
        {
            InitializeComponent();
            pelota1 = new pelota();
            pelota2= new pelota();
            pelota3= new pelota();
            pelota4= new pelota();
            pelota5= new pelota();

            timer2.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
        }

        private bool Collision(pelota a, pelota b)
        {
            float dx = a.x - b.x;
            float dy = a.y - b.y;
            float distance = (float)Math.Sqrt(dx * dx + dy * dy);
            return (distance) < (a.radio + b.radio);
        }

        

       
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Collision(pelota1, pelota2))
            {
                pelota1.velx = -pelota1.velx;
                pelota1.vely = -pelota1.vely;

                pelota2.velx = -pelota2.velx;
                pelota2.vely = -pelota2.vely;
            }

            if (Collision(pelota1, pelota3))
            {
                pelota1.velx = -pelota1.velx;
                pelota1.vely = -pelota1.vely;

                pelota3.velx = -pelota3.velx;
                pelota3.vely = -pelota3.vely;
            }

            if (Collision(pelota1, pelota4))
            {
                pelota1.velx = -pelota1.velx;
                pelota1.vely = -pelota1.vely;

                pelota4.velx = -pelota4.velx;
                pelota4.vely = -pelota4.vely;
            }

            if (Collision(pelota1, pelota5))
            {
                pelota1.velx = -pelota1.velx;
                pelota1.vely = -pelota1.vely;

                pelota5.velx = -pelota5.velx;
                pelota5.vely = -pelota5.vely;
            }
             ///////////////////////////////

            if (Collision(pelota2, pelota3))
            {
                pelota2.velx = -pelota2.velx;
                pelota2.vely = -pelota2.vely;

                pelota3.velx = -pelota3.velx;
                pelota3.vely = -pelota3.vely;
            }

            if (Collision(pelota2, pelota4))
            {
                pelota2.velx = -pelota2.velx;
                pelota2.vely = -pelota2.vely;

                pelota4.velx = -pelota4.velx;
                pelota4.vely = -pelota4.vely;
            }

            if (Collision(pelota2, pelota5))
            {
                pelota2.velx = -pelota2.velx;
                pelota2.vely = -pelota2.vely;
                
                pelota5.velx = -pelota5.velx;
                pelota5.vely = -pelota5.vely;
            }

            ///////////////////////////////

            if (Collision(pelota3, pelota4))
            {
                pelota3.velx = -pelota3.velx;
                pelota3.vely = -pelota3.vely;

                pelota4.velx = -pelota4.velx;
                pelota4.vely = -pelota4.vely;
            }

            if (Collision(pelota3, pelota5))
            {
                pelota3.velx = -pelota3.velx;
                pelota3.vely = -pelota3.vely;

                pelota5.velx = -pelota5.velx;
                pelota5.vely = -pelota5.vely;
            }

            ///////////////////////////////

            if (Collision(pelota4, pelota5))
            {
                pelota4.velx = -pelota4.velx;
                pelota4.vely = -pelota4.vely;

                pelota5.velx = -pelota5.velx;
                pelota5.vely = -pelota5.vely;
            }

            
            pelota1.Update();
            pelota2.Update();
            pelota3.Update();
            pelota4.Update();
            pelota5.Update();

            DrawBall();

            pictureBox1.Invalidate();
        }

        public void DrawBall()
        {
            g.Clear(Color.White);
            g.FillEllipse(Brushes.Red, pelota1.x, pelota1.y, pelota1.size, pelota1.size);
            g.FillEllipse(Brushes.Blue, pelota2.x, pelota2.y, pelota2.size, pelota2.size);
            g.FillEllipse(Brushes.Green, pelota3.x, pelota3.y, pelota3.size, pelota3.size);
            g.FillEllipse(Brushes.Pink, pelota4.x, pelota4.y, pelota4.size, pelota4.size);
            g.FillEllipse(Brushes.BlueViolet, pelota5.x, pelota5.y, pelota5.size, pelota5.size);

        }
    }
}