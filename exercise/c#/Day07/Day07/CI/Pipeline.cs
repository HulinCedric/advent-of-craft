using Day07.CI.Dependencies;

namespace Day07.CI;

public class Pipeline(IConfig config, IEmailer emailer, ILogger log)
{
    public void Run(Project project)
    {
        var testsPassed = RunTests(project);

        var deploySuccessful = RunDeployment(project, testsPassed);

        RunSendEmailSummary(testsPassed, deploySuccessful);
    }

    private bool RunTests(Project project)
    {
        if (!project.HasTests())
        {
            return StepPassed("No tests");
        }

        return project.RunTests() == "success"
                   ? StepPassed("Tests passed")
                   : StepFailed("Tests failed");
    }

    private bool RunDeployment(Project project, bool testsPassed)
    {
        if (!testsPassed)
        {
            return StepFailed();
        }

        return project.Deploy() == "success"
                   ? StepPassed("Deployment successful")
                   : StepFailed("Deployment failed");
    }

    private void RunSendEmailSummary(bool testsPassed, bool deploySuccessful)
    {
        if (config.SendEmailSummary())
        {
            log.Info("Sending email");
            if (testsPassed)
            {
                if (deploySuccessful)
                {
                    emailer.Send("Deployment completed successfully");
                }
                else
                {
                    emailer.Send("Deployment failed");
                }
            }
            else
            {
                emailer.Send("Tests failed");
            }
        }
        else
        {
            log.Info("Email disabled");
        }
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