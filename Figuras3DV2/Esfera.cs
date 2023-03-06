using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3DV2
{
    public class Esfera
    {
        public Vertex Center { get; set; } // Centro de la esfera
        public float Radius { get; set; }
        public List<TriangularFace> Faces { get; set; }

        public Mesh mesh { get; set; }

        public Esfera(Vertex center, float radius, int divisions)
        {
            Center = center;
            Radius = radius;
            Faces = new List<TriangularFace>();
            mesh = new Mesh();
            // Crear los vértices de la esfera utilizando la proyección de una esfera unitaria
            var vertices = new List<Vertex>();
            for (int i = 0; i <= divisions; i++)
            {
                double lat = Math.PI / 2 - i * Math.PI / divisions;
                double y = Radius * Math.Sin(lat);
                double scale = Radius * Math.Cos(lat);
                for (int j = 0; j <= divisions; j++)
                {
                    double lon = j * 2 * Math.PI / divisions;
                    double x = scale * Math.Sin(lon);
                    double z = scale * Math.Cos(lon);
                    vertices.Add(new Vertex(new float[] { (float)(Center.x + x), (float)(Center.y + y), (float)(Center.z + z) }));
                }
            }

            // Crear las caras triangulares que conectan los vértices de la esfera
            var faces = new List<TriangularFace>();
            for (int i = 0; i < divisions; i++)
            {
                for (int j = 0; j < divisions; j++)
                {
                    int index = i * (divisions + 1) + j;
                    var faceColor = Color.FromArgb(155, 155, 155); // Aquí puedes elegir el color que quieras
                    var face = new TriangularFace(new List<Vertex> { vertices[index], vertices[index + 1], vertices[index + divisions + 2] }, faceColor);
                    faces.Add(face);
                    mesh.triangles.Add(face);

                    face = new TriangularFace(new List<Vertex> { vertices[index], vertices[index + divisions + 2], vertices[index + divisions + 1] }, faceColor);
                    faces.Add(face);
                    mesh.triangles.Add(face);
                }
            }

            Faces = faces;
        }
    }
}
