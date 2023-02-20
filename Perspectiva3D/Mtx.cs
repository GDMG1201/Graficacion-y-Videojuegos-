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

            x = (mat[0, 0] * vector[0]) + (mat[1, 0] * vector[1]) + (mat[2,0] * vector[2]);
            y = (mat[0, 1] * vector[0]) + (mat[1, 1] * vector[1]) + (mat[2, 1] * vector[2]);
            z = (mat[0, 2] * vector[0]) + (mat[1, 2] * vector[1]) + (mat[2, 2] * vector[2]);


            return new Vertex(new float[]
            {
                x, y, z
            });

        }
    }
}
