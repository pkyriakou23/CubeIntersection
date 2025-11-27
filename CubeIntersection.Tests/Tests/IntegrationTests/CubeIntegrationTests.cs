using CubeIntersection.Core.IO;
using CubeIntersection.Core.Logger;
using CubeIntersection.Models;
using CubeIntersection.Services.Implementations;

namespace CubeIntersection.Tests.Tests.IntegrationTests
{
    public class CubeIntegrationTests
    {
        [Fact]
        public void CompleteFlow_WithCollidingCubes_Success()
        {
            var logger = new LoggerErrorImpl();
            var errorHandler = new ConsoleErrorHandler(logger);
            var consoleHandler = new ConsoleHandler(errorHandler);
            var collisionService = new CubeIntersectionServiceImpl();

            var cube1 = new Cube(new Point(0, 0, 0), 4);
            var cube2 = new Cube(new Point(2, 0, 0), 4);

            var areColliding = collisionService.AreColliding(cube1, cube2);
            var volume = collisionService.CalculateIntersectionVolume(cube1, cube2);

            Assert.True(areColliding);
            Assert.Equal(32, volume);
        }

        [Theory]
        [InlineData(0, 0, 0, 4, 0, 0, 0, 2, true, 8)]   // Complete overlap
        [InlineData(0, 0, 0, 2, 5, 5, 5, 2, false, 0)]  // Separated
        [InlineData(0, 0, 0, 4, 3, 3, 3, 4, true, 1)]   // Corner overlap
        public void ServiceAndModels_Integration(
            int x1, int y1, int z1, int size1,
            int x2, int y2, int z2, int size2,
            bool expectedCollision, int expectedVolume)
        {
            var logger = new LoggerErrorImpl();
            var collisionService = new CubeIntersectionServiceImpl();

            var cube1 = new Cube(new Point(x1, y1, z1), size1);
            var cube2 = new Cube(new Point(x2, y2, z2), size2);

            var areColliding = collisionService.AreColliding(cube1, cube2);
            var volume = collisionService.CalculateIntersectionVolume(cube1, cube2);

            Assert.Equal(expectedCollision, areColliding);
            Assert.Equal(expectedVolume, volume);
        }

        [Fact]
        public void ConsoleHandler_WithErrorHandler_Integration()
        {
            var logger = new LoggerErrorImpl();
            var errorHandler = new ConsoleErrorHandler(logger);
            var consoleHandler = new ConsoleHandler(errorHandler);

            Assert.NotNull(consoleHandler);
            Assert.NotNull(errorHandler);
            Assert.NotNull(logger);
        }

        [Fact]
        public void RealWorldScenario_WarehouseBoxes_Integration()
        {
            var logger = new LoggerErrorImpl();
            var collisionService = new CubeIntersectionServiceImpl();

            var container = new Cube(new Point(0, 0, 0), 10);
            var item = new Cube(new Point(2, 2, 2), 2);

            var isInside = collisionService.AreColliding(container, item);
            var overlapVolume = collisionService.CalculateIntersectionVolume(container, item);

            Assert.True(isInside);
            Assert.Equal(8, overlapVolume);
        }
    }
}
