using Day07.CI.Dependencies;

namespace Day07.CI;

public class Pipeline(IConfig config, IEmailer emailer, ILogger log)
{
    public void Run(Project project)
    {
        if (!project.RunTestsPassed(log))
        {
            SendEmail("Tests failed");
            return;
        }

        if (!project.RunDeploymentPassed(log))
        {
            SendEmail("Deployment failed");
            return;
        }

        SendEmail("Deployment completed successfully");
    }


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
}