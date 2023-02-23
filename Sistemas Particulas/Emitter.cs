using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelotas
{
    public class Emitter
    {
        public int PosX, PosY;
        public SolidBrush brusOrange = new SolidBrush(Color.Orange);
        public int size = 200;
        Image image = Resource1._7;
        public Emitter(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }

        public int x
        {
            set { PosX = value; }
        }

        public int y
        {
            set { PosY = value; }
        }

        public void DrawPalita(Graphics g)
        {
            g.DrawImage(image, PosX, PosY, size, size);
        }
    }
}
