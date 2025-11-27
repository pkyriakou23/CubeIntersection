using CubeIntersection.Core.IO;
using CubeIntersection.Core.Logger;
using CubeIntersection.Services;

namespace CubeIntersection.Application
{
    public class Application
    {
        private readonly ILogger _logger;
        private readonly ConsoleErrorHandler _errorHandler;
        private readonly ConsoleHandler _consoleHandler;
        private readonly IIntersectionService _collisionService;

        public Application(
            ILogger logger,
            ConsoleErrorHandler errorHandler,
            ConsoleHandler consoleHandler,
            IIntersectionService collisionService)
        {
            _logger = logger;
            _errorHandler = errorHandler;
            _consoleHandler = consoleHandler;
            _collisionService = collisionService;
        }

        public void Run()
        {
            try
            {
                _consoleHandler.DisplayWelcome();

                var cube1 = _consoleHandler.GetCubeFromUser(Constants.Constants.Cube1);
                var cube2 = _consoleHandler.GetCubeFromUser(Constants.Constants.Cube2);

                var areColliding = _collisionService.AreColliding(cube1, cube2);
                var volume = _collisionService.CalculateIntersectionVolume(cube1, cube2);

                _consoleHandler.DisplayResult(areColliding, volume);
            }
            catch (Exception ex)
            {
                _errorHandler.HandleApplicationError(ex);
            }
        }
    }
}
