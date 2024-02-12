using Day07.CI.Dependencies;

namespace Day07.CI;

public class Pipeline(IConfig config, IEmailer emailer, ILogger log)
{
    private const string Success = "success";

    public void Run(Project project)
    {
        if (!RunTests(project))
        {
            SendEmail("Tests failed");
            return;
        }

        if (!RunDeployment(project))
        {
            SendEmail("Deployment failed");
            return;
        }

        SendEmail("Deployment completed successfully");
    }

    private bool RunTests(Project project)
    {
        if (!project.HasTests())
        {
            return StepPassed("No tests");
        }

        return project.RunTests() == Success
                   ? StepPassed("Tests passed")
                   : StepFailed("Tests failed");
    }

    private bool RunDeployment(Project project)
        => project.Deploy() == Success
               ? StepPassed("Deployment successful")
               : StepFailed("Deployment failed");

    private void SendEmail(string message)
    {
        if (!config.SendEmailSummary())
        {
            log.Info("Email disabled");
            return;
        }

        log.Info("Sending email");

        emailer.Send(message);
    }

    private bool StepPassed(string message)
    {
        log.Info(message);
        return true;
    }

    private bool StepFailed(string message = "")
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            log.Error(message);
        }

        return false;
    }
}