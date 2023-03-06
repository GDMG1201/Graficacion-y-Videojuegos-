using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figuras3DV2
{
    public class Mesh
    {
        public List<TriangularFace> triangles;
        public Mesh()
        {
            triangles = new List<TriangularFace>();
        }
    }
}
