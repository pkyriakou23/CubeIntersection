using CubeIntersection.Models;

namespace CubeIntersection.Services.Implementations
{
    public class CubeIntersectionServiceImpl : IIntersectionService
    {
        public bool AreColliding(Cube cube1, Cube cube2)
        {
            var overlapX = CalculateOverlap(cube1.Center.X, cube1.Size, cube2.Center.X, cube2.Size);
            var overlapY = CalculateOverlap(cube1.Center.Y, cube1.Size, cube2.Center.Y, cube2.Size);
            var overlapZ = CalculateOverlap(cube1.Center.Z, cube1.Size, cube2.Center.Z, cube2.Size);

            return overlapX > 0 && overlapY > 0 && overlapZ > 0;
        }

        public double CalculateIntersectionVolume(Cube cube1, Cube cube2)
        {
            var overlapX = CalculateOverlap(cube1.Center.X, cube1.Size, cube2.Center.X, cube2.Size);
            var overlapY = CalculateOverlap(cube1.Center.Y, cube1.Size, cube2.Center.Y, cube2.Size);
            var overlapZ = CalculateOverlap(cube1.Center.Z, cube1.Size, cube2.Center.Z, cube2.Size);

            return overlapX * overlapY * overlapZ;
        }

        private int CalculateOverlap(int center1, int size1, int center2, int size2)
        {
            var half1 = size1 / 2;
            var half2 = size2 / 2;

            var min1 = center1 - half1;
            var max1 = center1 + half1;
            var min2 = center2 - half2;
            var max2 = center2 + half2;

            var overlap = Math.Min(max1, max2) - Math.Max(min1, min2);
            return Math.Max(0, overlap);
        }
    }
}
