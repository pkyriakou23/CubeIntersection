using CubeIntersection.Models;
using CubeIntersection.Services.Implementations;

namespace CubeIntersection.Tests.Tests.UnitTests;

public class CubeUnitTests
{
    [Fact]
    public void Cube_Constructor_Success()
    {
        var center = new Point(1, 2, 3);
        var cube = new Cube(center, 4);

        Assert.Equal(center, cube.Center);
        Assert.Equal(4, cube.Size);
    }

    [Theory]
    [InlineData(1, 2, 3, 1, 2, 3, true)]
    [InlineData(1, 2, 3, 4, 5, 6, false)]
    public void Point_Equality_Success(int x1, int y1, int z1, int x2, int y2, int z2, bool expectedEqual)
    {
        var point1 = new Point(x1, y1, z1);
        var point2 = new Point(x2, y2, z2);

        if (expectedEqual)
        {
            Assert.Equal(point1, point2);
        }
        else
        {
            Assert.NotEqual(point1, point2);
        }
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, -2, -3)]
    public void Point_Deconstruction_Success(int x, int y, int z)
    {
        var point = new Point(x, y, z);

        var (resultX, resultY, resultZ) = point;

        Assert.Equal(x, resultX);
        Assert.Equal(y, resultY);
        Assert.Equal(z, resultZ);
    }
}