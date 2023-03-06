using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3DV2
{
    public class Projection
    {
        const int X = 0;
        const int Y = 1;
        const int Z = 2;

        public Mtx Mat;
        public float[,] mat;

        public Vertex Ortograph(Vertex vector)
        {
            float v = 1;
            mat = new float[,]
            {
                {v,0,0},
                {0,v,0},
                {0,0,0}
            };

            Mat = new Mtx(mat);

            return Mat.Mul(vector);
        }

        public Vertex TranslateCenter(Vertex vector, float x, float y)
        {
            float v = 1;
            mat = new float[,]
            {
                {v,0,0},
                {0,v,0},
                {0,0,0},
            };
            Mat = new Mtx(mat);
            return Mat.Mul(vector);
        }

        public Vertex Perspective(Vertex v)
        {
            float z = 1 / (2.5F - v[Z]);
            mat = new float[,]
            {
                { z, 0, 0 },
                { 0, z, 0 },
                { 0, 0, 1 }
            };
            Mat = new Mtx(mat);
            return Mat.Mul(v);
        }

    }
}
