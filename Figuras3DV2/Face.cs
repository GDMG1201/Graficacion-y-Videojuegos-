using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3DV2
{
    public class Face
    {
        public List<Vertex> Vertices { get; set; }
        public Color Color { get; set; }

        public int NormalIndex { get; set; }

        public Face(List<Vertex> vertices, Color color)
        {
            Vertices = vertices;
            Color = color;
        }

        public Face(Vertex v1, Vertex v2, Vertex v3, Color color)
        {
            Vertices = new List<Vertex> { v1, v2, v3 };
            Color = color;
        }

        
    }
}

