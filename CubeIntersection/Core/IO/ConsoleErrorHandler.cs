using CubeIntersection.Constants;
using CubeIntersection.Core.Logger;

namespace CubeIntersection.Core.IO
{
    public class ConsoleErrorHandler
    {
        private readonly ILogger _logger;
        public ConsoleErrorHandler(ILogger logger)
        {
            _logger = logger;
        }
        public void ShowErrorWithField(string fieldName, string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error in {fieldName}: {errorMessage}");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void ShowError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {errorMessage}");
            Console.ResetColor();
            Console.WriteLine();
        }
        public void HandleApplicationError(Exception ex, string context = "")
        {
            _logger.LogError($"Application error in {context}: {ex.Message}");
            Console.WriteLine(ErrorMessages.ApplicationError);
        }
    }
}
