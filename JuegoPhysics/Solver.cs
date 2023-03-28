using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billar
{
    public class VSolver
    {
        VPoint p1, p2;
        Vec2 axis, normal, res;
        float dis, dif;
        List<VPoint> pts;
        List<Ball> holesPts;
        bool whiteHole = false;
        public VSolver(List<VPoint> pts, List<Ball> holespts)
        {
            this.pts = pts;
            this.holesPts = holespts;
        }

        public int Update(Graphics g, int Width, int Height, Point mouse, bool isMouseDown)
        {
            int id;
            id = -1;
            for (int s = 0; s < pts.Count; s++)
            {
                for (int h = 0; h < holesPts.Count; h++)
                {
                    p1 = pts[s];
                    if (p1.Radius == 0)
                        continue;
                    CollisionHoles(holesPts[h], p1);
                }
            }

            for (int s = 0; s < pts.Count; s++)
            {
                for (int p = s; p < pts.Count; p++)
                {
                    p1 = pts[s];
                    p2 = pts[p];

                    if (p1.Id == p2.Id)// BY ID
                        continue;
                    if (p1.Radius == 0 || p2.Radius == 0)
                        continue;

                    axis = p1.Pos - p2.Pos;//vector de direccion
                    dis = axis.Length(); // magnitud

                    if (dis < (p1.Radius + p2.Radius))//COLLISION DETECTED
                    {
                        dif = (dis - (p1.Radius + p2.Radius)) * .5f;// dividir la fuerza para repatar entre ambas colisiones
                        normal = axis / dis; // normalizar la direccion para tener el vector unitario
                        res = dif * normal;// vector resultante

                        if (!p1.IsPinned)
                            if (p2.IsPinned)
                                p1.Pos -= res * 2;
                            else
                                p1.Pos -= res;

                        if (!p2.IsPinned)
                            if (p1.IsPinned)
                                p2.Pos += res * 2;
                            else
                                p2.Pos += res;
                    }
                }

                if (isMouseDown)// para seleccionar el punto de masa a mover escogiendo su ID 
                    if (Math.Abs((p1.X - mouse.X) * (p1.X - mouse.X) + (p1.Y - mouse.Y) * (p1.Y - mouse.Y)) <= ((p1.Radius) * (p1.Radius)))
                        id = p1.Id;

                p1.Render(g, Width, Height);
            }

            return id;
        }
        public void CollisionHoles(Ball hole, VPoint ball)
        {
            var main = Application.OpenForms.OfType<Billar>().First();
            float distancia = (float)Math.Sqrt(Math.Pow((hole.x - ball.X), 2) + Math.Pow((hole.y - ball.Y), 2));

            if (distancia < (ball.Radius + hole.radio - 15))//ESTO SIGNIFICA COLISIÓN...
            {
                // Para jugador 1 son las pelotas rayadas
                if (main.player1)
                {   
                    //Si mete una de sus bolas
                    if (ball.id == 14 || ball.id == 8 || ball.id == 3 || ball.id == 1 || ball.id == 11 || ball.id == 5 || ball.id == 13)
                    {
                         main.player1 = true;
                         main.player2 = false;
                         main.score1 += 1;
                         main.sLBL1.ForeColor = Color.White;
                         main.sLBL.ForeColor = Color.Green;

                    } // si mete la blanca
                    else if (ball.id == 15)
                    {
                        pts.RemoveAt(pts.Count - 1);
                        VPoint whiteBall = new VPoint(main.initialBallPosX, main.initialBallPosY, 15, main.tableHolesSize);
                        pts.Add(whiteBall);
                        main.player2 = true;
                        main.player1 = false;
                        main.sLBL.ForeColor = Color.White;
                        main.sLBL1.ForeColor = Color.Green;
                    }
                    else if (ball.id == 0 || ball.id == 7 || ball.id == 2 || ball.id == 9 || ball.id == 4 || ball.id == 12 || ball.id == 6)
                    {

                        //main.score1 -= 1;
                        main.score2 += 1;
                        main.player2 = true;
                        main.player1 = false;
                        main.sLBL.ForeColor = Color.White;
                        main.sLBL1.ForeColor = Color.Green;


                    } //Si mete la bola negra y su score es 7
                    else if(ball.id == 10 && main.score1 == 7)
                    {
                        main.winner1.Text = "Player 1 wins";
                        main.winner1.ForeColor = Color.Green;
                        main.sLBL.ForeColor = Color.White;
                        main.sLBL1.ForeColor = Color.White;
                        pts.RemoveAt(pts.Count - 1);

                    } // si mete bola negra y su score es menor a 7 
                    else if (ball.id == 10 && main.score1 < 7)
                    {
                        main.winner1.Text = "Player 2 wins";
                        main.winner1.ForeColor = Color.Green;
                        main.sLBL.ForeColor = Color.White;
                        main.sLBL1.ForeColor = Color.White;
                        pts.RemoveAt(pts.Count - 1);
                    }

                }
                else if (main.player2) // para jugador son las pelotas lisas
                {
                    //si mete alguna de sus bolas
                    if (ball.id == 0 || ball.id == 7 || ball.id == 2 || ball.id == 9 || ball.id == 4 || ball.id == 12 || ball.id == 6)
                    {
                        main.player2 = true;
                        main.player1 = false;
                        main.score2 += 1;
                        main.sLBL.ForeColor = Color.White;
                        main.sLBL1.ForeColor = Color.Green;

                    } // si mete la bola blanca
                    else if (ball.id == 15)
                    {
                        pts.RemoveAt(pts.Count - 1);
                        VPoint whiteBall = new VPoint(main.initialBallPosX, main.initialBallPosY, 15, main.tableHolesSize);
                        pts.Add(whiteBall);
                        main.player1 = true;
                        main.player2 = false;
                        main.sLBL1.ForeColor = Color.White;
                        main.sLBL.ForeColor = Color.Green;

                    } // si mete una bola del jugador 2
                    else if(ball.id == 14 || ball.id == 8 || ball.id == 3 || ball.id == 1 || ball.id == 11 || ball.id == 5 || ball.id == 13)
                    {

                        //main.score2 -= 1;
                        main.score1 += 1;
                        main.player1 = true;
                        main.player2 = false;
                        main.sLBL1.ForeColor = Color.White;
                        main.sLBL.ForeColor = Color.Green;

                    } //Si mete la bola negra y su score es 7
                    else if(ball.id == 10 && main.score2 == 7)
                    {
                        main.winner1.Text = "Player 2 wins";
                        main.winner1.ForeColor = Color.Green;
                        main.sLBL.ForeColor = Color.White;
                        main.sLBL1.ForeColor = Color.White;
                        pts.RemoveAt(pts.Count - 1);

                    } // si mete bola negra y su score es menor a 7 
                    else if (ball.id == 10 && main.score2 < 7)
                    {
                        main.winner1.Text = "Player 1 wins";
                        main.winner1.ForeColor = Color.Green;
                        main.sLBL.ForeColor = Color.White;
                        main.sLBL1.ForeColor = Color.White;
                        pts.RemoveAt(pts.Count - 1);
                    }
                }

                if (ball.id != 15)
                {
                    ball.Radius = 0;

                }
                
            }
        }
    }
}
