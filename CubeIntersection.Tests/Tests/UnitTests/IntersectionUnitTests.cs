using CubeIntersection.Core.Logger;
using CubeIntersection.Models;
using CubeIntersection.Services.Implementations;

namespace CubeIntersection.Tests.Tests.UnitTests
{
    public class IntersectionUnitTests
    {
        private readonly CubeIntersectionServiceImpl _service;

        public IntersectionUnitTests()
        {
            var logger = new LoggerErrorImpl();
            _service = new CubeIntersectionServiceImpl();
        }

        [Theory]
        [InlineData(2, 10, 10, 2, 0, 0, 0, 2, false)]  // Separated
        [InlineData(0, 0, 0, 2, 1, 1, 1, 2, true)]   // Overlapping
        [InlineData(0, 0, 0, 4, 0, 0, 0, 2, true)]   // One inside another
        [InlineData(0, 0, 0, 2, 2, 0, 0, 2, false)]  // Touching edges
        public void AreColliding_Tests(
            int x1, int y1, int z1, int size1,
            int x2, int y2, int z2, int size2,
            bool expectedCollision)
        {
            var cube1 = new Cube(new Point(x1, y1, z1), size1);
            var cube2 = new Cube(new Point(x2, y2, z2), size2);

            var result = _service.AreColliding(cube1, cube2);

            Assert.Equal(expectedCollision, result);
        }

        [Theory]
        [InlineData(0, 0, 0, 4, 0, 0, 0, 2, 8)]     // Complete overlap
        [InlineData(0, 0, 0, 4, 2, 0, 0, 4, 32)]    // Partial overlap
        [InlineData(0, 0, 0, 4, 3, 3, 3, 4, 1)]     // Corner overlap
        [InlineData(0, 0, 0, 2, 5, 5, 5, 2, 0)]     // No overlap
        public void CalculateIntersectionVolume_ReturnsCorrectVolume(
            int x1, int y1, int z1, int size1,
            int x2, int y2, int z2, int size2,
            int expectedVolume)
        {
            var cube1 = new Cube(new Point(x1, y1, z1), size1);
            var cube2 = new Cube(new Point(x2, y2, z2), size2);

            var volume = _service.CalculateIntersectionVolume(cube1, cube2);

            Assert.Equal(expectedVolume, volume);
        }

        [Fact]
        public void CalculateIntersectionVolume_WhenNotColliding_ReturnsZero()
        {

            var cube1 = new Cube(new Point(0, 0, 0), 2);
            var cube2 = new Cube(new Point(10, 10, 10), 2);

            var volume = _service.CalculateIntersectionVolume(cube1, cube2);

            Assert.Equal(0, volume);
        }
    }
}
