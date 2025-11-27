// In real application, this would include:
// - Timestamps
// - Log levels (Debug, Info, Warning, Error)
// - Different outputs (File, Database, Cloud)
// - Structured logging
// - Configuration for log levels
namespace CubeIntersection.Core.Logger
{
    
    public interface ILogger
    {
        void LogError(string message);
    }
}


