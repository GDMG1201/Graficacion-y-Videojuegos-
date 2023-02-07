using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Proyecto_PacMan
{
    public partial class Form1 : Form
    {
        //Redondear las esquinas del frame
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        bool gameOn = false;
        private bool mouseDown;
        private Point lastLocation;
        static Map map;
        private Bitmap bmp;
        static Graphics g;
        static bool isMouseDown;
        static Brush brush, eraser;
        static Brush brushW = new SolidBrush(Color.FromArgb(0, 0, 139));
        static Brush brushP = new SolidBrush(Color.FromArgb(255, 255, 0));
        static Brush brushT = new SolidBrush(Color.FromArgb(52, 52, 52));
        static int posicionPacManX;
        static int posicionPacManY;
        static int score = 0;
        static int coinsCounter = 0;
        static char token;
        char tokenPen = 'D';
        bool initOpen = false;
        public char[,] chargedMap = new char[25, 25];
        string path = "..\\maps\\";
        string[] directoryFiles;
        List<string> filesNames = new List<string>();
        int mapCounter = 0;
        static int pacmanOrientation = -45;

        static Brush redGhost = new SolidBrush(Color.FromArgb(255, 0, 0));
        static int posicionRedGhostX;
        static int posicionRedGhostY;

        static Brush pinkGhost = new SolidBrush(Color.FromArgb(255, 153, 255));
        static int posicionPinkGhostX;
        static int posicionPinkGhostY;

        static Brush blueGhost = new SolidBrush(Color.FromArgb(0, 204, 255));
        static int posicionBlueGhostX;
        static int posicionBlueGhostY;

        static Brush orangeGhost = new SolidBrush(Color.FromArgb(255, 204, 0));
        static int posicionOrangeGhostX;
        static int posicionOrangeGhostY;

        public Form1()
        {
            InitializeComponent();
            //Redondear las esquinas del frame
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pbLogo.Image = MyResources.Logo;
            map = new Map(new char[25, 25]);
            Init();
        }

        private void InitRectangle(int x, int y)
        {
            char c = map.map[x, y];
            switch (c)
            {
                case '0':
                    g.FillRectangle(eraser, x * 25, y * 25, 25, 25);
                    break;
                case 'P':
                    g.FillPie(brushP, x * 25, y * 25, 25, 25, 45, 270);
                    break;
                case 'W':
                    g.FillRectangle(brushW, x * 25, y * 25, 25, 25);
                    break;
                case 'C':
                    g.FillEllipse(Brushes.NavajoWhite, (x * 25) + 6, (y * 25) + 6, 9, 12);
                    break;
                case 'T':
                    g.FillRectangle(brushT, x * 25, y * 25, 25, 25);
                    break;
                case '1':
                    g.FillEllipse(redGhost, x * 25, y * 25, 25, 25);
                    break;
                case '2':
                    g.FillEllipse(pinkGhost, x * 25, y * 25, 25, 25);
                    break;
                case '3':
                    g.FillEllipse(blueGhost, x * 25, y * 25, 25, 25);
                    break;
                case '4':
                    g.FillEllipse(orangeGhost, x * 25, y * 25, 25, 25);
                    break;
            }
            g.DrawRectangle(Pens.Gray, x * 25, y * 25, 25, 25);
        }

        private void InitRectangleOpen(int x, int y)
        {
            char c = map.map[x, y];
            switch (c)
            {
                case '0':
                    g.FillRectangle(eraser, x * 25, y * 25, 25, 25);
                    break;
                case 'P':
                    g.FillPie(brushP, x * 25, y * 25, 25, 25, 45, 270);
                    posicionPacManX = x;
                    posicionPacManY = y;
                    break;
                case 'W':
                    g.FillRectangle(brushW, x * 25, y * 25, 25, 25);
                    break;
                case 'C':
                    g.FillEllipse(Brushes.NavajoWhite, (x * 25) + 6, (y * 25) + 6, 9, 12);
                    coinsCounter++;
                    break;
                case 'T':
                    g.FillRectangle(brushT, x * 25, y * 25, 25, 25);
                    break;
                case '1':
                    g.FillEllipse(redGhost, x * 25, y * 25, 25, 25);
                    posicionRedGhostX = x;
                    posicionRedGhostY = y;
                    break;
                case '2':
                    g.FillEllipse(pinkGhost, x * 25, y * 25, 25, 25);
                    posicionPinkGhostX = x;
                    posicionPinkGhostY = y;
                    break;
                case '3':
                    g.FillEllipse(blueGhost, x * 25, y * 25, 25, 25);
                    posicionBlueGhostX = x;
                    posicionBlueGhostY = y;
                    break;
                case '4':
                    g.FillEllipse(orangeGhost, x * 25, y * 25, 25, 25);
                    posicionOrangeGhostX = x;
                    posicionOrangeGhostY = y;
                    break;
            }
        }

        //private void pbGame_MouseMove(object sender, MouseEventArgs e)
        //{
        //    Point p = new Point(e.X / 25, e.Y / 25);
        //}

        private void pbGame_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        private void pbGame_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void pbGame_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Init()
        {
            token = 'W';
            isMouseDown = false;

            bmp = new Bitmap(pbGame.Width, pbGame.Height);
            pbGame.Image = bmp;

            g = Graphics.FromImage(bmp);
            brush = new SolidBrush(Color.FromArgb(0, 0, 139));
            eraser = new SolidBrush(Color.FromArgb(60, 60, 60));
            for (int x = 0; x < 25; x++)
                for (int y = 0; y < 25; y++)
                {
                    if(!initOpen)
                        InitRectangle(x, y);
                    else
                        InitRectangleOpen(x, y);
                }
            g.DrawRectangle(Pens.Gray, 0, 0, bmp.Width - 1, bmp.Height - 1);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void updateMapList()
        {
            directoryFiles = Directory.GetFiles(path, "*");
            filesNames.Clear();
            foreach (string fileName in directoryFiles)
            {
                int start = fileName.Length - 8;
                string name = fileName.Substring(start);
                filesNames.Add(name);
            }
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            updateMapList();

            if (filesNames.Count() !=0 && mapCounter != filesNames.Count())
            {
                mapLabel.Text = "Map " + (mapCounter + 1);
                mapCounter++;
                pbGame.MouseDown -= pbGame_MouseDown;
                Open();
            }
            scoreLabel.Text = "";
            score = 0;
            timer1.Enabled = false;
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            if (filesNames.Count() != 0 && mapCounter != 1)
            {
                mapLabel.Text = "Map " + (mapCounter - 1);
                mapCounter--;
                Open();
            }
            scoreLabel.Text = "";
            score = 0;
            timer1.Enabled = false;
        }

        private void Open()
        {
            initOpen = true;
            map = new Map(path + "map-" + (mapCounter) + ".mx");
            Init();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void checkLost()
        {
            if (posicionPacManX == posicionRedGhostX &&
                posicionPacManY == posicionRedGhostY ||

                posicionPacManX == posicionPinkGhostX &&
                posicionPacManY == posicionPinkGhostY ||

                posicionPacManX == posicionBlueGhostX &&
                posicionPacManY == posicionBlueGhostY ||

                posicionPacManX == posicionOrangeGhostX &&
                posicionPacManY == posicionOrangeGhostX)
            {
                labelS.Text = "Oh, you lose :(";
                scoreLabel.Text = "Your score is " + score;
                startButton.Text = "Restart game";
                stopGame();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (gameOn)
            {

                switch (keyData)
                {
                    case Keys.Up:
                        if (posicionPacManY > 0 && map.map[posicionPacManX, posicionPacManY - 1] != 'W')
                        {
                            posicionPacManY--;
                            UpdateScore();
                            pacmanOrientation = -45;
                        }
                        else if (posicionPacManY == 0 && map.map[posicionPacManX, posicionPacManY] == 'T')
                        {
                            posicionPacManY = 24;
                            pacmanOrientation = -45;
                        }
                        break;
                    case Keys.Down:

                        if (posicionPacManY < 24 && map.map[posicionPacManX, posicionPacManY + 1] != 'W')
                        {
                            posicionPacManY++;
                            UpdateScore();
                            pacmanOrientation = -225;
                        }
                        else if (posicionPacManY == 24 && map.map[posicionPacManX, posicionPacManY] == 'T')
                        {
                            posicionPacManY = 0;
                            pacmanOrientation = -225;
                        }
                        break;
                    case Keys.Left:

                        if (posicionPacManX > 0 && map.map[posicionPacManX - 1, posicionPacManY] != 'W')
                        {

                            posicionPacManX--;
                            UpdateScore();
                            pacmanOrientation = 225;
                        }
                        else if (posicionPacManX == 0 && map.map[posicionPacManX, posicionPacManY] == 'T')
                        {
                            posicionPacManX = 24;
                            pacmanOrientation = 225;
                        }
                        break;
                    case Keys.Right:
                        if (posicionPacManX < 24 && map.map[posicionPacManX + 1, posicionPacManY] != 'W')
                        {
                            posicionPacManX++;
                            UpdateScore();
                            pacmanOrientation = 45;
                        }
                        else if (posicionPacManX == 24 && map.map[posicionPacManX, posicionPacManY] == 'T')
                        {
                            posicionPacManX = 0;
                            pacmanOrientation = 45;
                        }
                        reDraw();
                        break;
                }

                // Asegura que la posición de Pac-Man sea un índice válido
                posicionPacManX = Math.Max(0, Math.Min(posicionPacManX, 24));
                posicionPacManY = Math.Max(0, Math.Min(posicionPacManY, 24));

                // Elimina la comida en la posición actual de Pac-Man
                if (map.map[posicionPacManX, posicionPacManY] == 'C')
                    map.map[posicionPacManX, posicionPacManY] = '0';

                //Check if the player lost
                checkLost();
                // Actualiza el contenido del formulario
                Invalidate();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UpdateScore()
        {
            if (map.map[posicionPacManX, posicionPacManY] == 'C')
            {
                score += 10;
                coinsCounter--;
                scoreLabel.Text = (score.ToString());
                if(coinsCounter == 0)
                {
                    stopGame();
                    labelS.Text = "¡Wow, you won!";
                    scoreLabel.Text = "Your score is " + score;
                    startButton.Text = "Play again";
                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            coinsCounter = 0;
            timer1.Enabled = true;
            gameOn = true;
            scoreLabel.Text = "";
            score = 0;
            labelS.Text = "Score";
            startButton.Text = "Start Game";
            Open();
        }

        private void stopGame()
        {
            gameOn = false;
            timer1.Enabled = false;
        }

        private void moveGhost(int x, int y, int movement, char ghost)
        {
            if (gameOn)
            {
                switch (movement)
                {
                    // Arriba
                    case 0:
                        if (y > 0 && map.map[x, y - 1] != 'W')
                        {
                            switch (ghost)
                            {
                                case 'r':
                                    posicionRedGhostY--;
                                    break;
                                case 'p':
                                    posicionPinkGhostY--;
                                    break;
                                case 'b':
                                    posicionBlueGhostY--;
                                    break;
                                case 'o':
                                    posicionOrangeGhostY--;
                                    break;
                            }
                        }
                        else if (y == 0 && map.map[x, y] == 'T')
                        {
                            switch (ghost)
                            {
                                case 'r':
                                    posicionRedGhostY = 24;
                                    break;
                                case 'p':
                                    posicionPinkGhostY = 24;
                                    break;
                                case 'b':
                                    posicionBlueGhostY = 24;
                                    break;
                                case 'o':
                                    posicionOrangeGhostY = 24;
                                    break;
                            }
                        }
                        break;
                    // Abajo
                    case 1:
                        if (y < 24 && map.map[x, y + 1] != 'W')
                        {
                            switch (ghost)
                            {
                                case 'r':
                                    posicionRedGhostY++;
                                    break;
                                case 'p':
                                    posicionPinkGhostY++;
                                    break;
                                case 'b':
                                    posicionBlueGhostY++;
                                    break;
                                case 'o':
                                    posicionOrangeGhostY++;
                                    break;
                            }
                        }
                        else if (y == 24 && map.map[x, y] == 'T')
                        {
                            switch (ghost)
                            {
                                case 'r':
                                    posicionRedGhostY = 0;
                                    break;
                                case 'p':
                                    posicionPinkGhostY = 0;
                                    break;
                                case 'b':
                                    posicionBlueGhostY = 0;
                                    break;
                                case 'o':
                                    posicionOrangeGhostY = 0;
                                    break;
                            }
                        }
                        break;
                    // Izquierda 
                    case 2:
                        if (x > 0 && map.map[x - 1, y] != 'W')
                        {
                            switch (ghost)
                            {
                                case 'r':
                                    posicionRedGhostX--;
                                    break;
                                case 'p':
                                    posicionPinkGhostX--;
                                    break;
                                case 'b':
                                    posicionBlueGhostX--;
                                    break;
                                case 'o':
                                    posicionOrangeGhostX--;
                                    break;
                            }
                        }
                        else if (x == 0 && map.map[x, y] == 'T')
                        {
                            switch (ghost)
                            {
                                case 'r':
                                    posicionRedGhostX = 24;
                                    break;
                                case 'p':
                                    posicionPinkGhostX = 24;
                                    break;
                                case 'b':
                                    posicionBlueGhostX = 24;
                                    break;
                                case 'o':
                                    posicionOrangeGhostX = 24;
                                    break;
                            }
                        }
                        break;
                    // Derecha
                    case 3:
                        if (x < 24 && map.map[x + 1, y] != 'W')
                        {
                            switch (ghost)
                            {
                                case 'r':
                                    posicionRedGhostX++;
                                    break;
                                case 'p':
                                    posicionPinkGhostX++;
                                    break;
                                case 'b':
                                    posicionBlueGhostX++;
                                    break;
                                case 'o':
                                    posicionOrangeGhostX++;
                                    break;
                            }
                        }
                        else if (x == 24 && map.map[x, y] == 'T')
                        {
                            switch (ghost)
                            {
                                case 'r':
                                    posicionRedGhostX = 0;
                                    break;
                                case 'p':
                                    posicionPinkGhostX = 0;
                                    break;
                                case 'b':
                                    posicionBlueGhostX = 0;
                                    break;
                                case 'o':
                                    posicionOrangeGhostX = 0;
                                    break;
                            }
                        }
                        reDraw();
                        break;
                }
            }
        }

        private void randomGhostMove()
        {
            Random random = new Random();
            int randomGhost = random.Next(0, 4);
            int randomeMove = random.Next(0, 4);

            switch (randomGhost)
            {
                //red ghost
                case 0:
                    moveGhost(posicionRedGhostX, posicionRedGhostY, randomeMove, 'r');
                    break;
                //pink ghost
                case 1:
                    moveGhost(posicionPinkGhostX, posicionPinkGhostY, randomeMove, 'p');
                    break;
                //blue ghost
                case 2:
                    moveGhost(posicionBlueGhostX, posicionBlueGhostY, randomeMove, 'b');
                    break;
                //orange ghost
                case 3:
                    moveGhost(posicionOrangeGhostX, posicionOrangeGhostY, randomeMove, 'o');
                    break;

            }
            checkLost();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            randomGhostMove();
        }

        public void reDraw()
        {
            bmp = new Bitmap(pbGame.Width, pbGame.Height);
            pbGame.Image = bmp;
            g = Graphics.FromImage(bmp);

            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    char c = map.map[x, y];

                    switch (c)
                    {
                        case '0':
                            g.FillRectangle(eraser, x * 25, y * 25, 25, 25);
                            break;
                        case 'P':
                            g.FillEllipse(eraser, x * 25, y * 25, 25, 25);
                            break;
                        case 'W':
                            g.FillRectangle(brushW, x * 25, y * 25, 25, 25);
                            break;
                        case 'C':
                            g.FillEllipse(Brushes.NavajoWhite, (x * 25) + 6, (y * 25) + 6, 9, 12);
                            break;
                        case 'T':
                            g.FillRectangle(brushT, x * 25, y * 25, 25, 25);
                            break;
                    }
                    // Dibujar pacman y fantasmas
                    g.FillEllipse(redGhost, posicionRedGhostX * 25, posicionRedGhostY * 25, 25, 25);
                    g.FillEllipse(pinkGhost, posicionPinkGhostX * 25, posicionPinkGhostY * 25, 25, 25);
                    g.FillEllipse(blueGhost, posicionBlueGhostX * 25, posicionBlueGhostY * 25, 25, 25);
                    g.FillEllipse(orangeGhost, posicionOrangeGhostX * 25, posicionOrangeGhostY * 25, 25, 25);
                    g.FillPie(brushP, posicionPacManX * 25, posicionPacManY * 25, 25, 25, pacmanOrientation, 270);
                }
            }
            g.DrawRectangle(Pens.Gray, 0, 0, bmp.Width - 1, bmp.Height - 1);
        }
    }
}