using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3DV2
{
    public class Vertex
    {
        public float[] Values;
        const int X = 0;
        const int Y = 1;
        const int Z = 2;

        public float x
        {
            get { return Values[X]; }
            set { Values[X] = value; }
        }

        public float y
        {
            get { return Values[Y]; }
            set { Values[Y] = value; }
        }

        public float z
        {
            get { return Values[Z]; }
            set { Values[Z] = value; }
        }

        public float this[int i]
        {
            get { return Values[i]; }
            set { Values[i] = value; }
        }

        public Vertex(float[] values)
        {
            Values = values;
        }
    }
}
