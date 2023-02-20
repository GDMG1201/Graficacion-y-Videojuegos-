using Demo3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3D
{
    public class Figura
    {
        public float[] P1 = new float[3];
        public float[] P2 = new float[3];
        public float[] P3 = new float[3];
        public float[] P4 = new float[3];
        public float[] P5 = new float[3];
        public float[] P6 = new float[3];
        public float[] P7 = new float[3];
        public float[] P8 = new float[3];


        public Figura(Vertex v1, Vertex v2, Vertex v3, Vertex v4, Vertex v5, Vertex v6, Vertex v7, Vertex v8) 
        {
            P1[0] = v1.x;
            P1[1] = v1.y;
            P1[2] = v1.z;

            P2[0] = v2.x;
            P2[1] = v2.y;
            P2[2] = v2.z;

            P3[0] = v3.x;
            P3[1] = v3.y;
            P3[2] = v3.z;

            P4[0] = v4.x;
            P4[1] = v4.y;
            P4[2] = v4.z;

            P5[0] = v5.x;
            P5[1] = v5.y;
            P5[2] = v5.z;

            P6[0] = v6.x;
            P6[1] = v6.y;
            P6[2] = v6.z;

            P7[0] = v7.x;
            P7[1] = v7.y;
            P7[2] = v7.z;

            P8[0] = v8.x;
            P8[1] = v8.y;
            P8[2] = v8.z;
        }
        

    }
}
