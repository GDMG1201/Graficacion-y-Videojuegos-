using Billar.Properties;
using Microsoft.VisualBasic.Devices;
using System.Drawing.Drawing2D;
using System.Media;
using System.Runtime.Intrinsics.X86;

namespace Billar
{
    public partial class Billar : Form
    {
        Graphics g;
        Graphics gTop;
        Bitmap bmp, bmp2;
        public int tableHolesSize = 60;
        SolidBrush holeColor = new SolidBrush(Color.FromArgb(0, 0, 0));
        SolidBrush brownBrush = new SolidBrush(Color.FromArgb(60, 13, 1));
        SolidBrush whiteBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
        public static List<VPoint> balls2;
        public List<Ball> holes;
        public int score1 = 0;
        public int score2 = 0;
        static Random rand = new Random();
        static float deltaTime;
        VSolver solver;
        Point mouse, trigger;
        public bool isMouseDown, isRightButton;
        int ballId;
        Pen ballPen = new Pen(Color.FromArgb(255, 255, 255), 10);
        public int initialBallPosX;
        public int initialBallPosY;
        public bool whiteHole = false;
        VPoint whiteBall, unoBall, dosBall, tresBall, cuatroBall, cincoBall, seisBall, sieteBall;
        VPoint ochoBall, nueveBall, diezBall, blackBall, doceBall, treceBall, catorceBall, quinceBall;

        private void reload_Click(object sender, EventArgs e)
        {
            
            Init();
            
        }

        bool didLoad = false;
        public bool player1 = true;
        public bool player2 = false;
        public bool isplayer1,isplayer2;


        public Billar()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            PCT_Canvas1.BackColor = Color.FromArgb(0, 127, 14);
            PCT_Canvas2.Parent = PCT_Canvas1;
            balls2 = new List<VPoint>();
            holes = new List<Ball>();
            solver = new VSolver(balls2, holes);
            deltaTime = 1;
            int x = PCT_Canvas1.Width / 3;
            int y = PCT_Canvas1.Height / 2;
            int radius = 15;
            int xOffset = (int)((int)radius * (float)1.95);
            int yOffset = radius * 2;
            initialBallPosX = (int)(PCT_Canvas1.Width / 1.3f);
            initialBallPosY = PCT_Canvas1.Height / 2;

            int xInitial = (int)(PCT_Canvas1.Width / 5.5f);
            int yInitial = (int)(PCT_Canvas1.Height / 2.5f);

            unoBall = new VPoint(xInitial, yInitial, 0, tableHolesSize);
            balls2.Add(unoBall);
            dosBall = new VPoint(xInitial, yInitial + radius * 3, 1, tableHolesSize);
            balls2.Add(dosBall);
            tresBall = new VPoint(xInitial, yInitial + radius * 6, 2, tableHolesSize);
            balls2.Add(tresBall);
            cuatroBall = new VPoint(xInitial, yInitial + radius * 9, 3, tableHolesSize);
            balls2.Add(cuatroBall);
            cincoBall = new VPoint(xInitial, yInitial + radius * 12, 4, tableHolesSize);
            balls2.Add(cincoBall);

            seisBall = new VPoint(xInitial + radius * 3, yInitial + radius * 3 - 20, 5, tableHolesSize);
            balls2.Add(seisBall);
            sieteBall = new VPoint(xInitial + radius * 3, yInitial + radius * 6 - 22, 6, tableHolesSize);
            balls2.Add(sieteBall);
            ochoBall = new VPoint(xInitial + radius * 3, yInitial + radius * 9 - 24, 7, tableHolesSize);
            balls2.Add(ochoBall);
            nueveBall = new VPoint(xInitial + radius * 3, yInitial + radius * 12 - 24, 8, tableHolesSize);
            balls2.Add(nueveBall);

            diezBall = new VPoint(xInitial + radius * 6, yInitial + radius * 6 - 44, 9, tableHolesSize);
            balls2.Add(diezBall);
            blackBall = new VPoint(xInitial + radius * 6, yInitial + radius * 9 -42, 10,tableHolesSize);
            balls2.Add(blackBall);
            doceBall = new VPoint(xInitial + radius * 6, yInitial + radius * 12 -40, 11, tableHolesSize);
            balls2.Add(doceBall);

            treceBall = new VPoint(xInitial + radius * 9, yInitial + radius * 6 - 22, 12, tableHolesSize);
            balls2.Add(treceBall);
            catorceBall = new VPoint(xInitial + radius * 9, yInitial + radius * 9 - 20, 13, tableHolesSize);
            balls2.Add(catorceBall);

            quinceBall = new VPoint(xInitial + radius * 12, yInitial + radius * 6 , 14, tableHolesSize);
            balls2.Add(quinceBall);


            whiteBall = new VPoint(initialBallPosX, initialBallPosY, 15, tableHolesSize);
            balls2.Add(whiteBall);

            holes.Add(new Ball(rand, PCT_Canvas1.Size, 0, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 1, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 2, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 3, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 4, tableHolesSize, tableHolesSize / 2));
            holes.Add(new Ball(rand, PCT_Canvas1.Size, 5, tableHolesSize, tableHolesSize / 2));

            for(int i = 0; i < holes.Count; i++)
            {
                holes[i].vx = 0;
                holes[i].vy = 0;
            }

            didLoad = true;
            player1 = true;
            sLBL.ForeColor = Color.Green;
            sLBL1.ForeColor = Color.White;
            player2 = false;
            winner1.Text = "";
            score1 = 0;
            score2 = 0;

        }

        private void Billar_Load(object sender, EventArgs e)
        {
            DrawTable();
        }

        private void Billar_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;

            isRightButton = (e.Button == MouseButtons.Right);
            if (isRightButton)
                trigger = e.Location;

            mouse = e.Location;
        }

        private void Billar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)//MOVE BALL TO POINTER
                {
                    mouse = e.Location;
                    if (ballId > -1)
                    {
                        balls2[ballId].Pos.X = e.Location.X;
                        balls2[ballId].Pos.Y = e.Location.Y;
                        balls2[ballId].Old = balls2[ballId].Pos;
                    }
                }
                else
                    trigger = e.Location;
            }
        }

        private void Billar_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (e.Button == MouseButtons.Right && ballId != -1)
            {
                balls2[ballId].Old.X = e.Location.X;
                balls2[ballId].Old.Y = e.Location.Y;
            }

            ballId = -1;
        }

        private void PCT_Canvas2_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void PCT_Canvas2_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;

            isRightButton = (e.Button == MouseButtons.Right);
            if (isRightButton)
                trigger = e.Location;

            mouse = e.Location;
        }

        private void PCT_Canvas2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)//MOVE BALL TO POINTER
                {
                    mouse = e.Location;
                    if (ballId == 15)
                    {
                        balls2[ballId].Pos.X = e.Location.X;
                        balls2[ballId].Pos.Y = e.Location.Y;
                        balls2[ballId].Old = balls2[ballId].Pos;
                    }
                }
                else
                    trigger = e.Location;
            }
        }

        private void PCT_Canvas2_MouseUp(object sender, MouseEventArgs e)
        {

            isMouseDown = false;
            if (e.Button == MouseButtons.Right && ballId == 15)
            {
               balls2[ballId].Old.X = e.Location.X;
               balls2[ballId].Old.Y = e.Location.Y;
            }
            ballId = -1;
        }

        private void panelCenter_SizeChanged(object sender, EventArgs e)
        {
            if (didLoad == true)
                DrawTable();
        }

        private void DrawTable()
        {
            int ancho = panelCenter.Width;
            int alto = panelCenter.Height;

            bmp = new Bitmap(ancho, alto);
            bmp2 = new Bitmap(ancho, alto);
            g = Graphics.FromImage(bmp);
            gTop = Graphics.FromImage(bmp2);
            PCT_Canvas1.Image = bmp;
            PCT_Canvas2.Image = bmp2;


            Rectangle r = new Rectangle(0, 0, ancho, alto);
            GraphicsPath gp = new GraphicsPath();
            int d = tableHolesSize;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            PCT_Canvas1.Region = new Region(gp);
            PCT_Canvas2.Region = new Region(gp);

            // Draw the lines in the table
            gTop.FillRectangle(brownBrush, new Rectangle(0, 0, ancho, tableHolesSize));
            gTop.FillRectangle(brownBrush, new Rectangle(ancho - tableHolesSize, 0, tableHolesSize, alto));
            gTop.FillRectangle(brownBrush, new Rectangle(0, alto - tableHolesSize, ancho, tableHolesSize));
            gTop.FillRectangle(brownBrush, new Rectangle(0, 0, tableHolesSize, alto));

            // Draw the holes of the table
            // Top left
            holes[0].x = tableHolesSize;
            holes[0].y = tableHolesSize;
            gTop.FillEllipse(holeColor, holes[0].x - holes[0].radio, holes[0].y - holes[0].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Top middle
            holes[1].x = (ancho / 2);
            holes[1].y = tableHolesSize;
            gTop.FillEllipse(holeColor, holes[1].x - holes[1].radio, holes[1].y - holes[1].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Top right
            holes[2].x = (ancho - tableHolesSize);
            holes[2].y = tableHolesSize;
            gTop.FillEllipse(holeColor, holes[2].x - holes[2].radio, holes[2].y - holes[2].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Bottom right
            holes[3].x = (ancho - tableHolesSize);
            holes[3].y = (alto - tableHolesSize);
            gTop.FillEllipse(holeColor, holes[3].x - holes[3].radio, holes[3].y - holes[3].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Bottom middle
            holes[4].x = (ancho / 2);
            holes[4].y = (alto - tableHolesSize);
            gTop.FillEllipse(holeColor, holes[4].x - holes[4].radio, holes[4].y - holes[4].radio, holes[0].radio * 2, holes[0].radio * 2);

            // Bottom left
            holes[5].x = tableHolesSize;
            holes[5].y = (alto - tableHolesSize);
            gTop.FillEllipse(holeColor, holes[5].x - holes[5].radio, holes[5].y - holes[5].radio, holes[0].radio * 2, holes[0].radio * 2);


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            scoreLBL.Text = score1.ToString();
            score2LBL.Text = score2.ToString();

            g.Clear(Color.FromArgb(0, 127, 14));

            ballId = solver.Update(g, PCT_Canvas1.Width, PCT_Canvas1.Height, mouse, isMouseDown);

            if (isMouseDown && isRightButton  && ballId == 15)
                    g.DrawLine(ballPen, balls2[ballId].X, balls2[ballId].Y, trigger.X, trigger.Y);


            PCT_Canvas1.Invalidate();
            PCT_Canvas2.Invalidate();
            deltaTime += .1f;
        }
    }
}