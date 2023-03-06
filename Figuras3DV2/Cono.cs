using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3DV2
{
    public class Cono
    {
        public Vertex BaseCenter { get; set; } //Centro de la base del cono 
        public float Radius { get; set; }
        public float Height { get; set; } //Altura del cono
        public Vertex Tip { get; set; } //Vertice de la punto del cono 

        public List<TriangularFace> Faces { get; set; }

        public Mesh mesh;

        public Cono(Vertex baseCenter, float radius, float height)
        {
            BaseCenter = baseCenter;
            Radius = radius;
            Height = height;

            // Definir los vértices
            Tip = new Vertex(new float[] { baseCenter.x, baseCenter.y, baseCenter.z + height });

            Faces = new List<TriangularFace>();

            mesh = new Mesh();

            //Crear los vértices de la base utilizando un círculo
            var baseVertices = new List<Vertex>();
            for (int i = 0; i < 360; i += 10)
            {
                float x = baseCenter.x + (float)(radius * Math.Cos(i * Math.PI / 180));
                float y = baseCenter.y + (float)(radius * Math.Sin(i * Math.PI / 180));
                float z = baseCenter.z;
                baseVertices.Add(new Vertex(new float[] { x, y, z }));
            }

            // Crear las caras triangulares que conectan los vértices de la base con la punta
            var faces = new List<TriangularFace>();
            for (int i = 0; i < baseVertices.Count; i++)
            {
                int j = (i + 1) % baseVertices.Count;
                var faceColor = Color.FromArgb(155, 155, 155); // Aquí puedes elegir el color que quieras
                var face = new TriangularFace(new List<Vertex> { baseVertices[i], baseVertices[j], Tip }, faceColor);
                faces.Add(face);
                mesh.triangles.Add(face);
                
            }

            Faces = faces;

            // Crear las caras triangulares que conforman la base
            var baseFaces = new List<TriangularFace>();
            for (int i = 0; i < baseVertices.Count - 2; i++)
            {
                var faceColor = Color.FromArgb(155, 155, 155); // Aquí puedes elegir el color que quieras
                var face = new TriangularFace(new List<Vertex> { baseVertices[i], baseVertices[i + 1], baseCenter }, faceColor);
                baseFaces.Add(face);
                mesh.triangles.Add(face);
            }
            var lastFace = new TriangularFace(new List<Vertex> { baseVertices[baseVertices.Count - 1], baseVertices[0], baseCenter }, Color.FromArgb(155, 155, 155));
            baseFaces.Add(lastFace);

            // Agregar las caras de la base a la lista de caras del cono
            Faces.AddRange(baseFaces);


        }

     
    }
}
