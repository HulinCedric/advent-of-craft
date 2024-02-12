using Day07.CI.Dependencies;

namespace Day07.CI;

public static class LoggerExtensions
{
    public static bool StepPassed(this ILogger logger, string message)
    {
        logger.Info(message);
        return true;
    }

    public static bool StepFailed(this ILogger logger, string message = "")
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            logger.Error(message);
        }

        return false;
    }
}