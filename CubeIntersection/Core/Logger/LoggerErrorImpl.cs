namespace CubeIntersection.Core.Logger
{
    public class LoggerErrorImpl : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine($"[ERROR] {message}");
        }
    }
}
