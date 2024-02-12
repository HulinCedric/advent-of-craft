using Day07.CI.Dependencies;

namespace Day07.CI;

public static class ProjectSteps
{
    private const string Success = "success";

    public static bool RunTestsPassed(this Project project, ILogger logger)
    {
        if (!project.HasTests())
        {
            return logger.StepPassed("No tests");
        }

        return project.RunTests() == Success
                   ? logger.StepPassed("Tests passed")
                   : logger.StepFailed("Tests failed");
    }

    public static bool RunDeploymentPassed(this Project project, ILogger logger)
        => project.Deploy() == Success
               ? logger.StepPassed("Deployment successful")
               : logger.StepFailed("Deployment failed");
}