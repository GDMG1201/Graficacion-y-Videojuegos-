using Billar.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Billar
{
    public class Ball
    {
        int index;
        public Size space;
        public Color c;
        

        // Variables de posición
        public float x;
        public float y;

        // Variables de velocidad
        public float vx;
        public float vy;

        // Variable de radio
        public float radio;

        public int tableHolesSize;

        // Constructor
        public Ball(Random rand, Size size, int index, int tableHoles, int radio)
        {
            this.radio = radio;
            this.x = rand.Next(tableHoles + radio, size.Width - (int)radio -  tableHoles);
            this.y = rand.Next(tableHoles + radio, size.Height - (int)radio - tableHoles);
            if (index == 0)
            {  // Si es la primera pelota, será negra
                c = Color.Black;
            }
            else
            {  // Para todas las demás pelotas, se elegirá un color aleatorio
                c = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            }

            // Velocidades iniciales
            this.vx = rand.Next((int)-radio, (int)radio);
            this.vy = rand.Next((int)-radio, (int)radio);

            this.index = index;
            space = size;
            this.tableHolesSize = tableHoles;
        }

        // Método para actualizar la posición de la pelota en función de su velocidad
        public void Update(float deltaTime, List<Ball> balls, List<Ball> holes)
        {
            for (int h = 0; h < holes.Count; h++)
            {
                CollisionHoles(holes[h]);
            }

            for (int b = index + 1; b < balls.Count; b++)
            {
                if (balls[b].radio != 0)
                    Collision(balls[b]);
            }

            if ((x - radio) <= tableHolesSize || (x + radio) >= space.Width - tableHolesSize)
            {
                if (x - radio <= tableHolesSize)
                    x = (tableHolesSize + radio) + 3;
                else
                    x = (space.Width - tableHolesSize) - radio - 3;

                vx *= -.5f;
                vy *= .75f;
            }

            if ((y - radio) <= tableHolesSize || (y + radio) >= space.Height - tableHolesSize)
            {
                if (y - radio <= tableHolesSize)
                    y = (tableHolesSize + radio) + 3;
                else
                    y = (space.Height - tableHolesSize) - radio - 3;

                vx *= .75f;
                vy *= -.55f;
            }

            this.x += this.vx;
            this.y += this.vy;
        }

        public void CollisionHoles(Ball hole)
        {
            var main = Application.OpenForms.OfType<Billar>().First();
            float distancia = (float)Math.Sqrt(Math.Pow((hole.x - this.x), 2) + Math.Pow((hole.y - this.y), 2));

            if (distancia < (this.radio + (hole.radio - 15)))//ESTO SIGNIFICA COLISIÓN...
            {
                // Actualizamos las velocidades de las pelotas
                this.radio = 0;
                this.vx = 0;
                this.vy = 0;
                main.score1 += 1;
            }
        }

        public void Collision(Ball otraPelota)
        {
            float distanciaX = otraPelota.x - this.x;
            float distanciaY = otraPelota.y - this.y;
            float distancia = (float)Math.Sqrt(distanciaX * distanciaX + distanciaY * distanciaY);

            if (distancia < (this.radio + otraPelota.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada pelota en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraPelota.radio;
                float masaRelativa = this.radio / masaTotal;

                // Componentes de velocidad en la dirección del choque
                float v1fParalela = ((this.vx * distanciaX) + (this.vy * distanciaY)) / distancia;
                float v2fParalela = ((otraPelota.vx * distanciaX) + (otraPelota.vy * distanciaY)) / distancia;

                // Componentes de velocidad en la dirección perpendicular al choque
                float v1fPerpendicular = ((this.vx * distanciaY) - (this.vy * distanciaX)) / distancia;
                float v2fPerpendicular = ((otraPelota.vx * distanciaY) - (otraPelota.vy * distanciaX)) / distancia;

                // Velocidades finales en la dirección del choque
                float v1fx = ((masaRelativa * (otraPelota.radio - this.radio) * v1fParalela) + ((1 + masaRelativa) * this.radio * v2fParalela)) / masaTotal;
                float v2fx = ((masaRelativa * (this.radio - otraPelota.radio) * v2fParalela) + ((1 + masaRelativa) * otraPelota.radio * v1fParalela)) / masaTotal;

                // Velocidades finales en la dirección perpendicular al choque
                float v1fy = v1fPerpendicular;
                float v2fy = v2fPerpendicular;

                // Actualizamos las velocidades de las pelotas
                this.vx = v1fx * distanciaX / distancia + v1fy * distanciaY / distancia;
                this.vy = v1fx * distanciaY / distancia - v1fy * distanciaX / distancia;

                otraPelota.vx = v2fx * distanciaX / distancia + v2fy * distanciaY / distancia;
                otraPelota.vy = v2fx * distanciaY / distancia - v2fy * distanciaX / distancia;

                // Movemos las pelotas para evitar que se superpongan
                float distanciaOverlap = (this.radio + otraPelota.radio) - distancia;
                float dx = (this.x - otraPelota.x) / distancia;
                float dy = (this.y - otraPelota.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraPelota.x -= dx * distanciaOverlap / 2f;
                otraPelota.y -= dy * distanciaOverlap / 2f;
            }
        }
    }
}
