using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pruebacolisionq
{
    public class pelota
    {
        public int x;
        public int y;
        public int size;
        public int radio;
        public Point speed;
        public Color color;
        public int velx;
        public int vely;

        public pelota()
        {
            Random rdan = new Random();


            this.size = rdan.Next(30, 50);
            this.radio = size / 2;

            this.x = rdan.Next(3, 790);
            this.y = rdan.Next(3, 440);

            this.velx = rdan.Next(3, 10);
            this.vely = rdan.Next(3, 10);

            this.speed = new Point(x, y);

        }

        public void Update()
        {
            
            x += velx;
            y += vely;

            if (x <= 0 || x + size >= 800)
            {
                x -= velx;
            }

            if (y <= 0 || y + size >= 450)
            {
                y -= vely;
            }
            
        }   
    }
}
