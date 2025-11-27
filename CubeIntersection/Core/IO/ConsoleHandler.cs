using CubeIntersection.Constants;
using CubeIntersection.Models;

namespace CubeIntersection.Core.IO
{
    public class ConsoleHandler
    {
        private readonly ConsoleErrorHandler _errorHandler;

        public ConsoleHandler(ConsoleErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }
        public void DisplayWelcome()
        {
            Console.WriteLine("=== CUBE INTERSECTION ===");
            Console.WriteLine("Enter the coordinates and size for two cubes");
            Console.WriteLine();
        }

        public void DisplayResult(bool areColliding, double volume)
        {
            Console.WriteLine("\n=== INTERSECTION RESULT ===");
            Console.WriteLine($"Cubes are colliding: {areColliding}");
            Console.WriteLine($"Intersection volume: {volume}");
            Console.WriteLine("========================");
        }

        public Cube GetCubeFromUser(string cubeName)
        {
            Console.WriteLine($"\n=== {cubeName} ===");

            var x = GetIntegerInput("Center X");
            var y = GetIntegerInput("Center Y");
            var z = GetIntegerInput("Center Z");
            var size = GetPositiveIntegerInput("Size");

            return new Cube(new Point(x, y, z), size);
        }

        private int GetIntegerInput(string fieldName)
        {
            while (true)
            {
                Console.Write($"{fieldName}: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out var result))
                    return result;

                _errorHandler.ShowErrorWithField(fieldName, ErrorMessages.InvalidInput);
            }
        }

        private int GetPositiveIntegerInput(string fieldName)
        {
            while (true)
            {
                var result = GetIntegerInput(fieldName);

                if (result > 0)
                    return result;

                _errorHandler.ShowErrorWithField(fieldName, ErrorMessages.MustBePositive);
            }
        }
    }
}