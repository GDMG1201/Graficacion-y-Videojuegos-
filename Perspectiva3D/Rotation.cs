using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo3D
{
    public class Rotation
    {
        float[,] axis;
        Mtx MatZ;
        public Rotation()
        {

        }

        public Vertex Rotz(float angle, Vertex p)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            axis = new float[,]
            {
                { cos, -sin, 0 },
                { sin, cos, 0 },
                { 0, 0, 1 },
            };

            MatZ = new Mtx(axis);
            return MatZ.Mul(p);

        }

        public Vertex Roty(float angle, Vertex p)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            axis = new float[,]
            {
                { cos, 0, sin },
                { 0, 1, 0 },
                { -sin, 0, cos },
            };

            MatZ = new Mtx(axis);
            return MatZ.Mul(p);

        }

        public Vertex Rotx(float angle, Vertex p)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            axis = new float[,]
            {
                { 1, 0, 0 },
                { 0, cos, -sin },
                { 0, sin, cos },
            };

            MatZ = new Mtx(axis);
            return MatZ.Mul(p);

        }
    }
}
