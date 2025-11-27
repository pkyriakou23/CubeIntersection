namespace CubeIntersection.Models
{
    public class Cube
    {
        public Point Center { get; }
        public int Size { get; }

        public Cube(Point center, int size)
        {
            Center = center;
            Size = size;
        }
    }
}
