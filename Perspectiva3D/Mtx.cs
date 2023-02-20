namespace Demo3D
{
    public class Mtx
    {
        private float[,] mat;

        public Mtx(float[,] mat)
        {
            this.mat = mat;
        }

        public Vertex Mul(Vertex vector)
        {
            float x = vector.x;
            float y = vector.y;
            float z = vector.z;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                x += mat[i, 0] * vector[0];
                y += mat[i, 1] * vector[1];
                z += mat[i, 2] * vector[2];
            }

            return new Vertex(new float[]
            {
                x, y, z
            });

        }
    }
}