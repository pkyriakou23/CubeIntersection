using CubeIntersection.Models;

namespace CubeIntersection.Services
{
    public interface IIntersectionService
    {
        bool AreColliding(Cube cube1, Cube cube2);
        double CalculateIntersectionVolume(Cube cube1, Cube cube2);
    }
}
