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

        if (project.RunTests() == "success")
        {
            return StepPassed("Tests passed");
        }

        return StepFailed("Tests failed");

    }

    private bool RunDeployment(Project project, bool testsPassed)
    {
        if (testsPassed)
        {
            if (project.Deploy() == "success")
            {
                return StepPassed("Deployment successful");
            }
            else
            {
                return StepFailed("Deployment failed");
            }
        }
        else
        {
            return StepFailed();
        }
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