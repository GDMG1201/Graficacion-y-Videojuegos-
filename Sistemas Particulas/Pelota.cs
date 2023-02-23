using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Pelotas
{
    public class Pelota
    {
        int index;
        Size space;
        public Color c;
        // Variables de posición
        public float x;
        public float y;

        // Variables de velocidad
        private float vx;
        private float vy;

        // Variable de radio
        public float radio;

        Emitter emitter;


        // Constructor
        public Pelota(Random rand, Size size, int index)
        {
            emitter = new Emitter(500, 400);
            this.radio = rand.Next(10, 15);
            this.x = emitter.PosX + (emitter.size / 2) + 30;
            this.y = rand.Next((int)emitter.PosY + ((int)radio +60), (int)emitter.PosY + 90);          
            c = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            // Velocidades iniciales
            this.vx = rand.Next((int)radio, 50);
            this.vy = rand.Next((int)-radio, (int)radio);
            this.index = index;
            space = size;
        }

        public void Update(float deltaTime, List<Pelota> balls)
        {

            if (x >= space.Width)
                x = emitter.PosX + (emitter.size / 2) + 30;

            this.x -= this.vx * -1;  
            
        }


    }
}