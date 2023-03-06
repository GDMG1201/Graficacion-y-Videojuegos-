using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3DV2
{
    public class TriangularFace
    {
        public List<Vertex> Triangulos { get; set; }
        public Vertex V1 { get; set; }
        public Vertex V2 { get; set; }
        public Vertex V3 { get; set; }
        public Color Color { get; set; }

        public int NormalIndex { get; set; }

        public TriangularFace(List<Vertex> triangulos, Color color)
        {
            Triangulos = triangulos;
            Color = color;
        }
        public TriangularFace(Vertex v1, Vertex v2, Vertex v3, Color color)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            Color = color;
        }

        
    }
}
