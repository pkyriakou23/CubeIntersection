using CubeIntersection.Application;
using CubeIntersection.Core.IO;
using CubeIntersection.Core.Logger;
using CubeIntersection.Services.Implementations;

class Program
{
    static void Main()
    {
        var logger = new LoggerErrorImpl();
        var errorHandler = new ConsoleErrorHandler(logger);
        var consoleHandler = new ConsoleHandler(errorHandler);
        var collisionService = new CubeIntersectionServiceImpl();

        var app = new Application(logger, errorHandler, consoleHandler, collisionService);
        app.Run();
    }
}