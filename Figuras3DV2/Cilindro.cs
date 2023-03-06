using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3DV2
{
    public class Cilindro
    {
        public Vertex BaseCenter { get; set; } // Centro de la base del cilindro
        public float Radius { get; set; }
        public float Height { get; set; } // Altura del cilindro
        public List<Face> Faces { get; set; }

        public Cilindro(Vertex baseCenter, float radius, float height)
        {
            BaseCenter = baseCenter;
            Radius = radius;
            Height = height;
            Faces = new List<Face>();

            // Crear los vértices de la base utilizando un círculo
            var baseVertices = new List<Vertex>();
            for (int i = 0; i < 360; i += 10)
            {
                float x = baseCenter.x + (float)(radius * Math.Cos(i * Math.PI / 180));
                float y = baseCenter.y + (float)(radius * Math.Sin(i * Math.PI / 180));
                float z = baseCenter.z;
                baseVertices.Add(new Vertex(new float[] { x, y, z }));
            }

            // Crear los vértices del tope utilizando un círculo
            var topCenter = new Vertex(new float[] { baseCenter.x, baseCenter.y, baseCenter.z + height });
            var topVertices = new List<Vertex>();
            for (int i = 0; i < 360; i += 10)
            {
                float x = topCenter.x + (float)(radius * Math.Cos(i * Math.PI / 180));
                float y = topCenter.y + (float)(radius * Math.Sin(i * Math.PI / 180));
                float z = topCenter.z;
                topVertices.Add(new Vertex(new float[] { x, y, z }));
            }

            // Crear las caras triangulares de la base
            var baseFaces = new List<Face>();
            for (int i = 0; i < baseVertices.Count - 2; i++)
            {
                var faceColor = Color.FromArgb(155, 155, 155); // Aquí puedes elegir el color que quieras
                var face = new Face(new List<Vertex> { baseVertices[i], baseVertices[i + 1], baseCenter }, faceColor);
                baseFaces.Add(face);
            }
            var lastBaseFace = new Face(new List<Vertex> { baseVertices[baseVertices.Count - 1], baseVertices[0], baseCenter }, Color.FromArgb(155, 155, 155));
            baseFaces.Add(lastBaseFace);

            // Crear las caras triangulares del tope
            var topFaces = new List<Face>();
            for (int i = 0; i < topVertices.Count - 2; i++)
            {
                var faceColor = Color.FromArgb(155, 155, 155); // Aquí puedes elegir el color que quieras
                var face = new Face(new List<Vertex> { topCenter, topVertices[i + 1], topVertices[i] }, faceColor);
                topFaces.Add(face);
            }
            var lastTopFace = new Face(new List<Vertex> { topCenter, topVertices[0], topVertices[topVertices.Count - 1] }, Color.FromArgb(155, 155, 155));
            topFaces.Add(lastTopFace);

            // Agregar las caras triangulares que conectan la base y el tope
            var connectingFaces = new List<Face>();
            for (int i = 0; i < baseVertices.Count; i++)
            {
                int j = (i + 1) % baseVertices.Count; // El índice del siguiente vértice de la base
                var faceColor = Color.FromArgb(155, 155, 155); // Aquí puedes elegir el color que quieras
                var face = new Face(new List<Vertex> { baseVertices[i], topVertices[i], topVertices[j] }, faceColor);
                connectingFaces.Add(face);
                var face2 = new Face(new List<Vertex> { baseVertices[i], topVertices[j], baseVertices[j] }, faceColor);
                connectingFaces.Add(face2);
            }

            // Agregar todas las caras a la lista de caras del cilindro
            Faces.AddRange(baseFaces);
            Faces.AddRange(topFaces);
            Faces.AddRange(connectingFaces);
        }
    }
}
